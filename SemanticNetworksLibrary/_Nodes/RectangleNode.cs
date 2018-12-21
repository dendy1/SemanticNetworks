using SemanticNetworksLibrary.Drawing;
using SemanticNetworksLibrary.Semantic_Network;
using System;
using System.Drawing;
using SemanticNetworksLibrary.Misc;
using System.Collections.Generic;

namespace SemanticNetworksLibrary._Nodes
{
    public class RectangleNode : INodeShape
    {
        public bool Contains(Point point, Node n, DrawConfig drawConfig)
        {
            if (n == null) return false;
            Rectangle rectangle = new Rectangle();

            using (Graphics g = Graphics.FromImage(new Bitmap(1, 1)))
            {
                Size sizeRect = Size.Round(g.MeasureString(n.ToString(), drawConfig.Converter.ToScreenFont(drawConfig.NodeConfig.Font)));
                PointF pos = new PointF(drawConfig.Converter.XXtoII(n.X) - sizeRect.Width / 2, drawConfig.Converter.YYtoJJ(n.Y) - sizeRect.Height / 2);
                rectangle = new Rectangle(pos.ToPoint(), sizeRect);
            }

            return rectangle.Contains(point);
        }

        public void Draw(Graphics g, Node node, DrawConfig drawConfig)
        {
            Converter converter = drawConfig.Converter;
            Size size = Size.Round(g.MeasureString(node.Concept, converter.ToScreenFont(drawConfig.NodeConfig.Font)));
            Pen pen = node.Selected ? drawConfig.NodeConfig.SelectedNodePen : drawConfig.NodeConfig.NodePen;
            Brush brush = node.Selected ? new SolidBrush(drawConfig.NodeConfig.FillSelectedNodeColor) : new SolidBrush(drawConfig.NodeConfig.FillNodeColor);

            g.FillRectangle(brush, converter.XXtoII(node.X) - size.Width / 2, converter.YYtoJJ(node.Y) - size.Height / 2, size.Width, size.Height);
            g.DrawRectangle(pen, converter.XXtoII(node.X) - size.Width / 2, converter.YYtoJJ(node.Y) - size.Height / 2, size.Width, size.Height);
            g.DrawString(node.Concept, converter.ToScreenFont(drawConfig.NodeConfig.Font),
                new SolidBrush(drawConfig.NodeConfig.FontColor),
                converter.XXtoII(node.X) - size.Width / 2, converter.YYtoJJ(node.Y) - size.Height / 2);
        }

        public void CalculateMarks(Node n, DrawConfig drawConfig) //в экранных координатах
        {
            SizeF size = new SizeF();
            using (Bitmap bmp = new Bitmap(1, 1))
            {
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    size = g.MeasureString(n.Concept, drawConfig.Converter.ToScreenFont(drawConfig.NodeConfig.Font));
                }
            }

            float stepX = size.Width / 4;
            float stepY = size.Height / 3;

            n.Marks = new List<PointF>()
            {
                new PointF(drawConfig.Converter.XXtoII(n.X) - size.Width / 2 + stepX, drawConfig.Converter.YYtoJJ(n.Y) - size.Height / 2),
                new PointF(drawConfig.Converter.XXtoII(n.X) - size.Width / 2 + stepX * 2, drawConfig.Converter.YYtoJJ(n.Y) - size.Height / 2),
                new PointF(drawConfig.Converter.XXtoII(n.X) - size.Width / 2 + stepX * 3, drawConfig.Converter.YYtoJJ(n.Y) - size.Height / 2),

                new PointF(drawConfig.Converter.XXtoII(n.X) - size.Width / 2 + stepX, drawConfig.Converter.YYtoJJ(n.Y) + size.Height / 2),
                new PointF(drawConfig.Converter.XXtoII(n.X) - size.Width / 2 + stepX * 2, drawConfig.Converter.YYtoJJ(n.Y) + size.Height / 2),
                new PointF(drawConfig.Converter.XXtoII(n.X) - size.Width / 2 + stepX * 3, drawConfig.Converter.YYtoJJ(n.Y) + size.Height / 2),

                new PointF(drawConfig.Converter.XXtoII(n.X) - size.Width / 2, drawConfig.Converter.YYtoJJ(n.Y) - size.Height / 2 + stepY),
                new PointF(drawConfig.Converter.XXtoII(n.X) - size.Width / 2, drawConfig.Converter.YYtoJJ(n.Y) - size.Height / 2 + stepY * 2),

                new PointF(drawConfig.Converter.XXtoII(n.X) + size.Width / 2, drawConfig.Converter.YYtoJJ(n.Y) - size.Height / 2 + stepY),
                new PointF(drawConfig.Converter.XXtoII(n.X) + size.Width / 2, drawConfig.Converter.YYtoJJ(n.Y) - size.Height / 2 + stepY * 2),
            };
        }
    }
}
