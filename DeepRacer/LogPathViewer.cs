using DeepRacer.OptimalPath;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeepRacer
{
    public partial class LogPathViewer : Form
    {
        public PathFinder PathFinder { get; set; }

        public List<LogRecord> Logs { get; set; }

        private void CopyImageToClibpboard(object sender, EventArgs e)
        {
            PictureBox pbox = (PictureBox)sender;
            if (pbox.Image == null) return;
            Clipboard.SetImage(pbox.Image);
        }
        public LogPathViewer()
        {
            InitializeComponent();
        }

        private void ShowLogs()
        {
            if (Logs == null) return;
            this.tabBar.TabPages.Clear();
            foreach (LogRecord log in Logs)
            {
                TabPage page = new TabPage();
                this.tabBar.TabPages.Add(page);
                PictureBox picBox = new PictureBox();
                picBox.DoubleClick += CopyImageToClibpboard;
                page.Controls.Add(picBox);
                picBox.Dock = DockStyle.Fill;

                picBox.Image = log.GetImage(picBox.Width, picBox.Height);
                Brush brush = log.Finished ? Brushes.Green : Brushes.Red;
                Graphics graphics = Graphics.FromImage(picBox.Image);
                graphics.DrawString(String.Format("Progress: {0:0.00}%", log.Progress), Font, brush, 10, 10);
                graphics.DrawString(String.Format("Time: {0:0.000} seconds", log.EndTime - log.StartTime), Font, brush, 10, 40);
                page.Text = String.Format("Lap #{0} - {1}", log.LapId, log.Finished ? "OK" : "KO");
            }
        }

        private void LogPathViewer_Resize(object sender, EventArgs e)
        {
            ShowLogs();
        }

        private void LogPathViewer_Shown(object sender, EventArgs e)
        {
            ShowLogs();
        }
    }
}
