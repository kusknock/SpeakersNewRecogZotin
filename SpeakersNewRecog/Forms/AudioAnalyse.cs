using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpeakersNewRecog.Classes;
using System.IO;
using System.Numerics;
using System.Windows.Forms.DataVisualization.Charting;
using System.Diagnostics;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace SpeakersNewRecog
{
    public partial class AudioAnalyse : Form
    {
        /// <summary>
        /// (+ теория обработки сигналов)
        /// LPC
        /// MFCC - LPC
        /// MWFCC - Mel-wavelets frequency cepstrum coefficients (исследовать \ сравнить с MFCC)
        /// ------
        /// GMM (+UBM) (добавить из Accord.NET)
        /// Обработка базы обучения циклично (форма тестирования: получать список файлов, показывать графики mfcc)
        /// ------
        /// Multilayer Perceptron
        /// Форма k-means (уменьшение размерности вектора)
        /// ------
        /// Эксперименты
        /// a. Mfcc
        /// b. Mfcc+d
        /// c. Mfcc+d+dd
        /// d. Mfcc+CMN+CVN
        /// e. Mfcc+CMN+CVN+d+dd
        /// f. Mfcc+Lpc
        /// g. With pre-emphasis
        /// h. Without pre-emphasis
        /// i. Менять размер перекрытия
        /// -------
        /// Методы оценки характеристик
        /// -------
        /// </summary>

        WaveReader waveAnalyse; // данные файла (.wav)

        WaveReader cleanWaveAnalyse; // чистые данные файла (.wav)

        Preemphasis analyseProcess; // первый этап (предварительная обработка)

        Overlapping overlapProcess; // второй этап (перекрывающиеся кадры)

        DiscreteTransform transformProcess; // третий этап (дискретное преобразование «Фурье»)

        Mfcc mfccProcess; // четвертый этап (вычисление мел-частотных кепстральных коэффициентов)

        // TODO: 
        // LPC - признаки 

        public AudioAnalyse()
        {
            InitializeComponent();
        }

        private void AudioAnalyse_Load(object sender, EventArgs e)
        {
            cmbNoise.SelectedIndex = 0;

            cmbFilter.SelectedIndex = 0;

            cmbTypeTransform.SelectedIndex = 0;

            cmbMfcc.SelectedIndex = 0;
        }

        #region Интерфейс

        private void btnOpen_Click(object sender, EventArgs e) // открытие файла 
        {
            string path = string.Empty;

            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "WAV file *.wav|*.wav",
                Title = "Open WAV"
            };


            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            path = ofd.FileName;

            LoadWaveFile(path);

            groupProccesSignal.Enabled = true;
            groupNoise.Enabled = true;
            groupDiscreteTransform.Enabled = true;
            groupFourier.Enabled = true;
            groupStatistic.Enabled = true;
        }

        private void btnRecorder_Click(object sender, EventArgs e) // форма диктофона 
        {
            Recorder recorder = new Recorder();

            recorder.Show();
        }

        private void btnMixForm_Click(object sender, EventArgs e) // форма микширования
        {
            Mixer mix = new Mixer();

            Visible = false;

            if (mix.ShowDialog() == DialogResult.OK)
                Visible = true;
        }

        private void btnExit_Click(object sender, EventArgs e) // выход 
        {
            Close();
        }

        private void LoadWaveFile(string path) // функция загрузки wav-файла 
        {
            statusStrip.Items.Clear();

            waveAnalyse = new WaveReader(path);

            cleanWaveAnalyse = new WaveReader(path);

            int sampleRate = waveAnalyse.Format.SampleRate;
            int channels = waveAnalyse.Format.Channels;
            int bits = waveAnalyse.Format.BitsPerSample;
            int duration = waveAnalyse.Format.Duration;
            string name = Path.GetFileName(waveAnalyse.Format.Path);

            string status = string.Format("Имя файла: {4}, Частота дискретизации: {0}, Каналов: {1}, Бит: {2}, Длительность: {3} сек.",
                sampleRate, channels, bits, duration, name);

            ToolStripLabel infoLabel = new ToolStripLabel() { Text = status };

            statusStrip.Items.Add(infoLabel);

            // добавление элемента в comboBox с названием графика
            cmbPlot.Items.Clear();
            cmbPlot.Items.Add("Амплитуды до обработки");
            cmbPlot.Items.Add("Амплитуды чистого файла");
            cmbPlot.SelectedIndex = 0;
        }

        private void DrawGraph(double[] amplitudes) // функция отрисовки графика 
        {
            graphChart.Series.Clear();

            string graphName = "FastLine";

            double maxValue = amplitudes.Max(); // максимальное значение для нормализации графика

            graphChart.Series.Add(graphName);
            graphChart.Series[graphName].ChartType = SeriesChartType.FastLine;
            graphChart.Series[graphName].Color = Color.Green;
            graphChart.Series[graphName].ChartArea = "Area";

            for (int index = 0; index < amplitudes.Length; index++)
                graphChart.Series[graphName].Points.Add(amplitudes[index] / maxValue); // нормализация для корректного отображения на графике

        }

        private void DrawGraphFeatures(double[][] array) // функция отрисовки графика признаков 
        {
            graphChart.Series.Clear();

            string graphName = "FastLine";

            for (int line = 0; line < array.Length; line++)
            {
                graphName = string.Format($"{graphName}_{line}");
                graphChart.Series.Add(graphName);
                graphChart.Series[graphName].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
                graphChart.Series[graphName].ChartArea = "Area";

                for (int index = 0; index < array[0].Length; index++)
                    graphChart.Series[graphName].Points.Add(array[line][index]);
            }
        }

        private void cmbPlot_SelectedIndexChanged(object sender, EventArgs e) // переключение графиков
        {
            switch (cmbPlot.Text)
            {
                case "Амплитуды чистого файла":
                    DrawGraph((double[])cleanWaveAnalyse.Amplitudes.Clone()); // отрисовка графика до обработки
                    break;
                case "Амплитуды до обработки":
                    DrawGraph((double[])waveAnalyse.Amplitudes.Clone()); // отрисовка графика до обработки
                    break;
                case "Амплитуды после обработки":
                    DrawGraph((double[])analyseProcess.Wav.Amplitudes.Clone()); // отрисовка графика после обработки
                    break;
                case "Магнитуды сигнала":
                    DrawGraph(ToOneDimension(transformProcess.Fourier, "complex")); // отрисовка графика магнитуд спектра
                    break;
                case "Спектр сигнала":
                    DrawGraph(ToOneDimension(transformProcess.Spectre, "double")); // отрисовка графика спектра
                    break;
                case "Признаки MFCC":
                    DrawGraphFeatures(mfccProcess.WithoutEnergyFeatures); // отрисовка графика признаков
                    break;
                default: break;
            }
        }

        #endregion

        #region Шум

        private void cmbNoise_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbNoise.Text)
            {
                case "Импульсный":
                    numPercentDeviation.Enabled = true;
                    rbGauss.Checked = true;
                    rbLinear.Enabled = false;
                    break;
                case "Аддитивный":
                    rbLinear.Enabled = true;
                    numPercentDeviation.Enabled = false;
                    break;
                case "Мультипликативный":
                    rbLinear.Enabled = true;
                    numPercentDeviation.Enabled = false;
                    break;
                default: throw new Exception("invalid noise type");
            }
        }

        private void btnNoise_Click(object sender, EventArgs e) // добавить шум
        {
            // добавление шума
            waveAnalyse.AddNoise(cmbNoise.Text, (int)numPercentNoise.Value, rbGauss.Checked,
                (double)numSigma.Value, (double)numPercentDeviation.Value,
                (double)numDevPlus.Value, (double)numDevMinus.Value);

            // отрисовка графика
            DrawGraph(waveAnalyse.Amplitudes);

            // активация кнопки сохранения
            btnSaveNoise.Enabled = true;
        }

        private void btnSaveNoise_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "WAV file *.wav|*.wav",
                Title = "Save WAV"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                // сохранение файла с шумом с новым именем
                waveAnalyse.Save(sfd.FileName, false);

                // деактивация кнопки сохранения
                btnSaveNoise.Enabled = false;
            }
        }

        private void rbGauss_CheckedChanged(object sender, EventArgs e)
        {
            numSigma.Enabled = true;
            numDevMinus.Enabled = false;
            numDevPlus.Enabled = false;
        }

        private void rbLinear_CheckedChanged(object sender, EventArgs e)
        {
            numSigma.Enabled = false;
            numDevMinus.Enabled = true;
            numDevPlus.Enabled = true;
        }

        #endregion

        #region Предварительная обработка

        private void EnabledProcessParameters(int type) // функция для вкл/выкл компонент параметров предварительной обработки 
        {
            switch (type)
            {
                case 0:
                    numProcess1.Enabled = false;
                    numProcess2.Enabled = false;
                    break;
                case 1:
                    numProcess1.Enabled = true;
                    numProcess2.Enabled = false;
                    break;
                case 2:
                    numProcess1.Enabled = true;
                    numProcess2.Enabled = true;
                    break;
                default: break;
            }
        }

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e) // выбор и переключение фильтров
        {
            switch (cmbFilter.SelectedIndex)
            {
                case 2:
                case 3:
                case 6:
                case 7:
                case 10:
                    EnabledProcessParameters(2);
                    break;
                case 0:
                case 1:
                case 4:
                case 5:
                case 8:
                    EnabledProcessParameters(1);
                    break;
                case 9:
                    EnabledProcessParameters(0);
                    break;
                default: break;
            }
        }

        private void btnPreemphasis_Click(object sender, EventArgs e) // кнопка запуска процесса предобработки
        {
            try
            {
                analyseProcess = new Preemphasis(waveAnalyse.Format.Path);

                // обработка
                analyseProcess.Process(cmbFilter.Text, (double)numProcess1.Value, (double)numProcess2.Value);

                // проверка на существование элементов
                int findedItems = cmbPlot.FindStringExact("Амплитуды после обработки");

                // добавление элемента графика после обработки
                if (findedItems == -1)
                    cmbPlot.Items.Add("Амплитуды после обработки");

                // активация кнопки сохранения после обработки
                btnSaveProcess.Enabled = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSaveProcess_Click(object sender, EventArgs e) // сохранение файла после обработки
        {
            SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "WAV file *.wav|*.wav",
                Title = "Save WAV"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                // сохранение файла после обработки
                analyseProcess.Wav.Save(sfd.FileName, false);

                // деактивация кнопки сохранения
                btnSaveProcess.Enabled = false;
            }
        }

        #endregion

        #region Метрики

        private void btnCalcMetric_Click(object sender, EventArgs e)
        {
            WaveReader wr1 = null, wr2 = null;

            if(rbNoise.Checked)
            {
                wr1 = cleanWaveAnalyse;
                wr2 = waveAnalyse;
            }
            else if(rbPreemphasis.Checked)
            {
                wr1 = cleanWaveAnalyse;
                wr2 = analyseProcess.Wav;
            }
            else if(rbOtherSignal.Checked)
            {
                wr1 = cleanWaveAnalyse;
                wr2 = new WaveReader(txbOtherMetricSignal.Text);
            }

            listMetrics.Items.Clear();
            listMetrics.Items.Add(string.Format($"Имя файла 1: {Path.GetFileName(wr1.Format.Path)}"));
            listMetrics.Items.Add(string.Format($"Имя файла 2: {Path.GetFileName(wr2.Format.Path)}"));

            // -------------- РАСЧЕТ МЕТРИК ------------

            if (!checkDistance.Checked)
            {
                int width = wr1.Amplitudes.Length > wr2.Amplitudes.Length ? wr2.Amplitudes.Length : wr1.Amplitudes.Length;

                double mse = 0, snr = 0;

                double summ = 0;

                for (int j = 0; j < width; j++)
                {
                    mse += Math.Pow(wr1.Amplitudes[j] - wr2.Amplitudes[j], 2);

                    summ += Math.Pow(wr1.Amplitudes[j], 2);
                }

                snr = 10 * Math.Log(summ / mse, 10);

                listMetrics.Items.Add(string.Format($"MSE: {mse}"));
                listMetrics.Items.Add(string.Format($"SNR: {snr}"));
            }

            // -------------- РАСЧЕТ РАССТОЯНИЙ ------------

            if (checkDistance.Checked)
            {
                double[][] f1 = GetFeatures(wr1);
                double[][] f2 = GetFeatures(wr2);

                List<double> test1 = new List<double>();
                List<double> test2 = new List<double>();

                for (int i = 0; i < f1.Length; i++)
                {
                    for (int j = 0; j < f1[0].Length; j++)
                        test1.Add(f1[i][j]);
                }

                for (int i = 0; i < f2.Length; i++)
                {
                    for (int j = 0; j < f2[0].Length; j++)
                        test2.Add(f2[i][j]);
                }

                double[] t1 = test1.ToArray();
                double[] t2 = test2.ToArray();

                double distanceDtw1 = Distance.calcDistance(t1, t1.Length, t2, t2.Length);

                double buffer = 0;

                test1.Clear();
                test2.Clear();

                for (int i = 0; i < f1[0].Length; i++)
                {
                    for (int j = 0; j < f1.Length; j++)
                        buffer += f1[j][i];

                    test1.Add(buffer / f1[0].Length);

                    buffer = 0;
                }

                for (int i = 0; i < f2[0].Length; i++)
                {
                    for (int j = 0; j < f2.Length; j++)
                        buffer += f2[j][i];

                    test2.Add(buffer / f2[0].Length);

                    buffer = 0;
                }

                t1 = test1.ToArray();
                t2 = test2.ToArray();

                double distanceDtw2 = Distance.calcDistance(t1, t1.Length, t2, t2.Length);
                double distanceEuqlid = Distance.GetDistanceEuqlid(t1, t2);
                double distanceChebyshev = Distance.GetDistanceChebyshev(t1, t2);

                listMetrics.Items.Add(string.Format($"DTW (для всего файла): {distanceDtw1}"));
                listMetrics.Items.Add(string.Format($"DTW (средний вектор): {distanceDtw2}"));
                listMetrics.Items.Add(string.Format($"Евклид: {distanceEuqlid}"));
                listMetrics.Items.Add(string.Format($"Чебышев: {distanceChebyshev}"));
            }
        }

        private void rbPreemphasis_CheckedChanged(object sender, EventArgs e)
        {
            if (analyseProcess == null && rbPreemphasis.Checked)
            {
                MessageBox.Show("Сигнал не обработан");
                rbPreemphasis.Checked = false;
            }
        }

        private void rbOtherSignal_CheckedChanged(object sender, EventArgs e)
        {
            if (rbOtherSignal.Checked)
            {
                txbOtherMetricSignal.Enabled = true;
                btnOtherMetricSignal.Enabled = true;
            }
            else
            {
                txbOtherMetricSignal.Enabled = false;
                btnOtherMetricSignal.Enabled = false;
            }
        }

        private void btnOtherMetricSignal_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "Wav file *.wav|*.wav",
                Title = "Open Wav"
            };

            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            txbOtherMetricSignal.Text = ofd.FileName;
        }

        private double[][] GetFeatures(WaveReader wr) // извлечение признаков из файла (поэтапно)
        {
            try
            {
                Mfcc mfccProcess = null; // инициализация класса извлечения признаков

                // открытие wav-файла (первый этап)
                var waveAnalyse = wr;

                // частота дискретизации
                int s_rate = waveAnalyse.Format.SampleRate;

                // второй этап (предварительная обработка) будет вынесен отдельно

                int frameSize = (int)numWindowSize.Value; // размер окна в миллисекундах
                int frameShift = (int)numWindowShift.Value; // размер перекрытия в миллисекундах
                int durabilitiSize = (int)numBuffer.Value; // длительность файла в секундах, в пределах которой будет осуществляться перекрытие

                // инициализация и процесс дискретное преобразование (третий этап)
                var transformProcess = new DiscreteTransform(new Overlapping(waveAnalyse, frameSize, frameShift));
                transformProcess.Process(DiscreteTransform.TransformType.InFrequency);

                double[][] spectrum = (double[][])transformProcess.Spectre.Clone(); // спектр частот сигнала

                int num_c = (int)numCoefficients.Value; // количество коэффициентов
                int num_f = (int)numFilters.Value; // количество фильтров

                int min_f = (int)numLowFrequency.Value; // минимальная частота
                int max_f = (int)numUpFrequency.Value; // максимальная частота

                bool energy = checkEnergy.Checked; // первый коэффициент (энергия)
                bool delta = rbDelta.Checked; // дельта коэффициенты
                bool delta2 = rbDeltaDelta.Checked; // двойные дельта коэффициенты
                bool cvmn = checkCvmn.Checked; // нормализация мел-кепстров

                // извлечение признаков (четвертый этап), выбор алгоритма
                // выбор реализации выделения векторов-признаков (Accord / SpeakersNewRecog)
                if (cmbMfcc.Text == "SpeakersNewRecog")
                    mfccProcess = new Mfcc(spectrum, num_c, num_f, s_rate, min_f, max_f, cvmn, energy, delta, delta2);
                else if (cmbMfcc.Text == "Accord.NET") // для данной реализации не работает размер буффера, только перекрытие
                    mfccProcess = new Mfcc(waveAnalyse.SourceSignal, num_c, num_f, s_rate, frameSize, frameShift, min_f, max_f, cvmn, energy, delta, delta2);

                // возврат значений в зависимости от выбора пользователя

                if (delta) return mfccProcess.DeltaFeatures;

                else if (delta2) return mfccProcess.Delta2Features;

                else if (energy) return mfccProcess.Features;

                return mfccProcess.WithoutEnergyFeatures;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        #endregion 

        #region Дискретные преобразования

        private double[] ToOneDimension(object obj, string typeObject) // преобразование в одномерный массив для графика
        {
            double[] buffer = null;

            int b = 0;

            if (typeObject == "double")
            {
                double[][] obj2d = (double[][])obj;

                buffer = new double[obj2d.Length * obj2d[0].Length];

                for (int i = 0; i < obj2d.Length; i++)
                    for (int j = 0; j < obj2d[0].Length; j++, b++)
                        buffer[b] = obj2d[i][j];
            }
            else if (typeObject == "complex")
            {
                Complex[][] obj2d = (Complex[][])obj;

                buffer = new double[obj2d.Length * obj2d[0].Length];

                for (int i = 0; i < obj2d.Length; i++)
                    for (int j = 0; j < obj2d[0].Length; j++, b++)
                        buffer[b] = obj2d[i][j].Magnitude;
            }

            return buffer;
        }

        private void btnFourier_Click(object sender, EventArgs e) // нарезка сигнала с перекрытием и преобразование Фурье
        {
            int frameSize = (int)numWindowSize.Value; // размер окна в миллисекундах
            int frameShift = (int)numWindowShift.Value; // размер перекрытия в миллисекундах
            int durabilitiSize = (int)numBuffer.Value; // длительность файла в секундах, в пределах которой будет осуществляться перекрытие

            WaveReader tempWave; // временный объект wav-файла

            // условие существования файла для обработки
            if (analyseProcess != null) tempWave = analyseProcess.Wav;
            else tempWave = waveAnalyse;

            // преобразование сигнала в массив перекрывающихся фреймов
            overlapProcess = new Overlapping(tempWave, frameSize, frameShift, durabilitiSize);

            // инициализация объекта дискретного преобразования
            transformProcess = new DiscreteTransform(overlapProcess);

            // тип преобразования (по времени, по частоте)
            var type = (DiscreteTransform.TransformType)(cmbTypeTransform.SelectedIndex + 1);

            transformProcess.Process(type); // преобразование Фурье массива фреймов

            groupMel.Enabled = true; // активация группы элементов mfcc
            cmbMfcc.SelectedIndex = 1; // по умолчанию реализация SpeakerNewRecog

            // проверка на существование элементов
            int findedItems = cmbPlot.FindStringExact("Магнитуды сигнала") + cmbPlot.FindStringExact("Спектр сигнала");

            // добавление новых объектов для отрисовки
            if (findedItems == -2)
            {
                cmbPlot.Items.Add("Магнитуды сигнала");
                cmbPlot.Items.Add("Спектр сигнала");
            }
        }

        #endregion

        #region Признаки Mfcc

        private void btnMel_Click(object sender, EventArgs e)
        {
            int num_c = (int)numCoefficients.Value; // количество коэффициентов
            int num_f = (int)numFilters.Value; // количество фильтров
            int s_rate = waveAnalyse.Format.SampleRate; // частота дискретизации

            int frameSize = (int)numWindowSize.Value; // размер окна в миллисекундах
            int frameShift = (int)numWindowShift.Value; // размер перекрытия в миллисекундах

            int min_f = (int)numLowFrequency.Value; // минимальная частота
            int max_f = (int)numUpFrequency.Value; // максимальная частота

            double[][] spectrum = (double[][])transformProcess.Spectre.Clone(); // спектр частот сигнала

            bool energy = checkEnergy.Checked; // первый коэффициент (энергия)
            bool delta = rbDelta.Checked; // дельта коэффициенты
            bool delta2 = rbDeltaDelta.Checked; // двойные дельта коэффициенты
            bool cvmn = checkCvmn.Checked; // нормализация мел-кепстров

            int durability = (int)numBuffer.Value; // в этой функции данная переменная только для Accord.NET

            // выбор реализации выделения векторов-признаков (Accord / SpeakersNewRecog)
            if (cmbMfcc.Text == "SpeakersNewRecog")
                mfccProcess = new Mfcc(spectrum, num_c, num_f, s_rate, min_f, max_f, cvmn, energy, delta, delta2);
            else if (cmbMfcc.Text == "Accord.NET") // для данной реализации не работает размер буффера, только перекрытие
                mfccProcess = new Mfcc(waveAnalyse.SourceSignal, num_c, num_f, s_rate, frameSize, frameShift, min_f, max_f, cvmn, energy, delta, delta2, durability);

            // проверка на существование элементов
            int findedItems = cmbPlot.FindStringExact("Признаки MFCC");

            // добавление новых объектов для отрисовки
            if (findedItems == -1)
                cmbPlot.Items.Add("Признаки MFCC");
        }



        #endregion

        
    }
}
