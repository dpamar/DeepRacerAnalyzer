namespace DeepRacer
{
    partial class LogPathViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogPathViewer));
            this.tabBar = new System.Windows.Forms.TabControl();
            this.SuspendLayout();
            // 
            // tabBar
            // 
            this.tabBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabBar.Location = new System.Drawing.Point(0, 0);
            this.tabBar.Name = "tabBar";
            this.tabBar.SelectedIndex = 0;
            this.tabBar.Size = new System.Drawing.Size(1351, 1054);
            this.tabBar.TabIndex = 0;
            // 
            // LogPathViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1351, 1054);
            this.Controls.Add(this.tabBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LogPathViewer";
            this.Text = "LogPathViewer";
            this.Shown += new System.EventHandler(this.LogPathViewer_Shown);
            this.Resize += new System.EventHandler(this.LogPathViewer_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabBar;
    }
}