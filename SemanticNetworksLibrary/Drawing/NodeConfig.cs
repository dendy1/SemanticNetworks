using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SemanticNetworksLibrary.Drawing
{
    public class NodeConfig
    {
        public enum Shape
        {
            Ellipse,
            Triangle,
            Rectangle,
            RoundedRectangle,
            Trapeze,
            Parallelogram,
            Pentagon
        }

        public Pen NodePen { get; set; }
        public Pen SelectedNodePen { get; set; }
        public Color FillNodeColor { get; set; }
        public Color FillSelectedNodeColor { get; set; }
        public Font Font { get; set; }
        public Color FontColor { get; set; }
        public Shape NodeShape { get; set; }
    }
}
