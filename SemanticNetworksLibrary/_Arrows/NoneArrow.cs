using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemanticNetworksLibrary._Arrows
{
    public class NoneArrow : IArrowShape
    {
        public void Draw(Graphics g, Pen pen, PointF start, PointF end, SizeF arrowSize)
        {
            
        }

        public override string ToString()
        {
            return "Без стрелки";
        }
    }
}
