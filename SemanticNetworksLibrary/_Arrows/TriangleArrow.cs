using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SemanticNetworksLibrary.Misc;

namespace SemanticNetworksLibrary
{
    public class TriangleArrow : IArrowShape
    {
        public void Draw(Graphics g, Pen pen, PointF start, PointF end, SizeF arrowSize)
        {
            if (start == end) return;

            //длина отрезка
            float d = (float)Math.Sqrt((end.X - start.X) * (end.X - start.X) + (end.Y - start.Y) * (end.Y - start.Y));

            //координаты вектора
            float X = end.X - start.X;
            float Y = end.Y - start.Y;

            //координаты точки, расположенной на расстоянии h от конца
            float Ox = end.X - (X / d) * arrowSize.Height;
            float Oy = end.Y - (Y / d) * arrowSize.Height;
            PointF O = new PointF(Ox, Oy);


            float Olx = end.X - (X / d) * (arrowSize.Height - 5);
            float Oly = end.Y - (Y / d) * (arrowSize.Height - 5);
            PointF Ol = new PointF(Olx, Oly);

            //координаты вектора нормали
            float Xp = end.Y - start.Y;
            float Yp = start.X - end.X;

            float Tx = O.X + (Xp / d) * arrowSize.Width; float Ty = O.Y + (Yp / d) * arrowSize.Width;
            PointF A = new PointF(Tx, Ty);
            Tx = O.X - (Xp / d) * arrowSize.Width; Ty = O.Y - (Yp / d) * arrowSize.Width;
            PointF B = new PointF(Tx, Ty);

            g.FillPolygon(new SolidBrush(pen.Color), new PointF[] { end, A, B });
        }
    }
}
