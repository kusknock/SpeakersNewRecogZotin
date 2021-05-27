using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpeakersNewRecog.Classes
{
    class DiscreteTransform
    {
        double[][] overlap;

        Complex[][] fourier;

        double[][] spectre;

        int frameCount, windowSize, frameSize;

        public Complex[][] Fourier { get { return fourier; } }

        public double[][] Spectre { get { return spectre; } }

        public DiscreteTransform(Overlapping frames)
        {
            overlap = frames.Overlap; // амплитуды с перекрытием
            frameCount = frames.FrameCount; // количество фреймов
            windowSize = frames.WindowSize; // размер окна степень двойки
            frameSize = frames.FrameSize; // размер окна
        }

        public enum TransformType // тип преобразования (прореживание по времени, прореживание по частоте)
        {
            InTime = 1,
            InFrequency = 2
        };

        Complex[] FourierInTime(Complex[] frame, bool direct) // Фурье-преобразование с прореживанием по времени 
        {
            if (frame.Length == 1) return frame;
            var frameHalfSize = frame.Length >> 1; // frame.Length/2
            var frameFullSize = frame.Length;

            var frameOdd = new Complex[frameHalfSize];
            var frameEven = new Complex[frameHalfSize];
            for (var i = 0; i < frameHalfSize; i++)
            {
                var j = i << 1; // i = 2*j;
                frameOdd[i] = frame[j + 1];
                frameEven[i] = frame[j];
            }

            var spectrumOdd = FourierInTime(frameOdd, direct);
            var spectrumEven = FourierInTime(frameEven, direct);

            var arg = direct ? -2 * Math.PI / frameFullSize : 2 * Math.PI / frameFullSize;
            var omegaPowBase = new Complex(Math.Cos(arg), Math.Sin(arg));
            var omega = Complex.One;
            var spectrum = new Complex[frameFullSize];

            for (var j = 0; j < frameHalfSize; j++)
            {
                spectrum[j] = spectrumEven[j] + omega * spectrumOdd[j];
                spectrum[j + frameHalfSize] = spectrumEven[j] - omega * spectrumOdd[j];
                omega *= omegaPowBase;
            }

            return spectrum;
        }

        Complex[] FourierInFrequency(Complex[] frame, bool direct) // Фурье-преобразование с прореживанием по частоте 
        {
            if (frame.Length == 1) return frame;
            var halfSampleSize = frame.Length >> 1; // frame.Length/2
            var fullSampleSize = frame.Length;

            var arg = direct ? -2 * Math.PI / fullSampleSize : 2 * Math.PI / fullSampleSize;
            var omegaPowBase = new Complex(Math.Cos(arg), Math.Sin(arg));
            var omega = Complex.One;
            var spectrum = new Complex[fullSampleSize];

            for (var j = 0; j < halfSampleSize; j++)
            {
                spectrum[j] = frame[j] + frame[j + halfSampleSize];
                spectrum[j + halfSampleSize] = omega * (frame[j] - frame[j + halfSampleSize]);
                omega *= omegaPowBase;
            }

            var yTop = new Complex[halfSampleSize];
            var yBottom = new Complex[halfSampleSize];
            for (var i = 0; i < halfSampleSize; i++)
            {
                yTop[i] = spectrum[i];
                yBottom[i] = spectrum[i + halfSampleSize];
            }

            yTop = FourierInFrequency(yTop, direct);
            yBottom = FourierInFrequency(yBottom, direct);
            for (var i = 0; i < halfSampleSize; i++)
            {
                var j = i << 1; // i = 2*j;
                spectrum[j] = yTop[i];
                spectrum[j + 1] = yBottom[i];
            }

            return spectrum;
        }

        Complex[] ConvertDoubleToComplex(double[] frame, int frameSize) // конвертирование фрейма в комплексную форму 
        {
            Complex[] retComplex = new Complex[frameSize];

            for (int i = 0; i < frameSize; i++)
                retComplex[i] = new Complex(frame[i], 0);

            return retComplex;
        }

        void SpectreCalculation() // функция вычисления спектра 
        {
            spectre = new double[frameCount][];
            for (int index = 0; index < frameCount; index++)
                spectre[index] = new double[windowSize / 2 + 1];

            for (int i = 0; i < frameCount; i++)
                for (int j = 0; j < windowSize / 2 + 1; j++)
                {
                    spectre[i][j] = fourier[i][j].Real * fourier[i][j].Real
                        + fourier[i][j].Imaginary * fourier[i][j].Imaginary;

                    // spectre[i][j] /= windowSize; // - тут правильно

                    // TODO: Периодограммы спектра (нормализация) (спектральная оценка мощности)
                    // Магнитундый спектр

                }
        }

        public void Process(TransformType type) // вычисление Фурье-преобразование 
        {
            fourier = new Complex[frameCount][];
            for (int index = 0; index < frameCount; index++)
                fourier[index] = new Complex[windowSize];

            Complex[] fftWindowComplex = new Complex[windowSize];

            for (int i = 0; i < frameCount; i++)
            {
                fftWindowComplex = ConvertDoubleToComplex(overlap[i], windowSize);

                switch ((int)type)
                {
                    case 1: fftWindowComplex = FourierInTime(fftWindowComplex, true); break;
                    case 2: fftWindowComplex = FourierInFrequency(fftWindowComplex, true); break;
                    default: throw new Exception("invalid type of transform");
                }

                for (int j = 0; j < windowSize; j++)
                    fourier[i][j] = fftWindowComplex[j];
            }

            SpectreCalculation(); // вычисление периодограмм спектра
        }

        /// <summary>
        /// Функция вычисления обратного преобразования Фурье
        /// Варианты использования:
        /// 1. Вместо косинусного преобразования
        /// 2. Для проверки
        /// </summary>
        public double[][] InverseFourierTransform(Complex[][] frames, int type) // обратное преобразование Фурье (для проверки) 
        {
            double[][] result;
            result = new double[frameCount][];
            for (int index = 0; index < frameCount; index++)
                result[index] = new double[windowSize];

            Complex[] fftWindowComplex = new Complex[windowSize];

            for (int i = 0; i < frameCount; i++)
            {
                for (int j = 0; j < windowSize; j++)
                    frames[i][j] *= windowSize;

                switch (type)
                {
                    case 1: fftWindowComplex = FourierInTime(frames[i], false); break;
                    case 2: fftWindowComplex = FourierInFrequency(frames[i], false); break;
                    default: break;
                }

                for (int j = 0; j < frameSize; j++)
                    result[i][j] = fftWindowComplex[j].Real / Window.Hamming(j, windowSize);
            }

            return result;
        }

        /// <summary>
        /// Реализация быстрого преобразования Фурье
        /// Использовал ее для проверки
        /// Для использования внутри функции есть комментарий
        /// </summary>
        private void CalcFFT(double[] re, double[] im, int direction)
        {
            // Для использования реализации преобразования Фурье (CalcFFT)
            //double[] re = new double[windowSize];
            //double[] im = new double[windowSize];
            //CalFFT(re, im, -1);
            //re[j] = Window.Hamming(j, frameSize) * (short)(overlap[i][j] * 32768f);

            int n = re.Length;
            int bits = (int)Math.Round(Math.Log(n) / Math.Log(2), 0);

            if (n != (1 << bits))
                throw new Exception("fft data must be power of 2");

            int localN;
            int j = 0;
            for (int i = 0; i < n - 1; i++)
            {
                if (i < j)
                {
                    double temp = re[j];
                    re[j] = re[i];
                    re[i] = temp;
                    temp = im[j];
                    im[j] = im[i];
                    im[i] = temp;
                }

                int k = n / 2;

                while ((k >= 1) && (k - 1 < j))
                {
                    j = j - k;
                    k = k / 2;
                }

                j = j + k;
            }

            for (int m = 1; m <= bits; m++)
            {
                localN = 1 << m;
                double Wjk_r = 1;
                double Wjk_i = 0;
                double theta = (2 * Math.PI) / localN;
                double Wj_r = Math.Cos(theta);
                double Wj_i = direction * Math.Sin(theta);
                int nby2 = localN / 2;
                for (j = 0; j < nby2; j++)
                {
                    for (int k = j; k < n; k += localN)
                    {
                        int id = k + nby2;
                        double tempr = Wjk_r * re[id] - Wjk_i * im[id];
                        double tempi = Wjk_r * im[id] + Wjk_i * re[id];
                        re[id] = re[k] - tempr;
                        im[id] = im[k] - tempi;
                        re[k] += tempr;
                        im[k] += tempi;
                    }
                    double wtemp = Wjk_r;
                    Wjk_r = Wj_r * Wjk_r - Wj_i * Wjk_i;
                    Wjk_i = Wj_r * Wjk_i + Wj_i * wtemp;
                }
            }
        }

    }

    class Wavelets
    {
        public static class Haar
        {
            private const double w0 = 0.5;
            private const double w1 = -0.5;
            private const double s0 = 0.5;
            private const double s1 = 0.5;

            /// <summary>
            ///   Discrete Haar Wavelet Transform
            /// </summary>
            public static void FWT(double[] data)
            {
                double[] temp = new double[data.Length];

                int h = data.Length >> 1;
                for (int i = 0; i < h; i++)
                {
                    int k = (i << 1);
                    temp[i] = data[k] * s0 + data[k + 1] * s1;
                    temp[i + h] = data[k] * w0 + data[k + 1] * w1;
                }

                for (int i = 0; i < data.Length; i++)
                    data[i] = temp[i];
            }

            /// <summary>
            ///   Inverse Haar Wavelet Transform
            /// </summary>
            public static void IWT(double[] data)
            {
                double[] temp = new double[data.Length];

                int h = data.Length >> 1;
                for (int i = 0; i < h; i++)
                {
                    int k = (i << 1);
                    temp[k] = (data[i] * s0 + data[i + h] * w0) / w0;
                    temp[k + 1] = (data[i] * s1 + data[i + h] * w1) / s0;
                }

                for (int i = 0; i < data.Length; i++)
                    data[i] = temp[i];
            }
        }

        public static class CFT97
        {
            // Constants as used by Gregoire P.
            const double alpha = -1.586134342;
            const double beta = -0.05298011854;
            const double gamma = 0.8829110762;
            const double delta = 0.4435068522;
            const double zeta = 1.149604398;

            /// <summary>
            ///   Forward biorthogonal 9/7 wavelet transform
            /// </summary>
            public static void FWT97(double[] x)
            {
                int n = x.Length;

                // Predict 1
                for (int i = 1; i < n - 2; i += 2)
                    x[i] += alpha * (x[i - 1] + x[i + 1]);
                x[n - 1] += 2 * alpha * x[n - 2];

                // Update 1
                for (int i = 2; i < n; i += 2)
                    x[i] += beta * (x[i - 1] + x[i + 1]);
                x[0] += 2 * beta * x[1];

                // Predict 2
                for (int i = 1; i < n - 2; i += 2)
                    x[i] += gamma * (x[i - 1] + x[i + 1]);
                x[n - 1] += 2 * gamma * x[n - 2];

                // Update 2
                for (int i = 2; i < n; i += 2)
                    x[i] += delta * (x[i - 1] + x[i + 1]);
                x[0] += 2.0 * delta * x[1];

                // Scale
                for (int i = 0; i < n; i++)
                {
                    if ((i % 2) != 0)
                        x[i] *= (1 / zeta);
                    else x[i] /= (1 / zeta);
                }

                // Pack
                var tempbank = new double[n];
                for (int i = 0; i < n; i++)
                {
                    if ((i % 2) == 0)
                        tempbank[i / 2] = x[i];
                    else tempbank[n / 2 + i / 2] = x[i];
                }

                for (int i = 0; i < n; i++)
                    x[i] = tempbank[i];
            }

            /// <summary>
            ///   Inverse biorthogonal 9/7 wavelet transform
            /// </summary>
            public static void IWT97(double[] x)
            {
                int n = x.Length;

                // Unpack
                var tempbank = new double[n];
                for (int i = 0; i < n / 2; i++)
                {
                    tempbank[i * 2] = x[i];
                    tempbank[i * 2 + 1] = x[i + n / 2];
                }

                for (int i = 0; i < n; i++)
                    x[i] = tempbank[i];

                // Undo scale
                for (int i = 0; i < n; i++)
                {
                    if ((i % 2) != 0)
                        x[i] *= zeta;
                    else x[i] /= zeta;
                }

                // Undo update 2
                for (int i = 2; i < n; i += 2)
                    x[i] -= delta * (x[i - 1] + x[i + 1]);
                x[0] -= 2.0 * delta * x[1];

                // Undo predict 2
                for (int i = 1; i < n - 2; i += 2)
                    x[i] -= gamma * (x[i - 1] + x[i + 1]);
                x[n - 1] -= 2.0 * gamma * x[n - 2];

                // Undo update 1
                for (int i = 2; i < n; i += 2)
                    x[i] -= beta * (x[i - 1] + x[i + 1]);
                x[0] -= 2.0 * beta * x[1];

                // Undo predict 1
                for (int i = 1; i < n - 2; i += 2)
                    x[i] -= alpha * (x[i - 1] + x[i + 1]);
                x[n - 1] -= 2.0 * alpha * x[n - 2];

            }
        }
    }

    class Overlapping
    {
        double[][] overlap; // результат работы алгоритма

        int sampleRate, freqPerMSec, frameSize,
            frameCount, frameShift, windowSize,
            durability;

        double nPowerTwo;

        public double[][] Overlap { get { return overlap; } }

        public int FrameSize { get { return frameSize; } }

        public int FrameCount { get { return frameCount; } }

        public int WindowSize { get { return windowSize; } }

        public Overlapping(WaveReader wav, int size, int shift, int durability_size = 0)
        {
            sampleRate = wav.Format.SampleRate; // частота дискретизации
            freqPerMSec = sampleRate / 1000; // частота в миллисекунде
            frameShift = shift * freqPerMSec; // размер перекрытия
            frameSize = size * freqPerMSec; // размер окна
            durability = durability_size * sampleRate; // ограничение по длительности обучающего высказывания
            if (durability > wav.Mono.Length || durability_size == 0) durability = wav.Mono.Length; // проверка на выход за пределы файла
            frameCount = (durability - frameSize + frameShift) / frameShift; // количество блоков, которые укладываются за время аудиосигнала
            nPowerTwo = Math.Ceiling(Math.Log(frameSize, 2)); // вычисление степени двойки от размера окна
            windowSize = (int)Math.Pow(2, nPowerTwo); // размер окна итоговый (степень двойки)

            overlap = Process(wav.Mono, frameCount, windowSize, frameSize, frameShift); // вычисление амплитуд с перекрытием
        }

        double[][] Process(double[] amplitudes, int frameCount, int windowSize, int frameSize, int frameShift)
        {
            //инициализация массива амплитуд с перекрытием
            double[][] fOverlap = new double[frameCount][];
            for (int index = 0; index < frameCount; index++)
                fOverlap[index] = new double[windowSize];

            for (int i = 0; i < frameCount; i++) //заполнение результирующего массива с амплитудой и перекрытием
            {
                // TODO: 
                // frameSize = windowSize; // power of 2
                // windowSize = frameSize // !(power of 2)
                for (int j = 0; j < windowSize; j++)
                {
                    if (i * frameShift + j >= amplitudes.Length) break;

                    fOverlap[i][j] = amplitudes[i * frameShift + j] /** 32768f*/ * Window.Hamming(j, windowSize);
                }
            }

            return fOverlap;
        }

        //без окна, без перекрытия, без степени двойки, без приведения к short
        public Overlapping(WaveReader wav, int size, bool powerOfTwo)
        {
            sampleRate = wav.Format.SampleRate; // частота дискретизации
            freqPerMSec = sampleRate / 1000; // частота в миллисекунде
            frameSize = size * freqPerMSec; // размер окна
            durability = wav.Mono.Length;

            nPowerTwo = Math.Ceiling(Math.Log(frameSize, 2)); // вычисление степени двойки от размера окна
            windowSize = (int)Math.Pow(2, nPowerTwo); // размер окна итоговый (степень двойки)

            if (!powerOfTwo) windowSize = frameSize;

            //(целочисленное деление, можно округлять в большую сторону, чтобы учитывать все отсчеты)
            frameCount = durability / windowSize; // количество блоков, которые укладываются за время аудиосигнала
            overlap = ProcessWithoutOverlap(wav.Mono, frameCount, windowSize);
        }

        //без окна, без перекрытия, без степени двойки, без приведения к short
        double[][] ProcessWithoutOverlap(double[] amplitudes, int frameCount, int windowSize)
        {
            double[][] fOverlap = new double[frameCount][];
            for (int index = 0; index < frameCount; index++)
                fOverlap[index] = new double[windowSize];

            for (int i = 0; i < frameCount; i++)
            {
                for (int j = 0; j < windowSize; j++)
                {
                    if (i * windowSize + j >= amplitudes.Length) break;

                    fOverlap[i][j] = amplitudes[i * windowSize + j];
                }
            }

            return fOverlap;
        }

        //без окна, без перекрытия, без степени двойки, без приведения к short, с заполнением нулями в кадре последних отсчетов
        public Overlapping(WaveReader wav, int size)
        {
            sampleRate = wav.Format.SampleRate; // частота дискретизации
            freqPerMSec = sampleRate / 1000; // частота в миллисекунде
            frameSize = size * freqPerMSec; // размер окна
            durability = wav.Mono.Length;

            nPowerTwo = Math.Ceiling(Math.Log(frameSize, 2)); // вычисление степени двойки от размера окна
            windowSize = (int)Math.Pow(2, nPowerTwo); // размер кадра со степенью двойки

            //(целочисленное деление, можно округлять в большую сторону, чтобы учитывать все отсчеты)
            frameCount = durability / frameSize; // количество блоков, которые укладываются за время аудиосигнала
            overlap = ProcessWithoutOverlapFillNull(wav.Mono, frameCount, windowSize, frameSize);
        }

        //без окна, без перекрытия, без степени двойки, без приведения к short, с заполнением нулями в кадре последних отсчетов
        double[][] ProcessWithoutOverlapFillNull(double[] amplitudes, int frameCount, int windowSize, int frameSize)
        {
            double[][] fOverlap = new double[frameCount][];
            for (int index = 0; index < frameCount; index++)
                fOverlap[index] = new double[windowSize];

            for (int i = 0; i < frameCount; i++)
            {
                for (int j = 0; j < frameSize; j++)
                {
                    if (i * frameSize + j >= amplitudes.Length) break;

                    fOverlap[i][j] = amplitudes[i * frameSize + j];
                }
            }

            return fOverlap;
        }
    }

    class Window
    {
        private const double Q = 0.5;

        public static double Rectangle(double n, double frameSize)
        {
            return 1;
        }

        public static double Gauss(double n, double frameSize)
        {
            var a = (frameSize - 1) / 2;
            var t = (n - a) / (Q * a);
            t = t * t;
            return Math.Exp(-t / 2);
        }

        public static double Hamming(double n, double frameSize)
        {
            return 0.54 - 0.46 * Math.Cos((2 * Math.PI * n) / (frameSize - 1));
        }

        public static double Hann(double n, double frameSize)
        {
            return 0.5 * (1 - Math.Cos((2 * Math.PI * n) / (frameSize - 1)));
        }

        public static double BlackmannHarris(double n, double frameSize)
        {
            return 0.35875 - (0.48829 * Math.Cos((2 * Math.PI * n) / (frameSize - 1))) +
                   (0.14128 * Math.Cos((4 * Math.PI * n) / (frameSize - 1))) - (0.01168 * Math.Cos((4 * Math.PI * n) / (frameSize - 1)));
        }
    }

    class Distance
    {
        static public double calcDistance(double[] seq1, int seq1size, double[] seq2, int seq2size)
        {

            // Create diff matrix
            double[,] diffM = new double[seq1size, seq2size];


            for (int i = 0; i < seq1size; i++)
            {
                for (int j = 0; j < seq2size; j++)
                {
                    diffM[i, j] = Math.Abs(seq1[i] - seq2[j]);
                }
            }

            // Compute distance
            double distance = findDistance(seq1size, seq2size, diffM);

            return distance;
        }

        static double calcDistanceVector(double[] seq1, int seq1size,
                double[] seq2, int seq2size, int vectorSize)
        {

            int seq1sizeV = seq1size / vectorSize;
            int seq2sizeV = seq2size / vectorSize;

            // Create diff matrix
            double[,] diffM = new double[seq1sizeV, seq2sizeV];


            for (int i = 0; i < seq1sizeV; i++)
            {
                for (int j = 0; j < seq2sizeV; j++)
                {

                    // Calc distance between vectors
                    double distanceVector = 0f;
                    for (int k = 0; k < vectorSize; k++)
                    {
                        distanceVector += Math.Pow(seq1[i * vectorSize + k] - seq2[j * vectorSize + k], 2);
                    }

                    diffM[i, j] = (float)Math.Sqrt(distanceVector);
                }
            }

            // Compute distance
            double distance = findDistance(seq1sizeV, seq2sizeV, diffM);

            return distance;
        }

        static double findDistance(int seq1size, int seq2size, double[,] diffM)
        {

            // Create distance matrix (forward direction)
            double[,] pathM = new double[seq1size, seq2size];


            pathM[0, 0] = diffM[0, 0];
            for (int i = 1; i < seq1size; i++)
            {
                pathM[i, 0] = diffM[i, 0] + pathM[i - 1, 0];
            }
            for (int j = 1; j < seq2size; j++)
            {
                pathM[0, j] = diffM[0, j] + pathM[0, j - 1];
            }

            for (int i = 1; i < seq1size; i++)
            {
                for (int j = 1; j < seq2size; j++)
                {
                    if (pathM[i - 1, j - 1] < pathM[i - 1, j])
                    {
                        if (pathM[i - 1, j - 1] < pathM[i, j - 1])
                        {
                            pathM[i, j] = diffM[i, j] + pathM[i - 1, j - 1];
                        }
                        else
                        {
                            pathM[i, j] = diffM[i, j] + pathM[i, j - 1];
                        }
                    }
                    else
                    {
                        if (pathM[i - 1, j] < pathM[i, j - 1])
                        {
                            pathM[i, j] = diffM[i, j] + pathM[i - 1, j];
                        }
                        else
                        {
                            pathM[i, j] = diffM[i, j] + pathM[i, j - 1];
                        }
                    }
                }
            }

            // Find the warping path (backward direction)
            int warpSize = seq1size * seq2size;
            double[] warpPath = new double[warpSize];

            int warpPathIndex = 0;
            int iW = seq1size - 1, jW = seq2size - 1;

            warpPath[warpPathIndex] = pathM[iW, jW];

            do
            {
                if (iW > 0 && jW > 0)
                {

                    if (pathM[iW - 1, jW - 1] < pathM[iW - 1, jW])
                    {
                        if (pathM[iW - 1, jW - 1] < pathM[iW, jW - 1])
                        {
                            iW--;
                            jW--;
                        }
                        else
                        {
                            jW--;
                        }

                    }
                    else
                    {
                        if (pathM[iW - 1, jW] < pathM[iW, jW - 1])
                        {
                            iW--;
                        }
                        else
                        {
                            jW--;
                        }
                    }

                }
                else
                {
                    if (0 == iW)
                    {
                        jW--;
                    }
                    else
                    {
                        iW--;
                    }
                }

                warpPath[++warpPathIndex] = pathM[iW, jW];

            } while (iW > 0 || jW > 0);

            // Calculate path measure
            double distance = 0f;
            for (int k = 0; k < warpPathIndex + 1; k++)
            {
                distance += warpPath[k];
            }
            distance = distance / (warpPathIndex + 1);

            return distance;
        }

        static public double GetDistanceChebyshev(double[] features1, double[] features2)
        {
            int width = features1.Length > features2.Length ? features2.Length : features1.Length;

            double distance = 0.0d;

            for (int i = 0; i < width; i++)
            {
                var currentDistance = Math.Abs(features1[i] - features2[i]);

                distance = (currentDistance > distance) ? currentDistance : distance;
            }

            return distance;
        }

        static public double GetDistanceEuqlid(double[] features1, double[] features2)
        {
            int width = features1.Length > features2.Length ? features2.Length : features1.Length;

            double distance = 0.0d;

            for (int i = 0; i < width; i++)
            {
                var diff = features1[i] - features2[i];
                distance += diff * diff;
            }

            return (float)Math.Sqrt(distance);
        }
    }

    public static class Harmonic
    {

        public static void Peaks(double[] spectrum, int[] peaks, double[] peakFrequencies, int samplingRate, double pitch = -1)
        {
            if (pitch < 0)
            {
                pitch = FromSpectralPeaks(spectrum, samplingRate);
            }

            var resolution = (float)samplingRate / (2 * (spectrum.Length - 1));

            var region = (int)(pitch / (2 * resolution));

            peaks[0] = (int)(pitch / resolution);
            peakFrequencies[0] = pitch;

            for (var i = 0; i < peaks.Length; i++)
            {
                var candidate = (i + 1) * peaks[0];

                if (candidate >= spectrum.Length)
                {
                    peaks[i] = spectrum.Length - 1;
                    peakFrequencies[i] = resolution * (spectrum.Length - 1);
                    continue;
                }

                var c = candidate;
                for (var j = -region; j < region; j++)
                {
                    if (c + j - 1 > 0 &&
                        c + j + 1 < spectrum.Length &&
                        spectrum[c + j] > spectrum[c + j - 1] &&
                        spectrum[c + j] > spectrum[c + j + 1] &&
                        spectrum[c + j] > spectrum[candidate])
                    {
                        candidate = c + j;
                    }
                }

                peaks[i] = candidate;
                peakFrequencies[i] = resolution * candidate;
            }
        }

        public static double FromSpectralPeaks(double[] spectrum,
                                             int samplingRate,
                                             double low = 80,
                                             double high = 400)
        {
            var fftSize = (spectrum.Length - 1) * 2;

            var startIdx = (int)(low * fftSize / samplingRate) + 1;
            var endIdx = (int)(high * fftSize / samplingRate) + 1;

            for (var k = startIdx + 1; k < endIdx; k++)
            {
                if (spectrum[k] > spectrum[k - 1] && spectrum[k] > spectrum[k - 2] &&
                    spectrum[k] > spectrum[k + 1] && spectrum[k] > spectrum[k + 2])
                {
                    return (float)k * samplingRate / fftSize;
                }
            }

            return (float)startIdx * samplingRate / fftSize;
        }

        public static double Centroid(double[] spectrum, int[] peaks, double[] peakFrequencies)
        {
            if (peaks[0] == 0)
            {
                return 0;
            }

            var sum = 1e-10d;
            var weightedSum = 0.0d;

            for (var i = 0; i < peaks.Length; i++)
            {
                var p = peaks[i];
                sum += spectrum[p];
                weightedSum += peakFrequencies[i] * spectrum[p];
            }

            return weightedSum / sum;
        }

        public static double Spread(double[] spectrum, int[] peaks, double[] peakFrequencies)
        {
            if (peaks[0] == 0)
            {
                return 0;
            }

            var centroid = Centroid(spectrum, peaks, peakFrequencies);

            var sum = 1e-10d;
            var weightedSum = 0.0d;

            for (var i = 0; i < peaks.Length; i++)
            {
                var p = peaks[i];
                sum += spectrum[p];
                weightedSum += spectrum[p] * (peakFrequencies[i] - centroid) * (peakFrequencies[i] - centroid);
            }

            return Math.Sqrt(weightedSum / sum);
        }

        public static double Inharmonicity(double[] spectrum, int[] peaks, double[] peakFrequencies)
        {
            if (peaks[0] == 0)
            {
                return 0;
            }

            var f0 = peakFrequencies[0];

            var squaredSum = 1e-10d;
            var sum = 0.0d;

            for (var i = 0; i < peaks.Length; i++)
            {
                var p = peaks[i];
                var sqr = spectrum[p] * spectrum[p];

                sum += (peakFrequencies[i] - (i + 1) * f0) * sqr;
                squaredSum += sqr;
            }

            return 2 * sum / (f0 * squaredSum);
        }

        public static double OddToEvenRatio(double[] spectrum, int[] peaks)
        {
            if (peaks[0] == 0)
            {
                return 0;
            }

            var oddSum = 1e-10d;
            var evenSum = 1e-10d;

            for (var i = 0; i < peaks.Length; i += 2)
            {
                evenSum += spectrum[peaks[i]];
            }

            for (var i = 1; i < peaks.Length; i += 2)
            {
                oddSum += spectrum[peaks[i]];
            }

            return oddSum / evenSum;
        }

        public static double Tristimulus(double[] spectrum, int[] peaks, int n)
        {
            if (peaks[0] == 0)
            {
                return 0;
            }

            var sum = 1e-10d;

            for (var i = 0; i < peaks.Length; i++)
            {
                sum += spectrum[peaks[i]];
            }

            if (n == 1)
            {
                return spectrum[peaks[0]] / sum;
            }
            else if (n == 2)
            {
                return (spectrum[peaks[1]] + spectrum[peaks[2]] + spectrum[peaks[3]]) / sum;
            }
            else
            {
                return (sum - spectrum[peaks[0]] - spectrum[peaks[1]] - spectrum[peaks[2]] - spectrum[peaks[3]]) / sum;
            }
        }
    }
}
