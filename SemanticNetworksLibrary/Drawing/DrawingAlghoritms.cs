using System;
using System.Drawing;

namespace SemanticNetworksLibrary.Drawing
{
    public class DrawingAlghoritms
    {
        public static void DrawLine(Bitmap bmp, Color color, int x0, int y0, int x1, int y1)
        {
            var steep = Math.Abs(y1 - y0) > Math.Abs(x1 - x0);
            if (steep)
            {
                Swap(ref x0, ref y0);
                Swap(ref x1, ref y1);
            }
            if (x0 > x1)
            {
                Swap(ref x0, ref x1);
                Swap(ref y0, ref y1);
            }
            DrawPoint(bmp, color, x0, y0, 1, steep);
            DrawPoint(bmp, color, x1, y1, 1, steep);
            float dx = x1 - x0;
            float dy = y1 - y0;
            float gradient = dy / dx;
            float y = y0 + gradient;
            for (var x = x0 + 1; x <= x1 - 1; x++)
            {
                DrawPoint(bmp, color, x, (int)y, 1 - (y - (int)y), steep);
                DrawPoint(bmp, color, x, (int)y + 1, y - (int)y, steep);
                y += gradient;
            }
        }

        public static void DrawLine(Bitmap bmp, Color color, Point p0, Point p1)
        {
            DrawLine(bmp, color, p0.X, p0.Y, p1.X, p1.Y);
        }

        public static void DrawLine(Bitmap bmp, Color color, Point p0, int x1, int y1)
        {
            DrawLine(bmp, color, p0.X, p0.Y, x1, y1);
        }

        public static void DrawLine(Bitmap bmp, Color color, int x0, int y0, Point p1)
        {
            DrawLine(bmp, color, x0, y0, p1.X, p1.Y);
        }

        public static void DrawEllipse(Bitmap bmp, Color color, int x, int y, int width, int height)
        {
            int a = width / 2;
            int b = height / 2;
            int _x = 0;
            int _y = b;
            int a_sqr = a * a;
            int b_sqr = b * b;
            int delta = 
                4 * b_sqr * ((_x + 1) * (_x + 1)) +
                a_sqr * ((2 * _y - 1) * (2 * _y - 1)) -
                4 * a_sqr * b_sqr;

            while (a_sqr * (2 * _y - 1) > 2 * b_sqr * (_x + 1))
            {
                DrawPoint(bmp, color, x + _x, y + _y, 255);
                DrawPoint(bmp, color, x + _x, y - _y, 255);
                DrawPoint(bmp, color, x - _x, y + _y, 255);
                DrawPoint(bmp, color, x - _x, y - _y, 255);

                if (delta < 0)
                {
                    _x++;
                    delta += 4 * b_sqr * (2 * _x + 3);
                }
                else
                {
                    _x++;
                    delta = 
                        delta - 
                        8 * a_sqr * (_y - 1) + 
                        4 * b_sqr * (2 * _x + 3);
                    _y--;
                }
            }

            delta =
                b_sqr * ((2 * _x + 1) * (2 * _x + 1)) +
                4 * a_sqr * ((_y + 1) * (_y + 1)) -
                4 * a_sqr * b_sqr;

            while (_y + 1 != 0)
            {
                DrawPoint(bmp, color, x + _x, y + _y, 255);
                DrawPoint(bmp, color, x + _x, y - _y, 255);
                DrawPoint(bmp, color, x - _x, y + _y, 255);
                DrawPoint(bmp, color, x - _x, y - _y, 255);

                if (delta < 0)
                {
                    _y--;
                    delta += 4 * a_sqr * (2 * _y + 3);
                }
                else
                {
                    _y--;
                    delta = delta - 8 * b_sqr * (_x + 1) + 4 * a_sqr * (2 * _y - 3);
                    _x++;
                }
            }
        }

        public static void DrawEllipse(Bitmap bmp, Color color, Point center, int a, int b)
        {
            DrawEllipse(bmp, color, center.X, center.Y, a, b);
        }

        public static void DrawRectangle(Bitmap bmp, Color color, int x, int y, int width, int height)
        {
            DrawLine(bmp, color, x - width / 2, y - height / 2, x + width / 2, y - height / 2);
            DrawLine(bmp, color, x + width / 2, y - height / 2, x + width / 2, y + height / 2);
            DrawLine(bmp, color, x + width / 2, y + height / 2, x - width / 2, y + height / 2);
            DrawLine(bmp, color, x - width / 2, y + height / 2, x - width / 2, y - height / 2);
        }
       
