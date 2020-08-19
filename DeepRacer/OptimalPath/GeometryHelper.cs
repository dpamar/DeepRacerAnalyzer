using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepRacer.OptimalPath
{
    public class GeometryHelper
    {
        /// <summary>
        /// Check if point lies in polygon, using the "ray beam" method : considering a ray starting from Point and moving horizontally
        /// Then for each edge
        ///     - ray crosses the edge : it moves from outside polygon to inside, or the opposite
        ///     - ray doesn't cross the edge : it stays where it initially was
        /// Note : for clockwise polygons, result is inverted (the delimited shape isn't the polygon but all the space around)
        /// </summary>
        /// <param name="point">(x,y) coordinates</param>
        /// <param name="polygon">Set of (x,y) coordinates, counterclockwise</param>
        /// <returns>True if point lies in delimited area, false otherwise</returns>
        public static bool PointWithinPolygon(double[] point, double[][] polygon)
        {
            bool isInside = false;

            double[] oldPoint = polygon[polygon.Length - 1];
            foreach (double[] currentPoint in polygon)
            {
                isInside ^= ((currentPoint[1] > point[1]) ^ (oldPoint[1] > point[1]))
                    && point[0] < (oldPoint[0] - currentPoint[0]) * (point[1] - currentPoint[1]) / (oldPoint[1] - currentPoint[1]) + currentPoint[0];

                oldPoint = currentPoint;
            }
            return isInside;
        }

        /// <summary>
        /// Dot product between 2 2D vectors
        /// </summary>
        /// <param name="vec1">First vector</param>
        /// <param name="vec2">Second vector</param>
        /// <returns>Sum of products for each vector coordinate</returns>
        public static double Dot(double[] vec1, double[] vec2)
        {
            return vec1[0] * vec2[0] + vec1[1] * vec2[1];
        }

        /// <summary>
        /// Get mid point of segment [P1;P2]
        /// </summary>
        /// <param name="p1">First point</param>
        /// <param name="p2">Second point</param>
        /// <returns>Mid point coordinates</returns>
        public static double[] MidPoint(double[] p1, double[] p2)
        {
            return new double[] { (p1[0] + p2[0]) / 2, (p1[1] + p2[1]) / 2 };
        }

        /// <summary>
        /// Get curvature through 3 points
        /// </summary>
        /// <param name="pt1">First point</param>
        /// <param name="pt2">Second point</param>
        /// <param name="pt3">Third point</param>
        /// <returns>Curvature</returns>
        public static double Curvature(double[] pt1, double[] pt2, double[] pt3)
        {
            double[] vec21 = new double[] { pt1[0] - pt2[0], pt1[1] - pt2[1] };
            double[] vec23 = new double[] { pt3[0] - pt2[0], pt3[1] - pt2[1] };
            double[] vec13 = new double[] { pt3[0] - pt1[0], pt3[1] - pt1[1] };

            double norm21 = Norm(vec21);
            double norm23 = Norm(vec23);

            return 2 * Math.Sqrt(Math.Pow(norm21 * norm23, 2) - Math.Pow(Dot(vec21, vec23), 2)) / Norm(vec13) / norm21 / norm23;
        }

        /// <summary>
        /// Get euclidean norm of 2D vector
        /// </summary>
        /// <param name="vector">Vector</param>
        /// <returns>Euclidean norm</returns>
        private static double Norm(double[] vector)
        {
            return Math.Sqrt(vector[0] * vector[0] + vector[1] * vector[1]);
        }
    }
}
