using System;
using System.Collections.Generic;
using Accord.Audio;
using Accord.Audio.Formats;
using Accord.Audio.Filters;
using System.IO;

namespace SpeakersNewRecog.Classes
{
    public class WaveReader
    {
        public struct WaveFormat 
        {
            string path; // путь до файла

            int sampleRate; // частота дискретизации

            int bitsPerSample; // бит в секунду

            int channels; // кол-во каналов

            int duration; // длительность

            public string Path { get { return path; } set { path = value; } }

            public int SampleRate { get { return sampleRate; } set { sampleRate = value; } }

            public int BitsPerSample { get { return bitsPerSample; } set { bitsPerSample = value; } }

            public int Channels { get { return channels; } set { channels = value; } }

            public int Duration { get { return duration; } set { duration = value; } }
        }

        double[] mono; // значения амплитуд одного канала

        double[] amplitudes; // значения амплитуд сигнала

        Signal sourceSignal; // исходный сигнал

        Signal monoSignal; // исходный сигнал

        WaveFormat format; // данные об файле wav

        public double[] Amplitudes { get { return amplitudes; } set { amplitudes = value; } }

        public double[] Mono { get { return mono; } set { mono = value; } }

        public Signal SourceSignal { get { return sourceSignal; } }

        public Signal MonoSignal { get { return monoSignal; } }

        public WaveFormat Format { get { return format; } }

        public WaveReader(string fileName)
        {
            Load(fileName);
        }

        public short[] GetShortAmplitudes(double[] array)
        {
            short[] shortAmplitudes = new short[array.Length];

            for (int i = 0; i < array.Length; i++) { shortAmplitudes[i] = (short)(array[i] * 32768f); }

            return shortAmplitudes;
        }

        public void Load(string fileName) // загрузка данных о wav
        {
            WaveDecoder sourceDecoder = new WaveDecoder(fileName);

            // заполнение формата файла
            format.Path = fileName;
            format.SampleRate = sourceDecoder.SampleRate;
            format.Channels = sourceDecoder.Channels;
            format.BitsPerSample = sourceDecoder.BitsPerSample;
            format.Duration = sourceDecoder.Duration / 1000;

            sourceSignal = sourceDecoder.Decode();

            amplitudes = new double[sourceSignal.Length * sourceSignal.Channels];

            for (int i = 0; i < sourceSignal.Length; i++)
            {
                // заполнение амплитуд по каналам
                for (int channel = 0; channel < sourceSignal.Channels; channel++)
                    amplitudes[i * sourceSignal.Channels + channel] = sourceSignal.GetSample(channel, i);
            }

            monoSignal = new MonoFilter().Apply(sourceSignal);

            mono = new double[monoSignal.Length];

            for (int i = 0; i < monoSignal.Length; i++)
                mono[i] = monoSignal.GetSample(0, i);
        }

        public void Save(string fileName, bool bMono) // сохранение wav 
        {
            using (FileStream SourceStream = File.Open(fileName, FileMode.OpenOrCreate))
            {
                WaveEncoder sourceEncoder = new WaveEncoder(SourceStream);

                if (bMono)
                {
                    for (int i = 0; i < monoSignal.Length; i++)
                        monoSignal.SetSample(0, i, (float)mono[i]);

                    sourceEncoder.Encode(monoSignal);
                }
                else
                {
                    for (int i = 0; i < sourceSignal.Length; i++)
                    {
                        // заполнение амплитуд по каналам
                        for (int channel = 0; channel < sourceSignal.Channels; channel++)
                            sourceSignal.SetSample(channel, i, (float)amplitudes[i * sourceSignal.Channels + channel]);
                    }

                    sourceEncoder.Encode(sourceSignal);
                }
            }
        }

        public void AddNoise(string noiseType, int percent, bool gauss, params double[] noiseValue)
        {
            NormalRandom nr = new NormalRandom();

            Random r = new Random(DateTime.Now.Second);

            int length = amplitudes.Length;

            double deviation = 0;

            if (gauss) deviation = noiseValue[0];

            int spercent = (int)(length * (percent / 100f));

            double plus = 0, minus = 0;

            if(!gauss)
            {
                plus = noiseValue[2] * 100;
                minus = -noiseValue[3] * 100;
            }

            switch (noiseType)
            {
                case "Импульсный":
                    {
                        int mppercent = spercent / 100 * (int)noiseValue[1];

                        for (int i = 0; i < spercent; i++)
                        {
                            int position = r.Next(0, length);

                            double randomSample = nr.NextDouble() * deviation;

                            if (i < mppercent)
                                amplitudes[position] = -randomSample;
                            else
                                amplitudes[position] = randomSample;
                        }

                        break;
                    }
                case "Аддитивный":
                    {
                        for (int i = 0; i < spercent; i++)
                        {
                            int position = r.Next(0, length);

                            double randomSample = 0;

                            if (gauss) randomSample = nr.NextDouble() * deviation;
                            else randomSample = r.Next((int)minus, (int)plus) / 100f;

                            amplitudes[position] += randomSample;
                        }

                        break;
                    }
                case "Мультипликативный":
                    {
                        for (int i = 0; i < spercent; i++)
                        {
                            int position = r.Next(0, length);

                            double randomSample = 0;

                            if (gauss) randomSample = nr.NextDouble() * deviation;
                            else randomSample = r.Next((int)minus, (int)plus) / 100f;

                            amplitudes[position] *= randomSample;
                        }

                        break;
                    }
                default: throw new Exception("invalid noise type");
            }

            // перезагрузка исходного сигнала
            for (int i = 0; i < sourceSignal.Length; i++)
            {
                // заполнение амплитуд по каналам
                for (int channel = 0; channel < sourceSignal.Channels; channel++)
                    sourceSignal.SetSample(channel, i, (float)amplitudes[i * sourceSignal.Channels + channel]);
            }

            // перезагрузка сигнала с моно фильтром
            monoSignal = new MonoFilter().Apply(sourceSignal);

            // получение амплитуд сигнала с моно фильтром
            for (int i = 0; i < monoSignal.Length; i++)
                mono[i] = monoSignal.GetSample(0, i);
        }
    }

    class NormalRandom : Random
    {
        // сохранённое предыдущее значение
        double prevSample = double.NaN;

        protected override double Sample()
        {
            // есть предыдущее значение? возвращаем его
            if (!double.IsNaN(prevSample))
            {
                double result = prevSample;
                prevSample = double.NaN;
                return result;
            }

            // нет? вычисляем следующие два
            // Marsaglia polar method из википедии
            double u, v, s;
            do
            {
                u = 2 * base.Sample() - 1;
                v = 2 * base.Sample() - 1; // [-1, 1)
                s = u * u + v * v;
            }
            while (u <= -1 || v <= -1 || s >= 1 || s == 0);
            double r = Math.Sqrt(-2 * Math.Log(s) / s);

            prevSample = r * v;
            return r * u;
        }
    }
}