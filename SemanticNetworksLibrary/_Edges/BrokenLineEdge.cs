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
    public class BrokenLineEdge : IEdgeShape
    {
        public void Draw(Graphics g, Edge edge, DrawConfig drawConfig)
        {
            Pen pen = edge.Selected ? drawConfig.EdgeConfig.SelectedEdgePen : drawConfig.EdgeConfig.EdgePen;
            Converter converter = drawConfig.Converter;

            Node startNode = edge.NodeOne, endNode = edge.NodeTwo;

            PointF start = new PointF(), end = new PointF(), centerS = new PointF(), centerE = new PointF();

            SizeF sizeStart = Drawing.Drawing.GetSizeF(startNode, drawConfig);
            SizeF sizeEnd = Drawing.Drawing.GetSizeF(endNode, drawConfig);

            start = new PointF(converter.XXtoII(startNode.X) - sizeStart.Width / 2 + edge.XStart, converter.YYtoJJ(startNode.Y));
            end = new PointF(converter.XXtoII(endNode.X) - sizeEnd.Width / 2 + edge.XEnd,
                converter.YYtoJJ(endNode.Y));

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

            centerS = new PointF(start.X, converter.YYtoJJ(edge.Y));
            centerE = new PointF(end.X, converter.YYtoJJ(edge.Y));

            //edge.LinePoints = new List<PointF>
            //{
            //    start, centerS, centerE, end
            //};

            if (edge.XEnd < 0)
            {
                edge.LinePoints[edge.LinePoints.Count - 1] = new PointF(converter.XXtoII(endNode.X) - sizeEnd.Width / 2 + edge.XEnd,
                    converter.YYtoJJ(endNode.Y));
                edge.LinePoints.Add(new PointF(converter.XXtoII(endNode.X) - sizeEnd.Width / 2, converter.YYtoJJ(endNode.Y)));
            }
            else if (edge.XEnd > sizeEnd.Width)
            {
                edge.LinePoints[edge.LinePoints.Count - 1] = new PointF(converter.XXtoII(endNode.X) - sizeEnd.Width / 2 + edge.XEnd,
                    converter.YYtoJJ(endNode.Y));
                edge.LinePoints.Add(new PointF(converter.XXtoII(endNode.X) + sizeEnd.Width / 2, converter.YYtoJJ(endNode.Y)));
            }

            if (edge.XStart < 0)
            {
                edge.LinePoints[0] = new PointF(converter.XXtoII(startNode.X) - sizeStart.Width / 2 + edge.XStart, converter.YYtoJJ(startNode.Y));
                edge.LinePoints.Insert(0, new PointF(converter.XXtoII(startNode.X) - sizeStart.Width / 2, converter.YYtoJJ(startNode.Y)));
            }
            else if (edge.XStart > sizeStart.Width)
            {
                edge.LinePoints[0] = new PointF(converter.XXtoII(startNode.X) - sizeStart.Width / 2 + edge.XStart, converter.YYtoJJ(startNode.Y));
                edge.LinePoints.Insert(0, new PointF(converter.XXtoII(startNode.X) + sizeStart.Width / 2, converter.YYtoJJ(startNode.Y)));
            }

            edge.MovementPoints = new List<PointF>
            {
                edge.LinePoints[0],
                new PointF(start.X, (converter.YYtoJJ(edge.Y) + start.Y) / 2),
                new PointF((centerE.X + centerS.X) / 2, converter.YYtoJJ(edge.Y)),
                new PointF(end.X, (converter.YYtoJJ(edge.Y) + end.Y) / 2),
                edge.LinePoints.Last()
            };

            g.DrawLines(pen, edge.LinePoints.ToArray());
            g.DrawString(edge.ToString(), converter.ToScreenFont(drawConfig.EdgeConfig.Font), new SolidBrush(drawConfig.EdgeConfig.FontColor),
                (centerE.X + centerS.X) / 2, centerE.Y);
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
