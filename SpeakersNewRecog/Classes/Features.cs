using Accord.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeakersNewRecog.Classes
{
    class Mfcc
    {
        /// <summary>
        /// TODO: 
        /// Функция сохранения признаков в файл
        /// Liftering 
        /// </summary>

        double[][] features; // матрица признаков mfcc

        double[][] featuresWithoutEnergy; // признаки без энергии

        double[][] deltaFeatures; // дельта признаки

        double[][] delta2Features; // двойные дельта признаки

        int numberCoefficients, numberFilters, sampleRate,
            windowSize, frameCount, minFreq, maxFreq;

        bool cvmn = false, energy = false,
            delta = false, delta2 = false;

        public double[][] Delta2Features { get { return delta2Features; } }

        public double[][] DeltaFeatures { get { return deltaFeatures; } }

        public double[][] WithoutEnergyFeatures { get { return featuresWithoutEnergy; } }

        public double[][] Features { get { return features; } }

        /// <summary>
        /// Вычисление признаков MFCC. Реализация через функции в классе. 
        /// После выполнения доступны свойства класса (различные вариации признаков).
        /// </summary>
        /// <param name="spectre">Спектр сигнала.</param>
        /// <param name="n_coeff">Кол-во коэффициентов MFCC.</param>
        /// <param name="n_filter">Кол-во гребенок фильтров.</param>
        /// <param name="s_rate">Частота дискретизации.</param>
        /// <param name="min_freq">Минимальная частота мел-шкалы.</param>
        /// <param name="max_freq">Максимальная частота мел-шкалы.</param>
        /// <param name="cepstr_mean">Использовать нормализацию.</param>
        /// <param name="energy_coeff">Использовать первый энергетический коэффциент в признаках.</param>
        /// <param name="d_features">Вычисление дельта-значений первого порядка.</param>
        /// <param name="dd_features">Вычисление дельта-значений второго порядка.</param>
        public Mfcc(double[][] spectre, int n_coeff, int n_filter, int s_rate, int min_freq, int max_freq,
            bool cepstr_mean, bool energy_coeff, bool d_features, bool dd_features)
        {
            if (n_coeff > 24 || n_filter > 40 || n_coeff < 12 || n_filter < 24 || n_coeff > n_filter)
                throw new Exception("invalid value number filters or number coefficients");

            numberCoefficients = n_coeff + 1; // длина вектора-признака
            numberFilters = n_filter; // количество фильтров 
            sampleRate = s_rate; // частота дискретизации
            frameCount = spectre.Length; // количество фреймов
            windowSize = spectre[0].Length; // длина фрейма (windowSize / 2 + 1)

            minFreq = min_freq; // минимальная частота
            maxFreq = max_freq; // максимальная частота

            cvmn = cepstr_mean; // нормализация коэффициентов
            energy = energy_coeff; // использовать энергию
            delta = d_features; // дельта коэффициенты
            delta2 = dd_features; // двойные дельта коэффициенты

            features = ProcessFeatures(spectre); // вычисление коэффициентов

            #region Нормализация, дельты, двойные дельты, признаки без энергии (первый коэффициент)

            // если переменная нормализации истинна, то нормируются все матрицы признаков
            // вычисляемых на данном этапе. В заключении нормируется матрица исходных признаков
            // P.S. возможно это небольшой костыль, однако я не знаю как сделать по-другому
            // скорее всего потому, что не хочу, но мне кажется, что можно сделать лучше

            if (cvmn)
            {
                if (energy && delta || energy && delta2)
                {
                    if (delta) deltaFeatures = Normalization(FeaturesDeltaDelta(energy, delta2));
                    if (delta2) delta2Features = Normalization(FeaturesDeltaDelta(energy, delta2));
                }
                else
                {
                    if (!energy) featuresWithoutEnergy = Normalization(FeaturesWithoutEnergy());
                    if (delta) deltaFeatures = Normalization(FeaturesDeltaDelta(energy, delta2));
                    if (delta2) delta2Features = Normalization(FeaturesDeltaDelta(energy, delta2));
                }

                features = Normalization(features);
            }
            else
            {
                // условия совместной работы переменных энергий и значений дельт
                // если энергия истина и какая-то из переменных дельт истинна
                // то вычисляется дельты от признаков с энергиями
                // иначе по каждому условию вычисляются отдельные признаки
                if (energy && delta || energy && delta2)
                {
                    if (delta) deltaFeatures = FeaturesDeltaDelta(energy, delta2);
                    if (delta2) delta2Features = FeaturesDeltaDelta(energy, delta2);
                }
                else
                {
                    if (!energy) featuresWithoutEnergy = FeaturesWithoutEnergy();
                    if (delta) deltaFeatures = FeaturesDeltaDelta(energy, delta2);
                    if (delta2) delta2Features = FeaturesDeltaDelta(energy, delta2);
                }
            }

            #endregion

            // TODO: Energy feature, добавить энергетический признак сигнала - E = Log(f1^2 + f2^2 + ... + fn^2); 
        }

        /// <summary>
        /// Вычисление признаков MFCC. Реализация через библиотеки Accord.NET. 
        /// После выполнения доступны свойства класса (различные вариации признаков).
        /// </summary>
        /// <param name="signal">Отсчеты сигнала. Тип Accord.Audio.Signal.</param>
        /// <param name="n_coeff">Кол-во коэффициентов MFCC.</param>
        /// <param name="n_filter">Кол-во гребенок фильтров.</param>
        /// <param name="s_rate">Частота дискретизации.</param>
        /// <param name="size">Размер окна.</param>
        /// <param name="shift">Размер перекрытия.</param>
        /// <param name="min_freq">Минимальная частота мел-шкалы.</param>
        /// <param name="max_freq">Максимальная частота мел-шкалы.</param>
        /// <param name="cepstr_mean">Использовать нормализацию.</param>
        /// <param name="energy_coeff">Использовать первый энергетический коэффциент в признаках.</param>
        /// <param name="d_features">Вычисление дельта-значений первого порядка.</param>
        /// <param name="dd_features">Вычисление дельта-значений второго порядка.</param>
        /// <param name="durability">Длина сигнала, в пределах которого будут выделяться признаки.</param>
        public Mfcc(Signal signal, int n_coeff, int n_filter, int s_rate, int size, int shift, int min_freq, int max_freq,
            bool cepstr_mean, bool energy_coeff, bool d_features, bool dd_features, int durability = 0)
        {
            if (n_coeff > 24 || n_filter > 40 || n_coeff < 12 || n_filter < 24 || n_coeff > n_filter)
                throw new Exception("invalid value number filters or number coefficients");

            numberCoefficients = n_coeff + 1; // длина вектора-признака
            numberFilters = n_filter; // количество фильтров 
            sampleRate = s_rate; // частота дискретизации
            minFreq = min_freq; // минимальная частота
            maxFreq = max_freq; // максимальная частота

            // вычисление длины окна и перекрытия
            int frameShift = shift * (sampleRate / 1000); // размер перекрытия
            double frameSize = size / 1000f; // размер окна
            double nPowerTwo = Math.Ceiling(Math.Log(frameSize * sampleRate, 2)); // вычисление степени двойки от размера окна
            windowSize = (int)Math.Pow(2, nPowerTwo); // размер окна итоговый (степень двойки) (windowSize / 2 + 1)

            cvmn = cepstr_mean; // нормализация коэффициентов
            energy = energy_coeff; // использовать энергию
            delta = d_features; // дельта коэффициенты
            delta2 = dd_features; // двойные дельта коэффициенты

            #region Изменение сигнала по длине (durability). Инициализация нового (newSignal)

            // получение новой длины сигнала (durability)
            int lengthSignal = durability * signal.SampleRate * signal.Channels;

            // проверка на превышение длины исходного сигнала
            if (lengthSignal > signal.Length || lengthSignal == 0) lengthSignal = signal.Length;

            // инициализация нового сигнала с новой длиной. Параметры совпадают с исходным сигналом
            Signal newSignal = new Signal(signal.Channels, lengthSignal, signal.SampleRate, signal.SampleFormat);

            for (int i = 0; i < newSignal.Length; i++)
            {
                // заполнение нового сигнала по каналам
                for (int channel = 0; channel < newSignal.Channels; channel++)
                    newSignal.SetSample(channel, i, signal.GetSample(channel, i));
            }

            #endregion

            MelFrequencyCepstrumCoefficient mfcc =
               new MelFrequencyCepstrumCoefficient(numberFilters, numberCoefficients, minFreq, maxFreq,
               0.97, sampleRate, frameShift, frameSize, windowSize);

            features = mfcc.Transform(newSignal).Select(x => x.Descriptor).ToArray();

            frameCount = features.Length; // количество фреймов

            #region Нормализация, дельты, двойные дельты, признаки без энергии (первый коэффициент)

            // если переменная нормализации истинна, то нормируются все матрицы признаков
            // вычисляемых на данном этапе. В заключении нормируется матрица исходных признаков
            // P.S. возможно это небольшой костыль, однако я не знаю как сделать по-другому
            // скорее всего потому, что не хочу, но мне кажется, что можно сделать лучше

            if (cvmn)
            {
                if (energy && delta || energy && delta2)
                {
                    if (delta) deltaFeatures = Normalization(FeaturesDeltaDelta(energy, delta2));
                    if (delta2) delta2Features = Normalization(FeaturesDeltaDelta(energy, delta2));
                }
                else
                {
                    if (!energy) featuresWithoutEnergy = Normalization(FeaturesWithoutEnergy());
                    if (delta) deltaFeatures = Normalization(FeaturesDeltaDelta(energy, delta2));
                    if (delta2) delta2Features = Normalization(FeaturesDeltaDelta(energy, delta2));
                }

                features = Normalization(features);
            }
            else
            {
                // условия совместной работы переменных энергий и значений дельт
                // если энергия истина и какая-то из переменных дельт истинна
                // то вычисляется дельты от признаков с энергиями
                // иначе по каждому условию вычисляются отдельные признаки
                if (energy && delta || energy && delta2)
                {
                    if (delta) deltaFeatures = FeaturesDeltaDelta(energy, delta2);
                    if (delta2) delta2Features = FeaturesDeltaDelta(energy, delta2);
                }
                else
                {
                    if (!energy) featuresWithoutEnergy = FeaturesWithoutEnergy();
                    if (delta) deltaFeatures = FeaturesDeltaDelta(energy, delta2);
                    if (delta2) delta2Features = FeaturesDeltaDelta(energy, delta2);
                }
            }

            #endregion
        }

        double[][] ProcessFeatures(double[][] spectre) // вычисление признаков 
        {
            // инициализация матрицы признаков
            double[][] mfcc = new double[frameCount][];
            for (int i = 0; i < frameCount; i++)
                mfcc[i] = new double[numberCoefficients];

            // инициализация матрицы кепстра
            double[][] cepstre = new double[numberFilters][];
            for (int i = 0; i < numberFilters; i++)
                cepstre[i] = new double[frameCount];

            // инициализация матрицы фильтров
            double[][] filters = GetMelFilterBanks();

            // инициализация матрицы значений дискретного косинусного преобразования
            double[][] dctmat = GetDCTMatrix(2); 

            // инициализация вектора лифтеринга
            double[] liftmat = Liftering();

            for (int i = 0; i < numberFilters; i++)
            {
                for (int k = 0; k < frameCount; k++)
                {
                    // применение фильтров к спектру
                    for (int j = 0; j < windowSize; j++)
                        cepstre[i][k] += filters[i][j] * spectre[k][j];

                    //получение логарифма кепстра
                    if (cepstre[i][k] < 1.0f / 100000.0f) { cepstre[i][k] = Math.Log(1.0f / 100000.0f); }
                    else { cepstre[i][k] = Math.Log(cepstre[i][k]); }
                }
            }

            for (int k = 0; k < frameCount; k++)
            {
                for (int i = 0; i < numberCoefficients; i++)
                {
                    // применение дискретного косинусного преобразования
                    for (int j = 0; j < numberFilters; j++)
                        mfcc[k][i] += dctmat[i][j] * cepstre[j][k];
                }
            }

            for (int i = 0; i < frameCount; i++)
                for (int j = 1; j < numberCoefficients; j++)
                    mfcc[i][j] *= liftmat[j - 1];

            return mfcc;
        }

        #region Функции для вычисления MFCC (гребенки, и матрица косинусного преобразования, преобразования в мел и обратно)

        double[][] GetMelFilterBanks() // получение матрицы фильтров 
        {
            double[][] matrix = new double[numberFilters][];
            for (int i = 0; i < numberFilters; i++)
                matrix[i] = new double[windowSize];

            double maxMelf, deltaMelf;
            double lowFreq, mediumFreq, highFreq, currentFreq;

            maxMelf = LinToMelFreq(maxFreq);
            deltaMelf = maxMelf / (numberFilters + 1);

            lowFreq = MelToLinFreq(minFreq);
            mediumFreq = MelToLinFreq(deltaMelf);
            highFreq = 0;

            for (int i = 0; i < numberFilters; i++)
            {
                highFreq = MelToLinFreq(deltaMelf * (i + 2));

                for (int j = 0; j < windowSize; j++)
                {
                    currentFreq = (j * 1.0 / (windowSize - 1) * (maxFreq));

                    if ((currentFreq >= lowFreq) && (currentFreq <= mediumFreq))
                        matrix[i][j] = 2 * (currentFreq - lowFreq) / (mediumFreq - lowFreq);
                    else if ((currentFreq >= mediumFreq) && (currentFreq <= highFreq))
                        matrix[i][j] = 2 * (highFreq - currentFreq) / (highFreq - mediumFreq);
                    else
                        matrix[i][j] = 0;
                }

                lowFreq = mediumFreq;
                mediumFreq = highFreq;
            }

            return matrix;
        }

        double[][] GetDCTMatrix(int type) // получение значений дискретного косинусного преобразования 
        {
            double k = Math.PI / numberFilters;
            double w1 = 1.0 / (Math.Sqrt(numberFilters));
            double w2 = Math.Sqrt(2.0 / numberFilters);

            double[][] matrix = new double[numberCoefficients][];
            for (int i = 0; i < numberCoefficients; i++)
                matrix[i] = new double[numberFilters];

            for (int i = 0; i < numberCoefficients; i++)
            {
                for (int j = 0; j < numberFilters; j++)
                {
                    if (type == 0) // ортогональное
                    {
                        if (i == 0)
                            matrix[i][j] = w1 * Math.Cos(k * i * (j + 0.5d));
                        else
                            matrix[i][j] = w2 * Math.Cos(k * i * (j + 0.5d));
                    }
                    else if( type == 1) // не ортогональное
                    {
                        matrix[i][j] = Math.Cos(k * i * (j + 0.5d));
                    }
                    else if(type == 2) // wtf?
                    {
                        if (i == 0)
                            matrix[i][j] = 1;
                        else
                            matrix[i][j] = (2 * Math.Cos((0.5d * k * i * (2 * j + 1))));
                    }
                    else
                    {
                        throw new Exception("invalid type of dct");
                    }
                }
            }

            return matrix;
        }

        double[] Liftering() // лифтеринг 
        {
            int num_c = numberCoefficients - 1;

            double[] matrix = new double[num_c];

            for (int i = 0; i < num_c; i++)
                matrix[i] = ((1.0 + 0.5 * num_c * Math.Sin(Math.PI * (i + 1) / (num_c)))
                    / (1.0 + 0.5 * num_c));

            return matrix;
        }

        double LinToMelFreq(double inputFreq) // преобразование частоты в шкалу мел 
        {
            return 1125 * Math.Log((1 + inputFreq / 700), 10);
        }

        double MelToLinFreq(double inputFreq) // преобразование мел шкалы в частоты
        {
            return (Math.Pow(10, inputFreq / 1125) - 1) * 700;
        }

        #endregion

        #region Функции для работы с признаками (признаки без энергии, дельта и двойные дельта признаки)

        double[][] FeaturesWithoutEnergy() // получение признаков без первого коэффициента
        {
            double[][] withoutEnergy = new double[frameCount][];
            for (int i = 0; i < frameCount; i++)
                withoutEnergy[i] = new double[numberCoefficients - 1];

            for (int i = 0; i < frameCount; i++)
                for (int j = 1; j < numberCoefficients; j++)
                    withoutEnergy[i][j - 1] = features[i][j]; // создание нового вектора без энергии

            return withoutEnergy;
        }

        double[][] FeaturesDeltaDelta(bool energy, bool dDelta) // получение дельта и двойных дельта значений
        {
            int newNumCoeff = 0;

            double[][] featuresForProcess = null;

            // для тестирования вычисления дельт с энергией или без (withoutEnergy -> features)
            if (energy)
            {
                newNumCoeff = numberCoefficients;
                featuresForProcess = (double[][])features.Clone();
            }
            else
            {
                newNumCoeff = numberCoefficients - 1;
                featuresForProcess = FeaturesWithoutEnergy();
            }

            // инициализация
            double[][] deltaFeatures = new double[frameCount][]; // дельта-коэффициенты
            for (int i = 0; i < frameCount; i++)
                deltaFeatures[i] = new double[newNumCoeff * 2];

            // инициализация
            double[][] dDeltaFeatures = new double[frameCount][]; // коэффициенты ускорения
            for (int i = 0; i < frameCount; i++)
                dDeltaFeatures[i] = new double[newNumCoeff * 3];

            for (int i = 0; i < frameCount; i++)
            {
                double[] buffer = DeltaProcess(featuresForProcess[i]); // временное значение дельт первого порядка
                double[] buffer2 = DeltaProcess(buffer); // временное значение дельт второго порядка

                for (int j = 0; j < newNumCoeff * 3; j++)
                {
                    if (j < newNumCoeff)
                    {
                        deltaFeatures[i][j] = featuresForProcess[i][j]; // первый порядок (mfcc)
                        dDeltaFeatures[i][j] = featuresForProcess[i][j]; // второй порядок (mfcc)
                    }
                    else if (j >= newNumCoeff && j < newNumCoeff * 2)
                    {
                        deltaFeatures[i][j] = buffer[j - newNumCoeff];  // первый порядок (delta)
                        dDeltaFeatures[i][j] = buffer[j - newNumCoeff]; // второй порядок (delta)
                    }
                    else if (j >= newNumCoeff * 2)
                    {
                        dDeltaFeatures[i][j] = buffer2[j - newNumCoeff * 2]; // второй порядок (delta-delta)
                    }
                }
            }

            if (dDelta) return dDeltaFeatures;

            return deltaFeatures;
        }

        double[] DeltaProcess(double[] vector) // функция вычисления дельт
        {
            double[] delta = new double[vector.Length];

            double num, denom;

            int N = 2; //deltawindow, accwindow (HTK)

            int next, last;

            for (int i = 0; i < vector.Length; i++)
            {
                num = 0; denom = 0;

                for (int j = 1; j <= N; j++)
                {
                    next = i + j > vector.Length - 1 ? vector.Length - 1 : i + j;
                    last = i - j < 0 ? 0 : i - j;

                    num += j * (vector[next] - vector[last]);
                    denom += 2 * j * j;
                }

                delta[i] = num / denom;
            }

            return delta;
        }

        #endregion

        #region Функции постобработки признаков

        double[][] Normalization(double[][] array) // нормализация 
        {
            for (int i = 0; i < array[0].Length; i++)
            {
                List<double> buffer = new List<double>();

                double mean = 0, std = 0;

                for (int j = 0; j < array.Length; j++)
                    buffer.Add(array[j][i]);

                mean = Mean(buffer.ToArray()); // среднее
                std = Std(buffer.ToArray()); // стандартное отклонение

                for (int j = 0; j < frameCount; j++)
                    array[j][i] = (array[j][i] - mean) / std;
            }

            return array;
        }

        double Mean(double[] array) // среднее значение
        {
            double m = 0;

            for (int i = 0; i < array.Length; i++)
                m += array[i];

            m /= array.Length;

            return m;
        }

        double Std(double[] array) // стандартное отклонение
        {
            double m = 0;
            double s = 0;

            for (int i = 0; i < array.Length; i++)
                m += array[i];

            m /= array.Length;

            for (int i = 0; i < array.Length; i++)
                s += Math.Pow(array[i] - m, 2);

            s = Math.Sqrt(s / array.Length - 1);

            return s;
        }

        #endregion
    }

    class Lpc
    {

    }
}
