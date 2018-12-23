using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace SemanticNetworksLibrary.Drawing
{
    public class DrawingAlghoritms
    {
        public static Point GetPoint(double t, PointF p1, PointF p2, PointF p3)
        {
            int x = (int)Math.Round((1 - t) * (1 - t) * p1.X + 2 * (1 - t) * t * p2.X + t * t * p3.X);
            int y = (int)Math.Round((1 - t) * (1 - t) * p1.Y + 2 * (1 - t) * t * p2.Y + t * t * p3.Y);
            return new Point(x, y);
        }

        public static void Circle(Graphics g, Brush brush, Pen pen, int x, int y, int w, int h)
        {
            g.FillEllipse(brush, x, y, w, h);
            g.DrawEllipse(pen, x, y, w, h);
        }

        public static void Rectangle(Graphics g, Brush brush, Pen pen, int x, int y, int w, int h)
        {
            g.FillRectangle(brush, x, y, w, h);
            g.DrawRectangle(pen, x, y, w, h);
        }

        public static List<PointF> GetBezierCurveNodes(float p1X, float p1Y, float p2X, float p2Y, float p1cX, float p1cY, float p2cX, float p2cY, int numberOfNodes)
        {
            List<PointF> pts = new List<PointF>();

            float dt = 1f / (numberOfNodes - 1);
            float t = -dt;
            for (int i = 0; i < numberOfNodes; i++)
            {
                t += dt;
                float tt = t * t;
                float ttt = tt * t;
                float tt1 = (1 - t) * (1 - t);
                float ttt1 = tt1 * (1 - t);

                float x = ttt1 * p1X +
                          3 * t * tt1 * p1cX +
                          3 * tt * (1 - t) * p2cX +
                          ttt * p2X;

                float y = ttt1 * p1Y +
                          3 * t * tt1 * p1cY +
                          3 * tt * (1 - t) * p2cY +
                          ttt * p2Y;

                pts.Add(new PointF(x, y));
            }
            return pts;
        }

        public static List<PointF> GetBezierCurveNodes(PointF p1, PointF p1c, PointF p2c, PointF p2, int numberOfNodes)
        {
            List<PointF> pts = new List<PointF>();

            float dt = 1f / (numberOfNodes - 1);
            float t = -dt;
            for (int i = 0; i < numberOfNodes; i++)
            {
                t += dt;
                float tt = t * t;
                float ttt = tt * t;
                float tt1 = (1 - t) * (1 - t);
                float ttt1 = tt1 * (1 - t);

                float x = ttt1 * p1.X +
                          3 * t * tt1 * p1c.X +
                          3 * tt * (1 - t) * p2c.X +
                          ttt * p2.X;

                float y = ttt1 * p1.Y +
                          3 * t * tt1 * p1c.Y +
                          3 * tt * (1 - t) * p2c.Y +
                          ttt * p2.Y;

                pts.Add(new PointF(x, y));
            }
            return pts;
        }

        public static float GetDistance(float x1, float y1, float x2, float y2)
        {
            return (float)Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
        }

        public static GraphicsPath RoundedRectangle(RectangleF rect, float xradius, float yradius, bool upperleft, bool upperright, bool lowerright, bool lowerleft)
        {
            PointF point1, point2;
            GraphicsPath path = new GraphicsPath();

            // Верхний левый угол
            if (upperleft)
            {
                RectangleF corner = new RectangleF(
                    rect.X, rect.Y,
                    2 * xradius, 2 * yradius);
                path.AddArc(corner, 180, 90);
                point1 = new PointF(rect.X + xradius, rect.Y);
            }
            else point1 = new PointF(rect.X, rect.Y);

            // Вверхняя сторона
            if (upperright)
                point2 = new PointF(rect.Right - xradius, rect.Y);
            else
                point2 = new PointF(rect.Right, rect.Y);
            path.AddLine(point1, point2);

            // Верхний правый угол
            if (upperright)
            {
                RectangleF corner = new RectangleF(
                    rect.Right - 2 * xradius, rect.Y,
                    2 * xradius, 2 * yradius);
                path.AddArc(corner, 270, 90);
                point1 = new PointF(rect.Right, rect.Y + yradius);
            }
            else point1 = new PointF(rect.Right, rect.Y);

            // Правая сторона
            if (lowerright)
                point2 = new PointF(rect.Right, rect.Bottom - yradius);
            else
                point2 = new PointF(rect.Right, rect.Bottom);
            path.AddLine(point1, point2);

            // Нижний правый угол
            if (lowerright)
            {
                RectangleF corner = new RectangleF(
                    rect.Right - 2 * xradius,
                    rect.Bottom - 2 * yradius,
                    2 * xradius, 2 * yradius);
                path.AddArc(corner, 0, 90);
                point1 = new PointF(rect.Right - xradius, rect.Bottom);
            }
            else point1 = new PointF(rect.Right, rect.Bottom);

            // Нижняя сторона
            if (lowerleft)
                point2 = new PointF(rect.X + xradius, rect.Bottom);
            else
                point2 = new PointF(rect.X, rect.Bottom);
            path.AddLine(point1, point2);

            // Нижняя левая сторона
            if (lowerleft)
            {
                RectangleF corner = new RectangleF(
                    rect.X, rect.Bottom - 2 * yradius,
                    2 * xradius, 2 * yradius);
                path.AddArc(corner, 90, 90);
                point1 = new PointF(rect.X, rect.Bottom - yradius);
            }
            else point1 = new PointF(rect.X, rect.Bottom);

            // Левая сторона
            if (upperleft)
                point2 = new PointF(rect.X, rect.Y + yradius);
            else
                point2 = new PointF(rect.X, rect.Y);
            path.AddLine(point1, point2);

            // Замкнуть контур
            path.CloseFigure();

            return path;
        }
    }
}
