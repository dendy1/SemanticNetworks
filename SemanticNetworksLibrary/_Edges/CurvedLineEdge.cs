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
    public class CurvedLineEdge : IEdgeShape
    {
        public void Draw(Graphics g, Edge edge, DrawConfig drawConfig)
        {
            Pen pen = edge.Selected ? drawConfig.EdgeConfig.SelectedEdgePen : drawConfig.EdgeConfig.EdgePen;
            Node startNode = edge.NodeOne, endNode = edge.NodeTwo;
            PointF start = new PointF(), end = new PointF(), centerS = new PointF(), centerE = new PointF();
            SizeF sizeStart = Drawing.Drawing.GetSizeF(startNode, drawConfig);
            SizeF sizeEnd = Drawing.Drawing.GetSizeF(endNode, drawConfig);

            start = drawConfig.Converter.XYtoIJ(startNode.Position);
            if (startNode.Y < endNode.Y)
            {
                start = new PointF(drawConfig.Converter.XXtoII(startNode.X) - sizeStart.Width / 2 + edge.XStart, drawConfig.Converter.YYtoJJ(startNode.Y) - sizeStart.Height / 2);
                end = new PointF(drawConfig.Converter.XYtoIJ(endNode.Position).X, drawConfig.Converter.XYtoIJ(endNode.Position).Y + (int)sizeEnd.Height / 2);
            }
            else if (startNode.Y >= endNode.Y)
            {
                start = new PointF(drawConfig.Converter.XXtoII(startNode.X) - sizeStart.Width / 2 + edge.XStart, drawConfig.Converter.YYtoJJ(startNode.Y) + sizeStart.Height / 2);
                end = new PointF(drawConfig.Converter.XYtoIJ(endNode.Position).X, drawConfig.Converter.XYtoIJ(endNode.Position).Y - (int)sizeEnd.Height / 2);
            }

            centerS = new PointF(start.X, (start.Y + end.Y) / 2);
            centerE = new PointF(end.X, (start.Y + end.Y) / 2);

            edge.LinePoints = DrawingAlghoritms.GetBezierCurveNodes(start, centerS, centerE, end, 10).ToList();

            edge.MovementPoints = new List<PointF>
            {
                start,
                //centerS,
                //centerE,
                end
            };

            g.DrawCurve(pen, start.X, start.Y, end.X, end.Y, centerS.X, centerS.Y, centerE.X, centerE.Y, drawConfig.EdgeConfig.ArrowSize.Width, drawConfig.EdgeConfig.ArrowSize.Height, 10);
            g.DrawString(edge.ToString(), drawConfig.Converter.ToScreenFont(drawConfig.EdgeConfig.Font), new SolidBrush(drawConfig.EdgeConfig.FontColor), (centerE.X + centerS.X) / 2, centerE.Y);
        }

        public bool Contains(Point point, Edge e, DrawConfig drawConfig)
        {
            if (e.LinePoints.Count == 0) return false;

            var path = new GraphicsPath();
            path.AddBeziers(e.LinePoints.ToArray());
            Pen pen = e.Selected ? drawConfig.EdgeConfig.SelectedEdgePen : drawConfig.EdgeConfig.EdgePen;
            return path.IsOutlineVisible(point, new Pen(pen.Color, pen.Width + 15));
        }
    }
}
