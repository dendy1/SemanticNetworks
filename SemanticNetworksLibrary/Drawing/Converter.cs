using System;
using System.Drawing;

namespace SemanticNetworksLibrary.Misc
{
    public class Converter
    {
        private int width, height;
        public double Xmin { get; set; }
        public double Xmax { get; set; }
        public double Ymin { get; set; }
        public double Ymax { get; set; }

        public Converter(int Width, int Height, double Xmin, double Xmax, double Ymin, double Ymax)
        {
            this.Width = Width;
            this.Height = Height;
            this.Xmin = Xmin;
            this.Xmax = Xmax;
            this.Ymin = Ymin;
            this.Ymax = Ymax;
        }

        public int Width
        {
            get { return width; }
            set
            {
                if (value < 0) throw new Exception("Вы неверно ввели ширину поля");
                width = value;
            }
        }

        public int Height
        {
            get { return height; }
            set
            {
                if (value < 0) throw new Exception("Вы неверно ввели высоту поля");
                height = value;
            }
        }

        public float XXtoII(float x)
        {
            return (int)Math.Round(Width / (Xmax - Xmin) * (x - Xmin));
        }

        public float YYtoJJ(float y)
        {
            return (int)Math.Round(Height - Height / (Ymax - Ymin) * (y - Ymin));
        }

        public float IItoXX(float i)
        {
            return (float)(Xmin + (Xmax - Xmin) / Width * i);
        }

        public float JJtoYY(float j)
        {
            return (float)(Ymax - (Ymax - Ymin) / Height * j);
        }

        public PointF IJtoXY(Point pos)
        {
            return new PointF(IItoXX(pos.X), JJtoYY(pos.Y));
        }

        public PointF XYtoIJ(PointF pos)
        {
            return new PointF(XXtoII(pos.X), YYtoJJ(pos.Y));
        }

        public Font ToScreenFont(Font font)
        {
            return new Font(font.FontFamily, font.Size * Scale);
        }

        public Font ToRealFont(Font font)
        {
            return new Font(font.FontFamily, font.Size / Scale);
        }

        public float Scale
        {
            get
            {
                return Width / (float)(Xmax - Xmin);
            }
        }

        public SizeF UnscaledSize(SizeF size)
        {
            return new SizeF(size.Width * Scale, size.Height * Scale);
        }

        public SizeF ScaledSize(SizeF size)
        {
            return new SizeF(size.Width / Scale, size.Height / Scale);
        }
    }
}
