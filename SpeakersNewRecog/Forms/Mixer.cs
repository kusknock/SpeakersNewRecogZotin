using SpeakersNewRecog.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;
using Accord.MachineLearning;
using NAudio.Wave.SampleProviders;
using NAudio.Wave;
using System.Diagnostics;
using System.Threading;
using System.IO;
using Accord.Audio.Formats;
using Accord.Audio;

namespace SpeakersNewRecog
{
    public partial class Mixer : Form
    {
        private WaveReader waveAnalyse;

        double atSeconds = 0;

        double start = 0, end = 0;

        List<double[]> arrays = new List<double[]>();

        List<string> names = new List<string>();

        public Mixer()
        {
            InitializeComponent();

            InitializeGraph();

            cmbAudioMode.SelectedIndex = 0;

            cmbTypeSTF.SelectedIndex = 0;

            cmbAlgorithm.SelectedIndex = 0;
        }

        ///-------------------------------------

        private void InitializeGraph()
        {
            graphControl.GraphPane.Chart.Border.IsVisible = false;
            graphControl.GraphPane.Chart.Fill.IsVisible = false;
            graphControl.GraphPane.Fill.Color = Color.Black;
            graphControl.GraphPane.Title.IsVisible = false;
            graphControl.GraphPane.XAxis.IsVisible = false;
            graphControl.GraphPane.YAxis.IsVisible = false;
            graphControl.GraphPane.YAxis.Scale.Max = 1;
            graphControl.GraphPane.YAxis.Scale.Min = -1;
        }

        private void DisplayWaveGraph(double[] waveData)
        {
            start = 0;
            end = 0;

            lblPlaySection.Text = "Начало: 0, Конец: 0";

            btnPlay.Enabled = false;

            graphControl.GraphPane.CurveList.Clear();
            graphControl.GraphPane.GraphObjList.Clear();

            graphControl.GraphPane.XAxis.Scale.Max = waveData.Length - 1;
            graphControl.GraphPane.XAxis.Scale.Min = 0;
            graphControl.GraphPane.Margin.All = 0;
            var timeData = Enumerable.Range(0, waveData.Length)
                                     .Select(i => (double)i)
                                     .ToArray();
            graphControl.GraphPane.AddCurve(null, timeData, waveData, Color.Lime, SymbolType.None);
            graphControl.AxisChange();

            graphControl.Refresh();
        }

        private void graphControl_MouseClick(object sender, MouseEventArgs e)
        {
            if (tabControl.SelectedIndex == 1)
            {
                graphControl.GraphPane.GraphObjList.Clear();

                GraphPane myPane = graphControl.GraphPane;

                double xVal;
                double yVal;

                myPane.ReverseTransform(e.Location, out xVal, out yVal);

                if (myPane.CurveList.Count == 1)
                {
                    int pointsCount = myPane.CurveList[0].Points.Count;

                    start = myPane.CurveList[0].Points[0].X;
                    end = myPane.CurveList[0].Points[pointsCount - 1].X;
                }
                else
                {
                    for (int i = 1; i < myPane.CurveList.Count; i++)
                    {
                        if (myPane.CurveList[i].Points[0].X > xVal
                            && i == 1)
                        {
                            start = myPane.CurveList[0].Points[0].X;
                            end = myPane.CurveList[i].Points[0].X;
                        }
                        if (i != myPane.CurveList.Count - 1)
                        {
                            if (xVal > myPane.CurveList[i].Points[0].X
                                && xVal < myPane.CurveList[i + 1].Points[0].X)
                            {
                                start = myPane.CurveList[i].Points[0].X;
                                end = myPane.CurveList[i + 1].Points[0].X;
                            }
                        }

                        if (myPane.CurveList[i].Points[0].X < xVal
                            && i == myPane.CurveList.Count - 1)
                        {
                            int pointsCount = myPane.CurveList[0].Points.Count;

                            start = myPane.CurveList[i].Points[0].X;
                            end = myPane.CurveList[0].Points[pointsCount - 1].X;
                        }
                    }
                }

                var sectionPoly = new BoxObj(start, myPane.YAxis.Scale.Max, 
                    end - start, myPane.YAxis.Scale.Max - myPane.YAxis.Scale.Min)
                {
                    Fill = new Fill(Color.DimGray),
                    ZOrder = ZOrder.E_BehindCurves
                };

                lblPlaySection.Text = $"Начало: {start / waveAnalyse.Format.SampleRate}, Конец: {end / waveAnalyse.Format.SampleRate}";

                myPane.GraphObjList.Add(sectionPoly);

                graphControl.Refresh();

                btnPlay.Enabled = true;
            }
            else if (tabControl.SelectedIndex == 0)
            {
                PointPairList userClickrList = new PointPairList();
                LineItem userClickCurve = new LineItem("userClickCurve");

                // Create an instance of Graph Pane
                GraphPane myPane = graphControl.GraphPane;

                // x & y variables to store the axis values
                double xVal;
                double yVal;

                // Clear the previous values if any
                userClickrList.Clear();

                myPane.Legend.IsVisible = false;

                // Use the current mouse locations to get the corresponding 
                // X & Y CO-Ordinates
                myPane.ReverseTransform(e.Location, out xVal, out yVal);

                atSeconds = xVal / waveAnalyse.Format.SampleRate;

                // Create a list using the above x & y values
                userClickrList.Add(xVal, myPane.YAxis.Scale.Max);
                userClickrList.Add(xVal, myPane.YAxis.Scale.Min);

                // Add a curve

                userClickCurve = myPane.AddCurve(" ", userClickrList, Color.Red, SymbolType.None);

                graphControl.Refresh();
            }
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayWaveGraph(waveAnalyse.Mono);
        }

