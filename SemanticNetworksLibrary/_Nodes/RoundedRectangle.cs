using SemanticNetworksLibrary.Misc;
using SemanticNetworksLibrary.Semantic_Network;
using System.Drawing;

namespace SemanticNetworksLibrary._Nodes
{
    public class RoundedRectangle : INodeShape
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
            Size size = Size.Round(g.MeasureString(node.Concept, node.NodeConfig.Converter.ToScreenFont(node.NodeConfig.Font)));
            Pen pen = node.NodeConfig.Selected ? node.NodeConfig.SelectedNodePen : node.NodeConfig.NodePen;
            Brush brush = node.NodeConfig.Selected
                ? new SolidBrush(node.NodeConfig.FillSelectedNodeColor)
                : new SolidBrush(node.NodeConfig.FillNodeColor);
            float xradius = 10;
            float yradius = 10;
            g.FillRoundedRectangle(brush, node.NodeConfig.Converter.XXtoII(node.X) - size.Width / 2,
                node.NodeConfig.Converter.YYtoJJ(node.Y) - size.Height / 2, size.Width, size.Height, xradius, yradius, true, true, true, true);
            g.DrawRoundedRectangle(pen, node.NodeConfig.Converter.XXtoII(node.X) - size.Width / 2,
                node.NodeConfig.Converter.YYtoJJ(node.Y) - size.Height / 2, size.Width, size.Height, xradius, yradius, true, true, true, true);
            g.DrawString(node.Concept, node.NodeConfig.Converter.ToScreenFont(node.NodeConfig.Font),
                new SolidBrush(node.NodeConfig.FontColor),
                node.NodeConfig.Converter.XXtoII(node.X) - size.Width / 2, node.NodeConfig.Converter.YYtoJJ(node.Y) - size.Height / 2);
        }

        public override string ToString()
        {
            return "Скругленный прямоугольник";
        }
    }
}
