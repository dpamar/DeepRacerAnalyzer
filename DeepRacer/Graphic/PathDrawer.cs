using DeepRacer.OptimalPath;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepRacer.Graphic
{
    public class PathDrawer
    {
        public PathFinder PathFinder { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }

        public Color BackgroundColor { get; set; }

        public bool ShowWayPoints { get; set; }
        public bool ShowOptimalPath { get; set; }

        public bool ShowSpeedPoints { get; set; }
        public double[][] SpeedPoints { get; set; }
        public double[] SpeedValues { get; set; }


        private float xMin, xMax, yMin, yMax;
        private void SetScale()
        {
            xMin = (float)this.PathFinder.OuterBounds.Min(x => x[0]) - 1f;
            xMax = (float)this.PathFinder.OuterBounds.Max(x => x[0]) + 1f;
            yMin = (float)this.PathFinder.OuterBounds.Min(x => x[1]) - 1f;
            yMax = (float)this.PathFinder.OuterBounds.Max(x => x[1]) + 1f;
        }

        public PathDrawer(int width, int height)
        {
            this.Width = width;
            this.Height = height;
            this.ShowWayPoints = false;
            this.ShowOptimalPath = false;
            this.ShowSpeedPoints = false;
            this.BackgroundColor = Color.Black;
        }

        public Image Image
        {
            get
            {
                SetScale();

                Image img = new Bitmap(Width, Height);
                Graphics graphics = Graphics.FromImage(img);

                graphics.FillRectangle(new SolidBrush(BackgroundColor), 0, 0, Width, Height);
                GenerateBaseMap(graphics);

                if(ShowWayPoints)
                    graphics.DrawPolygon(Pens.DarkGoldenrod, GetScaledPolygon(PathFinder.WayPoints));
                if(ShowOptimalPath)
                    graphics.DrawPolygon(Pens.Aqua, GetScaledPolygon(PathFinder.Path));
                if (ShowSpeedPoints)
                    DrawSpeedPoints(graphics);
                return img;
            }
        }

        private void DrawSpeedPoints(Graphics graphics)
        {
            float radius = 1f;
            Brush[] brushMap = new Brush[9]
            {
                Brushes.GhostWhite,
                Brushes.MintCream,
                Brushes.LightGreen,
                Brushes.Chartreuse,
                Brushes.Yellow,
                Brushes.Gold,
                Brushes.Tomato,
                Brushes.OrangeRed,
                Brushes.Red
            };
            for (int i = 0; i < SpeedPoints.Length; i++)
            {
                graphics.FillRectangle(
                    SpeedValues[i] >= 4.5 ? Brushes.Crimson : brushMap[(int)(SpeedValues[i] * 2)],
                    new RectangleF(
                        ScaleX(SpeedPoints[i][0]) - radius,
                        ScaleY(SpeedPoints[i][1]) - radius,
                        2 * radius,
                        2 * radius));
            }
        }

        private void GenerateBaseMap(Graphics graphics)
        {
            graphics.DrawPolygon(Pens.Red, GetScaledPolygon(PathFinder.OuterBounds));
            graphics.DrawPolygon(Pens.Red, GetScaledPolygon(PathFinder.InnerBounds));
            graphics.DrawPolygon(Pens.Orange, GetScaledPolygon(PathFinder.OuterBand));
            graphics.DrawPolygon(Pens.Orange, GetScaledPolygon(PathFinder.InnerBand));
        }

        private PointF[] GetScaledPolygon(double[][] points)
        {
            return points.Select(p => new PointF(ScaleX(p[0]), ScaleY(p[1]))).ToArray();
        }

        private float ScaleX(double x)
        {
            float scale = Width / (xMax - xMin);
            return (float)(x - xMin) * scale;
        }

        private float ScaleY(double y)
        {
            float scale = Height / (yMax - yMin);
            return Height - (float)(y - yMin) * scale;
        }
    }
}
