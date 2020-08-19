using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepRacer.ActionSpace
{
    /// <summary>
    /// Compute set of needed actions, and means to fit AWS DeepRacer requirements
    /// </summary>
    public class ActionSpaceCalculator
    {

        public event EventHandler AfterRun;

        const double L = 0.165;
        const double MaxSpeed = 4;
        const double AngleMax = 30;
        const int K = 19;

        public double MinSpeed { get; set; }
        public int Forecast { get; set; }

        public double[][] Data { get; set; }
        public double[][] Means { get; private set; }
        public string CheatData {
            get
            {
                StringBuilder res = new StringBuilder("cheat_data = [");
                for (int i = 0; i < Data.Length; i++)
                    res.AppendFormat("[[{0},{1}],[{2},{3}],{4},{5},{6}]{7}",
                    this[i][0].ToString().Replace(",", "."),
                    this[i][1].ToString().Replace(",", "."),
                    this[i + 1][0].ToString().Replace(",", "."),
                    this[i + 1][1].ToString().Replace(",", "."),
                    GetSpeed(i).ToString().Replace(",", "."),
                    GetSteering(i).ToString().Replace(",", "."),
                    GetHeading(i).ToString().Replace(",", "."),
                    (i == Data.Length - 1 ? ']' : ',') + Environment.NewLine);

                return res.ToString();
            }
        }

        private double[] radius, speed, steering, heading;
        public double[] Speeds { get { return this.speed; }  }

        public ActionSpaceCalculator()
        {
            this.MinSpeed = 1.72;
            this.Forecast = 5;
        }

        public void Run()
        {
            this.radius = new double[Data.Length];
            this.speed = new double[Data.Length];
            this.steering = new double[Data.Length];
            this.heading = new double[Data.Length];

            int i = 0;
            for (i = 0; i < Data.Length; i++) this.radius[i] = Radius(i);
            for (i = 0; i < Data.Length; i++) this.speed[i] = Math.Min(MaxSpeed, Speed(i));
            for (i = 0; i < Data.Length; i++) this.steering[i] = Steering(i);
            for (i = 0; i < Data.Length; i++) this.heading[i] = Heading(i);

            KMeans kMeans = new KMeans(K, Data.Length);
            for (i = 0; i < Data.Length; i++) kMeans.AddPoint(steering[i], speed[i]);
            kMeans.Run();
            this.Means = new double[K + 2][];
            i = 0;
            kMeans.means.ForEach(x => Means[i++] = new double[] { x[0], x[1] });
            Means[i++] = new double[] { -AngleMax, MinSpeed };
            Means[i++] = new double[] { AngleMax, MinSpeed };

            if (AfterRun != null)
                AfterRun(this, null);
        }

        private double Heading(int index)
        {
            double[] p1 = this[index];
            double[] p2 = this[index + 1];
            return Math.Atan2(p2[1] - p1[1], p2[0] - p1[0]) / Math.PI * 180;
        }

        private double Speed(int index)
        {
            return MinSpeed * Math.Sqrt(Enumerable.Range(index, Forecast).Select(GetRadius).Min());
        }

        private int GetIndex(int index)
        {
            return (index + Data.Length) % Data.Length;
        }

        public double GetRadius(int index)
        {
            return this.radius[GetIndex(index)];
        }
        public double GetSpeed(int index)
        {
            return this.speed[GetIndex(index)];
        }
        public double GetSteering(int index)
        {
            return this.steering[GetIndex(index)];
        }
        public double GetHeading(int index)
        {
            return this.heading[GetIndex(index)];
        }

        private double Radius(int index)
        {
            double[] p1 = this[index - 1];
            double[] p2 = this[index];
            double[] p3 = this[index + 1];
            double x1 = p1[0], y1 = p1[1],
                x2 = p2[0], y2 = p2[1],
                x3 = p3[0], y3 = p3[1];
            double a = x1 * (y2 - y3) - y1 * (x2 - x3) + x2 * y3 - x3 * y2;
            double b = (x1 * x1 + y1 * y1) * (y3 - y2) + (x2 * x2 + y2 * y2) * (y1 - y3) + (x3 * x3 + y3 * y3) * (y2 - y1);
            double c = (x1 * x1 + y1 * y1) * (x2 - x3) + (x2 * x2 + y2 * y2) * (x3 - x1) + (x3 * x3 + y3 * y3) * (x1 - x2);
            double d = (x1 * x1 + y1 * y1) * (x3 * y2 - x2 * y3) + (x2 * x2 + y2 * y2) * (x1 * y3 - x3 * y1) + (x3 * x3 + y3 * y3) * (x2 * y1 - x1 * y2);
            if (a == 0) return 999;
            return Math.Sqrt(Math.Abs(b * b + c * c - 4 * a * d) / (4 * a * a));
        }

        private double Steering(int index)
        {
            double[] p1 = this[index - 1];
            double[] p2 = this[index];
            double[] p3 = this[index + 1];
            double angle = Math.Asin(L / radius[index]) * 180 / Math.PI;
            if ((p2[0] - p1[0]) * (p3[1] - p1[1]) > (p2[1] - p1[1]) * (p3[0] - p1[0]))
                return angle;
            return -angle;
        }

        public double[] this[int index] { get { return this.Data[GetIndex(index)]; } }
        
        public override string ToString()
        {
            int n = 0;
            StringBuilder sbActionSpace = new StringBuilder("\\\\\\\"action_space\\\\\\\":[");
            foreach (double[] m in Means)
                sbActionSpace.AppendFormat("{{\\\\\\\"steering_angle\\\\\\\":{0},\\\\\\\"speed\\\\\\\":{1},\\\\\\\"index\\\\\\\":{2}}}{3}",
                   m[0].ToString().Replace(",", "."),
                   m[1].ToString().Replace(",", "."),
                   n++,
                   (n == 21 ? "]" : ",")
                   );
            return sbActionSpace.ToString();
        }
    }
}
