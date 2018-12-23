using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using SemanticNetworksLibrary.Drawing;
using SemanticNetworksLibrary.Misc;
using SemanticNetworksLibrary.Semantic_Network;

namespace SemanticNetworksLibrary._Nodes
{
    public class RoundedRectangle : INodeShape
    {
        public bool Contains(Point point, Node n, DrawConfig drawConfig)
        {
            if (n == null) return false;
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle();

            using (Graphics g = Graphics.FromImage(new Bitmap(1, 1)))
            {
                Size sizeRect = Size.Round(g.MeasureString(n.ToString(), drawConfig.Converter.ToScreenFont(drawConfig.NodeConfig.Font)));
                PointF pos = new PointF(drawConfig.Converter.XXtoII(n.X) - sizeRect.Width / 2, drawConfig.Converter.YYtoJJ(n.Y) - sizeRect.Height / 2);
                rectangle = new System.Drawing.Rectangle(pos.ToPoint(), sizeRect);
            }

            return rectangle.Contains(point);
        }

        public void Draw(Graphics g, Node node, DrawConfig drawConfig)
        {
            Converter converter = drawConfig.Converter;
            Size size = Size.Round(g.MeasureString(node.Concept, converter.ToScreenFont(drawConfig.NodeConfig.Font)));
            Pen pen = node.Selected ? drawConfig.NodeConfig.SelectedNodePen : drawConfig.NodeConfig.NodePen;
            Brush brush = node.Selected
                ? new SolidBrush(drawConfig.NodeConfig.FillSelectedNodeColor)
                : new SolidBrush(drawConfig.NodeConfig.FillNodeColor);
            float xradius = 2;
            float yradius = 20;
            g.FillRoundedRectangle(brush, converter.XXtoII(node.X) - size.Width / 2,
                converter.YYtoJJ(node.Y) - size.Height / 2, size.Width, size.Height, xradius, yradius, true, true, true, true);
            g.DrawRoundedRectangle(pen, converter.XXtoII(node.X) - size.Width / 2,
                converter.YYtoJJ(node.Y) - size.Height / 2, size.Width, size.Height, xradius, yradius, true, true, true, true);
            g.DrawString(node.Concept, converter.ToScreenFont(drawConfig.NodeConfig.Font),
                new SolidBrush(drawConfig.NodeConfig.FontColor),
                converter.XXtoII(node.X) - size.Width / 2, converter.YYtoJJ(node.Y) - size.Height / 2);
        }
    }
}