        public static void FillEllipse(Bitmap bmp, Color color, int x, int y, int width, int height)
        {
            int a = width / 2;
            int b = height / 2;
            int _x = 0;
            int _y = b;
            int a_sqr = a * a;
            int b_sqr = b * b;
            int delta =
                4 * b_sqr * ((_x + 1) * (_x + 1)) +
                a_sqr * ((2 * _y - 1) * (2 * _y - 1)) -
                4 * a_sqr * b_sqr;

            while (a_sqr * (2 * _y - 1) > 2 * b_sqr * (_x + 1))
            {
                DrawHLine(bmp, color, x - _x, y + _y, 2 * _x);
                DrawHLine(bmp, color, x - _x, y - _y, 2 * _x);

                if (delta < 0)
                {
                    _x++;
                    delta += 4 * b_sqr * (2 * _x + 3);
                }
                else
                {
                    _x++;
                    delta =
                        delta -
                        8 * a_sqr * (_y - 1) +
                        4 * b_sqr * (2 * _x + 3);
                    _y--;
                }
            }

            delta =
                b_sqr * ((2 * _x + 1) * (2 * _x + 1)) +
                4 * a_sqr * ((_y + 1) * (_y + 1)) -
                4 * a_sqr * b_sqr;

            while (_y + 1 != 0)
            {
                DrawHLine(bmp, color, x - _x, y + _y, 2 * _x);
                DrawHLine(bmp, color, x - _x, y - _y, 2 * _x);

                if (delta < 0)
                {
                    _y--;
                    delta += 4 * a_sqr * (2 * _y + 3);
                }
                else
                {
                    _y--;
                    delta = delta - 8 * b_sqr * (_x + 1) + 4 * a_sqr * (2 * _y - 3);
                    _x++;
                }
            }
        }

        public static void FillEllipse(Bitmap bmp, Color color, Point center, int a, int b)
        {
            DrawEllipse(bmp, color, center.X, center.Y, a, b);
        }

        public static void FillRectangle(Bitmap bmp, Color color, int x, int y, int width, int height)
        {
            DrawLine(bmp, color, x - width / 2, y - height / 2, x + width / 2, y - height / 2);
            DrawLine(bmp, color, x + width / 2, y - height / 2, x + width / 2, y + height / 2);
            DrawLine(bmp, color, x + width / 2, y + height / 2, x - width / 2, y + height / 2);
            DrawLine(bmp, color, x - width / 2, y + height / 2, x - width / 2, y - height / 2);
        }

        private static void Swap(ref int x, ref int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }

        private static void Swap(ref Point p1, ref Point p2)
        {
            Point temp = p1;
            p1 = p2;
            p2 = temp;
        }

        private static void DrawPoint(Bitmap bmp, Color color, int x, int y, float alpha, bool steep)
        {
            if (alpha > 1) alpha = 1;
            if (alpha < 0) alpha = 0;
            Color newColor = Color.FromArgb((int)(alpha * 255), color);
            if (((steep ? x : y) >= 0) && ((steep ? x : y) < bmp.Height) && ((steep ? y : x) >= 0) && ((steep ? y : x) < bmp.Width))
                bmp.SetPixel(steep ? y : x, steep ? x : y, newColor);
        }

        private static void DrawPoint(Bitmap bmp, Color color, int x, int y, float alpha)
        {
            if (alpha > 1) alpha = 1;
            if (alpha < 0) alpha = 0;
            Color newColor = Color.FromArgb((int)(alpha * 255), color);
            if (y >= 0 && y < bmp.Height && x >= 0 && x < bmp.Width)
                bmp.SetPixel(x, y, newColor);
        }

        private static void DrawPoint(Bitmap bmp, Color color, int x, int y, int alpha)
        {
            if (alpha > 255) alpha = 255;
            if (alpha < 0) alpha = 0;
            Color newColor = Color.FromArgb(alpha, color);
            if (y >= 0 && y < bmp.Height && x >= 0 && x < bmp.Width)
                bmp.SetPixel(x, y, newColor);
        }

        private static void DrawHLine(Bitmap bmp, Color color, int x, int y, int w)
        {
            for (int i = 0; i < Math.Abs(w); i++)
                bmp.SetPixel(w > 0 ? x + i : x = i, y, color);
        }

        private static void DrawVLine(Bitmap bmp, Color color, int x, int y, int h)
        {
            for (int i = 0; i < Math.Abs(h); i++)
                bmp.SetPixel(x, h > 0 ? y + i : y - i, color);
        }

