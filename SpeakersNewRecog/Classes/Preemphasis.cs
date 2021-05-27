using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Filtering;

namespace SpeakersNewRecog.Classes
{
    public class Preemphasis
    {
        WaveReader wav; // данные wav

        double sampleRate;

        public enum TypeFilter // типы фильтров (низкочастотный, высокочастотный, полосовой, полосовой-заграждающий, шумодав)
        {
            Bandpass = 1,
            Bandstop = 2,
            Highpass = 3,
            Lowpass = 4
        };

        public WaveReader Wav
        {
            get { return wav; }
            set { wav = value; }
        }

        public Preemphasis(string w_reader)
        {
            wav = new WaveReader(w_reader);

            sampleRate = wav.Format.SampleRate;
        }

        private void Normalize() // функция нормализация сигнала 
        {
            double[] data = (double[])wav.Amplitudes.Clone(); // копия массива амплитуд

            double[] abswav = new double[data.Length];

            for (int i = 0; i < data.Length; i++)
                abswav[i] = Math.Abs(data[i]);

            double max = abswav.Max();
            double k = 1f / max;

            for (int i = 0; i < data.Length; i++)
                data[i] *= k;

            List<double> wavResize = new List<double>();

            for (int i = 0; i < data.Length; i++)
                if (data[i] != 0)
                    wavResize.Add(data[i]);

            Array.Resize(ref data, wavResize.Count);

            for (int i = 0; i < data.Length; i++)
                data[i] = wavResize[i];

            wav.Amplitudes = data; // сохранение изменений в wav-файл
        }

        private void RootMeanSquare() // функция для подавления шума по среднекравратичному уровню 
        {
            double[] data = (double[])wav.Amplitudes.Clone(); // копия массива амплитуд

            int k = 0, rate = 100; // индекс и порог индекса

            double rms = 0, threshold = 0.005; // среднеквадратичная ошибка, порог ошибки

            for (int j = 0; j < data.Length; j++)
            {
                if (k < rate)
                {
                    rms += Math.Pow(data[j], 2);
                    k++;
                }
                else
                {
                    if (Math.Sqrt(rms / rate) < threshold)
                        for (int i = j - rate; i <= j; i++)
                            data[i] = 0;
                    k = 0; rms = 0;
                }
            }

            wav.Amplitudes = data; // сохранение изменений в wav-файл
        }

        private void FirFilter(TypeFilter type, params double[] freq) // КИХ - фильтр 
        {
            OnlineFilter filter = null;

            switch ((int)type)
            {
                case 1:
                    filter = OnlineFilter.CreateBandpass(ImpulseResponse.Finite, 
                        sampleRate, freq[0], freq[1]); break;
                case 2:
                    filter = OnlineFilter.CreateBandstop(ImpulseResponse.Finite, 
                        sampleRate, freq[0], freq[1]); break;
                case 3:
                    filter = OnlineFilter.CreateHighpass(ImpulseResponse.Finite, 
                        sampleRate, freq[0]); break;
                case 4:
                    filter = OnlineFilter.CreateLowpass(ImpulseResponse.Finite, 
                        sampleRate, freq[0]); break;
                default:break;

            }

            wav.Amplitudes = filter.ProcessSamples(wav.Amplitudes);
        }

        private void IirFilter(TypeFilter type, params double[] freq) // БИХ - фильтр 
        {
            OnlineFilter filter = null;

            switch ((int)type)
            {
                case 1:
                    filter = OnlineFilter.CreateBandpass(ImpulseResponse.Infinite,
                        sampleRate, freq[0], freq[1]); break;
                case 2:
                    filter = OnlineFilter.CreateBandstop(ImpulseResponse.Infinite,
                        sampleRate, freq[0], freq[1]); break;
                case 3:
                    filter = OnlineFilter.CreateHighpass(ImpulseResponse.Infinite,
                        sampleRate, freq[0]); break;
                case 4:
                    filter = OnlineFilter.CreateLowpass(ImpulseResponse.Infinite,
                        sampleRate, freq[0]); break;
                default: break;

            }

            wav.Amplitudes = filter.ProcessSamples(wav.Amplitudes);
        }

