using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using SemanticNetworksLibrary.Misc;
using SemanticNetworksLibrary._Nodes;

namespace SemanticNetworksLibrary.Drawing
{
    public class NodeConfig
    {
        public Pen NodePen { get; set; }
        public Pen SelectedNodePen { get; set; }

        public Color FillNodeColor { get; set; }
        public Color FillSelectedNodeColor { get; set; }

        public Font Font { get; set; }
        public Color FontColor { get; set; }

        public Converter Converter { get; set; }
        public INodeShape Shape { get; set; }

        public bool Selected { get; set; }
        public bool Editing { get; set; }

        public NodeConfig(INodeShape shape, Converter c, Pen nodepen, Pen selectednodepen, Color fillNodeColor,
            Color fillSelectedNodeColor, Font font, Color fontColor)
        {
            Shape = shape;
            Converter = c;
            NodePen = nodepen;
            SelectedNodePen = selectednodepen;
            FillNodeColor = fillNodeColor;
            FillSelectedNodeColor = fillSelectedNodeColor;
            Font = font;
            FontColor = fontColor;
        }
    }
}