        public static void DrawArrowTest(Bitmap bmp, Color color, int x1, int y1, int x2, int y2, int h, int w)
        {
      
            Point p1 = new Point(x1, y1);
            Point p2 = new Point(x2, y2);
            //длина отрезка
            double d = Math.Sqrt((p2.X - p1.X) * (p2.X - p1.X) + (p2.Y - p1.Y) * (p2.Y - p1.Y));

            //координаты вектора
            int X = p2.X - p1.X;
            int Y = p2.Y - p1.Y;

            //координаты точки, расположенной на расстоянии h от конца
            int Ox = (int)Math.Round(p2.X - (X / d) * h);
            int Oy = (int)Math.Round(p2.Y - (Y / d) * h);
            Point O = new Point(Ox, Oy);


            int Olx = (int)Math.Round(p2.X - (X / d) * (h - 5));
            int Oly = (int)Math.Round(p2.Y - (Y / d) * (h - 5));
            Point Ol = new Point(Olx, Oly);

            //координаты вектора нормали
            int Xp = p2.Y - p1.Y;
            int Yp = p1.X - p2.X;

            int Tx = (int)Math.Round(O.X + (Xp / d) * w); int Ty = (int)Math.Round(O.Y + (Yp / d) * w);
            Point A = new Point(Tx, Ty);
            Tx = (int)Math.Round(O.X - (Xp / d) * w); Ty = (int)Math.Round(O.Y - (Yp / d) * w);
            Point B = new Point(Tx, Ty);

            DrawArrow(bmp, color, A, Ol, p2);
            DrawArrow(bmp, color, B, Ol, p2);
        }

        private static void DrawArrow(Bitmap bmp, Color color, Point p1, Point temp, Point p2)
        {
            double step = 0.01;
            Point current, previous;
            for (double t = 0; t <= 1;)
            {
                previous = GetPoint(t, p1, temp, p2);
                t += step;
                current = GetPoint(t, p1, temp, p2);
                DrawLine(bmp, color, current, previous);
                FillTriangle(bmp, color, temp, current, previous);
            }
        }

        public static Point GetPoint(double t, PointF p1, PointF p2, PointF p3)
        {
            int x = (int)Math.Round((1 - t) * (1 - t) * p1.X + 2 * (1 - t) * t * p2.X + t * t * p3.X);
            int y = (int)Math.Round((1 - t) * (1 - t) * p1.Y + 2 * (1 - t) * t * p2.Y + t * t * p3.Y);
            return new Point(x, y);
        }

        public static void FillTriangle(Bitmap bmp, Color color, Point p0, Point p1, Point p2)
        {
            if (p1.Y > p2.Y)
                Swap(ref p1, ref p2);
            if (p0.Y > p2.Y)
                Swap(ref p0, ref p2);
            if (p0.Y > p1.Y)
                Swap(ref p0, ref p1);
            if (p0.Y == p2.Y)
            {
                DrawLine(bmp, color, p0.X, p0.Y, p2.X, p0.Y);
                return;
            }
            int x, xEnd;
            for (int y = p0.Y; y <= p2.Y; y++)
            {
                x = p0.X + (y - p0.Y) * (p2.X - p0.X) / (p2.Y - p0.Y);
                if (y < p1.Y)
                    xEnd = p0.X + (y - p0.Y) * (p1.X - p0.X) / (p1.Y - p0.Y);
                else if (p1.Y == p2.Y)
                    xEnd = p1.X;
                else
                    xEnd = p1.X + (y - p1.Y) * (p2.X - p1.X) / (p2.Y - p1.Y);
                DrawLine(bmp, color, x, y, xEnd, y);
            }
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
        public static PointF[] GetBezierCurveNodes(float p1X, float p1Y, float p2X, float p2Y, float p1cX, float p1cY, float p2cX, float p2cY, int numberOfNodes)
        {
            PointF[] apt = new PointF[numberOfNodes];

            float dt = 1f / (apt.Length - 1);
            float t = -dt;
            for (int i = 0; i < apt.Length; i++)
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

                apt[i] = new PointF(x, y);
            }
            return apt;
        }

        public static PointF[] GetBezierCurveNodes(PointF p1, PointF p1c, PointF p2c, PointF p2, int numberOfNodes)
        {
            PointF[] apt = new PointF[numberOfNodes];

            float dt = 1f / (apt.Length - 1);
            float t = -dt;
            for (int i = 0; i < apt.Length; i++)
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

                apt[i] = new PointF(x, y);
            }
            return apt;
        }

        public static float GetDistance(float x1, float y1, float x2, float y2)
        {
            return (float)Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
        }
    }
}
