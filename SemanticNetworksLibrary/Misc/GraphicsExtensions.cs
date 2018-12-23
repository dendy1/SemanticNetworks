using SemanticNetworksLibrary.Drawing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace SemanticNetworksLibrary.Misc
{
    public static class GraphicsExtensions
    {
        public static void DrawHalfArrow(this Graphics g, Pen pen, PointF p1, PointF temp, PointF p2)
        {
            double step = 0.01;
            Point current, previous;
            for (double t = 0; t <= 1;)
            {
                previous = DrawingAlghoritms.GetPoint(t, p1, temp, p2);
                t += step;
                current = DrawingAlghoritms.GetPoint(t, p1, temp, p2);
                g.DrawLine(pen, current, previous);
                g.FillPolygon(new SolidBrush(pen.Color), new PointF[] { temp, current, previous });
            }
        }

        public static void DrawCurve(this Graphics g, Pen pen, float p1X, float p1Y, float p2X, float p2Y, float p1cX,
            float p1cY, float p2cX, float p2cY, float arrowHeadWidth, float arrowHeadHeight, int nodesCount)
        {
            List<PointF> bezierLine =
                DrawingAlghoritms.GetBezierCurveNodes(p1X, p1Y, p2X, p2Y, p1cX, p1cY, p2cX, p2cY, nodesCount * 3 + 1);
            g.DrawBeziers(pen, bezierLine.ToArray());
        }

        public static void DrawCurve(this Graphics g, Pen pen, PointF start, PointF centerS, PointF centerE, PointF end,  float arrowHeadWidth, float arrowHeadHeight, int nodesCount)
        {
            float p1X = start.X,
                p1Y = start.Y,
                p2X = end.X,
                p2Y = end.Y,
                p1cX = centerS.X,
                p1cY = centerS.Y,
                p2cX = centerE.X,
                p2cY = centerE.Y;

            g.DrawCurve(pen, p1X, p1Y, p2X, p2Y, p1cX, p1cY, p2cX, p2cY, arrowHeadWidth, arrowHeadWidth, nodesCount);
        }

        public static void DrawRoundedRectangle(this Graphics g, Pen pen, float X, float Y, float width, float height, float xradius, float yradius,
            bool upperleft, bool upperright, bool lowerleft, bool lowerright)
        {
            RectangleF rect = new RectangleF(X, Y, width, height);
            GraphicsPath rounded = DrawingAlghoritms.RoundedRectangle(rect, xradius, yradius, upperleft, upperright,
                lowerright, lowerleft);
            g.DrawPath(pen, rounded);
        }

        public static void FillRoundedRectangle(this Graphics g, Brush brush, float X, float Y, float width, float height, float xradius, float yradius,
            bool upperleft, bool upperright, bool lowerleft, bool lowerright)
        {
            RectangleF rect = new RectangleF(X, Y, width, height);
            GraphicsPath rounded = DrawingAlghoritms.RoundedRectangle(rect, xradius, yradius, upperleft, upperright,
                lowerright, lowerleft);
            g.FillPath(brush, rounded);
        }
    }
}
