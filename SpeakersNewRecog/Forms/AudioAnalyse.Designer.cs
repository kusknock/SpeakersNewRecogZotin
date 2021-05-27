namespace SpeakersNewRecog
{
    partial class AudioAnalyse
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.btnFile = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRecorder = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExit = new System.Windows.Forms.ToolStripMenuItem();
            this.btnHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.cmbPlot = new System.Windows.Forms.ComboBox();
            this.graphChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabFeatures = new System.Windows.Forms.TabPage();
            this.groupDiscreteTransform = new System.Windows.Forms.GroupBox();
            this.numBuffer = new System.Windows.Forms.NumericUpDown();
            this.lblBuffer = new System.Windows.Forms.Label();
            this.numWindowSize = new System.Windows.Forms.NumericUpDown();
            this.groupFourier = new System.Windows.Forms.GroupBox();
            this.btnFourier = new System.Windows.Forms.Button();
            this.cmbTypeTransform = new System.Windows.Forms.ComboBox();
            this.lblWindowSize = new System.Windows.Forms.Label();
            this.numWindowShift = new System.Windows.Forms.NumericUpDown();
            this.lblWindowShift = new System.Windows.Forms.Label();
            this.groupMel = new System.Windows.Forms.GroupBox();
            this.numUpFrequency = new System.Windows.Forms.NumericUpDown();
            this.lblUpFrequency = new System.Windows.Forms.Label();
            this.numLowFrequency = new System.Windows.Forms.NumericUpDown();
            this.lblLowFrequency = new System.Windows.Forms.Label();
            this.numFilters = new System.Windows.Forms.NumericUpDown();
            this.lblNumFilter = new System.Windows.Forms.Label();
            this.cmbMfcc = new System.Windows.Forms.ComboBox();
            this.checkCvmn = new System.Windows.Forms.CheckBox();
            this.checkEnergy = new System.Windows.Forms.CheckBox();
            this.btnMel = new System.Windows.Forms.Button();
            this.rbDeltaDelta = new System.Windows.Forms.RadioButton();
            this.rbDelta = new System.Windows.Forms.RadioButton();
            this.lblNumCoefficients = new System.Windows.Forms.Label();
            this.numCoefficients = new System.Windows.Forms.NumericUpDown();
            this.groupLpc = new System.Windows.Forms.GroupBox();
            this.checkMel = new System.Windows.Forms.CheckBox();
            this.btnLpc = new System.Windows.Forms.Button();
            this.lblNumCoefficients1 = new System.Windows.Forms.Label();
            this.numCoefficients1 = new System.Windows.Forms.NumericUpDown();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupStatistic = new System.Windows.Forms.GroupBox();
            this.checkDistance = new System.Windows.Forms.CheckBox();
            this.btnOtherMetricSignal = new System.Windows.Forms.Button();
            this.rbOtherSignal = new System.Windows.Forms.RadioButton();
            this.txbOtherMetricSignal = new System.Windows.Forms.TextBox();
            this.btnCalcMetric = new System.Windows.Forms.Button();
            this.rbPreemphasis = new System.Windows.Forms.RadioButton();
            this.rbNoise = new System.Windows.Forms.RadioButton();
            this.listMetrics = new System.Windows.Forms.ListBox();
            this.groupNoise = new System.Windows.Forms.GroupBox();
            this.lblDevMinus = new System.Windows.Forms.Label();
            this.numDevMinus = new System.Windows.Forms.NumericUpDown();
            this.lblDevPlus = new System.Windows.Forms.Label();
            this.numDevPlus = new System.Windows.Forms.NumericUpDown();
            this.rbLinear = new System.Windows.Forms.RadioButton();
            this.rbGauss = new System.Windows.Forms.RadioButton();
            this.lblPercentDeviation = new System.Windows.Forms.Label();
            this.numPercentDeviation = new System.Windows.Forms.NumericUpDown();
            this.lblSigma = new System.Windows.Forms.Label();
            this.lblPercentNoise = new System.Windows.Forms.Label();
            this.numSigma = new System.Windows.Forms.NumericUpDown();
            this.btnSaveNoise = new System.Windows.Forms.Button();
            this.numPercentNoise = new System.Windows.Forms.NumericUpDown();
            this.btnNoise = new System.Windows.Forms.Button();
            this.cmbNoise = new System.Windows.Forms.ComboBox();
            this.groupProccesSignal = new System.Windows.Forms.GroupBox();
            this.btnSaveProcess = new System.Windows.Forms.Button();
            this.groupProcessParam = new System.Windows.Forms.GroupBox();
            this.numProcess2 = new System.Windows.Forms.NumericUpDown();
            this.numProcess1 = new System.Windows.Forms.NumericUpDown();
            this.cmbFilter = new System.Windows.Forms.ComboBox();
            this.btnPreemphasis = new System.Windows.Forms.Button();
            this.tabPreemphasis = new System.Windows.Forms.TabControl();
            this.btnMixForm = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.graphChart)).BeginInit();
            this.tabFeatures.SuspendLayout();
            this.groupDiscreteTransform.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBuffer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWindowSize)).BeginInit();
            this.groupFourier.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWindowShift)).BeginInit();
            this.groupMel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpFrequency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLowFrequency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFilters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCoefficients)).BeginInit();
            this.groupLpc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCoefficients1)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupStatistic.SuspendLayout();
            this.groupNoise.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDevMinus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDevPlus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPercentDeviation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSigma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPercentNoise)).BeginInit();
            this.groupProccesSignal.SuspendLayout();
            this.groupProcessParam.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numProcess2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numProcess1)).BeginInit();
            this.tabPreemphasis.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnFile,
            this.btnHelp});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(962, 28);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // btnFile
            // 
            this.btnFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOpen,
            this.btnMixForm,
            this.btnRecorder,
            this.btnExit});
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(57, 24);
            this.btnFile.Text = "Файл";
            // 
            // btnOpen
            // 
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(235, 26);
            this.btnOpen.Text = "Открыть";
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnRecorder
            // 
            this.btnRecorder.Name = "btnRecorder";
            this.btnRecorder.Size = new System.Drawing.Size(235, 26);
            this.btnRecorder.Text = "Записать";
            this.btnRecorder.Click += new System.EventHandler(this.btnRecorder_Click);
            // 
            // btnExit
            // 
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(235, 26);
            this.btnExit.Text = "Выход";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(79, 24);
            this.btnHelp.Text = "Справка";
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Location = new System.Drawing.Point(0, 801);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(962, 22);
            this.statusStrip.TabIndex = 4;
            this.statusStrip.Text = "statusStrip";
            // 
            // cmbPlot
            // 
            this.cmbPlot.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbPlot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPlot.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbPlot.FormattingEnabled = true;
            this.cmbPlot.Location = new System.Drawing.Point(0, 28);
            this.cmbPlot.Name = "cmbPlot";
            this.cmbPlot.Size = new System.Drawing.Size(962, 33);
            this.cmbPlot.TabIndex = 5;
            this.cmbPlot.SelectedIndexChanged += new System.EventHandler(this.cmbPlot_SelectedIndexChanged);
            // 
            // graphChart
            // 
            chartArea3.BackColor = System.Drawing.Color.White;
            chartArea3.Name = "Area";
            this.graphChart.ChartAreas.Add(chartArea3);
            this.graphChart.Dock = System.Windows.Forms.DockStyle.Top;
            this.graphChart.Location = new System.Drawing.Point(0, 61);
            this.graphChart.Name = "graphChart";
            this.graphChart.Size = new System.Drawing.Size(962, 238);
            this.graphChart.TabIndex = 1;
            this.graphChart.Text = "Графики";
            // 
            // tabFeatures
            // 
            this.tabFeatures.Controls.Add(this.groupDiscreteTransform);
            this.tabFeatures.Controls.Add(this.groupMel);
            this.tabFeatures.Controls.Add(this.groupLpc);
            this.tabFeatures.Location = new System.Drawing.Point(4, 25);
            this.tabFeatures.Name = "tabFeatures";
            this.tabFeatures.Padding = new System.Windows.Forms.Padding(3);
            this.tabFeatures.Size = new System.Drawing.Size(954, 450);
            this.tabFeatures.TabIndex = 2;
            this.tabFeatures.Text = "Признаки";
            this.tabFeatures.UseVisualStyleBackColor = true;
            // 
            // groupDiscreteTransform
            // 
            this.groupDiscreteTransform.Controls.Add(this.numBuffer);
            this.groupDiscreteTransform.Controls.Add(this.lblBuffer);
            this.groupDiscreteTransform.Controls.Add(this.numWindowSize);
            this.groupDiscreteTransform.Controls.Add(this.groupFourier);
            this.groupDiscreteTransform.Controls.Add(this.lblWindowSize);
            this.groupDiscreteTransform.Controls.Add(this.numWindowShift);
            this.groupDiscreteTransform.Controls.Add(this.lblWindowShift);
            this.groupDiscreteTransform.Enabled = false;
            this.groupDiscreteTransform.Location = new System.Drawing.Point(6, 6);
            this.groupDiscreteTransform.Name = "groupDiscreteTransform";
            this.groupDiscreteTransform.Size = new System.Drawing.Size(321, 218);
            this.groupDiscreteTransform.TabIndex = 13;
            this.groupDiscreteTransform.TabStop = false;
            this.groupDiscreteTransform.Text = "Дискретные преобразования";
            // 
            // numBuffer
            // 
            this.numBuffer.Location = new System.Drawing.Point(212, 76);
            this.numBuffer.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numBuffer.Name = "numBuffer";
            this.numBuffer.Size = new System.Drawing.Size(102, 22);
            this.numBuffer.TabIndex = 42;
            this.numBuffer.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // lblBuffer
            // 
            this.lblBuffer.AutoSize = true;
            this.lblBuffer.Location = new System.Drawing.Point(55, 78);
            this.lblBuffer.Name = "lblBuffer";
            this.lblBuffer.Size = new System.Drawing.Size(151, 17);
            this.lblBuffer.TabIndex = 43;
            this.lblBuffer.Text = "Размер буфера (сек):";
            // 
            // numWindowSize
            // 
            this.numWindowSize.Location = new System.Drawing.Point(212, 19);
            this.numWindowSize.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numWindowSize.Minimum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numWindowSize.Name = "numWindowSize";
            this.numWindowSize.Size = new System.Drawing.Size(102, 22);
            this.numWindowSize.TabIndex = 40;
            this.numWindowSize.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // groupFourier
            // 
            this.groupFourier.Controls.Add(this.btnFourier);
            this.groupFourier.Controls.Add(this.cmbTypeTransform);
            this.groupFourier.Enabled = false;
            this.groupFourier.Location = new System.Drawing.Point(5, 112);
            this.groupFourier.Name = "groupFourier";
            this.groupFourier.Size = new System.Drawing.Size(309, 95);
            this.groupFourier.TabIndex = 9;
            this.groupFourier.TabStop = false;
            this.groupFourier.Text = "Фурье";
            // 
            // btnFourier
            // 
            this.btnFourier.Location = new System.Drawing.Point(7, 49);
            this.btnFourier.Name = "btnFourier";
            this.btnFourier.Size = new System.Drawing.Size(296, 36);
            this.btnFourier.TabIndex = 4;
            this.btnFourier.Text = "Старт";
            this.btnFourier.UseVisualStyleBackColor = true;
            this.btnFourier.Click += new System.EventHandler(this.btnFourier_Click);
            // 
            // cmbTypeTransform
            // 
            this.cmbTypeTransform.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTypeTransform.FormattingEnabled = true;
            this.cmbTypeTransform.Items.AddRange(new object[] {
            "Прореживание по частоте",
            "Прореживание по времени"});
            this.cmbTypeTransform.Location = new System.Drawing.Point(7, 19);
            this.cmbTypeTransform.Name = "cmbTypeTransform";
            this.cmbTypeTransform.Size = new System.Drawing.Size(296, 24);
            this.cmbTypeTransform.TabIndex = 0;
            // 
            // lblWindowSize
            // 
            this.lblWindowSize.AutoSize = true;
            this.lblWindowSize.Location = new System.Drawing.Point(80, 21);
            this.lblWindowSize.Name = "lblWindowSize";
            this.lblWindowSize.Size = new System.Drawing.Size(126, 17);
            this.lblWindowSize.TabIndex = 41;
            this.lblWindowSize.Text = "Размер окна (мс):";
            // 
            // numWindowShift
            // 
            this.numWindowShift.Location = new System.Drawing.Point(212, 47);
            this.numWindowShift.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numWindowShift.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numWindowShift.Name = "numWindowShift";
            this.numWindowShift.Size = new System.Drawing.Size(102, 22);
            this.numWindowShift.TabIndex = 38;
            this.numWindowShift.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // lblWindowShift
            // 
            this.lblWindowShift.AutoSize = true;
            this.lblWindowShift.Location = new System.Drawing.Point(31, 48);
            this.lblWindowShift.Name = "lblWindowShift";
            this.lblWindowShift.Size = new System.Drawing.Size(175, 17);
            this.lblWindowShift.TabIndex = 39;
            this.lblWindowShift.Text = "Размер перекрытия (мс):";
            // 
            // groupMel
            // 
            this.groupMel.Controls.Add(this.numUpFrequency);
            this.groupMel.Controls.Add(this.lblUpFrequency);
            this.groupMel.Controls.Add(this.numLowFrequency);
            this.groupMel.Controls.Add(this.lblLowFrequency);
            this.groupMel.Controls.Add(this.numFilters);
            this.groupMel.Controls.Add(this.lblNumFilter);
            this.groupMel.Controls.Add(this.cmbMfcc);
            this.groupMel.Controls.Add(this.checkCvmn);
            this.groupMel.Controls.Add(this.checkEnergy);
            this.groupMel.Controls.Add(this.btnMel);
            this.groupMel.Controls.Add(this.rbDeltaDelta);
            this.groupMel.Controls.Add(this.rbDelta);
            this.groupMel.Controls.Add(this.lblNumCoefficients);
            this.groupMel.Controls.Add(this.numCoefficients);
            this.groupMel.Enabled = false;
            this.groupMel.Location = new System.Drawing.Point(333, 6);
            this.groupMel.Name = "groupMel";
            this.groupMel.Size = new System.Drawing.Size(287, 268);
            this.groupMel.TabIndex = 11;
            this.groupMel.TabStop = false;
            this.groupMel.Text = "Мел-кепстры";
            // 
            // numUpFrequency
            // 
            this.numUpFrequency.Location = new System.Drawing.Point(179, 53);
            this.numUpFrequency.Maximum = new decimal(new int[] {
            48000,
            0,
            0,
            0});
            this.numUpFrequency.Name = "numUpFrequency";
            this.numUpFrequency.Size = new System.Drawing.Size(102, 22);
            this.numUpFrequency.TabIndex = 44;
            this.numUpFrequency.Value = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            // 
            // lblUpFrequency
            // 
            this.lblUpFrequency.AutoSize = true;
            this.lblUpFrequency.Location = new System.Drawing.Point(49, 55);
            this.lblUpFrequency.Name = "lblUpFrequency";
            this.lblUpFrequency.Size = new System.Drawing.Size(124, 17);
            this.lblUpFrequency.TabIndex = 45;
            this.lblUpFrequency.Text = "Верхняя частота:";
            // 
            // numLowFrequency
            // 
            this.numLowFrequency.Location = new System.Drawing.Point(179, 25);
            this.numLowFrequency.Maximum = new decimal(new int[] {
            48000,
            0,
            0,
            0});
            this.numLowFrequency.Name = "numLowFrequency";
            this.numLowFrequency.Size = new System.Drawing.Size(102, 22);
            this.numLowFrequency.TabIndex = 42;
            // 
            // lblLowFrequency
            // 
            this.lblLowFrequency.AutoSize = true;
            this.lblLowFrequency.Location = new System.Drawing.Point(53, 26);
            this.lblLowFrequency.Name = "lblLowFrequency";
            this.lblLowFrequency.Size = new System.Drawing.Size(120, 17);
            this.lblLowFrequency.TabIndex = 43;
            this.lblLowFrequency.Text = "Нижняя частота:";
            // 
            // numFilters
            // 
            this.numFilters.Location = new System.Drawing.Point(179, 81);
            this.numFilters.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.numFilters.Minimum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numFilters.Name = "numFilters";
            this.numFilters.Size = new System.Drawing.Size(102, 22);
            this.numFilters.TabIndex = 40;
            this.numFilters.Value = new decimal(new int[] {
            24,
            0,
            0,
            0});
            // 
            // lblNumFilter
            // 
            this.lblNumFilter.AutoSize = true;
            this.lblNumFilter.Location = new System.Drawing.Point(43, 83);
            this.lblNumFilter.Name = "lblNumFilter";
            this.lblNumFilter.Size = new System.Drawing.Size(125, 17);
            this.lblNumFilter.TabIndex = 41;
            this.lblNumFilter.Text = "Кол-во фильтров:";
            // 
            // cmbMfcc
            // 
            this.cmbMfcc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMfcc.FormattingEnabled = true;
            this.cmbMfcc.Items.AddRange(new object[] {
            "Accord.NET",
            "SpeakersNewRecog"});
            this.cmbMfcc.Location = new System.Drawing.Point(9, 189);
            this.cmbMfcc.Name = "cmbMfcc";
            this.cmbMfcc.Size = new System.Drawing.Size(272, 24);
            this.cmbMfcc.TabIndex = 11;
            // 
            // checkCvmn
            // 
            this.checkCvmn.AutoSize = true;
            this.checkCvmn.Location = new System.Drawing.Point(9, 162);
            this.checkCvmn.Name = "checkCvmn";
            this.checkCvmn.Size = new System.Drawing.Size(136, 21);
            this.checkCvmn.TabIndex = 10;
            this.checkCvmn.Text = "CVMN Normalize";
            this.checkCvmn.UseVisualStyleBackColor = true;
            // 
            // checkEnergy
            // 
            this.checkEnergy.AutoSize = true;
            this.checkEnergy.Location = new System.Drawing.Point(9, 135);
            this.checkEnergy.Name = "checkEnergy";
            this.checkEnergy.Size = new System.Drawing.Size(75, 21);
            this.checkEnergy.TabIndex = 9;
            this.checkEnergy.Text = "Energy";
            this.checkEnergy.UseVisualStyleBackColor = true;
            // 
            // btnMel
            // 
            this.btnMel.Location = new System.Drawing.Point(9, 219);
            this.btnMel.Name = "btnMel";
            this.btnMel.Size = new System.Drawing.Size(272, 41);
            this.btnMel.TabIndex = 5;
            this.btnMel.Text = "Старт";
            this.btnMel.UseVisualStyleBackColor = true;
            this.btnMel.Click += new System.EventHandler(this.btnMel_Click);
            // 
            // rbDeltaDelta
            // 
            this.rbDeltaDelta.AutoSize = true;
            this.rbDeltaDelta.Location = new System.Drawing.Point(157, 135);
            this.rbDeltaDelta.Name = "rbDeltaDelta";
            this.rbDeltaDelta.Size = new System.Drawing.Size(100, 21);
            this.rbDeltaDelta.TabIndex = 3;
            this.rbDeltaDelta.TabStop = true;
            this.rbDeltaDelta.Text = "Delta-Delta";
            this.rbDeltaDelta.UseVisualStyleBackColor = true;
            // 
            // rbDelta
            // 
            this.rbDelta.AutoSize = true;
            this.rbDelta.Location = new System.Drawing.Point(89, 135);
            this.rbDelta.Name = "rbDelta";
            this.rbDelta.Size = new System.Drawing.Size(62, 21);
            this.rbDelta.TabIndex = 2;
            this.rbDelta.TabStop = true;
            this.rbDelta.Text = "Delta";
            this.rbDelta.UseVisualStyleBackColor = true;
            // 
            // lblNumCoefficients
            // 
            this.lblNumCoefficients.AutoSize = true;
            this.lblNumCoefficients.Location = new System.Drawing.Point(6, 111);
            this.lblNumCoefficients.Name = "lblNumCoefficients";
            this.lblNumCoefficients.Size = new System.Drawing.Size(167, 17);
            this.lblNumCoefficients.TabIndex = 1;
            this.lblNumCoefficients.Text = "Кол-во коэффициентов:";
            // 
            // numCoefficients
            // 
            this.numCoefficients.Location = new System.Drawing.Point(179, 109);
            this.numCoefficients.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.numCoefficients.Minimum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numCoefficients.Name = "numCoefficients";
            this.numCoefficients.Size = new System.Drawing.Size(102, 22);
            this.numCoefficients.TabIndex = 0;
            this.numCoefficients.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            // 
            // groupLpc
            // 
            this.groupLpc.Controls.Add(this.checkMel);
            this.groupLpc.Controls.Add(this.btnLpc);
            this.groupLpc.Controls.Add(this.lblNumCoefficients1);
            this.groupLpc.Controls.Add(this.numCoefficients1);
            this.groupLpc.Enabled = false;
            this.groupLpc.Location = new System.Drawing.Point(626, 6);
            this.groupLpc.Name = "groupLpc";
            this.groupLpc.Size = new System.Drawing.Size(287, 124);
            this.groupLpc.TabIndex = 12;
            this.groupLpc.TabStop = false;
            this.groupLpc.Text = "Линейное предсказание";
            // 
            // checkMel
            // 
            this.checkMel.AutoSize = true;
            this.checkMel.Location = new System.Drawing.Point(9, 49);
            this.checkMel.Name = "checkMel";
            this.checkMel.Size = new System.Drawing.Size(155, 21);
            this.checkMel.TabIndex = 12;
            this.checkMel.Text = "Применить к MFCC";
            this.checkMel.UseVisualStyleBackColor = true;
            // 
            // btnLpc
            // 
            this.btnLpc.Location = new System.Drawing.Point(9, 76);
            this.btnLpc.Name = "btnLpc";
            this.btnLpc.Size = new System.Drawing.Size(272, 41);
            this.btnLpc.TabIndex = 5;
            this.btnLpc.Text = "Старт";
            this.btnLpc.UseVisualStyleBackColor = true;
            // 
            // lblNumCoefficients1
            // 
            this.lblNumCoefficients1.AutoSize = true;
            this.lblNumCoefficients1.Location = new System.Drawing.Point(6, 23);
            this.lblNumCoefficients1.Name = "lblNumCoefficients1";
            this.lblNumCoefficients1.Size = new System.Drawing.Size(167, 17);
            this.lblNumCoefficients1.TabIndex = 1;
            this.lblNumCoefficients1.Text = "Кол-во коэффициентов:";
            // 
            // numCoefficients1
            // 
            this.numCoefficients1.Location = new System.Drawing.Point(179, 21);
            this.numCoefficients1.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.numCoefficients1.Minimum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numCoefficients1.Name = "numCoefficients1";
            this.numCoefficients1.Size = new System.Drawing.Size(102, 22);
            this.numCoefficients1.TabIndex = 0;
            this.numCoefficients1.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupStatistic);
            this.tabPage2.Controls.Add(this.groupNoise);
            this.tabPage2.Controls.Add(this.groupProccesSignal);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(954, 450);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Обработка и метрики";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupStatistic
            // 
            this.groupStatistic.Controls.Add(this.checkDistance);
            this.groupStatistic.Controls.Add(this.btnOtherMetricSignal);
            this.groupStatistic.Controls.Add(this.rbOtherSignal);
            this.groupStatistic.Controls.Add(this.txbOtherMetricSignal);
            this.groupStatistic.Controls.Add(this.btnCalcMetric);
            this.groupStatistic.Controls.Add(this.rbPreemphasis);
            this.groupStatistic.Controls.Add(this.rbNoise);
            this.groupStatistic.Controls.Add(this.listMetrics);
            this.groupStatistic.Enabled = false;
            this.groupStatistic.Location = new System.Drawing.Point(584, 6);
            this.groupStatistic.Name = "groupStatistic";
            this.groupStatistic.Size = new System.Drawing.Size(340, 312);
            this.groupStatistic.TabIndex = 11;
            this.groupStatistic.TabStop = false;
            this.groupStatistic.Text = "Метрики";
            // 
            // checkDistance
            // 
            this.checkDistance.AutoSize = true;
            this.checkDistance.Location = new System.Drawing.Point(7, 96);
            this.checkDistance.Name = "checkDistance";
            this.checkDistance.Size = new System.Drawing.Size(184, 21);
            this.checkDistance.TabIndex = 16;
            this.checkDistance.Text = "Расстояния (признаки)";
            this.checkDistance.UseVisualStyleBackColor = true;
            // 
            // btnOtherMetricSignal
            // 
            this.btnOtherMetricSignal.Enabled = false;
            this.btnOtherMetricSignal.Location = new System.Drawing.Point(256, 129);
            this.btnOtherMetricSignal.Name = "btnOtherMetricSignal";
            this.btnOtherMetricSignal.Size = new System.Drawing.Size(78, 23);
            this.btnOtherMetricSignal.TabIndex = 13;
            this.btnOtherMetricSignal.Text = "...";
            this.btnOtherMetricSignal.UseVisualStyleBackColor = true;
            this.btnOtherMetricSignal.Click += new System.EventHandler(this.btnOtherMetricSignal_Click);
            // 
            // rbOtherSignal
            // 
            this.rbOtherSignal.AutoSize = true;
            this.rbOtherSignal.Location = new System.Drawing.Point(6, 68);
            this.rbOtherSignal.Name = "rbOtherSignal";
            this.rbOtherSignal.Size = new System.Drawing.Size(143, 21);
            this.rbOtherSignal.TabIndex = 15;
            this.rbOtherSignal.TabStop = true;
            this.rbOtherSignal.Text = "Загрузить другой";
            this.rbOtherSignal.UseVisualStyleBackColor = true;
            this.rbOtherSignal.CheckedChanged += new System.EventHandler(this.rbOtherSignal_CheckedChanged);
            // 
            // txbOtherMetricSignal
            // 
            this.txbOtherMetricSignal.Enabled = false;
            this.txbOtherMetricSignal.Location = new System.Drawing.Point(6, 131);
            this.txbOtherMetricSignal.Name = "txbOtherMetricSignal";
            this.txbOtherMetricSignal.Size = new System.Drawing.Size(244, 22);
            this.txbOtherMetricSignal.TabIndex = 12;
            this.txbOtherMetricSignal.Text = "Файл 1";
            // 
            // btnCalcMetric
            // 
            this.btnCalcMetric.Location = new System.Drawing.Point(6, 264);
            this.btnCalcMetric.Name = "btnCalcMetric";
            this.btnCalcMetric.Size = new System.Drawing.Size(328, 36);
            this.btnCalcMetric.TabIndex = 11;
            this.btnCalcMetric.Text = "Старт";
            this.btnCalcMetric.UseVisualStyleBackColor = true;
            this.btnCalcMetric.Click += new System.EventHandler(this.btnCalcMetric_Click);
            // 
            // rbPreemphasis
            // 
            this.rbPreemphasis.Location = new System.Drawing.Point(116, 21);
            this.rbPreemphasis.Name = "rbPreemphasis";
            this.rbPreemphasis.Size = new System.Drawing.Size(134, 45);
            this.rbPreemphasis.TabIndex = 14;
            this.rbPreemphasis.TabStop = true;
            this.rbPreemphasis.Text = "Обработанный сигнал";
            this.rbPreemphasis.UseVisualStyleBackColor = true;
            this.rbPreemphasis.CheckedChanged += new System.EventHandler(this.rbPreemphasis_CheckedChanged);
            // 
            // rbNoise
            // 
            this.rbNoise.Location = new System.Drawing.Point(6, 21);
            this.rbNoise.Name = "rbNoise";
            this.rbNoise.Size = new System.Drawing.Size(104, 48);
            this.rbNoise.TabIndex = 13;
            this.rbNoise.TabStop = true;
            this.rbNoise.Text = "Сигнал до обработки";
            this.rbNoise.UseVisualStyleBackColor = true;
            // 
            // listMetrics
            // 
            this.listMetrics.FormattingEnabled = true;
            this.listMetrics.ItemHeight = 16;
            this.listMetrics.Location = new System.Drawing.Point(6, 158);
            this.listMetrics.Name = "listMetrics";
            this.listMetrics.Size = new System.Drawing.Size(328, 100);
            this.listMetrics.TabIndex = 12;
            // 
            // groupNoise
            // 
            this.groupNoise.Controls.Add(this.lblDevMinus);
            this.groupNoise.Controls.Add(this.numDevMinus);
            this.groupNoise.Controls.Add(this.lblDevPlus);
            this.groupNoise.Controls.Add(this.numDevPlus);
            this.groupNoise.Controls.Add(this.rbLinear);
            this.groupNoise.Controls.Add(this.rbGauss);
            this.groupNoise.Controls.Add(this.lblPercentDeviation);
            this.groupNoise.Controls.Add(this.numPercentDeviation);
            this.groupNoise.Controls.Add(this.lblSigma);
            this.groupNoise.Controls.Add(this.lblPercentNoise);
            this.groupNoise.Controls.Add(this.numSigma);
            this.groupNoise.Controls.Add(this.btnSaveNoise);
            this.groupNoise.Controls.Add(this.numPercentNoise);
            this.groupNoise.Controls.Add(this.btnNoise);
            this.groupNoise.Controls.Add(this.cmbNoise);
            this.groupNoise.Enabled = false;
            this.groupNoise.Location = new System.Drawing.Point(6, 6);
            this.groupNoise.Name = "groupNoise";
            this.groupNoise.Size = new System.Drawing.Size(308, 312);
            this.groupNoise.TabIndex = 8;
            this.groupNoise.TabStop = false;
            this.groupNoise.Text = "Шум";
            // 
            // lblDevMinus
            // 
            this.lblDevMinus.AutoSize = true;
            this.lblDevMinus.Location = new System.Drawing.Point(91, 234);
            this.lblDevMinus.Name = "lblDevMinus";
            this.lblDevMinus.Size = new System.Drawing.Size(112, 17);
            this.lblDevMinus.TabIndex = 23;
            this.lblDevMinus.Text = "Отклонение (-):";
            // 
            // numDevMinus
            // 
            this.numDevMinus.DecimalPlaces = 3;
            this.numDevMinus.Enabled = false;
            this.numDevMinus.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numDevMinus.Location = new System.Drawing.Point(210, 232);
            this.numDevMinus.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDevMinus.Name = "numDevMinus";
            this.numDevMinus.Size = new System.Drawing.Size(91, 22);
            this.numDevMinus.TabIndex = 22;
            // 
            // lblDevPlus
            // 
            this.lblDevPlus.AutoSize = true;
            this.lblDevPlus.Location = new System.Drawing.Point(91, 206);
            this.lblDevPlus.Name = "lblDevPlus";
            this.lblDevPlus.Size = new System.Drawing.Size(115, 17);
            this.lblDevPlus.TabIndex = 21;
            this.lblDevPlus.Text = "Отклонение (+):";
            // 
            // numDevPlus
            // 
            this.numDevPlus.DecimalPlaces = 3;
            this.numDevPlus.Enabled = false;
            this.numDevPlus.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numDevPlus.Location = new System.Drawing.Point(210, 204);
            this.numDevPlus.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDevPlus.Name = "numDevPlus";
            this.numDevPlus.Size = new System.Drawing.Size(91, 22);
            this.numDevPlus.TabIndex = 20;
            // 
            // rbLinear
            // 
            this.rbLinear.AutoSize = true;
            this.rbLinear.Location = new System.Drawing.Point(7, 78);
            this.rbLinear.Name = "rbLinear";
            this.rbLinear.Size = new System.Drawing.Size(225, 21);
            this.rbLinear.TabIndex = 19;
            this.rbLinear.Text = "Равномерное распределение";
            this.rbLinear.UseVisualStyleBackColor = true;
            this.rbLinear.CheckedChanged += new System.EventHandler(this.rbLinear_CheckedChanged);
            // 
            // rbGauss
            // 
            this.rbGauss.AutoSize = true;
            this.rbGauss.Checked = true;
            this.rbGauss.Location = new System.Drawing.Point(7, 51);
            this.rbGauss.Name = "rbGauss";
            this.rbGauss.Size = new System.Drawing.Size(218, 21);
            this.rbGauss.TabIndex = 18;
            this.rbGauss.TabStop = true;
            this.rbGauss.Text = "Нормальное распределение";
            this.rbGauss.UseVisualStyleBackColor = true;
            this.rbGauss.CheckedChanged += new System.EventHandler(this.rbGauss_CheckedChanged);
            // 
            // lblPercentDeviation
            // 
            this.lblPercentDeviation.Location = new System.Drawing.Point(29, 157);
            this.lblPercentDeviation.Name = "lblPercentDeviation";
            this.lblPercentDeviation.Size = new System.Drawing.Size(177, 41);
            this.lblPercentDeviation.TabIndex = 17;
            this.lblPercentDeviation.Text = "Процент положительных к отрицательным:";
            // 
            // numPercentDeviation
            // 
            this.numPercentDeviation.Enabled = false;
            this.numPercentDeviation.Location = new System.Drawing.Point(210, 176);
            this.numPercentDeviation.Name = "numPercentDeviation";
            this.numPercentDeviation.Size = new System.Drawing.Size(91, 22);
            this.numPercentDeviation.TabIndex = 16;
            // 
            // lblSigma
            // 
            this.lblSigma.AutoSize = true;
            this.lblSigma.Location = new System.Drawing.Point(133, 137);
            this.lblSigma.Name = "lblSigma";
            this.lblSigma.Size = new System.Drawing.Size(73, 17);
            this.lblSigma.TabIndex = 15;
            this.lblSigma.Text = "Sigma (σ):";
            // 
            // lblPercentNoise
            // 
            this.lblPercentNoise.AutoSize = true;
            this.lblPercentNoise.Location = new System.Drawing.Point(29, 107);
            this.lblPercentNoise.Name = "lblPercentNoise";
            this.lblPercentNoise.Size = new System.Drawing.Size(177, 17);
            this.lblPercentNoise.TabIndex = 14;
            this.lblPercentNoise.Text = "Процент зашумленности:";
            // 
            // numSigma
            // 
            this.numSigma.DecimalPlaces = 2;
            this.numSigma.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numSigma.Location = new System.Drawing.Point(210, 135);
            this.numSigma.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSigma.Name = "numSigma";
            this.numSigma.Size = new System.Drawing.Size(91, 22);
            this.numSigma.TabIndex = 1;
            // 
            // btnSaveNoise
            // 
            this.btnSaveNoise.Enabled = false;
            this.btnSaveNoise.Location = new System.Drawing.Point(165, 264);
            this.btnSaveNoise.Name = "btnSaveNoise";
            this.btnSaveNoise.Size = new System.Drawing.Size(137, 36);
            this.btnSaveNoise.TabIndex = 13;
            this.btnSaveNoise.Text = "Сохранить файл";
            this.btnSaveNoise.UseVisualStyleBackColor = true;
            this.btnSaveNoise.Click += new System.EventHandler(this.btnSaveNoise_Click);
            // 
            // numPercentNoise
            // 
            this.numPercentNoise.Location = new System.Drawing.Point(210, 105);
            this.numPercentNoise.Name = "numPercentNoise";
            this.numPercentNoise.Size = new System.Drawing.Size(91, 22);
            this.numPercentNoise.TabIndex = 0;
            // 
            // btnNoise
            // 
            this.btnNoise.Location = new System.Drawing.Point(7, 264);
            this.btnNoise.Name = "btnNoise";
            this.btnNoise.Size = new System.Drawing.Size(152, 36);
            this.btnNoise.TabIndex = 3;
            this.btnNoise.Text = "Добавить шум";
            this.btnNoise.UseVisualStyleBackColor = true;
            this.btnNoise.Click += new System.EventHandler(this.btnNoise_Click);
            // 
            // cmbNoise
            // 
            this.cmbNoise.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNoise.FormattingEnabled = true;
            this.cmbNoise.Items.AddRange(new object[] {
            "Аддитивный",
            "Мультипликативный",
            "Импульсный"});
            this.cmbNoise.Location = new System.Drawing.Point(6, 21);
            this.cmbNoise.Name = "cmbNoise";
            this.cmbNoise.Size = new System.Drawing.Size(295, 24);
            this.cmbNoise.TabIndex = 11;
            this.cmbNoise.SelectedIndexChanged += new System.EventHandler(this.cmbNoise_SelectedIndexChanged);
            // 
            // groupProccesSignal
            // 
            this.groupProccesSignal.Controls.Add(this.btnSaveProcess);
            this.groupProccesSignal.Controls.Add(this.groupProcessParam);
            this.groupProccesSignal.Controls.Add(this.cmbFilter);
            this.groupProccesSignal.Controls.Add(this.btnPreemphasis);
            this.groupProccesSignal.Enabled = false;
            this.groupProccesSignal.Location = new System.Drawing.Point(320, 6);
            this.groupProccesSignal.Name = "groupProccesSignal";
            this.groupProccesSignal.Size = new System.Drawing.Size(258, 161);
            this.groupProccesSignal.TabIndex = 7;
            this.groupProccesSignal.TabStop = false;
            this.groupProccesSignal.Text = "Предварительная обработка";
            // 
            // btnSaveProcess
            // 
            this.btnSaveProcess.Enabled = false;
            this.btnSaveProcess.Location = new System.Drawing.Point(126, 105);
            this.btnSaveProcess.Name = "btnSaveProcess";
            this.btnSaveProcess.Size = new System.Drawing.Size(118, 42);
            this.btnSaveProcess.TabIndex = 10;
            this.btnSaveProcess.Text = "Сохранить файл";
            this.btnSaveProcess.UseVisualStyleBackColor = true;
            this.btnSaveProcess.Click += new System.EventHandler(this.btnSaveProcess_Click);
            // 
            // groupProcessParam
            // 
            this.groupProcessParam.Controls.Add(this.numProcess2);
            this.groupProcessParam.Controls.Add(this.numProcess1);
            this.groupProcessParam.Location = new System.Drawing.Point(6, 45);
            this.groupProcessParam.Name = "groupProcessParam";
            this.groupProcessParam.Size = new System.Drawing.Size(238, 54);
            this.groupProcessParam.TabIndex = 9;
            this.groupProcessParam.TabStop = false;
            this.groupProcessParam.Text = "Параметры:";
            // 
            // numProcess2
            // 
            this.numProcess2.DecimalPlaces = 4;
            this.numProcess2.Enabled = false;
            this.numProcess2.Location = new System.Drawing.Point(131, 21);
            this.numProcess2.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numProcess2.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.numProcess2.Name = "numProcess2";
            this.numProcess2.Size = new System.Drawing.Size(92, 22);
            this.numProcess2.TabIndex = 1;
            // 
            // numProcess1
            // 
            this.numProcess1.DecimalPlaces = 4;
            this.numProcess1.Enabled = false;
            this.numProcess1.Location = new System.Drawing.Point(7, 22);
            this.numProcess1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numProcess1.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.numProcess1.Name = "numProcess1";
            this.numProcess1.Size = new System.Drawing.Size(118, 22);
            this.numProcess1.TabIndex = 0;
            // 
            // cmbFilter
            // 
            this.cmbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilter.FormattingEnabled = true;
            this.cmbFilter.Items.AddRange(new object[] {
            "КИХ (низкочастотный)",
            "КИХ (высокочастотный)",
            "КИХ (полосовой)",
            "КИХ (полоcно-заграждающий)",
            "БИХ (низкочастотный)",
            "БИХ (высокочастотный)",
            "БИХ (полосовой)",
            "БИХ (полоcно-заграждающий)",
            "Медианный",
            "Среднеквадратичный (+нормализация)",
            "Шумоподавление (DWT)"});
            this.cmbFilter.Location = new System.Drawing.Point(6, 17);
            this.cmbFilter.Name = "cmbFilter";
            this.cmbFilter.Size = new System.Drawing.Size(238, 24);
            this.cmbFilter.TabIndex = 8;
            this.cmbFilter.SelectedIndexChanged += new System.EventHandler(this.cmbFilter_SelectedIndexChanged);
            // 
            // btnPreemphasis
            // 
            this.btnPreemphasis.Location = new System.Drawing.Point(6, 105);
            this.btnPreemphasis.Name = "btnPreemphasis";
            this.btnPreemphasis.Size = new System.Drawing.Size(114, 42);
            this.btnPreemphasis.TabIndex = 6;
            this.btnPreemphasis.Text = "Старт";
            this.btnPreemphasis.UseVisualStyleBackColor = true;
            this.btnPreemphasis.Click += new System.EventHandler(this.btnPreemphasis_Click);
            // 
            // tabPreemphasis
            // 
            this.tabPreemphasis.Controls.Add(this.tabPage2);
            this.tabPreemphasis.Controls.Add(this.tabFeatures);
            this.tabPreemphasis.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabPreemphasis.Location = new System.Drawing.Point(0, 299);
            this.tabPreemphasis.Name = "tabPreemphasis";
            this.tabPreemphasis.SelectedIndex = 0;
            this.tabPreemphasis.Size = new System.Drawing.Size(962, 479);
            this.tabPreemphasis.TabIndex = 16;
            // 
            // btnMixForm
            // 
            this.btnMixForm.Name = "btnMixForm";
            this.btnMixForm.Size = new System.Drawing.Size(235, 26);
            this.btnMixForm.Text = "Микширование / SED";
            this.btnMixForm.Click += new System.EventHandler(this.btnMixForm_Click);
            // 
            // AudioAnalyse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(962, 823);
            this.Controls.Add(this.tabPreemphasis);
            this.Controls.Add(this.graphChart);
            this.Controls.Add(this.cmbPlot);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "AudioAnalyse";
            this.Text = "Анализ аудиоданных";
            this.Load += new System.EventHandler(this.AudioAnalyse_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.graphChart)).EndInit();
            this.tabFeatures.ResumeLayout(false);
            this.groupDiscreteTransform.ResumeLayout(false);
            this.groupDiscreteTransform.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBuffer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWindowSize)).EndInit();
            this.groupFourier.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numWindowShift)).EndInit();
            this.groupMel.ResumeLayout(false);
            this.groupMel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpFrequency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLowFrequency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFilters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCoefficients)).EndInit();
            this.groupLpc.ResumeLayout(false);
            this.groupLpc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCoefficients1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.groupStatistic.ResumeLayout(false);
            this.groupStatistic.PerformLayout();
            this.groupNoise.ResumeLayout(false);
            this.groupNoise.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDevMinus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDevPlus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPercentDeviation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSigma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPercentNoise)).EndInit();
            this.groupProccesSignal.ResumeLayout(false);
            this.groupProcessParam.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numProcess2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numProcess1)).EndInit();
            this.tabPreemphasis.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem btnFile;
        private System.Windows.Forms.ToolStripMenuItem btnOpen;
        private System.Windows.Forms.ToolStripMenuItem btnRecorder;
        private System.Windows.Forms.ToolStripMenuItem btnExit;
        private System.Windows.Forms.ToolStripMenuItem btnHelp;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ComboBox cmbPlot;
        private System.Windows.Forms.DataVisualization.Charting.Chart graphChart;
        private System.Windows.Forms.TabPage tabFeatures;
        private System.Windows.Forms.GroupBox groupDiscreteTransform;
        private System.Windows.Forms.NumericUpDown numBuffer;
        private System.Windows.Forms.Label lblBuffer;
        private System.Windows.Forms.NumericUpDown numWindowSize;
        private System.Windows.Forms.GroupBox groupFourier;
        private System.Windows.Forms.Button btnFourier;
        private System.Windows.Forms.ComboBox cmbTypeTransform;
        private System.Windows.Forms.Label lblWindowSize;
        private System.Windows.Forms.NumericUpDown numWindowShift;
        private System.Windows.Forms.Label lblWindowShift;
        private System.Windows.Forms.GroupBox groupMel;
        private System.Windows.Forms.NumericUpDown numUpFrequency;
        private System.Windows.Forms.Label lblUpFrequency;
        private System.Windows.Forms.NumericUpDown numLowFrequency;
        private System.Windows.Forms.Label lblLowFrequency;
        private System.Windows.Forms.NumericUpDown numFilters;
        private System.Windows.Forms.Label lblNumFilter;
        private System.Windows.Forms.ComboBox cmbMfcc;
        private System.Windows.Forms.CheckBox checkCvmn;
        private System.Windows.Forms.CheckBox checkEnergy;
        private System.Windows.Forms.Button btnMel;
        private System.Windows.Forms.RadioButton rbDeltaDelta;
        private System.Windows.Forms.RadioButton rbDelta;
        private System.Windows.Forms.Label lblNumCoefficients;
        private System.Windows.Forms.NumericUpDown numCoefficients;
        private System.Windows.Forms.GroupBox groupLpc;
        private System.Windows.Forms.CheckBox checkMel;
        private System.Windows.Forms.Button btnLpc;
        private System.Windows.Forms.Label lblNumCoefficients1;
        private System.Windows.Forms.NumericUpDown numCoefficients1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupStatistic;
        private System.Windows.Forms.CheckBox checkDistance;
        private System.Windows.Forms.Button btnOtherMetricSignal;
        private System.Windows.Forms.RadioButton rbOtherSignal;
        private System.Windows.Forms.TextBox txbOtherMetricSignal;
        private System.Windows.Forms.Button btnCalcMetric;
        private System.Windows.Forms.RadioButton rbPreemphasis;
        private System.Windows.Forms.RadioButton rbNoise;
        private System.Windows.Forms.ListBox listMetrics;
        private System.Windows.Forms.GroupBox groupNoise;
        private System.Windows.Forms.Label lblDevMinus;
        private System.Windows.Forms.NumericUpDown numDevMinus;
        private System.Windows.Forms.Label lblDevPlus;
        private System.Windows.Forms.NumericUpDown numDevPlus;
        private System.Windows.Forms.RadioButton rbLinear;
        private System.Windows.Forms.RadioButton rbGauss;
        private System.Windows.Forms.Label lblPercentDeviation;
        private System.Windows.Forms.NumericUpDown numPercentDeviation;
        private System.Windows.Forms.Label lblSigma;
        private System.Windows.Forms.Label lblPercentNoise;
        private System.Windows.Forms.NumericUpDown numSigma;
        private System.Windows.Forms.Button btnSaveNoise;
        private System.Windows.Forms.NumericUpDown numPercentNoise;
        private System.Windows.Forms.Button btnNoise;
        private System.Windows.Forms.ComboBox cmbNoise;
        private System.Windows.Forms.GroupBox groupProccesSignal;
        private System.Windows.Forms.Button btnSaveProcess;
        private System.Windows.Forms.GroupBox groupProcessParam;
        private System.Windows.Forms.NumericUpDown numProcess2;
        private System.Windows.Forms.NumericUpDown numProcess1;
        private System.Windows.Forms.ComboBox cmbFilter;
        private System.Windows.Forms.Button btnPreemphasis;
        private System.Windows.Forms.TabControl tabPreemphasis;
        private System.Windows.Forms.ToolStripMenuItem btnMixForm;
    }
}