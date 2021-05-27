using System.Drawing;

namespace SpeakersNewRecog
{
    partial class Mixer
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
            this.components = new System.ComponentModel.Container();
            this.graphControl = new ZedGraph.ZedGraphControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.менюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClose = new System.Windows.Forms.ToolStripMenuItem();
            this.btnChartsStatistics = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabMixer = new System.Windows.Forms.TabPage();
            this.groupExtractWav = new System.Windows.Forms.GroupBox();
            this.btnPathSaveWave = new System.Windows.Forms.Button();
            this.txbPathSaveWave = new System.Windows.Forms.TextBox();
            this.btnExtract = new System.Windows.Forms.Button();
            this.btnPathVideo = new System.Windows.Forms.Button();
            this.txbPathVideo = new System.Windows.Forms.TextBox();
            this.groupMixer = new System.Windows.Forms.GroupBox();
            this.lblMix2FileAtSecond = new System.Windows.Forms.Label();
            this.numMix2FileAtSecond = new System.Windows.Forms.NumericUpDown();
            this.lblVolFile2 = new System.Windows.Forms.Label();
            this.numVolFile2 = new System.Windows.Forms.NumericUpDown();
            this.lblVolFile1 = new System.Windows.Forms.Label();
            this.numVolFile1 = new System.Windows.Forms.NumericUpDown();
            this.lblAudioMode = new System.Windows.Forms.Label();
            this.cmbAudioMode = new System.Windows.Forms.ComboBox();
            this.btnMixFileResult = new System.Windows.Forms.Button();
            this.txbMixFileResult = new System.Windows.Forms.TextBox();
            this.btnMix = new System.Windows.Forms.Button();
            this.btnMixFile2 = new System.Windows.Forms.Button();
            this.txbMixFile2 = new System.Windows.Forms.TextBox();
            this.tabSED = new System.Windows.Forms.TabPage();
            this.groupCompare = new System.Windows.Forms.GroupBox();
            this.lblAlgorithm = new System.Windows.Forms.Label();
            this.cmbAlgorithm = new System.Windows.Forms.ComboBox();
            this.btnOpenCompare = new System.Windows.Forms.Button();
            this.txbCompareFile = new System.Windows.Forms.TextBox();
            this.btnStartCompare = new System.Windows.Forms.Button();
            this.btnOpenEtalon = new System.Windows.Forms.Button();
            this.txbEtalon = new System.Windows.Forms.TextBox();
            this.groupPlay = new System.Windows.Forms.GroupBox();
            this.lblPlaySection = new System.Windows.Forms.Label();
            this.btnPlay = new System.Windows.Forms.Button();
            this.groupAutocorrelation = new System.Windows.Forms.GroupBox();
            this.numWindowSizeAutocor = new System.Windows.Forms.NumericUpDown();
            this.lblWindowSizeAutocor = new System.Windows.Forms.Label();
            this.numFrameSizeAutocor = new System.Windows.Forms.NumericUpDown();
            this.lblFrameSizeAutocor = new System.Windows.Forms.Label();
            this.btnAutocorrelation = new System.Windows.Forms.Button();
            this.numCountFrameAutocor = new System.Windows.Forms.NumericUpDown();
            this.lblCountFrameAutocor = new System.Windows.Forms.Label();
            this.numSizeFilterAutocor = new System.Windows.Forms.NumericUpDown();
            this.lblSizeFilterAutocor = new System.Windows.Forms.Label();
            this.groupNormalDistSED = new System.Windows.Forms.GroupBox();
            this.numFrameSizeND = new System.Windows.Forms.NumericUpDown();
            this.lblFrameSizeND = new System.Windows.Forms.Label();
            this.btnNormalDistribution = new System.Windows.Forms.Button();
            this.numCountFrameND = new System.Windows.Forms.NumericUpDown();
            this.lblCountFrameND = new System.Windows.Forms.Label();
            this.numSizeFilterND = new System.Windows.Forms.NumericUpDown();
            this.lblSizeFilterND = new System.Windows.Forms.Label();
            this.groupShortTimeFeatures = new System.Windows.Forms.GroupBox();
            this.numFrameSizeSTF = new System.Windows.Forms.NumericUpDown();
            this.lblFrameSizeSTF = new System.Windows.Forms.Label();
            this.btnShortTimeFeatures = new System.Windows.Forms.Button();
            this.numCountFrameSTF = new System.Windows.Forms.NumericUpDown();
            this.lblCountFrameSTF = new System.Windows.Forms.Label();
            this.cmbTypeSTF = new System.Windows.Forms.ComboBox();
            this.numSizeFilterSTF = new System.Windows.Forms.NumericUpDown();
            this.lblSizeFilterSTF = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabMixer.SuspendLayout();
            this.groupExtractWav.SuspendLayout();
            this.groupMixer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMix2FileAtSecond)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVolFile2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVolFile1)).BeginInit();
            this.tabSED.SuspendLayout();
            this.groupCompare.SuspendLayout();
            this.groupPlay.SuspendLayout();
            this.groupAutocorrelation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWindowSizeAutocor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFrameSizeAutocor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCountFrameAutocor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSizeFilterAutocor)).BeginInit();
            this.groupNormalDistSED.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFrameSizeND)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCountFrameND)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSizeFilterND)).BeginInit();
            this.groupShortTimeFeatures.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFrameSizeSTF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCountFrameSTF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSizeFilterSTF)).BeginInit();
            this.SuspendLayout();
            // 
            // graphControl
            // 
            this.graphControl.BackColor = System.Drawing.SystemColors.Control;
            this.graphControl.Location = new System.Drawing.Point(11, 42);
            this.graphControl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.graphControl.Name = "graphControl";
            this.graphControl.ScrollGrace = 0D;
            this.graphControl.ScrollMaxX = 0D;
            this.graphControl.ScrollMaxY = 0D;
            this.graphControl.ScrollMaxY2 = 0D;
            this.graphControl.ScrollMinX = 0D;
            this.graphControl.ScrollMinY = 0D;
            this.graphControl.ScrollMinY2 = 0D;
            this.graphControl.Size = new System.Drawing.Size(1005, 185);
            this.graphControl.TabIndex = 5;
            this.graphControl.UseExtendedPrintDialog = true;
            this.graphControl.ZoomButtons = System.Windows.Forms.MouseButtons.Right;
            this.graphControl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.graphControl_MouseClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.менюToolStripMenuItem,
            this.btnChartsStatistics,
            this.справкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1029, 28);
            this.menuStrip1.TabIndex = 17;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // менюToolStripMenuItem
            // 
            this.менюToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOpen,
            this.btnClose});
            this.менюToolStripMenuItem.Name = "менюToolStripMenuItem";
            this.менюToolStripMenuItem.Size = new System.Drawing.Size(63, 24);
            this.менюToolStripMenuItem.Text = "Меню";
            // 
            // btnOpen
            // 
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(146, 26);
            this.btnOpen.Text = "Открыть ";
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnClose
            // 
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(146, 26);
            this.btnClose.Text = "Выход";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnChartsStatistics
            // 
            this.btnChartsStatistics.Enabled = false;
            this.btnChartsStatistics.Name = "btnChartsStatistics";
            this.btnChartsStatistics.Size = new System.Drawing.Size(80, 24);
            this.btnChartsStatistics.Text = "Графики";
            this.btnChartsStatistics.Click += new System.EventHandler(this.btnChartsStatistics_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(79, 24);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabMixer);
            this.tabControl.Controls.Add(this.tabSED);
            this.tabControl.Enabled = false;
            this.tabControl.Location = new System.Drawing.Point(12, 233);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1004, 374);
            this.tabControl.TabIndex = 18;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabMixer
            // 
            this.tabMixer.Controls.Add(this.groupExtractWav);
            this.tabMixer.Controls.Add(this.groupMixer);
            this.tabMixer.Location = new System.Drawing.Point(4, 25);
            this.tabMixer.Name = "tabMixer";
            this.tabMixer.Padding = new System.Windows.Forms.Padding(3);
            this.tabMixer.Size = new System.Drawing.Size(996, 345);
            this.tabMixer.TabIndex = 0;
            this.tabMixer.Text = "Mixing";
            this.tabMixer.UseVisualStyleBackColor = true;
            // 
            // groupExtractWav
            // 
            this.groupExtractWav.Controls.Add(this.btnPathSaveWave);
            this.groupExtractWav.Controls.Add(this.txbPathSaveWave);
            this.groupExtractWav.Controls.Add(this.btnExtract);
            this.groupExtractWav.Controls.Add(this.btnPathVideo);
            this.groupExtractWav.Controls.Add(this.txbPathVideo);
            this.groupExtractWav.Location = new System.Drawing.Point(6, 6);
            this.groupExtractWav.Name = "groupExtractWav";
            this.groupExtractWav.Size = new System.Drawing.Size(307, 130);
            this.groupExtractWav.TabIndex = 16;
            this.groupExtractWav.TabStop = false;
            this.groupExtractWav.Text = "Извлечение аудиодорожки";
            // 
            // btnPathSaveWave
            // 
            this.btnPathSaveWave.Location = new System.Drawing.Point(226, 49);
            this.btnPathSaveWave.Name = "btnPathSaveWave";
            this.btnPathSaveWave.Size = new System.Drawing.Size(75, 23);
            this.btnPathSaveWave.TabIndex = 7;
            this.btnPathSaveWave.Text = "...";
            this.btnPathSaveWave.UseVisualStyleBackColor = true;
            this.btnPathSaveWave.Click += new System.EventHandler(this.btnPathSaveWave_Click);
            // 
            // txbPathSaveWave
            // 
            this.txbPathSaveWave.Location = new System.Drawing.Point(6, 50);
            this.txbPathSaveWave.Name = "txbPathSaveWave";
            this.txbPathSaveWave.Size = new System.Drawing.Size(214, 22);
            this.txbPathSaveWave.TabIndex = 6;
            this.txbPathSaveWave.Text = "Папка для сохранения";
            // 
            // btnExtract
            // 
            this.btnExtract.Location = new System.Drawing.Point(6, 83);
            this.btnExtract.Name = "btnExtract";
            this.btnExtract.Size = new System.Drawing.Size(295, 35);
            this.btnExtract.TabIndex = 5;
            this.btnExtract.Text = "Извлечь";
            this.btnExtract.UseVisualStyleBackColor = true;
            this.btnExtract.Click += new System.EventHandler(this.btnExtract_Click);
            // 
            // btnPathVideo
            // 
            this.btnPathVideo.Location = new System.Drawing.Point(226, 21);
            this.btnPathVideo.Name = "btnPathVideo";
            this.btnPathVideo.Size = new System.Drawing.Size(75, 23);
            this.btnPathVideo.TabIndex = 2;
            this.btnPathVideo.Text = "...";
            this.btnPathVideo.UseVisualStyleBackColor = true;
            this.btnPathVideo.Click += new System.EventHandler(this.btnPathVideo_Click);
            // 
            // txbPathVideo
            // 
            this.txbPathVideo.Location = new System.Drawing.Point(6, 21);
            this.txbPathVideo.Name = "txbPathVideo";
            this.txbPathVideo.Size = new System.Drawing.Size(214, 22);
            this.txbPathVideo.TabIndex = 0;
            this.txbPathVideo.Text = "Путь до видео";
            // 
            // groupMixer
            // 
            this.groupMixer.Controls.Add(this.lblMix2FileAtSecond);
            this.groupMixer.Controls.Add(this.numMix2FileAtSecond);
            this.groupMixer.Controls.Add(this.lblVolFile2);
            this.groupMixer.Controls.Add(this.numVolFile2);
            this.groupMixer.Controls.Add(this.lblVolFile1);
            this.groupMixer.Controls.Add(this.numVolFile1);
            this.groupMixer.Controls.Add(this.lblAudioMode);
            this.groupMixer.Controls.Add(this.cmbAudioMode);
            this.groupMixer.Controls.Add(this.btnMixFileResult);
            this.groupMixer.Controls.Add(this.txbMixFileResult);
            this.groupMixer.Controls.Add(this.btnMix);
            this.groupMixer.Controls.Add(this.btnMixFile2);
            this.groupMixer.Controls.Add(this.txbMixFile2);
            this.groupMixer.Location = new System.Drawing.Point(319, 6);
            this.groupMixer.Name = "groupMixer";
            this.groupMixer.Size = new System.Drawing.Size(311, 244);
            this.groupMixer.TabIndex = 17;
            this.groupMixer.TabStop = false;
            this.groupMixer.Text = "Микшер";
            // 
            // lblMix2FileAtSecond
            // 
            this.lblMix2FileAtSecond.AutoSize = true;
            this.lblMix2FileAtSecond.Location = new System.Drawing.Point(30, 53);
            this.lblMix2FileAtSecond.Name = "lblMix2FileAtSecond";
            this.lblMix2FileAtSecond.Size = new System.Drawing.Size(144, 17);
            this.lblMix2FileAtSecond.TabIndex = 17;
            this.lblMix2FileAtSecond.Text = "Пропуск сек. файла:";
            // 
            // numMix2FileAtSecond
            // 
            this.numMix2FileAtSecond.DecimalPlaces = 2;
            this.numMix2FileAtSecond.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numMix2FileAtSecond.Location = new System.Drawing.Point(181, 51);
            this.numMix2FileAtSecond.Name = "numMix2FileAtSecond";
            this.numMix2FileAtSecond.Size = new System.Drawing.Size(120, 22);
            this.numMix2FileAtSecond.TabIndex = 16;
            // 
            // lblVolFile2
            // 
            this.lblVolFile2.AutoSize = true;
            this.lblVolFile2.Location = new System.Drawing.Point(17, 146);
            this.lblVolFile2.Name = "lblVolFile2";
            this.lblVolFile2.Size = new System.Drawing.Size(158, 17);
            this.lblVolFile2.TabIndex = 15;
            this.lblVolFile2.Text = "Громкость 2-го файла:";
            // 
            // numVolFile2
            // 
            this.numVolFile2.DecimalPlaces = 2;
            this.numVolFile2.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numVolFile2.Location = new System.Drawing.Point(181, 144);
            this.numVolFile2.Name = "numVolFile2";
            this.numVolFile2.Size = new System.Drawing.Size(120, 22);
            this.numVolFile2.TabIndex = 14;
            this.numVolFile2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblVolFile1
            // 
            this.lblVolFile1.AutoSize = true;
            this.lblVolFile1.Location = new System.Drawing.Point(17, 118);
            this.lblVolFile1.Name = "lblVolFile1";
            this.lblVolFile1.Size = new System.Drawing.Size(158, 17);
            this.lblVolFile1.TabIndex = 13;
            this.lblVolFile1.Text = "Громкость 1-го файла:";
            // 
            // numVolFile1
            // 
            this.numVolFile1.DecimalPlaces = 2;
            this.numVolFile1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numVolFile1.Location = new System.Drawing.Point(181, 116);
            this.numVolFile1.Name = "numVolFile1";
            this.numVolFile1.Size = new System.Drawing.Size(120, 22);
            this.numVolFile1.TabIndex = 12;
            this.numVolFile1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblAudioMode
            // 
            this.lblAudioMode.AutoSize = true;
            this.lblAudioMode.Location = new System.Drawing.Point(30, 86);
            this.lblAudioMode.Name = "lblAudioMode";
            this.lblAudioMode.Size = new System.Drawing.Size(98, 17);
            this.lblAudioMode.TabIndex = 11;
            this.lblAudioMode.Text = "Режим аудио:";
            // 
            // cmbAudioMode
            // 
            this.cmbAudioMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAudioMode.FormattingEnabled = true;
            this.cmbAudioMode.Items.AddRange(new object[] {
            "Моно",
            "Стерео"});
            this.cmbAudioMode.Location = new System.Drawing.Point(134, 83);
            this.cmbAudioMode.Name = "cmbAudioMode";
            this.cmbAudioMode.Size = new System.Drawing.Size(167, 24);
            this.cmbAudioMode.TabIndex = 10;
            // 
            // btnMixFileResult
            // 
            this.btnMixFileResult.Location = new System.Drawing.Point(226, 172);
            this.btnMixFileResult.Name = "btnMixFileResult";
            this.btnMixFileResult.Size = new System.Drawing.Size(75, 23);
            this.btnMixFileResult.TabIndex = 7;
            this.btnMixFileResult.Text = "...";
            this.btnMixFileResult.UseVisualStyleBackColor = true;
            this.btnMixFileResult.Click += new System.EventHandler(this.btnMixFileResult_Click);
            // 
            // txbMixFileResult
            // 
            this.txbMixFileResult.Location = new System.Drawing.Point(6, 173);
            this.txbMixFileResult.Name = "txbMixFileResult";
            this.txbMixFileResult.Size = new System.Drawing.Size(214, 22);
            this.txbMixFileResult.TabIndex = 6;
            this.txbMixFileResult.Text = "Папка для сохранения";
            // 
            // btnMix
            // 
            this.btnMix.Location = new System.Drawing.Point(6, 201);
            this.btnMix.Name = "btnMix";
            this.btnMix.Size = new System.Drawing.Size(295, 35);
            this.btnMix.TabIndex = 5;
            this.btnMix.Text = "Микшировать";
            this.btnMix.UseVisualStyleBackColor = true;
            this.btnMix.Click += new System.EventHandler(this.btnMix_Click);
            // 
            // btnMixFile2
            // 
            this.btnMixFile2.Location = new System.Drawing.Point(226, 21);
            this.btnMixFile2.Name = "btnMixFile2";
            this.btnMixFile2.Size = new System.Drawing.Size(75, 23);
            this.btnMixFile2.TabIndex = 4;
            this.btnMixFile2.Text = "...";
            this.btnMixFile2.UseVisualStyleBackColor = true;
            this.btnMixFile2.Click += new System.EventHandler(this.btnMixFile2_Click);
            // 
            // txbMixFile2
            // 
            this.txbMixFile2.Location = new System.Drawing.Point(6, 22);
            this.txbMixFile2.Name = "txbMixFile2";
            this.txbMixFile2.Size = new System.Drawing.Size(214, 22);
            this.txbMixFile2.TabIndex = 3;
            this.txbMixFile2.Text = "Файл для наложения";
            // 
            // tabSED
            // 
            this.tabSED.Controls.Add(this.groupCompare);
            this.tabSED.Controls.Add(this.groupPlay);
            this.tabSED.Controls.Add(this.groupAutocorrelation);
            this.tabSED.Controls.Add(this.groupNormalDistSED);
            this.tabSED.Controls.Add(this.groupShortTimeFeatures);
            this.tabSED.Location = new System.Drawing.Point(4, 25);
            this.tabSED.Name = "tabSED";
            this.tabSED.Padding = new System.Windows.Forms.Padding(3);
            this.tabSED.Size = new System.Drawing.Size(996, 345);
            this.tabSED.TabIndex = 1;
            this.tabSED.Text = "Sound Event Detection";
            this.tabSED.UseVisualStyleBackColor = true;
            // 
            // groupCompare
            // 
            this.groupCompare.Controls.Add(this.lblAlgorithm);
            this.groupCompare.Controls.Add(this.cmbAlgorithm);
            this.groupCompare.Controls.Add(this.btnOpenCompare);
            this.groupCompare.Controls.Add(this.txbCompareFile);
            this.groupCompare.Controls.Add(this.btnStartCompare);
            this.groupCompare.Controls.Add(this.btnOpenEtalon);
            this.groupCompare.Controls.Add(this.txbEtalon);
            this.groupCompare.Location = new System.Drawing.Point(333, 169);
            this.groupCompare.Name = "groupCompare";
            this.groupCompare.Size = new System.Drawing.Size(321, 170);
            this.groupCompare.TabIndex = 51;
            this.groupCompare.TabStop = false;
            this.groupCompare.Text = "Оценка работы алгоритма";
            // 
            // lblAlgorithm
            // 
            this.lblAlgorithm.AutoSize = true;
            this.lblAlgorithm.Location = new System.Drawing.Point(7, 80);
            this.lblAlgorithm.Name = "lblAlgorithm";
            this.lblAlgorithm.Size = new System.Drawing.Size(143, 17);
            this.lblAlgorithm.TabIndex = 14;
            this.lblAlgorithm.Text = "Выберите алгоритм:";
            // 
            // cmbAlgorithm
            // 
            this.cmbAlgorithm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAlgorithm.FormattingEnabled = true;
            this.cmbAlgorithm.Items.AddRange(new object[] {
            "Energy Feature + Zero Cross #1",
            "Statistic Features",
            "Autocorrelation"});
            this.cmbAlgorithm.Location = new System.Drawing.Point(7, 105);
            this.cmbAlgorithm.Name = "cmbAlgorithm";
            this.cmbAlgorithm.Size = new System.Drawing.Size(307, 24);
            this.cmbAlgorithm.TabIndex = 13;
            // 
            // btnOpenCompare
            // 
            this.btnOpenCompare.Location = new System.Drawing.Point(226, 51);
            this.btnOpenCompare.Name = "btnOpenCompare";
            this.btnOpenCompare.Size = new System.Drawing.Size(89, 23);
            this.btnOpenCompare.TabIndex = 12;
            this.btnOpenCompare.Text = "...";
            this.btnOpenCompare.UseVisualStyleBackColor = true;
            this.btnOpenCompare.Click += new System.EventHandler(this.btnOpenCompare_Click);
            // 
            // txbCompareFile
            // 
            this.txbCompareFile.Location = new System.Drawing.Point(6, 51);
            this.txbCompareFile.Name = "txbCompareFile";
            this.txbCompareFile.Size = new System.Drawing.Size(214, 22);
            this.txbCompareFile.TabIndex = 11;
            this.txbCompareFile.Text = "Файл для сравнения";
            // 
            // btnStartCompare
            // 
            this.btnStartCompare.Location = new System.Drawing.Point(7, 135);
            this.btnStartCompare.Name = "btnStartCompare";
            this.btnStartCompare.Size = new System.Drawing.Size(309, 29);
            this.btnStartCompare.TabIndex = 10;
            this.btnStartCompare.Text = "Оценить";
            this.btnStartCompare.UseVisualStyleBackColor = true;
            this.btnStartCompare.Click += new System.EventHandler(this.btnStartCompare_Click);
            // 
            // btnOpenEtalon
            // 
            this.btnOpenEtalon.Location = new System.Drawing.Point(226, 22);
            this.btnOpenEtalon.Name = "btnOpenEtalon";
            this.btnOpenEtalon.Size = new System.Drawing.Size(89, 23);
            this.btnOpenEtalon.TabIndex = 9;
            this.btnOpenEtalon.Text = "...";
            this.btnOpenEtalon.UseVisualStyleBackColor = true;
            this.btnOpenEtalon.Click += new System.EventHandler(this.btnOpenEtalon_Click);
            // 
            // txbEtalon
            // 
            this.txbEtalon.Location = new System.Drawing.Point(6, 22);
            this.txbEtalon.Name = "txbEtalon";
            this.txbEtalon.Size = new System.Drawing.Size(214, 22);
            this.txbEtalon.TabIndex = 8;
            this.txbEtalon.Text = "Файл эталон";
            // 
            // groupPlay
            // 
            this.groupPlay.Controls.Add(this.lblPlaySection);
            this.groupPlay.Controls.Add(this.btnPlay);
            this.groupPlay.Location = new System.Drawing.Point(6, 202);
            this.groupPlay.Name = "groupPlay";
            this.groupPlay.Size = new System.Drawing.Size(321, 88);
            this.groupPlay.TabIndex = 50;
            this.groupPlay.TabStop = false;
            this.groupPlay.Text = "Прослушать";
            // 
            // lblPlaySection
            // 
            this.lblPlaySection.AutoSize = true;
            this.lblPlaySection.Location = new System.Drawing.Point(6, 18);
            this.lblPlaySection.Name = "lblPlaySection";
            this.lblPlaySection.Size = new System.Drawing.Size(139, 17);
            this.lblPlaySection.TabIndex = 46;
            this.lblPlaySection.Text = "Начало: 0, Конец: 0";
            // 
            // btnPlay
            // 
            this.btnPlay.Enabled = false;
            this.btnPlay.Location = new System.Drawing.Point(9, 49);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(303, 29);
            this.btnPlay.TabIndex = 45;
            this.btnPlay.Text = "Прослушать";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // groupAutocorrelation
            // 
            this.groupAutocorrelation.Controls.Add(this.numWindowSizeAutocor);
            this.groupAutocorrelation.Controls.Add(this.lblWindowSizeAutocor);
            this.groupAutocorrelation.Controls.Add(this.numFrameSizeAutocor);
            this.groupAutocorrelation.Controls.Add(this.lblFrameSizeAutocor);
            this.groupAutocorrelation.Controls.Add(this.btnAutocorrelation);
            this.groupAutocorrelation.Controls.Add(this.numCountFrameAutocor);
            this.groupAutocorrelation.Controls.Add(this.lblCountFrameAutocor);
            this.groupAutocorrelation.Controls.Add(this.numSizeFilterAutocor);
            this.groupAutocorrelation.Controls.Add(this.lblSizeFilterAutocor);
            this.groupAutocorrelation.Location = new System.Drawing.Point(660, 6);
            this.groupAutocorrelation.Name = "groupAutocorrelation";
            this.groupAutocorrelation.Size = new System.Drawing.Size(321, 173);
            this.groupAutocorrelation.TabIndex = 48;
            this.groupAutocorrelation.TabStop = false;
            this.groupAutocorrelation.Text = "Автокорреляция";
            // 
            // numWindowSizeAutocor
            // 
            this.numWindowSizeAutocor.Location = new System.Drawing.Point(213, 14);
            this.numWindowSizeAutocor.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numWindowSizeAutocor.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numWindowSizeAutocor.Name = "numWindowSizeAutocor";
            this.numWindowSizeAutocor.Size = new System.Drawing.Size(102, 22);
            this.numWindowSizeAutocor.TabIndex = 47;
            this.numWindowSizeAutocor.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblWindowSizeAutocor
            // 
            this.lblWindowSizeAutocor.AutoSize = true;
            this.lblWindowSizeAutocor.Location = new System.Drawing.Point(80, 16);
            this.lblWindowSizeAutocor.Name = "lblWindowSizeAutocor";
            this.lblWindowSizeAutocor.Size = new System.Drawing.Size(126, 17);
            this.lblWindowSizeAutocor.TabIndex = 48;
            this.lblWindowSizeAutocor.Text = "Размер окна (мс):";
            // 
            // numFrameSizeAutocor
            // 
            this.numFrameSizeAutocor.Location = new System.Drawing.Point(213, 42);
            this.numFrameSizeAutocor.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numFrameSizeAutocor.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numFrameSizeAutocor.Name = "numFrameSizeAutocor";
            this.numFrameSizeAutocor.Size = new System.Drawing.Size(102, 22);
            this.numFrameSizeAutocor.TabIndex = 45;
            this.numFrameSizeAutocor.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // lblFrameSizeAutocor
            // 
            this.lblFrameSizeAutocor.AutoSize = true;
            this.lblFrameSizeAutocor.Location = new System.Drawing.Point(80, 44);
            this.lblFrameSizeAutocor.Name = "lblFrameSizeAutocor";
            this.lblFrameSizeAutocor.Size = new System.Drawing.Size(134, 17);
            this.lblFrameSizeAutocor.TabIndex = 46;
            this.lblFrameSizeAutocor.Text = "Размер кадра (мс):";
            // 
            // btnAutocorrelation
            // 
            this.btnAutocorrelation.Location = new System.Drawing.Point(6, 138);
            this.btnAutocorrelation.Name = "btnAutocorrelation";
            this.btnAutocorrelation.Size = new System.Drawing.Size(309, 29);
            this.btnAutocorrelation.TabIndex = 44;
            this.btnAutocorrelation.Text = "Старт";
            this.btnAutocorrelation.UseVisualStyleBackColor = true;
            this.btnAutocorrelation.Click += new System.EventHandler(this.btnAutocorrelation_Click);
            // 
            // numCountFrameAutocor
            // 
            this.numCountFrameAutocor.Location = new System.Drawing.Point(213, 78);
            this.numCountFrameAutocor.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numCountFrameAutocor.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCountFrameAutocor.Name = "numCountFrameAutocor";
            this.numCountFrameAutocor.Size = new System.Drawing.Size(102, 22);
            this.numCountFrameAutocor.TabIndex = 42;
            this.numCountFrameAutocor.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // lblCountFrameAutocor
            // 
            this.lblCountFrameAutocor.Location = new System.Drawing.Point(33, 68);
            this.lblCountFrameAutocor.Name = "lblCountFrameAutocor";
            this.lblCountFrameAutocor.Size = new System.Drawing.Size(174, 35);
            this.lblCountFrameAutocor.TabIndex = 43;
            this.lblCountFrameAutocor.Text = "Размер окна для адаптации порогов (мс):";
            // 
            // numSizeFilterAutocor
            // 
            this.numSizeFilterAutocor.Location = new System.Drawing.Point(213, 106);
            this.numSizeFilterAutocor.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numSizeFilterAutocor.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSizeFilterAutocor.Name = "numSizeFilterAutocor";
            this.numSizeFilterAutocor.Size = new System.Drawing.Size(102, 22);
            this.numSizeFilterAutocor.TabIndex = 40;
            this.numSizeFilterAutocor.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // lblSizeFilterAutocor
            // 
            this.lblSizeFilterAutocor.AutoSize = true;
            this.lblSizeFilterAutocor.Location = new System.Drawing.Point(84, 108);
            this.lblSizeFilterAutocor.Name = "lblSizeFilterAutocor";
            this.lblSizeFilterAutocor.Size = new System.Drawing.Size(122, 17);
            this.lblSizeFilterAutocor.TabIndex = 41;
            this.lblSizeFilterAutocor.Text = "Размер фильтра:";
            // 
            // groupNormalDistSED
            // 
            this.groupNormalDistSED.Controls.Add(this.numFrameSizeND);
            this.groupNormalDistSED.Controls.Add(this.lblFrameSizeND);
            this.groupNormalDistSED.Controls.Add(this.btnNormalDistribution);
            this.groupNormalDistSED.Controls.Add(this.numCountFrameND);
            this.groupNormalDistSED.Controls.Add(this.lblCountFrameND);
            this.groupNormalDistSED.Controls.Add(this.numSizeFilterND);
            this.groupNormalDistSED.Controls.Add(this.lblSizeFilterND);
            this.groupNormalDistSED.Location = new System.Drawing.Point(333, 6);
            this.groupNormalDistSED.Name = "groupNormalDistSED";
            this.groupNormalDistSED.Size = new System.Drawing.Size(321, 157);
            this.groupNormalDistSED.TabIndex = 47;
            this.groupNormalDistSED.TabStop = false;
            this.groupNormalDistSED.Text = "Нормальное распределение";
            // 
            // numFrameSizeND
            // 
            this.numFrameSizeND.Location = new System.Drawing.Point(213, 28);
            this.numFrameSizeND.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numFrameSizeND.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numFrameSizeND.Name = "numFrameSizeND";
            this.numFrameSizeND.Size = new System.Drawing.Size(102, 22);
            this.numFrameSizeND.TabIndex = 45;
            this.numFrameSizeND.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // lblFrameSizeND
            // 
            this.lblFrameSizeND.AutoSize = true;
            this.lblFrameSizeND.Location = new System.Drawing.Point(80, 30);
            this.lblFrameSizeND.Name = "lblFrameSizeND";
            this.lblFrameSizeND.Size = new System.Drawing.Size(126, 17);
            this.lblFrameSizeND.TabIndex = 46;
            this.lblFrameSizeND.Text = "Размер окна (мс):";
            // 
            // btnNormalDistribution
            // 
            this.btnNormalDistribution.Location = new System.Drawing.Point(7, 120);
            this.btnNormalDistribution.Name = "btnNormalDistribution";
            this.btnNormalDistribution.Size = new System.Drawing.Size(308, 29);
            this.btnNormalDistribution.TabIndex = 44;
            this.btnNormalDistribution.Text = "Старт";
            this.btnNormalDistribution.UseVisualStyleBackColor = true;
            this.btnNormalDistribution.Click += new System.EventHandler(this.btnNormalDistribution_Click);
            // 
            // numCountFrameND
            // 
            this.numCountFrameND.Location = new System.Drawing.Point(213, 64);
            this.numCountFrameND.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numCountFrameND.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCountFrameND.Name = "numCountFrameND";
            this.numCountFrameND.Size = new System.Drawing.Size(102, 22);
            this.numCountFrameND.TabIndex = 42;
            this.numCountFrameND.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // lblCountFrameND
            // 
            this.lblCountFrameND.Location = new System.Drawing.Point(33, 54);
            this.lblCountFrameND.Name = "lblCountFrameND";
            this.lblCountFrameND.Size = new System.Drawing.Size(174, 35);
            this.lblCountFrameND.TabIndex = 43;
            this.lblCountFrameND.Text = "Размер окна для адаптации порогов (мс):";
            // 
            // numSizeFilterND
            // 
            this.numSizeFilterND.Location = new System.Drawing.Point(213, 92);
            this.numSizeFilterND.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numSizeFilterND.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSizeFilterND.Name = "numSizeFilterND";
            this.numSizeFilterND.Size = new System.Drawing.Size(102, 22);
            this.numSizeFilterND.TabIndex = 40;
            this.numSizeFilterND.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // lblSizeFilterND
            // 
            this.lblSizeFilterND.AutoSize = true;
            this.lblSizeFilterND.Location = new System.Drawing.Point(84, 94);
            this.lblSizeFilterND.Name = "lblSizeFilterND";
            this.lblSizeFilterND.Size = new System.Drawing.Size(122, 17);
            this.lblSizeFilterND.TabIndex = 41;
            this.lblSizeFilterND.Text = "Размер фильтра:";
            // 
            // groupShortTimeFeatures
            // 
            this.groupShortTimeFeatures.Controls.Add(this.numFrameSizeSTF);
            this.groupShortTimeFeatures.Controls.Add(this.lblFrameSizeSTF);
            this.groupShortTimeFeatures.Controls.Add(this.btnShortTimeFeatures);
            this.groupShortTimeFeatures.Controls.Add(this.numCountFrameSTF);
            this.groupShortTimeFeatures.Controls.Add(this.lblCountFrameSTF);
            this.groupShortTimeFeatures.Controls.Add(this.cmbTypeSTF);
            this.groupShortTimeFeatures.Controls.Add(this.numSizeFilterSTF);
            this.groupShortTimeFeatures.Controls.Add(this.lblSizeFilterSTF);
            this.groupShortTimeFeatures.Location = new System.Drawing.Point(6, 6);
            this.groupShortTimeFeatures.Name = "groupShortTimeFeatures";
            this.groupShortTimeFeatures.Size = new System.Drawing.Size(321, 190);
            this.groupShortTimeFeatures.TabIndex = 44;
            this.groupShortTimeFeatures.TabStop = false;
            this.groupShortTimeFeatures.Text = "Кратковременные характеристики";
            // 
            // numFrameSizeSTF
            // 
            this.numFrameSizeSTF.Location = new System.Drawing.Point(213, 28);
            this.numFrameSizeSTF.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numFrameSizeSTF.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numFrameSizeSTF.Name = "numFrameSizeSTF";
            this.numFrameSizeSTF.Size = new System.Drawing.Size(102, 22);
            this.numFrameSizeSTF.TabIndex = 45;
            this.numFrameSizeSTF.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // lblFrameSizeSTF
            // 
            this.lblFrameSizeSTF.AutoSize = true;
            this.lblFrameSizeSTF.Location = new System.Drawing.Point(80, 30);
            this.lblFrameSizeSTF.Name = "lblFrameSizeSTF";
            this.lblFrameSizeSTF.Size = new System.Drawing.Size(126, 17);
            this.lblFrameSizeSTF.TabIndex = 46;
            this.lblFrameSizeSTF.Text = "Размер окна (мс):";
            // 
            // btnShortTimeFeatures
            // 
            this.btnShortTimeFeatures.Location = new System.Drawing.Point(7, 152);
            this.btnShortTimeFeatures.Name = "btnShortTimeFeatures";
            this.btnShortTimeFeatures.Size = new System.Drawing.Size(308, 29);
            this.btnShortTimeFeatures.TabIndex = 44;
            this.btnShortTimeFeatures.Text = "Старт";
            this.btnShortTimeFeatures.UseVisualStyleBackColor = true;
            this.btnShortTimeFeatures.Click += new System.EventHandler(this.btnShortTimeFeatures_Click);
            // 
            // numCountFrameSTF
            // 
            this.numCountFrameSTF.Location = new System.Drawing.Point(213, 64);
            this.numCountFrameSTF.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numCountFrameSTF.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCountFrameSTF.Name = "numCountFrameSTF";
            this.numCountFrameSTF.Size = new System.Drawing.Size(102, 22);
            this.numCountFrameSTF.TabIndex = 42;
            this.numCountFrameSTF.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // lblCountFrameSTF
            // 
            this.lblCountFrameSTF.Location = new System.Drawing.Point(59, 54);
            this.lblCountFrameSTF.Name = "lblCountFrameSTF";
            this.lblCountFrameSTF.Size = new System.Drawing.Size(148, 35);
            this.lblCountFrameSTF.TabIndex = 43;
            this.lblCountFrameSTF.Text = "Кол-во кадров для адаптации порогов:";
            // 
            // cmbTypeSTF
            // 
            this.cmbTypeSTF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTypeSTF.FormattingEnabled = true;
            this.cmbTypeSTF.Items.AddRange(new object[] {
            "Energy Feature + Zero Cross #1",
            "Energy Feature + Zero Cross #2",
            "Energy Feature + Zero Cross + Most dominant frequency"});
            this.cmbTypeSTF.Location = new System.Drawing.Point(7, 122);
            this.cmbTypeSTF.Name = "cmbTypeSTF";
            this.cmbTypeSTF.Size = new System.Drawing.Size(308, 24);
            this.cmbTypeSTF.TabIndex = 0;
            // 
            // numSizeFilterSTF
            // 
            this.numSizeFilterSTF.Location = new System.Drawing.Point(213, 92);
            this.numSizeFilterSTF.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numSizeFilterSTF.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSizeFilterSTF.Name = "numSizeFilterSTF";
            this.numSizeFilterSTF.Size = new System.Drawing.Size(102, 22);
            this.numSizeFilterSTF.TabIndex = 40;
            this.numSizeFilterSTF.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // lblSizeFilterSTF
            // 
            this.lblSizeFilterSTF.AutoSize = true;
            this.lblSizeFilterSTF.Location = new System.Drawing.Point(84, 94);
            this.lblSizeFilterSTF.Name = "lblSizeFilterSTF";
            this.lblSizeFilterSTF.Size = new System.Drawing.Size(122, 17);
            this.lblSizeFilterSTF.TabIndex = 41;
            this.lblSizeFilterSTF.Text = "Размер фильтра:";
            // 
            // Mixer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 619);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.graphControl);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Mixer";
            this.Text = "Микширование аудиофайлов";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Mixer_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabMixer.ResumeLayout(false);
            this.groupExtractWav.ResumeLayout(false);
            this.groupExtractWav.PerformLayout();
            this.groupMixer.ResumeLayout(false);
            this.groupMixer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMix2FileAtSecond)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVolFile2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVolFile1)).EndInit();
            this.tabSED.ResumeLayout(false);
            this.groupCompare.ResumeLayout(false);
            this.groupCompare.PerformLayout();
            this.groupPlay.ResumeLayout(false);
            this.groupPlay.PerformLayout();
            this.groupAutocorrelation.ResumeLayout(false);
            this.groupAutocorrelation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWindowSizeAutocor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFrameSizeAutocor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCountFrameAutocor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSizeFilterAutocor)).EndInit();
            this.groupNormalDistSED.ResumeLayout(false);
            this.groupNormalDistSED.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFrameSizeND)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCountFrameND)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSizeFilterND)).EndInit();
            this.groupShortTimeFeatures.ResumeLayout(false);
            this.groupShortTimeFeatures.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFrameSizeSTF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCountFrameSTF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSizeFilterSTF)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ZedGraph.ZedGraphControl graphControl;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem менюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnOpen;
        private System.Windows.Forms.ToolStripMenuItem btnClose;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabMixer;
        private System.Windows.Forms.TabPage tabSED;
        private System.Windows.Forms.GroupBox groupExtractWav;
        private System.Windows.Forms.Button btnPathSaveWave;
        private System.Windows.Forms.TextBox txbPathSaveWave;
        private System.Windows.Forms.Button btnExtract;
        private System.Windows.Forms.Button btnPathVideo;
        private System.Windows.Forms.TextBox txbPathVideo;
        private System.Windows.Forms.GroupBox groupMixer;
        private System.Windows.Forms.Label lblVolFile2;
        private System.Windows.Forms.NumericUpDown numVolFile2;
        private System.Windows.Forms.Label lblVolFile1;
        private System.Windows.Forms.NumericUpDown numVolFile1;
        private System.Windows.Forms.Label lblAudioMode;
        private System.Windows.Forms.ComboBox cmbAudioMode;
        private System.Windows.Forms.Button btnMixFileResult;
        private System.Windows.Forms.TextBox txbMixFileResult;
        private System.Windows.Forms.Button btnMix;
        private System.Windows.Forms.Button btnMixFile2;
        private System.Windows.Forms.TextBox txbMixFile2;
        private System.Windows.Forms.Label lblMix2FileAtSecond;
        private System.Windows.Forms.NumericUpDown numMix2FileAtSecond;
        private System.Windows.Forms.GroupBox groupShortTimeFeatures;
        private System.Windows.Forms.NumericUpDown numCountFrameSTF;
        private System.Windows.Forms.Label lblCountFrameSTF;
        private System.Windows.Forms.ComboBox cmbTypeSTF;
        private System.Windows.Forms.NumericUpDown numSizeFilterSTF;
        private System.Windows.Forms.Label lblSizeFilterSTF;
        private System.Windows.Forms.Button btnShortTimeFeatures;
        private System.Windows.Forms.NumericUpDown numFrameSizeSTF;
        private System.Windows.Forms.Label lblFrameSizeSTF;
        private System.Windows.Forms.GroupBox groupNormalDistSED;
        private System.Windows.Forms.NumericUpDown numFrameSizeND;
        private System.Windows.Forms.Label lblFrameSizeND;
        private System.Windows.Forms.Button btnNormalDistribution;
        private System.Windows.Forms.NumericUpDown numCountFrameND;
        private System.Windows.Forms.Label lblCountFrameND;
        private System.Windows.Forms.NumericUpDown numSizeFilterND;
        private System.Windows.Forms.Label lblSizeFilterND;
        private System.Windows.Forms.GroupBox groupAutocorrelation;
        private System.Windows.Forms.NumericUpDown numFrameSizeAutocor;
        private System.Windows.Forms.Label lblFrameSizeAutocor;
        private System.Windows.Forms.Button btnAutocorrelation;
        private System.Windows.Forms.NumericUpDown numCountFrameAutocor;
        private System.Windows.Forms.Label lblCountFrameAutocor;
        private System.Windows.Forms.NumericUpDown numSizeFilterAutocor;
        private System.Windows.Forms.Label lblSizeFilterAutocor;
        private System.Windows.Forms.NumericUpDown numWindowSizeAutocor;
        private System.Windows.Forms.Label lblWindowSizeAutocor;
        private System.Windows.Forms.GroupBox groupPlay;
        private System.Windows.Forms.Label lblPlaySection;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.ToolStripMenuItem btnChartsStatistics;
        private System.Windows.Forms.GroupBox groupCompare;
        private System.Windows.Forms.Button btnOpenCompare;
        private System.Windows.Forms.TextBox txbCompareFile;
        private System.Windows.Forms.Button btnStartCompare;
        private System.Windows.Forms.Button btnOpenEtalon;
        private System.Windows.Forms.TextBox txbEtalon;
        private System.Windows.Forms.Label lblAlgorithm;
        private System.Windows.Forms.ComboBox cmbAlgorithm;
    }
}