﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SemanticNetworksLibrary.Drawing;

namespace SemanticNetworksLibrary
{
    public interface IArrowShape
    {
        void Draw(Graphics g, Pen pen, PointF start, PointF end, SizeF arrowSize);
    }
}