        private void Mixer_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "WAV file *.wav|*.wav",
                Title = "Open WAV"
            };


            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            waveAnalyse = new WaveReader(ofd.FileName);

            DisplayWaveGraph(waveAnalyse.Mono);

            tabControl.Enabled = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// ------------------------------------

        private void GetPointsActivity(int[] result, int frameSize)
        {
            List<int> points = new List<int>();

            for (int num_frame = 0; num_frame < result.Length - 1; num_frame++)
            {
                if (result[num_frame] == 0 && result[num_frame + 1] == 1)
                {
                    points.Add((num_frame + 1) * frameSize);
                }

                if(result[num_frame] == 1 && result[num_frame + 1] == 0)
                {
                    points.Add(num_frame * frameSize);
                }
            }

            foreach(int xVal in points)
            {
                PointPairList userClickrList = new PointPairList();
                LineItem userClickCurve = new LineItem("userClickCurve");

                // Create an instance of Graph Pane
                GraphPane myPane = graphControl.GraphPane;

                // Clear the previous values if any
                userClickrList.Clear();

                myPane.Legend.IsVisible = false;

                // Create a list using the above x & y values
                userClickrList.Add(xVal, myPane.YAxis.Scale.Max);
                userClickrList.Add(xVal, myPane.YAxis.Scale.Min);

                // Add a curve

                userClickCurve = myPane.AddCurve(" ", userClickrList, Color.Red, SymbolType.None);

                graphControl.Refresh();
            }
        }

        private double sign(double d)
        {
            return d < 0 ? -1d : 1d;
        }

        ///-------------------------------------

        private void btnShortTimeFeatures_Click(object sender, EventArgs e)
        {
            int searchRadius = (int)numSizeFilterSTF.Value;
            int countFrame = (int)numCountFrameSTF.Value;
            int frameSize = (int)numFrameSizeSTF.Value;

            int[] result = null;

            Overlapping wavFramed = new Overlapping(waveAnalyse, frameSize, false);

            switch(cmbTypeSTF.Text)
            {
                case "Energy Feature + Zero Cross #1":
                    result = EnergyZeroCrossVAD(wavFramed, searchRadius, countFrame);
                    break;
                case "Energy Feature + Zero Cross #2":
                    result = EnergyZeroCrossVAD2(wavFramed, searchRadius, countFrame);
                    break;
                case "Energy Feature + Zero Cross + Most dominant frequency":
                    result = EnergyZeroCrossMostDominantFreq(wavFramed, searchRadius, countFrame);
                    break;
                default: break;
            }

            DisplayWaveGraph(waveAnalyse.Mono);

            GetPointsActivity(result, wavFramed.FrameSize);

            btnChartsStatistics.Enabled = true;
        }

