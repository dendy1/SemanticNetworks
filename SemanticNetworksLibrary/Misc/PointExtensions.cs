using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SemanticNetworksLibrary.Misc
{
    public static class PointExtensions
    {
        public static Point ToPoint(this PointF pointF)
        {
            return new Point((int)pointF.X, (int)pointF.Y);
        }
    }
}
