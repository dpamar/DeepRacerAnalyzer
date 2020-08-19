using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepRacer.ActionSpace
{
    /// <summary>
    /// Quick and dirty KMeans++ implementation
    /// </summary>
    class KMeans
    {
        public double[][] points;
        public List<double[]> means = new List<double[]>();
        int index = 0;
        int k;
        int size;
        public int[] partition;

        public KMeans(int k, int size)
        {
            this.k = k;
            this.size = size;
            points = new double[size][];
        }

        public void AddPoint(double steering, double speed)
        {
            points[index++] = new double[] { steering, speed };
        }

        public void Run()
        {
            Random r = new Random();
            double[] p = this.points[r.Next(size)];
            this.means.Add(new double[] { p[0], p[1] });
            double[] distances = new double[size];
            for (int i = 1; i < size; i++) distances[i] = Double.MaxValue;

            for (int i = 1; i < k; i++)
            {

                double sum = 0;

                int j = 0;
                for (j = 0; j < size; j++)
                {
                    var d = Distance(this.points[j], this.means[i - 1]);
                    if (d < distances[j]) distances[j] = d;
                    sum += distances[j];
                }
                double rnd = r.NextDouble() * sum;
                for (j = 0; rnd > 0; j++) rnd -= distances[j];
                p = this.points[j - 1];
                this.means.Add(new double[] { p[0], p[1] });
            }

            this.GetPartition();
            while (Next()) ;
        }

        public bool Next()
        {
            int[] currentPartition = new int[size];
            double[][] sums = new double[k][];
            int[] counts = new int[k];

            for (int i = 0; i < this.k; i++)
            {
                double[] sum = new double[2] { 0, 0 };
                sums[i] = sum;
                counts[i] = 0;
            }


            for (int i = 0; i < size; i++)
            {
                int target = this.partition[i];
                currentPartition[i] = target;

                for (int j = 0; j < 2; j++) sums[target][j] += this.points[i][j];
                counts[target]++;
            }
            for (int i = 0; i < this.k; i++)
            {
                if (counts[i] == 0) continue;
                for (var j = 0; j < 2; j++) sums[i][j] /= counts[i];
            }

            this.means.Clear();
            for (int i = 0; i < k; i++) this.means.Add(sums[i]);
            this.GetPartition();
            for (int i = 0; i < size; i++)
                if (this.partition[i] != currentPartition[i]) return true;
            return false;

        }

        public int[] GetPartition()
        {
            int[] result = new int[size];
            for (int i = 0; i < size; i++)
            {
                double min = double.MaxValue;
                int target = -1;
                for (int j = 0; j < this.k; j++)
                {
                    double dist = Distance(this.means[j], this.points[i]);
                    if (dist > min) continue;
                    min = dist;
                    target = j;
    
                }
                result[i] = target;
            }
            return this.partition = result;
        }

        private double Distance(double[] p1, double[] p2)
        {
            return Math.Sqrt((p1[0] - p2[0]) * (p1[0] - p2[0]) + (p1[1] - p2[1]) * (p1[1] - p2[1]));
        }
    }
}
