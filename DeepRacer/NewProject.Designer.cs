namespace DeepRacer
{
    partial class NewProject
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewProject));
            this.lblTrackFile = new System.Windows.Forms.Label();
            this.lblCuveStepCount = new System.Windows.Forms.Label();
            this.lblForecast = new System.Windows.Forms.Label();
            this.lblMin = new System.Windows.Forms.Label();
            this.gbTrack = new System.Windows.Forms.GroupBox();
            this.tbTrackWidth = new System.Windows.Forms.TextBox();
            this.lblTrackWidth = new System.Windows.Forms.Label();
            this.btnSelectTrackFile = new System.Windows.Forms.Button();
            this.tbTrackFile = new System.Windows.Forms.TextBox();
            this.gbPath = new System.Windows.Forms.GroupBox();
            this.tbBand = new System.Windows.Forms.TextBox();
            this.lblInnerBand = new System.Windows.Forms.Label();
            this.tbCurveStepCount = new System.Windows.Forms.TextBox();
            this.gbSpeed = new System.Windows.Forms.GroupBox();
            this.tbForecast = new System.Windows.Forms.TextBox();
            this.tbMinSpeed = new System.Windows.Forms.TextBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbTrack.SuspendLayout();
            this.gbPath.SuspendLayout();
            this.gbSpeed.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTrackFile
            // 
            this.lblTrackFile.AutoSize = true;
            this.lblTrackFile.Location = new System.Drawing.Point(6, 34);
            this.lblTrackFile.Name = "lblTrackFile";
            this.lblTrackFile.Size = new System.Drawing.Size(186, 32);
            this.lblTrackFile.TabIndex = 0;
            this.lblTrackFile.Text = "NPY track file";
            // 
            // lblCuveStepCount
            // 
            this.lblCuveStepCount.AutoSize = true;
            this.lblCuveStepCount.Location = new System.Drawing.Point(6, 34);
            this.lblCuveStepCount.Name = "lblCuveStepCount";
            this.lblCuveStepCount.Size = new System.Drawing.Size(300, 32);
            this.lblCuveStepCount.TabIndex = 0;
            this.lblCuveStepCount.Text = "Curving iteration count";
            // 
            // lblForecast
            // 
            this.lblForecast.AutoSize = true;
            this.lblForecast.Location = new System.Drawing.Point(6, 92);
            this.lblForecast.Name = "lblForecast";
            this.lblForecast.Size = new System.Drawing.Size(125, 32);
            this.lblForecast.TabIndex = 2;
            this.lblForecast.Text = "Forecast";
            // 
            // lblMin
            // 
            this.lblMin.AutoSize = true;
            this.lblMin.Location = new System.Drawing.Point(6, 34);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(146, 32);
            this.lblMin.TabIndex = 0;
            this.lblMin.Text = "Min speed";
            // 
            // gbTrack
            // 
            this.gbTrack.Controls.Add(this.tbTrackWidth);
            this.gbTrack.Controls.Add(this.lblTrackWidth);
            this.gbTrack.Controls.Add(this.btnSelectTrackFile);
            this.gbTrack.Controls.Add(this.tbTrackFile);
            this.gbTrack.Controls.Add(this.lblTrackFile);
            this.gbTrack.Location = new System.Drawing.Point(12, 12);
            this.gbTrack.Name = "gbTrack";
            this.gbTrack.Size = new System.Drawing.Size(750, 144);
            this.gbTrack.TabIndex = 0;
            this.gbTrack.TabStop = false;
            this.gbTrack.Text = "Track";
            // 
            // tbTrackWidth
            // 
            this.tbTrackWidth.Location = new System.Drawing.Point(210, 89);
            this.tbTrackWidth.Name = "tbTrackWidth";
            this.tbTrackWidth.Size = new System.Drawing.Size(448, 38);
            this.tbTrackWidth.TabIndex = 4;
            this.tbTrackWidth.Text = "1.138";
            this.tbTrackWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTrackWidth
            // 
            this.lblTrackWidth.AutoSize = true;
            this.lblTrackWidth.Location = new System.Drawing.Point(6, 89);
            this.lblTrackWidth.Name = "lblTrackWidth";
            this.lblTrackWidth.Size = new System.Drawing.Size(159, 32);
            this.lblTrackWidth.TabIndex = 3;
            this.lblTrackWidth.Text = "Track width";
            // 
            // btnSelectTrackFile
            // 
            this.btnSelectTrackFile.Location = new System.Drawing.Point(664, 27);
            this.btnSelectTrackFile.Name = "btnSelectTrackFile";
            this.btnSelectTrackFile.Size = new System.Drawing.Size(80, 61);
            this.btnSelectTrackFile.TabIndex = 2;
            this.btnSelectTrackFile.Text = "...";
            this.btnSelectTrackFile.UseVisualStyleBackColor = true;
            this.btnSelectTrackFile.Click += new System.EventHandler(this.btnSelectTrackFile_Click);
            // 
            // tbTrackFile
            // 
            this.tbTrackFile.Location = new System.Drawing.Point(210, 31);
            this.tbTrackFile.Name = "tbTrackFile";
            this.tbTrackFile.Size = new System.Drawing.Size(448, 38);
            this.tbTrackFile.TabIndex = 1;
            // 
            // gbPath
            // 
            this.gbPath.Controls.Add(this.tbBand);
            this.gbPath.Controls.Add(this.lblInnerBand);
            this.gbPath.Controls.Add(this.tbCurveStepCount);
            this.gbPath.Controls.Add(this.lblCuveStepCount);
            this.gbPath.Location = new System.Drawing.Point(12, 162);
            this.gbPath.Name = "gbPath";
            this.gbPath.Size = new System.Drawing.Size(750, 170);
            this.gbPath.TabIndex = 1;
            this.gbPath.TabStop = false;
            this.gbPath.Text = "Path";
            // 
            // tbBand
            // 
            this.tbBand.Location = new System.Drawing.Point(310, 82);
            this.tbBand.Name = "tbBand";
            this.tbBand.Size = new System.Drawing.Size(434, 38);
            this.tbBand.TabIndex = 3;
            this.tbBand.Text = "80";
            this.tbBand.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblInnerBand
            // 
            this.lblInnerBand.AutoSize = true;
            this.lblInnerBand.Location = new System.Drawing.Point(6, 88);
            this.lblInnerBand.Name = "lblInnerBand";
            this.lblInnerBand.Size = new System.Drawing.Size(300, 32);
            this.lblInnerBand.TabIndex = 2;
            this.lblInnerBand.Text = "Inner band percentage";
            // 
            // tbCurveStepCount
            // 
            this.tbCurveStepCount.Location = new System.Drawing.Point(310, 31);
            this.tbCurveStepCount.Name = "tbCurveStepCount";
            this.tbCurveStepCount.Size = new System.Drawing.Size(434, 38);
            this.tbCurveStepCount.TabIndex = 1;
            this.tbCurveStepCount.Text = "1000";
            this.tbCurveStepCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // gbSpeed
            // 
            this.gbSpeed.Controls.Add(this.tbForecast);
            this.gbSpeed.Controls.Add(this.tbMinSpeed);
            this.gbSpeed.Controls.Add(this.lblMin);
            this.gbSpeed.Controls.Add(this.lblForecast);
            this.gbSpeed.Location = new System.Drawing.Point(12, 338);
            this.gbSpeed.Name = "gbSpeed";
            this.gbSpeed.Size = new System.Drawing.Size(750, 150);
            this.gbSpeed.TabIndex = 2;
            this.gbSpeed.TabStop = false;
            this.gbSpeed.Text = "Speed";
            // 
            // tbForecast
            // 
            this.tbForecast.Location = new System.Drawing.Point(310, 89);
            this.tbForecast.Name = "tbForecast";
            this.tbForecast.Size = new System.Drawing.Size(434, 38);
            this.tbForecast.TabIndex = 3;
            this.tbForecast.Text = "5";
            this.tbForecast.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbMinSpeed
            // 
            this.tbMinSpeed.Location = new System.Drawing.Point(310, 28);
            this.tbMinSpeed.Name = "tbMinSpeed";
            this.tbMinSpeed.Size = new System.Drawing.Size(434, 38);
            this.tbMinSpeed.TabIndex = 1;
            this.tbMinSpeed.Text = "1.7";
            this.tbMinSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(284, 494);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(229, 61);
            this.btnLoad.TabIndex = 3;
            this.btnLoad.Text = "&Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(519, 494);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(243, 61);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // NewProject
            // 
            this.AcceptButton = this.btnLoad;
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(783, 572);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.gbSpeed);
            this.Controls.Add(this.gbPath);
            this.Controls.Add(this.gbTrack);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(815, 660);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(815, 660);
            this.Name = "NewProject";
            this.Text = "Load new project";
            this.gbTrack.ResumeLayout(false);
            this.gbTrack.PerformLayout();
            this.gbPath.ResumeLayout(false);
            this.gbPath.PerformLayout();
            this.gbSpeed.ResumeLayout(false);
            this.gbSpeed.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTrackFile;
        private System.Windows.Forms.Label lblCuveStepCount;
        private System.Windows.Forms.Label lblForecast;
        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.GroupBox gbTrack;
        private System.Windows.Forms.Button btnSelectTrackFile;
        private System.Windows.Forms.TextBox tbTrackFile;
        private System.Windows.Forms.GroupBox gbPath;
        private System.Windows.Forms.GroupBox gbSpeed;
        private System.Windows.Forms.TextBox tbCurveStepCount;
        private System.Windows.Forms.TextBox tbForecast;
        private System.Windows.Forms.TextBox tbMinSpeed;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox tbBand;
        private System.Windows.Forms.Label lblInnerBand;
        private System.Windows.Forms.TextBox tbTrackWidth;
        private System.Windows.Forms.Label lblTrackWidth;
    }
}