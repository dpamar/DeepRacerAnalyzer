namespace DeepRacer
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.tabPathFinder = new System.Windows.Forms.TabPage();
            this.picTrack = new System.Windows.Forms.PictureBox();
            this.tabSimulation = new System.Windows.Forms.TabPage();
            this.picSimulation = new System.Windows.Forms.PictureBox();
            this.tabActionSpace = new System.Windows.Forms.TabPage();
            this.chartActionSpace = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabInject = new System.Windows.Forms.TabPage();
            this.tbPayLoad = new System.Windows.Forms.TextBox();
            this.tabCheatData = new System.Windows.Forms.TabPage();
            this.tbCheatData = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.projectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadNumpyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadPointsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.roboMakerLogsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.speedIncreaseToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainTabControl.SuspendLayout();
            this.tabPathFinder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTrack)).BeginInit();
            this.tabSimulation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSimulation)).BeginInit();
            this.tabActionSpace.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartActionSpace)).BeginInit();
            this.tabInject.SuspendLayout();
            this.tabCheatData.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainTabControl
            // 
            this.mainTabControl.Controls.Add(this.tabPathFinder);
            this.mainTabControl.Controls.Add(this.tabSimulation);
            this.mainTabControl.Controls.Add(this.tabActionSpace);
            this.mainTabControl.Controls.Add(this.tabInject);
            this.mainTabControl.Controls.Add(this.tabCheatData);
            this.mainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTabControl.Location = new System.Drawing.Point(0, 52);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(1467, 980);
            this.mainTabControl.TabIndex = 0;
            // 
            // tabPathFinder
            // 
            this.tabPathFinder.Controls.Add(this.picTrack);
            this.tabPathFinder.Location = new System.Drawing.Point(10, 48);
            this.tabPathFinder.Name = "tabPathFinder";
            this.tabPathFinder.Padding = new System.Windows.Forms.Padding(3);
            this.tabPathFinder.Size = new System.Drawing.Size(1447, 922);
            this.tabPathFinder.TabIndex = 1;
            this.tabPathFinder.Text = "Path Finder";
            this.tabPathFinder.UseVisualStyleBackColor = true;
            // 
            // picTrack
            // 
            this.picTrack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picTrack.Location = new System.Drawing.Point(3, 3);
            this.picTrack.Name = "picTrack";
            this.picTrack.Size = new System.Drawing.Size(1441, 916);
            this.picTrack.TabIndex = 0;
            this.picTrack.TabStop = false;
            this.picTrack.DoubleClick += new System.EventHandler(this.CopyImageToClibpboard);
            // 
            // tabSimulation
            // 
            this.tabSimulation.Controls.Add(this.picSimulation);
            this.tabSimulation.Location = new System.Drawing.Point(10, 48);
            this.tabSimulation.Name = "tabSimulation";
            this.tabSimulation.Size = new System.Drawing.Size(1447, 925);
            this.tabSimulation.TabIndex = 2;
            this.tabSimulation.Text = "Simulation";
            this.tabSimulation.UseVisualStyleBackColor = true;
            // 
            // picSimulation
            // 
            this.picSimulation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picSimulation.Location = new System.Drawing.Point(0, 0);
            this.picSimulation.Name = "picSimulation";
            this.picSimulation.Size = new System.Drawing.Size(1447, 925);
            this.picSimulation.TabIndex = 2;
            this.picSimulation.TabStop = false;
            this.picSimulation.DoubleClick += new System.EventHandler(this.CopyImageToClibpboard);
            // 
            // tabActionSpace
            // 
            this.tabActionSpace.Controls.Add(this.chartActionSpace);
            this.tabActionSpace.Location = new System.Drawing.Point(10, 48);
            this.tabActionSpace.Name = "tabActionSpace";
            this.tabActionSpace.Padding = new System.Windows.Forms.Padding(3);
            this.tabActionSpace.Size = new System.Drawing.Size(1447, 925);
            this.tabActionSpace.TabIndex = 0;
            this.tabActionSpace.Text = "ActionSpace";
            this.tabActionSpace.UseVisualStyleBackColor = true;
            // 
            // chartActionSpace
            // 
            chartArea1.Name = "ChartArea1";
            this.chartActionSpace.ChartAreas.Add(chartArea1);
            this.chartActionSpace.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chartActionSpace.Legends.Add(legend1);
            this.chartActionSpace.Location = new System.Drawing.Point(3, 3);
            this.chartActionSpace.Name = "chartActionSpace";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartActionSpace.Series.Add(series1);
            this.chartActionSpace.Size = new System.Drawing.Size(1441, 919);
            this.chartActionSpace.TabIndex = 0;
            this.chartActionSpace.Text = "chart1";
            // 
            // tabInject
            // 
            this.tabInject.Controls.Add(this.tbPayLoad);
            this.tabInject.Location = new System.Drawing.Point(10, 48);
            this.tabInject.Name = "tabInject";
            this.tabInject.Padding = new System.Windows.Forms.Padding(3);
            this.tabInject.Size = new System.Drawing.Size(1447, 925);
            this.tabInject.TabIndex = 3;
            this.tabInject.Text = "Payload injection";
            this.tabInject.UseVisualStyleBackColor = true;
            // 
            // tbPayLoad
            // 
            this.tbPayLoad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPayLoad.Location = new System.Drawing.Point(3, 3);
            this.tbPayLoad.Multiline = true;
            this.tbPayLoad.Name = "tbPayLoad";
            this.tbPayLoad.ReadOnly = true;
            this.tbPayLoad.Size = new System.Drawing.Size(1441, 919);
            this.tbPayLoad.TabIndex = 0;
            // 
            // tabCheatData
            // 
            this.tabCheatData.Controls.Add(this.tbCheatData);
            this.tabCheatData.Location = new System.Drawing.Point(10, 48);
            this.tabCheatData.Name = "tabCheatData";
            this.tabCheatData.Size = new System.Drawing.Size(1447, 925);
            this.tabCheatData.TabIndex = 4;
            this.tabCheatData.Text = "Reward function";
            this.tabCheatData.UseVisualStyleBackColor = true;
            // 
            // tbCheatData
            // 
            this.tbCheatData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbCheatData.Location = new System.Drawing.Point(0, 0);
            this.tbCheatData.Multiline = true;
            this.tbCheatData.Name = "tbCheatData";
            this.tbCheatData.ReadOnly = true;
            this.tbCheatData.Size = new System.Drawing.Size(1447, 925);
            this.tbCheatData.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.projectToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1467, 52);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // projectToolStripMenuItem
            // 
            this.projectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadNumpyToolStripMenuItem,
            this.loadPointsToolStripMenuItem,
            this.toolStripMenuItem2,
            this.roboMakerLogsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.speedIncreaseToolToolStripMenuItem});
            this.projectToolStripMenuItem.Name = "projectToolStripMenuItem";
            this.projectToolStripMenuItem.Size = new System.Drawing.Size(122, 48);
            this.projectToolStripMenuItem.Text = "&Project";
            // 
            // loadNumpyToolStripMenuItem
            // 
            this.loadNumpyToolStripMenuItem.Name = "loadNumpyToolStripMenuItem";
            this.loadNumpyToolStripMenuItem.Size = new System.Drawing.Size(396, 46);
            this.loadNumpyToolStripMenuItem.Text = "&Load Numpy";
            this.loadNumpyToolStripMenuItem.Click += new System.EventHandler(this.loadNumpyToolStripMenuItem_Click);
            // 
            // loadPointsToolStripMenuItem
            // 
            this.loadPointsToolStripMenuItem.Name = "loadPointsToolStripMenuItem";
            this.loadPointsToolStripMenuItem.Size = new System.Drawing.Size(396, 46);
            this.loadPointsToolStripMenuItem.Text = "Load &Points";
            this.loadPointsToolStripMenuItem.Click += new System.EventHandler(this.loadPointsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(393, 6);
            // 
            // roboMakerLogsToolStripMenuItem
            // 
            this.roboMakerLogsToolStripMenuItem.Name = "roboMakerLogsToolStripMenuItem";
            this.roboMakerLogsToolStripMenuItem.Size = new System.Drawing.Size(396, 46);
            this.roboMakerLogsToolStripMenuItem.Text = "&RoboMaker Logs";
            this.roboMakerLogsToolStripMenuItem.Click += new System.EventHandler(this.roboMakerLogsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(393, 6);
            // 
            // speedIncreaseToolToolStripMenuItem
            // 
            this.speedIncreaseToolToolStripMenuItem.Name = "speedIncreaseToolToolStripMenuItem";
            this.speedIncreaseToolToolStripMenuItem.Size = new System.Drawing.Size(396, 46);
            this.speedIncreaseToolToolStripMenuItem.Text = "&Speed increase tool";
            this.speedIncreaseToolToolStripMenuItem.Click += new System.EventHandler(this.speedIncreaseToolToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1467, 1032);
            this.Controls.Add(this.mainTabControl);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "DeepRacer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.mainTabControl.ResumeLayout(false);
            this.tabPathFinder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTrack)).EndInit();
            this.tabSimulation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picSimulation)).EndInit();
            this.tabActionSpace.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartActionSpace)).EndInit();
            this.tabInject.ResumeLayout(false);
            this.tabInject.PerformLayout();
            this.tabCheatData.ResumeLayout(false);
            this.tabCheatData.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage tabActionSpace;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartActionSpace;
        private System.Windows.Forms.TabPage tabPathFinder;
        private System.Windows.Forms.PictureBox picTrack;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem projectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadNumpyToolStripMenuItem;
        private System.Windows.Forms.TabPage tabSimulation;
        private System.Windows.Forms.PictureBox picSimulation;
        private System.Windows.Forms.TabPage tabInject;
        private System.Windows.Forms.TextBox tbPayLoad;
        private System.Windows.Forms.TabPage tabCheatData;
        private System.Windows.Forms.TextBox tbCheatData;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem roboMakerLogsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem speedIncreaseToolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadPointsToolStripMenuItem;
    }
}

