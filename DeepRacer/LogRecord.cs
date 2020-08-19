using DeepRacer.Graphic;
using DeepRacer.OptimalPath;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepRacer
{
    public class LogRecord
    {
        public int LapId { get; private set; }
        public List<double[]> Points { get; private set; }
        public List<double> Speeds { get; private set; }
        public double StartTime { get; private set; }
        public double EndTime { get; private set; }
        public double Progress { get; private set; }
        public bool Finished { get; private set; }
        public PathFinder PathFinder { get; set; }

        public LogRecord(int lapId, PathFinder pathFinder)
        {
            this.LapId = lapId;
            this.PathFinder = pathFinder;
            this.Points = new List<double[]>();
            this.Speeds = new List<double>();
            this.StartTime = double.MaxValue;
            this.EndTime = double.MinValue;
            this.Progress = double.MinValue;
            this.Finished = false;
        }

        public void AddLine(double x, double y, double speed, double progress, double time, String state)
        {
            this.Points.Add(new double[] { x, y });
            this.Speeds.Add(speed);
            this.Progress = Math.Max(this.Progress, progress);
            this.StartTime = Math.Min(this.StartTime, time);
            this.EndTime = Math.Max(this.EndTime, time);
            this.Finished |= state == "lap_complete";
        }

        public Image GetImage(int width, int height)
        {
            PathDrawer drawer = new PathDrawer(width, height)
            {
                PathFinder = PathFinder,
                SpeedPoints = Points.ToArray(),
                SpeedValues = Speeds.ToArray(),
                ShowSpeedPoints = true
            };
            return drawer.Image;
        }
    }
}