        // TODO (себе на будущее): 
        // проблемы с дисперсией (корень извлечь) 
        // подумать над алгоритмом, так как он работает плохо
        private int[] EnergyZeroCrossVAD(Overlapping wavFramed, int searchRadius, int firstCounts)
        {
            double[][] frames = (double[][])wavFramed.Overlap.Clone();

            double[] EArray = new double[frames.Length];

            double[] ZArray = new double[frames.Length];

            int[] result = new int[frames.Length];

            double E_Threshold = 0, Z_Threshold = 0;

            if (frames.Length <= firstCounts) throw new Exception("file is not correct");

            double EMean = 0, EDispersion = 0, ZMean = 0, ZDispersion = 0;

            for (int num_frame = 0; num_frame < firstCounts; num_frame++)
            {
                // суммирование отсчетов и числа пересечений через ноль
                for (int i = 0; i < frames[num_frame].Length; i++)
                {
                    EArray[num_frame] += frames[num_frame][i] * frames[num_frame][i];
                    if (i > 0) ZArray[num_frame] +=
                            Math.Abs(sign(frames[num_frame][i]) - sign(frames[num_frame][i - 1]));
                }

                EArray[num_frame] /= frames[num_frame].Length;
                ZArray[num_frame] /= 2;

                // суммирование значений энергий и пересечений в кадре
                EMean += EArray[num_frame];
                ZMean += ZArray[num_frame];
            }

            // вычисление средних значений
            EMean /= firstCounts;
            ZMean /= firstCounts;

            // суммирование значений для вычисления дисперсий
            for (int num_frame = 0; num_frame < firstCounts; num_frame++)
            {
                EDispersion += Math.Pow(EArray[num_frame] - EMean, 2);
                ZDispersion += Math.Pow(ZArray[num_frame] - ZMean, 2);
            }

            // вычисление дисперсий
            EDispersion /= firstCounts - 1;
            ZDispersion /= firstCounts - 1;

            E_Threshold = EMean + 3 * Math.Sqrt(EDispersion) + (1d / 400d) * EArray.Take(firstCounts).Max();
            Z_Threshold = ZMean + 3 * Math.Sqrt(ZDispersion) + (1d / 20d) * ZArray.Take(firstCounts).Max();

            for (int num_frame = firstCounts; num_frame < frames.Length; num_frame++)
            {
                // суммирование отсчетов и числа пересечений через ноль
                for (int i = 0; i < frames[num_frame].Length; i++)
                {
                    EArray[num_frame] += frames[num_frame][i] * frames[num_frame][i];
                    if (i > 0) ZArray[num_frame] +=
                            Math.Abs(sign(frames[num_frame][i]) - sign(frames[num_frame][i - 1]));
                }

                EArray[num_frame] /= frames[num_frame].Length;
                ZArray[num_frame] /= 2;
            }

            // помечаются речь (1) и пауза (0) в результирующем массиве
            for (int num_frame = 0; num_frame < frames.Length; num_frame++)
            {
                if (EArray[num_frame] > E_Threshold) result[num_frame] = 1;
                else result[num_frame] = 0;
            }

            // сглаживание медианной фильтрацией полученного результата
            for (int num_frame = 0; num_frame < frames.Length; num_frame++)
            {
                int b = 0;

                if (num_frame - searchRadius < 0 ||
                    num_frame + searchRadius > frames.Length - 1) continue;

                for (int i = num_frame - searchRadius; i <= num_frame + searchRadius; i++)
                {
                    b += result[i];
                }

                if (b > searchRadius) result[num_frame] = 1;
                else result[num_frame] = 0;
            }

            // радиус поиска для расширения с помощью zerocross
            int searchRadius2 = 20;

            // цикл по результирующему массиву с сегментированными участками
            for (int num_frame = 0; num_frame < frames.Length; num_frame++)
            {
                if (num_frame == 0 || num_frame == frames.Length - 1) continue;

                if (result[num_frame] == 1 && result[num_frame - 1] == 0)
                {
                    for (int i = 1; i <= searchRadius2; i++)
                    {
                        if (num_frame - i < 0) break;

                        if (Z_Threshold / ZArray[num_frame - i] > 3) result[num_frame - i] = 1;
                    }
                }

                if (result[num_frame] == 1 && result[num_frame + 1] == 0)
                {
                    for (int i = 1; i <= searchRadius2; i++)
                    {
                        if (num_frame + i > frames.Length - 1) break;

                        if (Z_Threshold / ZArray[num_frame + i] > 3) result[num_frame + i] = 1;
                    }
                }
            }

            arrays.Clear();
            names.Clear();

            arrays.Add(EArray);
            arrays.Add(ZArray);
            arrays.Add(waveAnalyse.Mono);

            names.Add("Энергетическая характеристика кадра");
            names.Add("Число пересечений через нуль в кадре");
            names.Add("Амплитуды сигнала");

            return result;
        }

        private int[] EnergyZeroCrossVAD2(Overlapping wavFramed, int searchRadius, int firstCounts)
        {
            double[][] frames = (double[][])wavFramed.Overlap.Clone();

            double[] EArray = new double[frames.Length];

            double[] ZArray = new double[frames.Length];

            int[] result = new int[frames.Length];

            double E_Threshold = 0, Z_Threshold = 0;

            if (frames.Length <= firstCounts) throw new Exception("file is not correct");

            for (int num_frame = 0; num_frame < firstCounts; num_frame++)
            {
                // суммирование отсчетов и числа пересечений через ноль
                for (int i = 0; i < frames[num_frame].Length; i++)
                {
                    EArray[num_frame] += frames[num_frame][i] * frames[num_frame][i];
                    if (i > 0) ZArray[num_frame] +=
                            Math.Abs(sign(frames[num_frame][i]) - sign(frames[num_frame][i - 1]));
                }

                EArray[num_frame] /= frames[num_frame].Length;
                ZArray[num_frame] /= 2;
            }

            E_Threshold = EArray.Take(firstCounts).Max();
            Z_Threshold = ZArray.Take(firstCounts).Max() * (3d / 5d);

            for (int num_frame = firstCounts; num_frame < frames.Length; num_frame++)
            {
                // суммирование отсчетов и числа пересечений через ноль
                for (int i = 0; i < frames[num_frame].Length; i++)
                {
                    EArray[num_frame] += frames[num_frame][i] * frames[num_frame][i];
                    if (i > 0) ZArray[num_frame] +=
                            Math.Abs(sign(frames[num_frame][i]) - sign(frames[num_frame][i - 1]));
                }

                EArray[num_frame] /= frames[num_frame].Length;
                ZArray[num_frame] /= 2;
            }

            // помечаются речь (1) и пауза (0) в результирующем массиве
            for (int num_frame = 0; num_frame < frames.Length; num_frame++)
            {
                int counter = 0;

                if (EArray[num_frame] > E_Threshold) counter++;
                if (ZArray[num_frame] < Z_Threshold) counter++;

                if (Z_Threshold == 0 ? counter >= 1 : counter > 1) result[num_frame] = 1;
                else result[num_frame] = 0;
            }

            // сглаживание медианной фильтрацией полученного результата
            for (int num_frame = 0; num_frame < frames.Length; num_frame++)
            {
                int b = 0;

                if (num_frame - searchRadius < 0 ||
                    num_frame + searchRadius > frames.Length - 1) continue;

                for (int i = num_frame - searchRadius; i <= num_frame + searchRadius; i++)
                {
                    b += result[i];
                }

                if (b > searchRadius) result[num_frame] = 1;
                else result[num_frame] = 0;
            }

            arrays.Clear();
            names.Clear();

            arrays.Add(EArray);
            arrays.Add(ZArray);
            arrays.Add(waveAnalyse.Mono);

            names.Add("Энергетическая характеристика кадра");
            names.Add("Число пересечений через нуль в кадре");
            names.Add("Амплитуды сигнала");

            return result;
        }

