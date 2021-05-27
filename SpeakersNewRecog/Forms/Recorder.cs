using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpeakersNewRecog
{
    public partial class Recorder : Form
    {
        /// <summary>
        /// TODO:
        /// Навести здесь порядок
        /// </summary>

        string dirName = string.Format($@"{Environment.CurrentDirectory}\Wav\");
        string wavFileName = string.Empty;
        int volume;

        bool record = false;

        WaveInEvent waveIn;
        WaveFileWriter waveFile;

        int durability;

        DateTime timer;

        public Recorder()
        {
            InitializeComponent();
        }

        /************************METHODS VOICE RECORDER**********************/

        private void Recorder_Load(object sender, EventArgs e)
        {
            for (int waveInDevice = 0; waveInDevice < WaveIn.DeviceCount; waveInDevice++)
            {
                WaveInCapabilities deviceInfo = WaveIn.GetCapabilities(waveInDevice);
                cmbDevice.Items.Add(string.Format("Device {0}: {1}, {2} channels", waveInDevice, deviceInfo.ProductName, deviceInfo.Channels));
            }

            cmbDevice.SelectedIndex = cmbDevice.Items.Count - 1;

            durability = (int)numDurability.Value;
        }

        private void numDurability_ValueChanged(object sender, EventArgs e)
        {
            durability = (int)numDurability.Value;
        }

        private void txbFileName_TextChanged(object sender, EventArgs e)
        {
            if (!Directory.Exists(dirName)) { Directory.CreateDirectory(dirName); }

            wavFileName = string.Format($@"{dirName}\{txbFileName.Text}.wav");
        }

        private void volTimer_Tick(object sender, EventArgs e)
        {
            panelLevel2.Size = new Size(volume, panelLevel1.Size.Height);

            if (record == true)
            {
                timer = timer.AddMilliseconds(100);
                lblTime.Text = timer.ToString("mm:ss:fff");
            }
        }

        private void wave_DataAvailable(object sender, WaveInEventArgs e)
        {
            long maxFileLength = waveIn.WaveFormat.AverageBytesPerSecond * durability;

            if (record == true)
            {
                int toWrite = (int)Math.Min(maxFileLength - waveFile.Length, e.BytesRecorded);
                if (toWrite > 0)
                {
                    waveFile.Write(e.Buffer, 0, e.BytesRecorded);
                    waveFile.Flush();
                }
                else Invoke(new MethodInvoker(btnStop.PerformClick));
            }

            for (int i = 0; i < e.BytesRecorded; i += 2)
            {
                short sample = (short)((e.Buffer[i + 1] << 8) | e.Buffer[i]);
                double amplitude = sample / 32768f;
                double level = Math.Abs(amplitude);
                volume = (int)(Math.Round(level * 1000) > 200 ? 200 : Math.Round(level * 2000));
            }
        }

        private void btnRec_Click(object sender, EventArgs e)
        {
            try
            {
                waveFile = new WaveFileWriter(wavFileName, waveIn.WaveFormat);

                record = true;

                btnRec.Enabled = false;

                btnStop.Enabled = true;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            record = false;

            lblTime.Text = "00:00:000";

            timer = new DateTime();

            btnRec.Enabled = true;

            btnStop.Enabled = false;

            if (waveFile != null)
            {
                waveFile.Dispose();
                waveFile = null;
            }
        }

        private void cmbDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbChannels.Items.Clear();

            for (int i = 1; i <= WaveIn.GetCapabilities(cmbDevice.SelectedIndex).Channels; i++)
                cmbChannels.Items.Add(i.ToString());

            cmbChannels.SelectedIndex = 0;
        }

        private void cmbChannels_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (waveIn != null)
                {
                    waveIn.Dispose();
                    waveIn = null;
                }
                waveIn = new WaveInEvent();
                waveIn.DeviceNumber = cmbDevice.SelectedIndex;
                waveIn.DataAvailable += wave_DataAvailable;
                waveIn.WaveFormat = new WaveFormat(16000, Convert.ToInt32(cmbChannels.Text));
                waveIn.StartRecording();
            }
            catch (NAudio.MmException ex)
            {
                MessageBox.Show(ex.Message);
                cmbDevice.SelectedIndex = 0;
            }
        }


        /********************************************************************/
    }
}
