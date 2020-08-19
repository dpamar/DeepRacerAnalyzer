namespace DeepRacer
{
    partial class SpeedHackForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpeedHackForm));
            this.lbl1stRange = new System.Windows.Forms.Label();
            this.tb1stRange = new System.Windows.Forms.TextBox();
            this.tb2ndRange = new System.Windows.Forms.TextBox();
            this.lbl2ndRange = new System.Windows.Forms.Label();
            this.tb3rdRange = new System.Windows.Forms.TextBox();
            this.lbl3rdRange = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl1stRange
            // 
            this.lbl1stRange.AutoSize = true;
            this.lbl1stRange.Location = new System.Drawing.Point(12, 33);
            this.lbl1stRange.Name = "lbl1stRange";
            this.lbl1stRange.Size = new System.Drawing.Size(414, 32);
            this.lbl1stRange.TabIndex = 0;
            this.lbl1stRange.Text = "Multiply speeds below 2m/s by :";
            // 
            // tb1stRange
            // 
            this.tb1stRange.Location = new System.Drawing.Point(432, 30);
            this.tb1stRange.Name = "tb1stRange";
            this.tb1stRange.Size = new System.Drawing.Size(100, 38);
            this.tb1stRange.TabIndex = 1;
            this.tb1stRange.Text = "1.11";
            this.tb1stRange.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tb2ndRange
            // 
            this.tb2ndRange.Location = new System.Drawing.Point(432, 74);
            this.tb2ndRange.Name = "tb2ndRange";
            this.tb2ndRange.Size = new System.Drawing.Size(100, 38);
            this.tb2ndRange.TabIndex = 3;
            this.tb2ndRange.Text = "1.17";
            this.tb2ndRange.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbl2ndRange
            // 
            this.lbl2ndRange.AutoSize = true;
            this.lbl2ndRange.Location = new System.Drawing.Point(12, 77);
            this.lbl2ndRange.Name = "lbl2ndRange";
            this.lbl2ndRange.Size = new System.Drawing.Size(414, 32);
            this.lbl2ndRange.TabIndex = 2;
            this.lbl2ndRange.Text = "Multiply speeds below 3m/s by :";
            // 
            // tb3rdRange
            // 
            this.tb3rdRange.Location = new System.Drawing.Point(432, 118);
            this.tb3rdRange.Name = "tb3rdRange";
            this.tb3rdRange.Size = new System.Drawing.Size(100, 38);
            this.tb3rdRange.TabIndex = 5;
            this.tb3rdRange.Text = "1.31";
            this.tb3rdRange.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbl3rdRange
            // 
            this.lbl3rdRange.AutoSize = true;
            this.lbl3rdRange.Location = new System.Drawing.Point(12, 121);
            this.lbl3rdRange.Name = "lbl3rdRange";
            this.lbl3rdRange.Size = new System.Drawing.Size(417, 32);
            this.lbl3rdRange.TabIndex = 4;
            this.lbl3rdRange.Text = "Multiply speeds above 3m/s by :";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(337, 169);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(195, 75);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(136, 169);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(195, 75);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "&Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // SpeedHackForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(568, 262);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tb3rdRange);
            this.Controls.Add(this.lbl3rdRange);
            this.Controls.Add(this.tb2ndRange);
            this.Controls.Add(this.lbl2ndRange);
            this.Controls.Add(this.tb1stRange);
            this.Controls.Add(this.lbl1stRange);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(600, 350);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 350);
            this.Name = "SpeedHackForm";
            this.Text = "SpeedHack";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl1stRange;
        private System.Windows.Forms.TextBox tb1stRange;
        private System.Windows.Forms.TextBox tb2ndRange;
        private System.Windows.Forms.Label lbl2ndRange;
        private System.Windows.Forms.TextBox tb3rdRange;
        private System.Windows.Forms.Label lbl3rdRange;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
    }
}