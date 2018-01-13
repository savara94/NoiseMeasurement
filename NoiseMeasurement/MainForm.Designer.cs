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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title4 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageMain = new System.Windows.Forms.TabPage();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.lblNoise = new System.Windows.Forms.Label();
            this.vuMeter = new VU_MeterLibrary.VuMeter();
            this.timeDomain = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.tabPageFilters = new System.Windows.Forms.TabPage();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calibrateToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl.SuspendLayout();
            this.tabPageMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeDomain)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageMain);
            this.tabControl.Controls.Add(this.tabPageFilters);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 24);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(624, 498);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageMain
            // 
            this.tabPageMain.Controls.Add(this.splitContainer);
            this.tabPageMain.Controls.Add(this.toolStrip);
            this.tabPageMain.Location = new System.Drawing.Point(4, 22);
            this.tabPageMain.Name = "tabPageMain";
            this.tabPageMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMain.Size = new System.Drawing.Size(616, 472);
            this.tabPageMain.TabIndex = 0;
            this.tabPageMain.Text = "Main";
            this.tabPageMain.UseVisualStyleBackColor = true;
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(3, 28);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.lblNoise);
            this.splitContainer.Panel1.Controls.Add(this.vuMeter);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.timeDomain);
            this.splitContainer.Size = new System.Drawing.Size(610, 441);
            this.splitContainer.SplitterDistance = 225;
            this.splitContainer.TabIndex = 4;
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
            chartArea4.Name = "ChartArea1";
            this.timeDomain.ChartAreas.Add(chartArea4);
            this.timeDomain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.timeDomain.Location = new System.Drawing.Point(0, 0);
            this.timeDomain.Name = "timeDomain";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Color = System.Drawing.Color.Blue;
            series4.Name = "Samples";
            this.timeDomain.Series.Add(series4);
            this.timeDomain.Size = new System.Drawing.Size(610, 212);
            this.timeDomain.TabIndex = 2;
            this.timeDomain.Text = "Time domain";
            title4.Name = "Title1";
            title4.Text = "Time domain";
            this.timeDomain.Titles.Add(title4);
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2});
            this.toolStrip.Location = new System.Drawing.Point(3, 3);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(610, 25);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::NoiseMeasurement.Properties.Resources.play1;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(49, 22);
            this.toolStripButton1.Text = "Play";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = global::NoiseMeasurement.Properties.Resources.pause;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(58, 22);
            this.toolStripButton2.Text = "Pause";
            // 
            // tabPageFilters
            // 
            this.tabPageFilters.Location = new System.Drawing.Point(4, 22);
            this.tabPageFilters.Name = "tabPageFilters";
            this.tabPageFilters.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFilters.Size = new System.Drawing.Size(616, 472);
            this.tabPageFilters.TabIndex = 1;
            this.tabPageFilters.Text = "Filters";
            this.tabPageFilters.UseVisualStyleBackColor = true;
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 522);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(640, 560);
            this.Name = "MainForm";
            this.Text = "NoiseMeasurement";
            this.tabControl.ResumeLayout(false);
            this.tabPageMain.ResumeLayout(false);
            this.tabPageMain.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.timeDomain)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageMain;
        private System.Windows.Forms.TabPage tabPageFilters;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem calibrateToolStripMenuItem1;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.DataVisualization.Charting.Chart timeDomain;
        private VU_MeterLibrary.VuMeter vuMeter;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Label lblNoise;
    }
}