        private void MedianFilter(int freq) // Медианный фильтр 
        {
            OnlineFilter filter = null;

            filter = OnlineFilter.CreateDenoise(Math.Abs(freq));

            wav.Amplitudes = filter.ProcessSamples(wav.Amplitudes);
        }

        private void WaveletsDenoise(int typeTransform, double threshold)
        {
            double[] waveletsCoefficients = (double[])wav.Amplitudes.Clone();

            switch (typeTransform)
            {
                case 0:
                    Wavelets.Haar.FWT(waveletsCoefficients);
                    break;
                case 1:
                    Wavelets.CFT97.FWT97(waveletsCoefficients);
                    break;
                default: throw new Exception("invalid type transform");
            }

            for (int i = 0; i < waveletsCoefficients.Length; i++)
            {
                if (Math.Abs(waveletsCoefficients[i]) <= threshold)
                    waveletsCoefficients[i] = 0;
                else if (waveletsCoefficients[i] > threshold)
                    waveletsCoefficients[i] -= threshold;
                else if (waveletsCoefficients[i] < -threshold)
                    waveletsCoefficients[i] += threshold;
            }

            switch (typeTransform)
            {
                case 0:
                    Wavelets.Haar.IWT(waveletsCoefficients);
                    break;
                case 1:
                    Wavelets.CFT97.IWT97(waveletsCoefficients);
                    break;
                default: throw new Exception("invalid type transform");
            }

            wav.Amplitudes = (double[])waveletsCoefficients.Clone();
        }

        /// <summary>
        /// КИХ (низкочастотный)
        /// КИХ (высокочастотный)
        /// КИХ (полосовой)
        /// КИХ (полоcно-заграждающий)
        /// БИХ (низкочастотный)
        /// БИХ (высокочастотный)
        /// БИХ (полосовой)
        /// БИХ (полоcно-заграждающий)
        /// Медианный
        /// Среднеквадратичный (+нормализация)
        /// Шумоподавление (DWT)
        /// </summary>
        /// <param name="processType">Тип фильтра.</param>
        /// <param name="processParam1">Параметр 1.</param>
        /// <param name="processParam2">Параметр 2.</param>
        public void Process(string processType, double processParam1, double processParam2)
        {
            switch (processType)
            {
                case "КИХ (полосовой)":
                    FirFilter(TypeFilter.Bandpass, processParam1, processParam2);
                    break;
                case "КИХ (полоcно-заграждающий)":
                    FirFilter(TypeFilter.Bandstop, processParam1, processParam2);
                    break;
                case "БИХ (полосовой)":
                    IirFilter(TypeFilter.Bandpass, processParam1, processParam2);
                    break;
                case "БИХ (полоcно-заграждающий)":
                    IirFilter(TypeFilter.Bandstop, processParam1, processParam2);
                    break;
                case "КИХ (низкочастотный)":
                    FirFilter(TypeFilter.Lowpass, processParam1);
                    break;
                case "КИХ (высокочастотный)":
                    FirFilter(TypeFilter.Highpass, processParam1);
                    break;
                case "БИХ (низкочастотный)":
                    IirFilter(TypeFilter.Lowpass, processParam1);
                    break;
                case "БИХ (высокочастотный)":
                    IirFilter(TypeFilter.Highpass, processParam1);
                    break;
                case "Медианный":
                    MedianFilter((int)processParam1);
                    break;
                case "Среднеквадратичный (+нормализация)":
                    RootMeanSquare();
                    Normalize();
                    break;
                case "Шумоподавление (DWT)":
                    WaveletsDenoise((int)processParam1, processParam2);
                    break;
                default: throw new Exception("invalid filter type");
            }
        }
    }
}
