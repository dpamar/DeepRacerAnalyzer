using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeepRacer
{
    public partial class NewProject : Form
    {
        public string Filename
        {
            get { return this.tbTrackFile.Text; }
            set { this.tbTrackFile.Text = value; }
        }

        public int IterationCount { get { return int.TryParse(this.tbCurveStepCount.Text, out int result) ? result : -1; } }
        public double InnerBand { get { return ParseDouble(tbBand, -100) / 100; } }
        public double MinSpeed { get { return ParseDouble(tbMinSpeed, -1); } }
        public int Forecast { get { return int.TryParse(this.tbForecast.Text, out int result) ? result : -1; } }
        public double TrackWidth { get { return ParseDouble(tbTrackWidth, -1); } }

        public NewProject()
        {
            this.DialogResult = DialogResult.Cancel;
            InitializeComponent();
            this.CsvMode = false;
        }

        private bool csvMode = false;
        public bool CsvMode
        {
            set
            {
                this.lblTrackFile.Text = (value ? "CSV" : "NPY") + " track file";
                this.lblTrackWidth.Visible = this.tbTrackWidth.Visible = this.csvMode = value;
            }
            get { return csvMode; }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (CsvMode && TrackWidth < 0)
            {
                MessageBox.Show("Invalid track width band percentage", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (IterationCount < 0)
            {
                MessageBox.Show("Invalid curving iteration count", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MinSpeed < 0)
            {
                MessageBox.Show("Invalid min speed", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Forecast < 0)
            {
                MessageBox.Show("Invalid forecast", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (InnerBand < 0)
            {
                MessageBox.Show("Invalid inner band percentage", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Filename.ToLower().StartsWith("http"))
            {
                string tmp = Path.GetTempFileName();
                WebClient webClient = new WebClient();
                webClient.DownloadFile(Filename, tmp);
                Filename = tmp;
            }
            if(String.IsNullOrEmpty(Filename) || !File.Exists(Filename))
            {
                MessageBox.Show("Invalid data file", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnSelectTrackFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
                this.tbTrackFile.Text = ofd.FileName;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private double ParseDouble(TextBox tb, double defaultValue)
        {
            return double.TryParse(tb.Text.Replace('.', ','), out double res) ? res : defaultValue;
        }
    }
}
