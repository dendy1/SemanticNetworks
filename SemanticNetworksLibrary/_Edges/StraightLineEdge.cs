using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SemanticNetworksLibrary.Drawing;
using SemanticNetworksLibrary.Misc;
using SemanticNetworksLibrary.Semantic_Network;

namespace SemanticNetworksLibrary
{
    public class StraightLineEdge : IEdgeShape
    {
        public void Draw(Graphics g, Edge edge, DrawConfig drawConfig)
        {
            Pen pen = edge.Selected ? drawConfig.EdgeConfig.SelectedEdgePen : drawConfig.EdgeConfig.EdgePen;
            Converter converter = drawConfig.Converter;

            Node startNode = edge.NodeOne, endNode = edge.NodeTwo;
            PointF start = new PointF(), end = new PointF();
            SizeF sizeStart = Drawing.Drawing.GetSizeF(startNode, drawConfig);
            SizeF sizeEnd = Drawing.Drawing.GetSizeF(endNode, drawConfig);

            if (startNode.Y < endNode.Y)
            {
                start = new PointF(converter.XXtoII(startNode.X) - sizeStart.Width / 2 + edge.XStart, converter.YYtoJJ(startNode.Y) - sizeStart.Height / 2);
                end = new PointF(converter.XXtoII(endNode.X) - sizeEnd.Width / 2 + edge.XEnd, converter.YYtoJJ(endNode.Y) + sizeEnd.Height / 2);
            }
            else if (startNode.Y >= endNode.Y)
            {
                start = new PointF(converter.XXtoII(startNode.X) - sizeStart.Width / 2 + edge.XStart, converter.YYtoJJ(startNode.Y) + sizeStart.Height / 2);
                end = new PointF(converter.XXtoII(endNode.X) - sizeEnd.Width / 2 + edge.XEnd, converter.YYtoJJ(endNode.Y) - sizeEnd.Height / 2);
            }

            edge.MovementPoints = new List<PointF>
            {
                start,
                end
            };

            edge.LinePoints = new List<PointF> { start, end };
            g.DrawLines(pen, edge.LinePoints.ToArray());
        }

        public bool Contains(Point point, Edge e, DrawConfig drawConfig)
        {
            if (e.LinePoints.Count == 0) return false;

            var path = new GraphicsPath();
            path.AddLines(e.LinePoints.ToArray());
            Pen pen = e.Selected ? drawConfig.EdgeConfig.SelectedEdgePen : drawConfig.EdgeConfig.EdgePen;
            return path.IsOutlineVisible(point, new Pen(pen.Color, pen.Width + 15));
        }
    }
}
