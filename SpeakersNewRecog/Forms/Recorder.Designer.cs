namespace SpeakersNewRecog
{
    partial class Recorder
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblTime = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnRec = new System.Windows.Forms.Button();
            this.lblLevel = new System.Windows.Forms.Label();
            this.lblCombo = new System.Windows.Forms.Label();
            this.cmbDevice = new System.Windows.Forms.ComboBox();
            this.panelLevel1 = new System.Windows.Forms.Panel();
            this.panelLevel2 = new System.Windows.Forms.Panel();
            this.lblFileName = new System.Windows.Forms.Label();
            this.txbFileName = new System.Windows.Forms.TextBox();
            this.volTimer = new System.Windows.Forms.Timer(this.components);
            this.lblDurability = new System.Windows.Forms.Label();
            this.numDurability = new System.Windows.Forms.NumericUpDown();
            this.lblChannels = new System.Windows.Forms.Label();
            this.cmbChannels = new System.Windows.Forms.ComboBox();
            this.panelLevel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDurability)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTime.Location = new System.Drawing.Point(13, 198);
            this.lblTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(144, 31);
            this.lblTime.TabIndex = 15;
            this.lblTime.Text = "00:00:000";
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(175, 166);
            this.btnStop.Margin = new System.Windows.Forms.Padding(4);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(152, 28);
            this.btnStop.TabIndex = 14;
            this.btnStop.Text = "Стоп";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnRec
            // 
            this.btnRec.Location = new System.Drawing.Point(12, 166);
            this.btnRec.Margin = new System.Windows.Forms.Padding(4);
            this.btnRec.Name = "btnRec";
            this.btnRec.Size = new System.Drawing.Size(156, 28);
            this.btnRec.TabIndex = 13;
            this.btnRec.Text = "Запись";
            this.btnRec.UseVisualStyleBackColor = true;
            this.btnRec.Click += new System.EventHandler(this.btnRec_Click);
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.Location = new System.Drawing.Point(9, 116);
            this.lblLevel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(123, 17);
            this.lblLevel.TabIndex = 12;
            this.lblLevel.Text = "Уровень сигнала:";
            // 
            // lblCombo
            // 
            this.lblCombo.AutoSize = true;
            this.lblCombo.Location = new System.Drawing.Point(12, 58);
            this.lblCombo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCombo.Name = "lblCombo";
            this.lblCombo.Size = new System.Drawing.Size(156, 17);
            this.lblCombo.TabIndex = 11;
            this.lblCombo.Text = "Выберите устройство:";
            // 
            // cmbDevice
            // 
            this.cmbDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDevice.FormattingEnabled = true;
            this.cmbDevice.Location = new System.Drawing.Point(13, 79);
            this.cmbDevice.Margin = new System.Windows.Forms.Padding(4);
            this.cmbDevice.Name = "cmbDevice";
            this.cmbDevice.Size = new System.Drawing.Size(506, 24);
            this.cmbDevice.TabIndex = 10;
            this.cmbDevice.SelectedIndexChanged += new System.EventHandler(this.cmbDevice_SelectedIndexChanged);
            // 
            // panelLevel1
            // 
            this.panelLevel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLevel1.Controls.Add(this.panelLevel2);
            this.panelLevel1.Location = new System.Drawing.Point(12, 138);
            this.panelLevel1.Margin = new System.Windows.Forms.Padding(4);
            this.panelLevel1.Name = "panelLevel1";
            this.panelLevel1.Size = new System.Drawing.Size(266, 20);
            this.panelLevel1.TabIndex = 9;
            // 
            // panelLevel2
            // 
            this.panelLevel2.BackColor = System.Drawing.Color.LimeGreen;
            this.panelLevel2.Location = new System.Drawing.Point(-1, -1);
            this.panelLevel2.Margin = new System.Windows.Forms.Padding(4);
            this.panelLevel2.Name = "panelLevel2";
            this.panelLevel2.Size = new System.Drawing.Size(267, 21);
            this.panelLevel2.TabIndex = 2;
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(12, 13);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(143, 17);
            this.lblFileName.TabIndex = 16;
            this.lblFileName.Text = "Введите имя файла:";
            // 
            // txbFileName
            // 
            this.txbFileName.Location = new System.Drawing.Point(12, 33);
            this.txbFileName.Name = "txbFileName";
            this.txbFileName.Size = new System.Drawing.Size(191, 22);
            this.txbFileName.TabIndex = 17;
            this.txbFileName.TextChanged += new System.EventHandler(this.txbFileName_TextChanged);
            // 
            // volTimer
            // 
            this.volTimer.Enabled = true;
            this.volTimer.Tick += new System.EventHandler(this.volTimer_Tick);
            // 
            // lblDurability
            // 
            this.lblDurability.AutoSize = true;
            this.lblDurability.Location = new System.Drawing.Point(206, 13);
            this.lblDurability.Name = "lblDurability";
            this.lblDurability.Size = new System.Drawing.Size(146, 17);
            this.lblDurability.TabIndex = 18;
            this.lblDurability.Text = "Длительность (сек.):";
            // 
            // numDurability
            // 
            this.numDurability.Location = new System.Drawing.Point(209, 33);
            this.numDurability.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.numDurability.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDurability.Name = "numDurability";
            this.numDurability.Size = new System.Drawing.Size(111, 22);
            this.numDurability.TabIndex = 19;
            this.numDurability.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numDurability.ValueChanged += new System.EventHandler(this.numDurability_ValueChanged);
            // 
            // lblChannels
            // 
            this.lblChannels.AutoSize = true;
            this.lblChannels.Location = new System.Drawing.Point(358, 13);
            this.lblChannels.Name = "lblChannels";
            this.lblChannels.Size = new System.Drawing.Size(115, 17);
            this.lblChannels.TabIndex = 20;
            this.lblChannels.Text = "Кол-во каналов:";
            // 
            // cmbChannels
            // 
            this.cmbChannels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChannels.FormattingEnabled = true;
            this.cmbChannels.Location = new System.Drawing.Point(361, 34);
            this.cmbChannels.Margin = new System.Windows.Forms.Padding(4);
            this.cmbChannels.Name = "cmbChannels";
            this.cmbChannels.Size = new System.Drawing.Size(158, 24);
            this.cmbChannels.TabIndex = 21;
            this.cmbChannels.SelectedIndexChanged += new System.EventHandler(this.cmbChannels_SelectedIndexChanged);
            // 
            // Recorder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 254);
            this.Controls.Add(this.cmbChannels);
            this.Controls.Add(this.lblChannels);
            this.Controls.Add(this.numDurability);
            this.Controls.Add(this.lblDurability);
            this.Controls.Add(this.txbFileName);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnRec);
            this.Controls.Add(this.lblLevel);
            this.Controls.Add(this.lblCombo);
            this.Controls.Add(this.cmbDevice);
            this.Controls.Add(this.panelLevel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Recorder";
            this.Text = "Диктофон";
            this.Load += new System.EventHandler(this.Recorder_Load);
            this.panelLevel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numDurability)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnRec;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.Label lblCombo;
        private System.Windows.Forms.ComboBox cmbDevice;
        private System.Windows.Forms.Panel panelLevel1;
        private System.Windows.Forms.Panel panelLevel2;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.TextBox txbFileName;
        private System.Windows.Forms.Timer volTimer;
        private System.Windows.Forms.Label lblDurability;
        private System.Windows.Forms.NumericUpDown numDurability;
        private System.Windows.Forms.Label lblChannels;
        private System.Windows.Forms.ComboBox cmbChannels;
    }
}