        private int[] EnergyZeroCrossMostDominantFreq(Overlapping wavFramed, int searchRadius, int firstCounts)
        {
            DiscreteTransform fft = new DiscreteTransform(wavFramed);

            fft.Process(DiscreteTransform.TransformType.InFrequency);

            double[][] spectre = (double[][])fft.Spectre.Clone();

            double[][] frames = (double[][])wavFramed.Overlap.Clone();

            double[] EArray = new double[frames.Length];

            double[] ZArray = new double[frames.Length];

            double[] FArray = new double[frames.Length];

            int[] result = new int[frames.Length];

            double E_Threshold = 0, Z_Threshold = 0, F_Threshold = 0;

            if (frames.Length <= firstCounts) throw new Exception("file is not correct");

            for (int num_frame = 0; num_frame < firstCounts; num_frame++)
            {
                // суммирование отсчетов и числа пересечений через ноль
                for (int i = 0; i < frames[num_frame].Length; i++)
                {
                    EArray[num_frame] += frames[num_frame][i] * frames[num_frame][i];
                    if (i > 0) ZArray[num_frame] +=
                            Math.Abs(sign(frames[num_frame][i]) - sign(frames[num_frame][i - 1]));
                }

                EArray[num_frame] /= frames[num_frame].Length;
                ZArray[num_frame] /= 2;
                FArray[num_frame] = spectre[num_frame].Max();
            }

            F_Threshold = 8; // эмпирически
            E_Threshold = EArray.Take(firstCounts).Max();
            Z_Threshold = ZArray.Take(firstCounts).Max() * (3d / 5d);

            for (int num_frame = firstCounts; num_frame < frames.Length; num_frame++)
            {
                // суммирование отсчетов и числа пересечений через ноль
                for (int i = 0; i < frames[num_frame].Length; i++)
                {
                    EArray[num_frame] += frames[num_frame][i] * frames[num_frame][i];
                    if (i > 0) ZArray[num_frame] +=
                            Math.Abs(sign(frames[num_frame][i]) - sign(frames[num_frame][i - 1]));
                }

                EArray[num_frame] /= frames[num_frame].Length;
                ZArray[num_frame] /= 2;
                FArray[num_frame] = spectre[num_frame].Max();
            }

            // помечаются речь (1) и пауза (0) в результирующем массиве
            for (int num_frame = 0; num_frame < frames.Length; num_frame++)
            {
                int counter = 0;

                if (EArray[num_frame] > E_Threshold) counter++;
                if (ZArray[num_frame] < Z_Threshold) counter++;
                if (FArray[num_frame] > F_Threshold) counter++;

                if (counter > 1) result[num_frame] = 1;
                else result[num_frame] = 0;
            }

            // сглаживание медианной фильтрацией полученного результата
            for (int num_frame = 0; num_frame < frames.Length; num_frame++)
            {
                int b = 0;

                if (num_frame - searchRadius < 0 ||
                    num_frame + searchRadius > frames.Length - 1) continue;

                for (int i = num_frame - searchRadius; i <= num_frame + searchRadius; i++)
                {
                    b += result[i];
                }

                if (b > searchRadius) result[num_frame] = 1;
                else result[num_frame] = 0;
            }

            arrays.Clear();
            names.Clear();

            arrays.Add(FArray);
            arrays.Add(EArray);
            arrays.Add(ZArray);
            arrays.Add(waveAnalyse.Mono);

            names.Add("Максимальная частота кадра");
            names.Add("Энергетическая характеристика кадра");
            names.Add("Число пересечений через нуль в кадре");
            names.Add("Амплитуды сигнала");

            return result;
        }

        ///-------------------------------------

        private void btnNormalDistribution_Click(object sender, EventArgs e)
        {
            int searchRadius = (int)numSizeFilterND.Value;
            int countFrame = (int)numCountFrameND.Value;
            int frameSizeMs = (int)numFrameSizeND.Value;

            int frameSize = 0;

            int[] result = null;

            result = NormalDistrubutionVAD(waveAnalyse, frameSizeMs, searchRadius, countFrame, out frameSize);

            DisplayWaveGraph(waveAnalyse.Mono);

            GetPointsActivity(result, frameSize);

            btnChartsStatistics.Enabled = true;
        }

