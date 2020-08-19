using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeepRacer.Track;

namespace DeepRacer.OptimalPath
{
    public class PathFinder
    {
        private const int CURVING_ITERATION_COUNT = 4;

        public event EventHandler AfterRun;

        public int IterationCount { get; set; }

        public double[][] InnerBand { get; set; }
        public double[][] OuterBand { get; set; }
        public double[][] Path { get; set; }

        public TrackData TrackData { get; set; }

        public double[][] WayPoints { get { return this.TrackData.WayPoints; } }
        public double[][] InnerBounds { get { return this.TrackData.InnerBounds; } }
        public double[][] OuterBounds { get { return this.TrackData.OuterBounds; } }

        public PathFinder()
        {
            IterationCount = 1000;
        }

        public void Run(double bandPercentage)
        {
            InnerBand = new double[WayPoints.Length][];
            OuterBand = new double[WayPoints.Length][];
            for (int i = 0; i < WayPoints.Length; i++)
            {
                InnerBand[i] = new double[]
                {
                    InnerBounds[i][0] * bandPercentage + WayPoints[i][0] * (1-bandPercentage),
                    InnerBounds[i][1] * bandPercentage + WayPoints[i][1] * (1-bandPercentage)
                };
                OuterBand[i] = new double[]
                {
                    OuterBounds[i][0] * bandPercentage + WayPoints[i][0] * (1-bandPercentage),
                    OuterBounds[i][1] * bandPercentage + WayPoints[i][1] * (1-bandPercentage)
                };
            }

            Path = ClonePath(WayPoints);

            for (int iteration = 0; iteration < IterationCount; iteration++)
            {
                for (int i = 0; i < Path.Length; i++)
                {
                    double[] a = this[i - 2],
                        b = this[i - 1],
                        c = this[i],
                        d = this[i + 1],
                        e = this[i + 2];

                    double prevCurv = GeometryHelper.Curvature(a, b, c);
                    double currCurv = GeometryHelper.Curvature(b, c, d);
                    double nextCurv = GeometryHelper.Curvature(c, d, e);
                    double targetCurv = (prevCurv + nextCurv) / 2;

                    //state : min, current, max
                    double[][] state = new double[][] {
                        GeometryHelper.MidPoint(b, d),
                        new double[] { c[0], c[1] },
                        new double[] { c[0], c[1] } };

                    for (int j = 0; j < CURVING_ITERATION_COUNT; j++)
                    {
                        double actualCurv = GeometryHelper.Curvature(b, state[1], d);
                        if (Math.Abs(actualCurv - targetCurv) <= 1e-8) break;

                        bool increaseCurve = actualCurv < targetCurv;
                        //Get midpoint from either min-current or current-max
                        state[increaseCurve ? 0 : 2] = state[1];
                        double[] newPoint = GeometryHelper.MidPoint(state[0], state[2]);
                        state[IsOnTrack(newPoint) ? 1 : increaseCurve ? 2 : 0] = newPoint;
                    }
                    Path[i][0] = state[1][0];
                    Path[i][1] = state[1][1];
                }
            }

            if (this.AfterRun != null)
                AfterRun(this, null);
        }

        private bool IsOnTrack(double[] point)
        {
            //Point is on track if it lies within the outer border but not within the inner one
            return GeometryHelper.PointWithinPolygon(point, OuterBand)
                && !GeometryHelper.PointWithinPolygon(point, InnerBand);
        }

        private double[] this[int index] { get { return Path[(index + Path.Length) % Path.Length]; } }

        private double[][] ClonePath(double[][] path)
        {
            double[][] result = new double[path.Length][];
            for(int i=0; i<path.Length; i++)
                result[i] = new double[]{ path[i][0], path[i][1]};
            return result;
        }
    }
}
