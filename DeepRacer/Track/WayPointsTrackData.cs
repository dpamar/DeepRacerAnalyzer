using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepRacer.Track
{
    /// <summary>
    /// Loads track data from a set of points (waypoints) and track width
    /// </summary>
    public class WayPointsTrackData : TrackData
    {
        public WayPointsTrackData(double trackWidth, double[][] waypoints)
        {
            WayPoints = waypoints;
            TrackWidth = trackWidth;
            ResolveBorders();
        }
    }
}