        private int[] NormalDistrubutionVAD(WaveReader wav, int frameSizeMs,
            int searchRadius, int firstCountsMs, out int frameSize)
        {
            double[] amplitudes = (double[])wav.Mono.Clone();

            int oneMilliInSamples = wav.Format.SampleRate / 1000;

            int firstCounts = oneMilliInSamples * firstCountsMs;

            frameSize = frameSizeMs * oneMilliInSamples;

            double mean = 0, sigma = 0;

            double DThreshold = 0;

            double[] frame = new double[frameSize];

            double[] DistArray = new double[amplitudes.Length];

            int[] result = new int[amplitudes.Length / frameSize];

            if (amplitudes.Length <= firstCounts) throw new Exception("file is not correct");

            // вычисление среднего значения
            for (int i = 0; i < firstCounts; i++)
                mean += amplitudes[i];

            mean /= firstCounts;

            // вычисление стандартного отклонения
            for (int i = 0; i < firstCounts; i++)
                sigma += Math.Pow(amplitudes[i] - mean, 2);

            sigma = Math.Sqrt(sigma / firstCounts);

            if (sigma == 0) sigma = 1;

            for (int i = 0; i < firstCounts; i++)
            {
                double distance = Math.Abs(amplitudes[i] - mean) / sigma;

                DistArray[i] = distance;
            }

            DThreshold = DistArray.Max();

            for (int i = 0, j = 0, k = 0; i < amplitudes.Length; i++, j++)
            {
                double distance = Math.Abs(amplitudes[i] - mean) / sigma;

                DistArray[i] = distance;

                if (distance > DThreshold)
                    frame[j] = 1;
                else frame[j] = 0;

                if (j == frame.Length - 1)
                {
                    j = 0;

                    int countOne = frame.Count(x => x == 1);
                    int countNull = frame.Length - countOne;

                    if (k < result.Length)
                        if (countOne > countNull) result[k++] = 1;
                        else result[k++] = 0;
                }
            }

            // сглаживание медианной фильтрацией полученного результата
            for (int num_frame = 0; num_frame < result.Length; num_frame++)
            {
                int b = 0;

                if (num_frame - searchRadius < 0 ||
                    num_frame + searchRadius > result.Length - 1) continue;

                for (int i = num_frame - searchRadius; i <= num_frame + searchRadius; i++)
                {
                    b += result[i];
                }

                if (b > searchRadius) result[num_frame] = 1;
                else result[num_frame] = 0;
            }

            arrays.Clear();
            names.Clear();

            arrays.Add(DistArray);
            arrays.Add(waveAnalyse.Mono);

            names.Add("Растояние Махаланобиса");
            names.Add("Амплитуды сигнала");

            return result;
        }

        ///-------------------------------------

        private void btnAutocorrelation_Click(object sender, EventArgs e)
        {
            int searchRadius = (int)numSizeFilterAutocor.Value;
            int countFrame = (int)numCountFrameAutocor.Value;
            int frameSizeMs = (int)numFrameSizeAutocor.Value;
            int windowSizeMs = (int)numWindowSizeAutocor.Value;

            int frameSize = 0;

            int[] result = null;

            result = Autocorrelation(waveAnalyse, windowSizeMs, frameSizeMs, countFrame, searchRadius, out frameSize);

            DisplayWaveGraph(waveAnalyse.Mono);

            GetPointsActivity(result, frameSize);

            btnChartsStatistics.Enabled = true;
        }

