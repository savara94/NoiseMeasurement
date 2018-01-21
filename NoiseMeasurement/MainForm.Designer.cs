namespace NoiseMeasurement
{
    partial class MainForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea21 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series17 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title21 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea22 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series18 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title22 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea24 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series19 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title24 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea23 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Title title23 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea25 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series20 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title25 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageMain = new System.Windows.Forms.TabPage();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.comboBoxTimeWeight = new System.Windows.Forms.ComboBox();
            this.lblDoseValue = new System.Windows.Forms.Label();
            this.lblTWAValue = new System.Windows.Forms.Label();
            this.lblLavgValue = new System.Windows.Forms.Label();
            this.lblLeqValue = new System.Windows.Forms.Label();
            this.lblNoiseDose = new System.Windows.Forms.Label();
            this.lblTWA = new System.Windows.Forms.Label();
            this.lblLavg = new System.Windows.Forms.Label();
            this.lblLeq = new System.Windows.Forms.Label();
            this.lblNoise = new System.Windows.Forms.Label();
            this.vuMeter = new VU_MeterLibrary.VuMeter();
            this.timeDomain = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPageWeightFilters = new System.Windows.Forms.TabPage();
            this.splitContainerFilters = new System.Windows.Forms.SplitContainer();
            this.groupBoxFilters = new System.Windows.Forms.GroupBox();
            this.radioCfilter = new System.Windows.Forms.RadioButton();
            this.radioAfilter = new System.Windows.Forms.RadioButton();
            this.radioNone = new System.Windows.Forms.RadioButton();
            this.freqDomain = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPageOctaveFilters = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.octaveFreqDomain = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblCenterFrequency = new System.Windows.Forms.Label();
            this.comboBoxFreq = new System.Windows.Forms.ComboBox();
            this.radioBtnThirdOctave = new System.Windows.Forms.RadioButton();
            this.radioBtnOctave = new System.Windows.Forms.RadioButton();
            this.octavesVisualisation = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPageSensors = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.gMap = new GMap.NET.WindowsForms.GMapControl();
            this.sensorReadings = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calibrateToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.btnPlay = new System.Windows.Forms.ToolStripButton();
            this.btnPause = new System.Windows.Forms.ToolStripButton();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.tabControl.SuspendLayout();
            this.tabPageMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeDomain)).BeginInit();
            this.tabPageWeightFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerFilters)).BeginInit();
            this.splitContainerFilters.Panel1.SuspendLayout();
            this.splitContainerFilters.Panel2.SuspendLayout();
            this.splitContainerFilters.SuspendLayout();
            this.groupBoxFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.freqDomain)).BeginInit();
            this.tabPageOctaveFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.octaveFreqDomain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.octavesVisualisation)).BeginInit();
            this.tabPageSensors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sensorReadings)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabPageMain);
            this.tabControl.Controls.Add(this.tabPageWeightFilters);
            this.tabControl.Controls.Add(this.tabPageOctaveFilters);
            this.tabControl.Controls.Add(this.tabPageSensors);
            this.tabControl.Location = new System.Drawing.Point(0, 50);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(624, 468);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageMain
            // 
            this.tabPageMain.Controls.Add(this.splitContainer);
            this.tabPageMain.Location = new System.Drawing.Point(4, 22);
            this.tabPageMain.Name = "tabPageMain";
            this.tabPageMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMain.Size = new System.Drawing.Size(616, 442);
            this.tabPageMain.TabIndex = 0;
            this.tabPageMain.Text = "Main";
            this.tabPageMain.UseVisualStyleBackColor = true;
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(3, 3);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.comboBoxTimeWeight);
            this.splitContainer.Panel1.Controls.Add(this.lblDoseValue);
            this.splitContainer.Panel1.Controls.Add(this.lblTWAValue);
            this.splitContainer.Panel1.Controls.Add(this.lblLavgValue);
            this.splitContainer.Panel1.Controls.Add(this.lblLeqValue);
            this.splitContainer.Panel1.Controls.Add(this.lblNoiseDose);
            this.splitContainer.Panel1.Controls.Add(this.lblTWA);
            this.splitContainer.Panel1.Controls.Add(this.lblLavg);
            this.splitContainer.Panel1.Controls.Add(this.lblLeq);
            this.splitContainer.Panel1.Controls.Add(this.lblNoise);
            this.splitContainer.Panel1.Controls.Add(this.vuMeter);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.timeDomain);
            this.splitContainer.Size = new System.Drawing.Size(610, 436);
            this.splitContainer.SplitterDistance = 222;
            this.splitContainer.TabIndex = 4;
            // 
            // comboBoxTimeWeight
            // 
            this.comboBoxTimeWeight.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTimeWeight.FormattingEnabled = true;
            this.comboBoxTimeWeight.Items.AddRange(new object[] {
            "Slow (1000 ms)",
            "Fast (125 ms)",
            "Impulse (35 ms)"});
            this.comboBoxTimeWeight.Location = new System.Drawing.Point(312, 42);
            this.comboBoxTimeWeight.Name = "comboBoxTimeWeight";
            this.comboBoxTimeWeight.Size = new System.Drawing.Size(121, 21);
            this.comboBoxTimeWeight.TabIndex = 13;
            this.comboBoxTimeWeight.SelectedIndexChanged += new System.EventHandler(this.comboBoxTimeWeight_SelectedIndexChanged);
            // 
            // lblDoseValue
            // 
            this.lblDoseValue.AutoSize = true;
            this.lblDoseValue.Location = new System.Drawing.Point(374, 128);
            this.lblDoseValue.Name = "lblDoseValue";
            this.lblDoseValue.Size = new System.Drawing.Size(24, 13);
            this.lblDoseValue.TabIndex = 12;
            this.lblDoseValue.Text = "0 %";
            // 
            // lblTWAValue
            // 
            this.lblTWAValue.AutoSize = true;
            this.lblTWAValue.Location = new System.Drawing.Point(374, 105);
            this.lblTWAValue.Name = "lblTWAValue";
            this.lblTWAValue.Size = new System.Drawing.Size(51, 13);
            this.lblTWAValue.TabIndex = 11;
            this.lblTWAValue.Text = "0 dB/day";
            // 
            // lblLavgValue
            // 
            this.lblLavgValue.AutoSize = true;
            this.lblLavgValue.Location = new System.Drawing.Point(374, 81);
            this.lblLavgValue.Name = "lblLavgValue";
            this.lblLavgValue.Size = new System.Drawing.Size(29, 13);
            this.lblLavgValue.TabIndex = 10;
            this.lblLavgValue.Text = "0 dB";
            // 
            // lblLeqValue
            // 
            this.lblLeqValue.AutoSize = true;
            this.lblLeqValue.Location = new System.Drawing.Point(374, 14);
            this.lblLeqValue.Name = "lblLeqValue";
            this.lblLeqValue.Size = new System.Drawing.Size(29, 13);
            this.lblLeqValue.TabIndex = 9;
            this.lblLeqValue.Text = "0 dB";
            // 
            // lblNoiseDose
            // 
            this.lblNoiseDose.AutoSize = true;
            this.lblNoiseDose.Location = new System.Drawing.Point(309, 128);
            this.lblNoiseDose.Name = "lblNoiseDose";
            this.lblNoiseDose.Size = new System.Drawing.Size(63, 13);
            this.lblNoiseDose.TabIndex = 8;
            this.lblNoiseDose.Text = "Noise dose:";
            // 
            // lblTWA
            // 
            this.lblTWA.AutoSize = true;
            this.lblTWA.Location = new System.Drawing.Point(309, 105);
            this.lblTWA.Name = "lblTWA";
            this.lblTWA.Size = new System.Drawing.Size(35, 13);
            this.lblTWA.TabIndex = 7;
            this.lblTWA.Text = "TWA:";
            // 
            // lblLavg
            // 
            this.lblLavg.AutoSize = true;
            this.lblLavg.Location = new System.Drawing.Point(309, 81);
            this.lblLavg.Name = "lblLavg";
            this.lblLavg.Size = new System.Drawing.Size(34, 13);
            this.lblLavg.TabIndex = 6;
            this.lblLavg.Text = "Lavg:";
            // 
            // lblLeq
            // 
            this.lblLeq.AutoSize = true;
            this.lblLeq.Location = new System.Drawing.Point(309, 14);
            this.lblLeq.Name = "lblLeq";
            this.lblLeq.Size = new System.Drawing.Size(28, 13);
            this.lblLeq.TabIndex = 5;
            this.lblLeq.Text = "Leq:";
            // 
            // lblNoise
            // 
            this.lblNoise.AutoSize = true;
            this.lblNoise.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoise.Location = new System.Drawing.Point(111, 138);
            this.lblNoise.Name = "lblNoise";
            this.lblNoise.Size = new System.Drawing.Size(36, 39);
            this.lblNoise.TabIndex = 4;
            this.lblNoise.Text = "0";
            this.lblNoise.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // vuMeter
            // 
            this.vuMeter.AnalogMeter = true;
            this.vuMeter.BackColor = System.Drawing.Color.LightGray;
            this.vuMeter.DialBackground = System.Drawing.Color.LightGray;
            this.vuMeter.DialTextNegative = System.Drawing.Color.Red;
            this.vuMeter.DialTextPositive = System.Drawing.Color.Black;
            this.vuMeter.DialTextZero = System.Drawing.Color.DarkGreen;
            this.vuMeter.Led1ColorOff = System.Drawing.Color.DarkGreen;
            this.vuMeter.Led1ColorOn = System.Drawing.Color.LimeGreen;
            this.vuMeter.Led1Count = 6;
            this.vuMeter.Led2ColorOff = System.Drawing.Color.Olive;
            this.vuMeter.Led2ColorOn = System.Drawing.Color.Yellow;
            this.vuMeter.Led2Count = 6;
            this.vuMeter.Led3ColorOff = System.Drawing.Color.Maroon;
            this.vuMeter.Led3ColorOn = System.Drawing.Color.Red;
            this.vuMeter.Led3Count = 4;
            this.vuMeter.LedSize = new System.Drawing.Size(6, 14);
            this.vuMeter.LedSpace = 3;
            this.vuMeter.Level = 0;
            this.vuMeter.LevelMax = 140;
            this.vuMeter.Location = new System.Drawing.Point(3, 3);
            this.vuMeter.MeterScale = VU_MeterLibrary.MeterScale.Analog;
            this.vuMeter.Name = "vuMeter";
            this.vuMeter.NeedleColor = System.Drawing.Color.Black;
            this.vuMeter.PeakHold = true;
            this.vuMeter.Peakms = 1000;
            this.vuMeter.PeakNeedleColor = System.Drawing.Color.Red;
            this.vuMeter.ShowDialOnly = true;
            this.vuMeter.ShowLedPeak = false;
            this.vuMeter.ShowTextInDial = true;
            this.vuMeter.Size = new System.Drawing.Size(273, 218);
            this.vuMeter.TabIndex = 3;
            this.vuMeter.TextInDial = new string[] {
        "0",
        "20",
        "40",
        "60",
        "80",
        "100",
        "120",
        "140"};
            this.vuMeter.UseLedLight = false;
            this.vuMeter.VerticalBar = false;
            this.vuMeter.VuText = "dB";
            // 
            // timeDomain
            // 
            this.timeDomain.BorderlineColor = System.Drawing.Color.Black;
            this.timeDomain.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea21.Name = "ChartArea1";
            this.timeDomain.ChartAreas.Add(chartArea21);
            this.timeDomain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.timeDomain.Location = new System.Drawing.Point(0, 0);
            this.timeDomain.Name = "timeDomain";
            series17.ChartArea = "ChartArea1";
            series17.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series17.Color = System.Drawing.Color.Blue;
            series17.Name = "Samples";
            this.timeDomain.Series.Add(series17);
            this.timeDomain.Size = new System.Drawing.Size(610, 210);
            this.timeDomain.TabIndex = 2;
            this.timeDomain.Text = "Time domain";
            title21.Name = "Title1";
            title21.Text = "Time domain";
            this.timeDomain.Titles.Add(title21);
            // 
            // tabPageWeightFilters
            // 
            this.tabPageWeightFilters.Controls.Add(this.splitContainerFilters);
            this.tabPageWeightFilters.Location = new System.Drawing.Point(4, 22);
            this.tabPageWeightFilters.Name = "tabPageWeightFilters";
            this.tabPageWeightFilters.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageWeightFilters.Size = new System.Drawing.Size(616, 442);
            this.tabPageWeightFilters.TabIndex = 1;
            this.tabPageWeightFilters.Text = "Weight filters";
            this.tabPageWeightFilters.UseVisualStyleBackColor = true;
            // 
            // splitContainerFilters
            // 
            this.splitContainerFilters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerFilters.Location = new System.Drawing.Point(3, 3);
            this.splitContainerFilters.Name = "splitContainerFilters";
            this.splitContainerFilters.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerFilters.Panel1
            // 
            this.splitContainerFilters.Panel1.Controls.Add(this.groupBoxFilters);
            // 
            // splitContainerFilters.Panel2
            // 
            this.splitContainerFilters.Panel2.Controls.Add(this.freqDomain);
            this.splitContainerFilters.Size = new System.Drawing.Size(610, 436);
            this.splitContainerFilters.SplitterDistance = 131;
            this.splitContainerFilters.TabIndex = 0;
            // 
            // groupBoxFilters
            // 
            this.groupBoxFilters.Controls.Add(this.radioCfilter);
            this.groupBoxFilters.Controls.Add(this.radioAfilter);
            this.groupBoxFilters.Controls.Add(this.radioNone);
            this.groupBoxFilters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxFilters.Location = new System.Drawing.Point(0, 0);
            this.groupBoxFilters.Name = "groupBoxFilters";
            this.groupBoxFilters.Size = new System.Drawing.Size(610, 131);
            this.groupBoxFilters.TabIndex = 0;
            this.groupBoxFilters.TabStop = false;
            this.groupBoxFilters.Text = "Available filters";
            // 
            // radioCfilter
            // 
            this.radioCfilter.AutoSize = true;
            this.radioCfilter.Location = new System.Drawing.Point(7, 89);
            this.radioCfilter.Name = "radioCfilter";
            this.radioCfilter.Size = new System.Drawing.Size(106, 17);
            this.radioCfilter.TabIndex = 2;
            this.radioCfilter.TabStop = true;
            this.radioCfilter.Text = "C - weighted filter";
            this.radioCfilter.UseVisualStyleBackColor = true;
            this.radioCfilter.CheckedChanged += new System.EventHandler(this.radio_CheckedChanged);
            // 
            // radioAfilter
            // 
            this.radioAfilter.AutoSize = true;
            this.radioAfilter.Location = new System.Drawing.Point(7, 56);
            this.radioAfilter.Name = "radioAfilter";
            this.radioAfilter.Size = new System.Drawing.Size(106, 17);
            this.radioAfilter.TabIndex = 1;
            this.radioAfilter.TabStop = true;
            this.radioAfilter.Text = "A - weighted filter";
            this.radioAfilter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioAfilter.UseVisualStyleBackColor = true;
            this.radioAfilter.CheckedChanged += new System.EventHandler(this.radio_CheckedChanged);
            // 
            // radioNone
            // 
            this.radioNone.AutoSize = true;
            this.radioNone.Checked = true;
            this.radioNone.Location = new System.Drawing.Point(7, 24);
            this.radioNone.Name = "radioNone";
            this.radioNone.Size = new System.Drawing.Size(51, 17);
            this.radioNone.TabIndex = 0;
            this.radioNone.TabStop = true;
            this.radioNone.Text = "None";
            this.radioNone.UseVisualStyleBackColor = true;
            this.radioNone.CheckedChanged += new System.EventHandler(this.radio_CheckedChanged);
            // 
            // freqDomain
            // 
            this.freqDomain.BorderlineColor = System.Drawing.Color.Black;
            this.freqDomain.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea22.Name = "ChartArea1";
            this.freqDomain.ChartAreas.Add(chartArea22);
            this.freqDomain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.freqDomain.Location = new System.Drawing.Point(0, 0);
            this.freqDomain.Name = "freqDomain";
            series18.ChartArea = "ChartArea1";
            series18.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series18.Color = System.Drawing.Color.Blue;
            series18.Name = "Amplitudes";
            this.freqDomain.Series.Add(series18);
            this.freqDomain.Size = new System.Drawing.Size(610, 301);
            this.freqDomain.TabIndex = 3;
            this.freqDomain.Text = "Frequency domain";
            title22.Name = "Title1";
            title22.Text = "Frequency domain";
            this.freqDomain.Titles.Add(title22);
            // 
            // tabPageOctaveFilters
            // 
            this.tabPageOctaveFilters.Controls.Add(this.splitContainer1);
            this.tabPageOctaveFilters.Location = new System.Drawing.Point(4, 22);
            this.tabPageOctaveFilters.Name = "tabPageOctaveFilters";
            this.tabPageOctaveFilters.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOctaveFilters.Size = new System.Drawing.Size(616, 442);
            this.tabPageOctaveFilters.TabIndex = 2;
            this.tabPageOctaveFilters.Text = "Octave band filters";
            this.tabPageOctaveFilters.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.octavesVisualisation);
            this.splitContainer1.Size = new System.Drawing.Size(610, 436);
            this.splitContainer1.SplitterDistance = 131;
            this.splitContainer1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.octaveFreqDomain);
            this.groupBox1.Controls.Add(this.lblCenterFrequency);
            this.groupBox1.Controls.Add(this.comboBoxFreq);
            this.groupBox1.Controls.Add(this.radioBtnThirdOctave);
            this.groupBox1.Controls.Add(this.radioBtnOctave);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(610, 131);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Available filters";
            // 
            // octaveFreqDomain
            // 
            this.octaveFreqDomain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.octaveFreqDomain.BorderlineColor = System.Drawing.Color.Black;
            this.octaveFreqDomain.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea24.Name = "ChartArea1";
            this.octaveFreqDomain.ChartAreas.Add(chartArea24);
            this.octaveFreqDomain.Location = new System.Drawing.Point(248, 19);
            this.octaveFreqDomain.Name = "octaveFreqDomain";
            series19.ChartArea = "ChartArea1";
            series19.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series19.Name = "Octave";
            this.octaveFreqDomain.Series.Add(series19);
            this.octaveFreqDomain.Size = new System.Drawing.Size(356, 106);
            this.octaveFreqDomain.TabIndex = 4;
            this.octaveFreqDomain.Text = "Octave";
            title24.Name = "Octave band";
            title24.Text = "Frequency domain";
            this.octaveFreqDomain.Titles.Add(title24);
            // 
            // lblCenterFrequency
            // 
            this.lblCenterFrequency.AutoSize = true;
            this.lblCenterFrequency.Location = new System.Drawing.Point(4, 89);
            this.lblCenterFrequency.Name = "lblCenterFrequency";
            this.lblCenterFrequency.Size = new System.Drawing.Size(91, 13);
            this.lblCenterFrequency.TabIndex = 3;
            this.lblCenterFrequency.Text = "Center frequency:";
            // 
            // comboBoxFreq
            // 
            this.comboBoxFreq.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFreq.FormattingEnabled = true;
            this.comboBoxFreq.Location = new System.Drawing.Point(110, 86);
            this.comboBoxFreq.Name = "comboBoxFreq";
            this.comboBoxFreq.Size = new System.Drawing.Size(121, 21);
            this.comboBoxFreq.TabIndex = 2;
            this.comboBoxFreq.SelectedIndexChanged += new System.EventHandler(this.comboBoxFreq_SelectedIndexChanged);
            // 
            // radioBtnThirdOctave
            // 
            this.radioBtnThirdOctave.AutoSize = true;
            this.radioBtnThirdOctave.Location = new System.Drawing.Point(6, 59);
            this.radioBtnThirdOctave.Name = "radioBtnThirdOctave";
            this.radioBtnThirdOctave.Size = new System.Drawing.Size(107, 17);
            this.radioBtnThirdOctave.TabIndex = 1;
            this.radioBtnThirdOctave.TabStop = true;
            this.radioBtnThirdOctave.Text = "1/3 Octave band";
            this.radioBtnThirdOctave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioBtnThirdOctave.UseVisualStyleBackColor = true;
            this.radioBtnThirdOctave.CheckedChanged += new System.EventHandler(this.radio_CheckedChanged);
            // 
            // radioBtnOctave
            // 
            this.radioBtnOctave.AutoSize = true;
            this.radioBtnOctave.Checked = true;
            this.radioBtnOctave.Location = new System.Drawing.Point(6, 27);
            this.radioBtnOctave.Name = "radioBtnOctave";
            this.radioBtnOctave.Size = new System.Drawing.Size(87, 17);
            this.radioBtnOctave.TabIndex = 0;
            this.radioBtnOctave.TabStop = true;
            this.radioBtnOctave.Text = "Octave band";
            this.radioBtnOctave.UseVisualStyleBackColor = true;
            this.radioBtnOctave.CheckedChanged += new System.EventHandler(this.radio_CheckedChanged);
            // 
            // octavesVisualisation
            // 
            this.octavesVisualisation.BorderlineColor = System.Drawing.Color.Black;
            this.octavesVisualisation.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea23.Name = "ChartArea1";
            this.octavesVisualisation.ChartAreas.Add(chartArea23);
            this.octavesVisualisation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.octavesVisualisation.Location = new System.Drawing.Point(0, 0);
            this.octavesVisualisation.Name = "octavesVisualisation";
            this.octavesVisualisation.Size = new System.Drawing.Size(610, 301);
            this.octavesVisualisation.TabIndex = 3;
            this.octavesVisualisation.Text = "Octave visualisation";
            title23.Name = "Octaves";
            title23.Text = "Octaves";
            this.octavesVisualisation.Titles.Add(title23);
            // 
            // tabPageSensors
            // 
            this.tabPageSensors.Controls.Add(this.splitContainer2);
            this.tabPageSensors.Location = new System.Drawing.Point(4, 22);
            this.tabPageSensors.Name = "tabPageSensors";
            this.tabPageSensors.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSensors.Size = new System.Drawing.Size(616, 442);
            this.tabPageSensors.TabIndex = 3;
            this.tabPageSensors.Text = "Sensors";
            this.tabPageSensors.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.gMap);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.sensorReadings);
            this.splitContainer2.Size = new System.Drawing.Size(610, 436);
            this.splitContainer2.SplitterDistance = 131;
            this.splitContainer2.TabIndex = 1;
            // 
            // gMap
            // 
            this.gMap.Bearing = 0F;
            this.gMap.CanDragMap = true;
            this.gMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gMap.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMap.GrayScaleMode = false;
            this.gMap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMap.LevelsKeepInMemmory = 5;
            this.gMap.Location = new System.Drawing.Point(0, 0);
            this.gMap.MarkersEnabled = true;
            this.gMap.MaxZoom = 18;
            this.gMap.MinZoom = 2;
            this.gMap.MouseWheelZoomEnabled = true;
            this.gMap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMap.Name = "gMap";
            this.gMap.NegativeMode = false;
            this.gMap.PolygonsEnabled = true;
            this.gMap.RetryLoadTile = 0;
            this.gMap.RoutesEnabled = false;
            this.gMap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMap.ShowTileGridLines = false;
            this.gMap.Size = new System.Drawing.Size(610, 131);
            this.gMap.TabIndex = 0;
            this.gMap.Zoom = 15D;
            this.gMap.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gMap_MouseClick);
            // 
            // sensorReadings
            // 
            this.sensorReadings.BorderlineColor = System.Drawing.Color.Black;
            this.sensorReadings.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea25.Name = "ChartArea1";
            this.sensorReadings.ChartAreas.Add(chartArea25);
            this.sensorReadings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sensorReadings.Location = new System.Drawing.Point(0, 0);
            this.sensorReadings.Name = "sensorReadings";
            series20.ChartArea = "ChartArea1";
            series20.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series20.Color = System.Drawing.Color.Blue;
            series20.Name = "Readings";
            this.sensorReadings.Series.Add(series20);
            this.sensorReadings.Size = new System.Drawing.Size(610, 301);
            this.sensorReadings.TabIndex = 3;
            this.sensorReadings.Text = "Sensor readings";
            title25.Name = "Title1";
            title25.Text = "Sensor readings";
            this.sensorReadings.Titles.Add(title25);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(624, 24);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(100, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // optionToolStripMenuItem
            // 
            this.optionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.calibrateToolStripMenuItem1});
            this.optionToolStripMenuItem.Name = "optionToolStripMenuItem";
            this.optionToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionToolStripMenuItem.Text = "Options";
            // 
            // calibrateToolStripMenuItem1
            // 
            this.calibrateToolStripMenuItem1.Name = "calibrateToolStripMenuItem1";
            this.calibrateToolStripMenuItem1.Size = new System.Drawing.Size(121, 22);
            this.calibrateToolStripMenuItem1.Text = "Calibrate";
            this.calibrateToolStripMenuItem1.Click += new System.EventHandler(this.calibrateToolStripMenuItem_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPlay,
            this.btnPause});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(624, 25);
            this.toolStrip.TabIndex = 3;
            this.toolStrip.Text = "toolStrip1";
            // 
            // btnPlay
            // 
            this.btnPlay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPlay.Image = global::NoiseMeasurement.Properties.Resources.play1;
            this.btnPlay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(23, 22);
            this.btnPlay.Text = "Play";
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnPause
            // 
            this.btnPause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPause.Image = global::NoiseMeasurement.Properties.Resources.pause;
            this.btnPause.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(23, 22);
            this.btnPause.Text = "Pause";
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 500;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 522);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(640, 560);
            this.Name = "MainForm";
            this.Text = "NoiseMeasurement";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.tabControl.ResumeLayout(false);
            this.tabPageMain.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.timeDomain)).EndInit();
            this.tabPageWeightFilters.ResumeLayout(false);
            this.splitContainerFilters.Panel1.ResumeLayout(false);
            this.splitContainerFilters.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerFilters)).EndInit();
            this.splitContainerFilters.ResumeLayout(false);
            this.groupBoxFilters.ResumeLayout(false);
            this.groupBoxFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.freqDomain)).EndInit();
            this.tabPageOctaveFilters.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.octaveFreqDomain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.octavesVisualisation)).EndInit();
            this.tabPageSensors.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sensorReadings)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageMain;
        private System.Windows.Forms.TabPage tabPageWeightFilters;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem calibrateToolStripMenuItem1;
        private System.Windows.Forms.DataVisualization.Charting.Chart timeDomain;
        private VU_MeterLibrary.VuMeter vuMeter;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Label lblNoise;
        private System.Windows.Forms.SplitContainer splitContainerFilters;
        private System.Windows.Forms.DataVisualization.Charting.Chart freqDomain;
        private System.Windows.Forms.GroupBox groupBoxFilters;
        private System.Windows.Forms.RadioButton radioCfilter;
        private System.Windows.Forms.RadioButton radioAfilter;
        private System.Windows.Forms.RadioButton radioNone;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton btnPlay;
        private System.Windows.Forms.ToolStripButton btnPause;
        private System.Windows.Forms.TabPage tabPageOctaveFilters;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioBtnThirdOctave;
        private System.Windows.Forms.RadioButton radioBtnOctave;
        private System.Windows.Forms.DataVisualization.Charting.Chart octavesVisualisation;
        private System.Windows.Forms.ComboBox comboBoxFreq;
        private System.Windows.Forms.Label lblCenterFrequency;
        private System.Windows.Forms.DataVisualization.Charting.Chart octaveFreqDomain;
        private System.Windows.Forms.Label lblLeq;
        private System.Windows.Forms.Label lblNoiseDose;
        private System.Windows.Forms.Label lblTWA;
        private System.Windows.Forms.Label lblLavg;
        private System.Windows.Forms.Label lblLeqValue;
        private System.Windows.Forms.Label lblDoseValue;
        private System.Windows.Forms.Label lblTWAValue;
        private System.Windows.Forms.Label lblLavgValue;
        private System.Windows.Forms.ComboBox comboBoxTimeWeight;
        private System.Windows.Forms.TabPage tabPageSensors;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataVisualization.Charting.Chart sensorReadings;
        private GMap.NET.WindowsForms.GMapControl gMap;
        private System.Windows.Forms.Timer timer;
    }
}

