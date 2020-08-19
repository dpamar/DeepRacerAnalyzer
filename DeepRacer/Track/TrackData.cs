using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepRacer.Track
{
    public abstract class TrackData
    {
        /// <summary>
        /// WayPoints : always loaded from data file (NPY or list of points)
        /// </summary>
        public double[][] WayPoints { get; protected set; }

        /// <summary>
        /// Track inner bounds : either loaded from NPY or computed from waypoints
        /// </summary>
        public double[][] InnerBounds { get; protected set; }
        /// <summary>
        /// Track outer bounds : either loaded from NPY or computed from waypoints
        /// </summary>
        public double[][] OuterBounds { get; protected set; }

        /// <summary>
        /// Track width - mandatory only to compute bounds from waypoints
        /// </summary>
        protected double TrackWidth { get; set; }

        /// <summary>
        /// Get waypoints in cyclic way
        /// </summary>
        /// <param name="index">Index of the waypoint</param>
        /// <returns>Point at desired index, converted into a Z/nZ value</returns>
        public double[] this[int index]
        {
            get { return WayPoints[(index + WayPoints.Length) % WayPoints.Length]; }
        }

        /// <summary>
        /// Fill innner and outer bounds from waypoints and track width
        /// </summary>
        protected void ResolveBorders()
        {
            //Compute multiplication factor : distance from waypoints divided by 2
            double factor = TrackWidth / 4;

            InnerBounds = new double[WayPoints.Length][];
            OuterBounds = new double[WayPoints.Length][];
            for (int i = 0; i < WayPoints.Length; i++)
            {
                double[] previous = this[i - 1];
                double[] current = this[i];
                double[] next = this[i + 1];

                double deltaX1 = current[0] - previous[0],
                    deltaX2 = next[0] - current[0],
                    deltaY1 = current[1] - previous[1],
                    deltaY2 = next[1] - current[1],
                    d1 = Math.Sqrt(deltaX1 * deltaX1 + deltaY1 * deltaY1),
                    d2 = Math.Sqrt(deltaX2 * deltaX2 + deltaY2 * deltaY2);

                InnerBounds[i] = new double[]
                {
                    current[0] - factor * (deltaY1 / d1 + deltaY2 / d2),
                    current[1] + factor * (deltaX1 / d1 + deltaX2 / d2),
                };
                OuterBounds[i] = new double[]
                {
                    current[0] + factor * (deltaY1 / d1 + deltaY2 / d2),
                    current[1] - factor * (deltaX1 / d1 + deltaX2 / d2),
                };
            }
        }
    }
}