        private int[] Autocorrelation(WaveReader wav, int WINDOW_MILLIS, int FRAME_SIZE_MILLIS, 
            int FIRST_COUNTS_MILLIS, int searchRadius, out int frameSize)
        {
            double[] voiceSample = (double[])wav.Mono.Clone();

            double sampleRate = wav.Format.SampleRate;

            double threshold = 0;

            int oneMilliInSamples = (int)sampleRate / 1000;

            frameSize = oneMilliInSamples * FRAME_SIZE_MILLIS;

            int firstCounts = oneMilliInSamples * FIRST_COUNTS_MILLIS;

            int length = voiceSample.Length;

            int[] resultFull = new int[length];

            int[] result = new int[length / frameSize];
            int[] frame = new int[frameSize];

            if (length <= firstCounts) throw new Exception("file is not correct");

            int windowSize = WINDOW_MILLIS * oneMilliInSamples;
            double[] correllation = new double[windowSize];
            double[] window = new double[windowSize];

            List<double> means = new List<double>();

            List<double> MeanArray = new List<double>();

            for (int position = 0; position + windowSize < firstCounts; position += windowSize)
            {
                Array.Copy(voiceSample, position, window, 0, windowSize);
                double mean = BruteForceAutocorrelation(window, correllation);

                means.Add(mean);
            }

            threshold = means.Max();

            for (int position = 0; position + windowSize < length; position += windowSize)
            {
                Array.Copy(voiceSample, position, window, 0, windowSize);
                double mean = BruteForceAutocorrelation(window, correllation);
                MeanArray.Add(mean);

                ArrayHelper.Fill(resultFull, position, position + windowSize, mean > threshold ? 1 : 0);
            }

            for (int num_frame = 0, k = 0; num_frame < result.Length; num_frame++)
            {
                frame = resultFull.Skip(num_frame * frameSize).Take(frameSize).ToArray();

                int countOne = frame.Count(x => x == 1);
                int countNull = frame.Length - countOne;

                if (k < result.Length)
                    if (countOne > countNull) result[k++] = 1;
                    else result[k++] = 0;
            }

            // сглаживание медианной фильтрацией полученного результата
            for (int num_frame = 0; num_frame < result.Length; num_frame++)
            {
                int b = 0;

                if (num_frame - searchRadius < 0 ||
                    num_frame + searchRadius > result.Length - 1) continue;

                for (int i = num_frame - searchRadius; i <= num_frame + searchRadius; i++)
                {
                    b += result[i];
                }

                if (b > searchRadius) result[num_frame] = 1;
                else result[num_frame] = 0;
            }

            arrays.Clear();
            names.Clear();

            arrays.Add(MeanArray.ToArray());
            arrays.Add(waveAnalyse.Mono);

            names.Add("Среднее значение корреляции");
            names.Add("Амплитуды сигнала");

            return result;
        }

        private double BruteForceAutocorrelation(double[] voiceSample, double[] correllation)
        {
            ArrayHelper.Fill(correllation, 0);
            int n = voiceSample.Length;
            for (int j = 0; j < n; j++)
            {
                for (int i = 0; i < n; i++)
                {
                    correllation[j] += voiceSample[i] * voiceSample[(n + i - j) % n];
                }
            }
            double mean = 0.0d;
            for (int i = 0; i < voiceSample.Length; i++)
            {
                mean += correllation[i];
            }
            return mean / correllation.Length;
        }

        ///-------------------------------------

        private void btnMix_Click(object sender, EventArgs e)
        {
            try
            {
                var wav1 = new WaveFileReader(waveAnalyse.Format.Path);
                var wav2 = new WaveFileReader(txbMixFile2.Text);

                double wav2Skip = (double)numMix2FileAtSecond.Value;

                int maxDuration = 0;

                WaveFileReader longFile = null, shortFile = null;

                ISampleProvider duration1 = null, duration2 = null;

                ISampleProvider silence = null, concat1 = null, concat2 = null;

                VolumeSampleProvider vol1, vol2;

                // инициализация переменных для длинного и короткого файла
                if (wav1.TotalTime > wav2.TotalTime)
                {
                    longFile = wav1;
                    shortFile = wav2;

                    duration1 = longFile.ToSampleProvider();
                    duration2 = shortFile.ToSampleProvider().Skip(TimeSpan.FromSeconds(wav2Skip));

                    maxDuration = longFile.TotalTime.Seconds;
                }
                else
                {
                    longFile = wav2;
                    shortFile = wav1;

                    duration1 = longFile.ToSampleProvider().Skip(TimeSpan.FromSeconds(wav2Skip)).Take(shortFile.TotalTime);
                    duration2 = shortFile.ToSampleProvider();

                    maxDuration = shortFile.TotalTime.Seconds;
                }

                if (atSeconds > maxDuration) throw new Exception("invalid mixing duration");

                if (atSeconds != 0)
                {
                    silence = new SilenceProvider(duration1.WaveFormat)
                        .ToSampleProvider().Take(TimeSpan.FromSeconds(atSeconds));

                    concat1 = silence.FollowedBy(duration1);
                    concat2 = duration2;
                }
                else
                {
                    concat1 = duration1;
                    concat2 = duration2;
                }


                switch (cmbAudioMode.Text)
                {
                    case "Моно":
                        vol1 = new VolumeSampleProvider(concat1.ToMono()) { Volume = (float)numVolFile1.Value };
                        vol2 = new VolumeSampleProvider(concat2.ToMono()) { Volume = (float)numVolFile2.Value };
                        break;
                    case "Стерео":
                        vol1 = new VolumeSampleProvider(concat1.ToStereo()) { Volume = (float)numVolFile1.Value };
                        vol2 = new VolumeSampleProvider(concat2.ToStereo()) { Volume = (float)numVolFile2.Value }; break;
                    default: throw new Exception("invalid audio mode");
                }

                var sources = new[] { vol1, vol2 };

                var mixer = new MixingSampleProvider(sources);

                WaveFileWriter.CreateWaveFile(txbMixFileResult.Text, mixer.ToWaveProvider());

                waveAnalyse = new WaveReader(txbMixFileResult.Text);

                DisplayWaveGraph(waveAnalyse.Mono);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnMixFile2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "Wav file *.wav|*.wav",
                Title = "Open Wav"
            };

            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            txbMixFile2.Text = ofd.FileName;
        }

