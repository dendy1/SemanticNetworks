using SemanticNetworksLibrary.Drawing;
using SemanticNetworksLibrary.Semantic_Network;
using System;
using System.Drawing;
using SemanticNetworksLibrary.Misc;
using System.Collections.Generic;

namespace SemanticNetworksLibrary._Nodes
{
    public class Ellipse : INodeShape
    {
        public bool Contains(Point point, Node node)
        {
            if (node == null) return false;
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle();

            using (Graphics g = Graphics.FromImage(new Bitmap(1, 1)))
            {
                Size sizeRect = Size.Round(g.MeasureString(node.ToString(), node.NodeConfig.Converter.ToScreenFont(node.NodeConfig.Font)));
                PointF pos = new PointF(node.NodeConfig.Converter.XXtoII(node.X) - sizeRect.Width / 2, node.NodeConfig.Converter.YYtoJJ(node.Y) - sizeRect.Height / 2);
                rectangle = new System.Drawing.Rectangle(pos.ToPoint(), sizeRect);
            }

            return rectangle.Contains(point);
        }

        public void Draw(Graphics g, Node node)
        {
            Converter converter = node.NodeConfig.Converter;
            Size size = Size.Round(g.MeasureString(node.Concept, converter.ToScreenFont(node.NodeConfig.Font)));
            Pen pen = node.NodeConfig.Selected ? node.NodeConfig.SelectedNodePen : node.NodeConfig.NodePen;
            Brush brush = node.NodeConfig.Selected ? new SolidBrush(node.NodeConfig.FillSelectedNodeColor) : new SolidBrush(node.NodeConfig.FillNodeColor);

            g.FillEllipse(brush, converter.XXtoII(node.X) - size.Width / 2, converter.YYtoJJ(node.Y) - size.Height / 2, size.Width, size.Height);
            g.DrawEllipse(pen, converter.XXtoII(node.X) - size.Width / 2, converter.YYtoJJ(node.Y) - size.Height / 2, size.Width, size.Height);
            g.DrawString(node.Concept, converter.ToScreenFont(node.NodeConfig.Font),
                new SolidBrush(node.NodeConfig.FontColor),
                converter.XXtoII(node.X) - size.Width / 2, converter.YYtoJJ(node.Y) - size.Height / 2);
        }

        public override string ToString()
        {
            return "Эллипс";
        }
    }
}
