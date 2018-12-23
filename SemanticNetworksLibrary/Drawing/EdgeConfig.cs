using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SemanticNetworksLibrary.Drawing
{
    public class EdgeConfig
    {
        public SizeF ArrowSize { get; set; }
        public Pen EdgePen { get; set; }
        public Pen SelectedEdgePen { get; set; }
        public Font Font { get; set; }
        public Color FontColor { get; set; }
        public SizeF MarkerSize { get; set; }
    }
}