        private void btnMixFileResult_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "Wav file *.wav|*.wav",
                Title = "Save Wav"
            };

            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            txbMixFileResult.Text = sfd.FileName;
        }

        ///-------------------------------------

        private void btnExtract_Click(object sender, EventArgs e)
        {
            try
            {
                var video = txbPathVideo.Text;
                var audio = txbPathSaveWave.Text;

                Process process = new Process();
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.FileName = string.Format("{0}\\MediaToolkit\\ffmpeg.exe", Environment.CurrentDirectory);

                process.StartInfo.Arguments = string.Format("-i \"{0}\" -acodec pcm_s16le -ar 16000 -ac 1 \"{1}\"", video, audio);

                //process.StartInfo.Arguments = string.Format("-i \"{0}\"  \"{1}\"", video, Path.Combine(audio, "test.wav"));

                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                MessageBox.Show("Операция успешно завершена.");
            }
        }

        private void btnPathVideo_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "Video file *.mp4|*.mp4",
                Title = "Open Video"
            };

            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            txbPathVideo.Text = ofd.FileName;
        }

        private void btnPathSaveWave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "Wav file *.wav|*.wav",
                Title = "Save Wav"
            };

            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            txbPathSaveWave.Text = sfd.FileName;
        }

        ///-------------------------------------

        private void btnPlay_Click(object sender, EventArgs e)
        {
            string path = string.Format(@"{0}\Temp Wav\temp_{1}.wav",
                Environment.CurrentDirectory, DateTime.Now.ToString().Replace(":", "."));

            using (FileStream SourceStream = File.Open(path, FileMode.OpenOrCreate))
            {
                Signal monoSignal = new Signal(waveAnalyse.MonoSignal.Channels, (int)(end - start),
                    waveAnalyse.MonoSignal.SampleRate, waveAnalyse.MonoSignal.SampleFormat);

                WaveEncoder sourceEncoder = new WaveEncoder(SourceStream);

                for (int i = 0, j = (int)start; i < (int)(end - start); i++, j++)
                    monoSignal.SetSample(0, i, (float)waveAnalyse.Mono[j]);

                sourceEncoder.Encode(monoSignal);
            }

            using (WaveStream writer = new WaveFileReader(path))
            using (WaveChannel32 volumeStream = new WaveChannel32(writer))
            {
                using (var ds = new DirectSoundOut())
                {
                    ds.Init(volumeStream);
                    ds.Play();
                    Thread.Sleep(3000);
                }
            }

            File.Delete(path);

            graphControl.GraphPane.GraphObjList.Clear();

            graphControl.Refresh();

            btnPlay.Enabled = false;
        }

        ///-------------------------------------

        private void btnChartsStatistics_Click(object sender, EventArgs e)
        {
            Form graphForm = new Form()
            {
                Text = "Графики статистик",
                AutoSize = true,
                Size = new Size(Size.Width, Size.Height),
                AutoScroll = true,

            };

            for (int i = 0; i < arrays.Count; i++)
            {
                GroupBox group = new GroupBox()
                {
                    Dock = DockStyle.Top,
                    Text = names[i],
                    Height = 200,
                };

                ZedGraphControl zgc = MakeZedGraph(arrays[i]);

                group.Controls.Add(zgc);

                graphForm.Controls.Add(group);
            }

            graphForm.Show();
        }

        private ZedGraphControl MakeZedGraph(double[] array)
        {
            ZedGraphControl zgc = new ZedGraphControl()
            {
                Dock = DockStyle.Fill,
            };

            zgc.GraphPane.Chart.Border.IsVisible = false;
            zgc.GraphPane.Chart.Fill.IsVisible = false;
            zgc.GraphPane.Fill.Color = Color.Black;
            zgc.GraphPane.Title.IsVisible = false;
            zgc.GraphPane.XAxis.IsVisible = false;
            zgc.GraphPane.YAxis.IsVisible = false;
            zgc.GraphPane.YAxis.Scale.Max = array.Max() + 1;
            zgc.GraphPane.YAxis.Scale.Min = -array.Max() - 1;

            zgc.GraphPane.XAxis.Scale.Max = array.Length - 1;
            zgc.GraphPane.XAxis.Scale.Min = 0;
            zgc.GraphPane.Margin.All = 0;
            var timeData = Enumerable.Range(0, array.Length)
                                     .Select(i => (double)i)
                                     .ToArray();
            zgc.GraphPane.AddCurve(null, timeData, array, Color.Lime, SymbolType.None);
            zgc.AxisChange();

            zgc.Refresh();

            return zgc;
        }

        //-----------------------------------------------------------

        private void btnOpenEtalon_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "WAV file *.wav|*.wav",
                Title = "Open WAV"
            };

            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            txbEtalon.Text = ofd.FileName;
        }

        private void btnOpenCompare_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "WAV file *.wav|*.wav",
                Title = "Open WAV"
            };

            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            txbCompareFile.Text = ofd.FileName;
        }

        private void btnStartCompare_Click(object sender, EventArgs e)
        {
            WaveReader wavEtalon = new WaveReader(txbEtalon.Text);

            WaveReader wavCompare= new WaveReader(txbCompareFile.Text);

            int[] resultEtalon = null, resultCompare =null;

            switch (cmbAlgorithm.Text)
            {
                case "Energy Feature + Zero Cross #1":
                    {
                        int searchRadius = (int)numSizeFilterSTF.Value;
                        int countFrame = (int)numCountFrameSTF.Value;
                        int frameSize = (int)numFrameSizeSTF.Value;

                        Overlapping wavFramedEtalon = new Overlapping(wavEtalon, frameSize, false);

                        Overlapping wavFramedCompare = new Overlapping(wavCompare, frameSize, false);

                        resultEtalon = EnergyZeroCrossVAD(wavFramedEtalon, searchRadius, countFrame);

                        resultCompare = EnergyZeroCrossVAD(wavFramedCompare, searchRadius, countFrame);

                        break;
                    }
                case "Statistic Features":
                    {
                        int searchRadius = (int)numSizeFilterND.Value;
                        int countFrame = (int)numCountFrameND.Value;
                        int frameSizeMs = (int)numFrameSizeND.Value;

                        int frameSize = 0;

                        resultEtalon = NormalDistrubutionVAD(wavEtalon, frameSizeMs, searchRadius, countFrame, out frameSize);

                        resultCompare = NormalDistrubutionVAD(wavCompare, frameSizeMs, searchRadius, countFrame, out frameSize);

                        break;
                    }
                case "Autocorrelation":
                    {
                        int searchRadius = (int)numSizeFilterAutocor.Value;
                        int countFrame = (int)numCountFrameAutocor.Value;
                        int frameSizeMs = (int)numFrameSizeAutocor.Value;
                        int windowSizeMs = (int)numWindowSizeAutocor.Value;

                        int frameSize = 0;

                        resultEtalon = Autocorrelation(wavEtalon, windowSizeMs, frameSizeMs, countFrame, searchRadius, out frameSize);

                        resultCompare = Autocorrelation(wavCompare, windowSizeMs, frameSizeMs, countFrame, searchRadius, out frameSize);

                        break;
                    }
                default: break;
            }

            CompareTwoResults(resultEtalon, resultCompare);
        }

        private void CompareTwoResults(int[] resultOne, int[] resultTwo)
        {
            List<Point> SectionsOne = new List<Point>();

            List<Point> SectionsTwo = new List<Point>();

            Point tempOne = new Point(0, 0);

            Point tempTwo = new Point(0, 0);

            List<Tuple<Point, double>> trueSections = new List<Tuple<Point, double>>();

            List<Tuple<Point, double>> falseSections = new List<Tuple<Point, double>>();

            double threshold = 40;

            for (int num_frame = 0; num_frame < resultOne.Length - 1; num_frame++)
            {
                if (resultOne[num_frame] == 0 && resultOne[num_frame + 1] == 1)
                {
                    tempOne.X = num_frame + 1;
                }

                if (resultOne[num_frame] == 1 && resultOne[num_frame + 1] == 0)
                {
                    tempOne.Y = num_frame;

                    SectionsOne.Add(tempOne);
                }

                if (resultTwo[num_frame] == 0 && resultTwo[num_frame + 1] == 1)
                {
                    tempTwo.X = num_frame + 1;
                }

                if (resultTwo[num_frame] == 1 && resultTwo[num_frame + 1] == 0)
                {
                    tempTwo.Y = num_frame;

                    SectionsTwo.Add(tempTwo);
                }
            }

            for (int i = 0; i < SectionsOne.Count; i++)
            {
                for (int j = 0; j < SectionsTwo.Count; j++)
                {
                    double deviation = Math.Abs(SectionsTwo[j].X - SectionsOne[i].X) +
                        Math.Abs(SectionsTwo[j].Y - SectionsOne[i].Y);

                    deviation /= SectionsOne[i].X + SectionsOne[i].Y;

                    deviation = deviation * 100;

                    if (deviation < threshold)
                    {
                        double countOnesInSectionOne = SectionsOne[i].Y - SectionsOne[i].X;

                        double countOnesInSectionTwo = SectionsTwo[j].Y - SectionsTwo[j].X;

                        double deviationCountsTwoSections = Math.Abs(countOnesInSectionTwo - countOnesInSectionOne) * 100 / countOnesInSectionOne;

                        if (deviationCountsTwoSections < threshold)
                            trueSections.Add(new Tuple<Point, double>(SectionsTwo[j], deviation));
                        else
                            falseSections.Add(new Tuple<Point, double>(SectionsTwo[j], deviation));
                    }
                    else
                        falseSections.Add(new Tuple<Point, double>(SectionsTwo[j], deviation));
                }
            }

            double meanTrueSections = 0;

            for (int i = 0; i < trueSections.Count; i++)
                meanTrueSections += trueSections[i].Item2;

            meanTrueSections /= trueSections.Count;

            string textResult = $"Правильно обнаруженых событий: {trueSections.Count}\n";
            textResult += $"Ложно обнаруженных событий: {falseSections.Count}\n";
            textResult += $"Среднее отклонение правильно обнаруженных событий: {meanTrueSections.ToString("0.####")}%";

            MessageBox.Show(textResult);
        }
    }
}