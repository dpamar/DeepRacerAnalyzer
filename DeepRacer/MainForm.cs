using DeepRacer.ActionSpace;
using DeepRacer.Graphic;
using DeepRacer.OptimalPath;
using DeepRacer.Track;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DeepRacer
{
    public partial class MainForm : Form
    {
        public ActionSpaceCalculator actionSpace;
        public PathFinder pathFinder;
        private float xMin, xMax, yMin, yMax;
        private SpeedHackForm speedHack;

        public MainForm()
        {
            InitializeComponent();
            speedHack = new SpeedHackForm();

            actionSpace = new ActionSpaceCalculator();
            actionSpace.AfterRun += RefreshActionSpaceAfterRun;

            pathFinder = new PathFinder();
            pathFinder.AfterRun += RefreshPathAfterRun;
        }

        #region Load project / refresh
        private void loadPointsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewProject newProject = new NewProject();
            newProject.CsvMode = true;
            if (newProject.ShowDialog() != DialogResult.OK) return;

            TrackData trackData = new WayPointsTrackData(newProject.TrackWidth,
                File.ReadAllLines(newProject.Filename)
                .Select(x => x.Split('\t', ' ', ',', ';').Select(y => double.Parse(y.Replace('.', ','))).ToArray())
                .ToArray());
            LoadProject(trackData, newProject.IterationCount, newProject.InnerBand, newProject.MinSpeed, newProject.Forecast);
        }

        private void loadNumpyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewProject newProject = new NewProject();
            newProject.CsvMode = false;
            if (newProject.ShowDialog() != DialogResult.OK) return;

            TrackData trackData = new NpyTrackData(newProject.Filename);
            LoadProject(trackData, newProject.IterationCount, newProject.InnerBand, newProject.MinSpeed, newProject.Forecast);
        }

        private void LoadProject(TrackData trackData, int iterationCount, double innerBand, double minSpeed, int forecast)
        {
            pathFinder.IterationCount = iterationCount;
            pathFinder.TrackData = trackData;
            pathFinder.Run(innerBand);

            actionSpace.MinSpeed = minSpeed;
            actionSpace.Forecast = forecast;
            actionSpace.Data = pathFinder.Path;
            actionSpace.Run();
        }

        private void RefreshActionSpaceAfterRun(object sender, EventArgs e)
        {
            chartActionSpace.Series.Clear();

            Series sTheory = chartActionSpace.Series.Add("Theory");
            sTheory.ChartType = SeriesChartType.Point;
            for (int i = 0; i < actionSpace.Data.Length; i++)
                sTheory.Points.AddXY(actionSpace.GetSteering(i), actionSpace.GetSpeed(i));

            Series sMeans = chartActionSpace.Series.Add("Means");
            sMeans.ChartType = SeriesChartType.Point;
            for (int i = 0; i < actionSpace.Means.Length; i++)
                sMeans.Points.AddXY(actionSpace.Means[i][0], actionSpace.Means[i][1]);

            this.tbPayLoad.Text = actionSpace.ToString();
            this.tbCheatData.Text = String.Format("import math{0}{0}{1}{0}{2}",
                Environment.NewLine,
                actionSpace.CheatData,
                Resources.Reward);

            DrawSimulation();
        }
        
        private void RefreshPathAfterRun(object sender, EventArgs e)
        {
            PathDrawer drawer = new PathDrawer(this.picTrack.Width, this.picTrack.Height)
            {
                PathFinder = this.pathFinder,
                BackgroundColor = Color.White,
                ShowOptimalPath = true,
                ShowWayPoints = true
            };

            this.picTrack.Image = drawer.Image;
        }
        #endregion

        #region Track drawing utilities
        private void DrawSimulation()
        {
            PathDrawer drawer = new PathDrawer(this.picSimulation.Width, this.picSimulation.Height)
            {
                PathFinder = this.pathFinder,
                SpeedPoints = this.actionSpace.Data,
                SpeedValues = this.actionSpace.Speeds,
                ShowSpeedPoints = true
            };
            this.picSimulation.Image = drawer.Image;
        }

        private bool resizeInProgress = false;
        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (this.pathFinder == null || this.pathFinder.TrackData == null || resizeInProgress) return;
            resizeInProgress = true;
            int currentIndex = this.mainTabControl.SelectedIndex;
            for (int i = 0; i < this.mainTabControl.TabCount; i++) this.mainTabControl.SelectTab(i);
            this.mainTabControl.SelectTab(currentIndex);
            RefreshPathAfterRun(sender, e);
            RefreshActionSpaceAfterRun(sender, e);
            resizeInProgress = false;
        }

        private void CopyImageToClibpboard(object sender, EventArgs e)
        {
            PictureBox pbox = (PictureBox)sender;
            if (pbox.Image == null) return;
            Clipboard.SetImage(pbox.Image);
        }
        #endregion

        private void roboMakerLogsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() != DialogResult.OK) return;

            Dictionary<int, LogRecord> logs = new Dictionary<int, LogRecord>();

            Regex regex = new Regex("^SIM_TRACE_LOG:(?<lap_id>\\d+),(?<step_id>\\d+),(?<x>[0-9.\\-]+),(?<y>[0-9.\\-]+),(?<head>[0-9.\\-]+),(?<steering>[0-9.\\-]+),(?<speed>[0-9.\\-]+).*,(?<progress>[0-9.\\-]+),([0-9.\\-]+),([0-9.\\-]+),(?<time>[0-9.\\-]+),(?<status>[a-z_]+)$");
            foreach (String s in File.ReadLines(ofd.FileName))
            {
                Match m = regex.Match(s);
                if (!m.Success) continue;
                Func<String, String> readString = name => m.Groups[name].Value.Replace('.', ',');

                int lapId = int.Parse(readString("lap_id"));
                if (!logs.ContainsKey(lapId)) logs.Add(lapId, new LogRecord(lapId, pathFinder));

                double x = double.Parse(readString("x"));
                double y = double.Parse(readString("y"));
                double speed = double.Parse(readString("speed"));
                double progress = double.Parse(readString("progress"));
                double time = double.Parse(readString("time"));
                String state = readString("status");
                logs[lapId].AddLine(x, y, speed, progress, time, state);
            }

            LogPathViewer logPathViewer = new LogPathViewer();
            logPathViewer.PathFinder = this.pathFinder;
            logPathViewer.Logs = logs.Values.ToList();
            logPathViewer.Show();
        }

        private void speedIncreaseToolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() != DialogResult.OK) return;

            if (speedHack.ShowDialog() != DialogResult.OK) return;
            Func<double, double> speedIncrease = speedHack.SpeedHackTransformer;
            
            Regex r = new Regex("\"speed\": (.+),");
            MatchEvaluator me = new MatchEvaluator(match =>
                "\"speed\": " +
                speedIncrease(double.Parse(match.Groups[1].Value.Replace('.', ','))).ToString().Replace(',', '.') +
                ","
            );
            String[] res = File.ReadLines(ofd.FileName).Select(s => r.Replace(s, me)).ToArray();
            File.WriteAllLines(Path.GetDirectoryName(ofd.FileName)+"\\model_metadata.json", res);
        }
    }
}
