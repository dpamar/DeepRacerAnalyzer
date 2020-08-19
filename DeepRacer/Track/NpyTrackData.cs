using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Numpy;

namespace DeepRacer.Track
{
    /// <summary>
    /// Loads track data from NPY file with waypoints and bounds inside
    /// </summary>
    public class NpyTrackData : TrackData
    {
        public NpyTrackData(string filename)
        {
            NDarray arr = np.load(filename);

            double[] t = arr.GetData<double>();
            int pointCount = t.Length / 6;
            WayPoints = new double[pointCount][];
            InnerBounds = new double[pointCount][];
            OuterBounds = new double[pointCount][];
            for (int i = 0; i < pointCount; i++)
            {
                WayPoints[i] = new double[] { t[i * 6], t[i * 6 + 1] };
                InnerBounds[i] = new double[] { t[i * 6 + 2], t[i * 6 + 3] };
                OuterBounds[i] = new double[] { t[i * 6 + 4], t[i * 6 + 5] };
            }
        }
    }
}
