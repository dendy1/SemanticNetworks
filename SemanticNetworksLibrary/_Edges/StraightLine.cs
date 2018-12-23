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
    public class StraightLine : IEdgeShape
    {
        public void Draw(Graphics g, Edge edge)
        {
            Pen pen = edge.EdgeConfig.Selected || edge.EdgeConfig.Edit ? edge.EdgeConfig.SelectedEdgePen : edge.EdgeConfig.EdgePen;

            List<PointF> pts = edge.EdgeConfig.RefreshPoints(edge.NodeOne, edge.NodeTwo);

            edge.EdgeConfig.HeadArrowStart = edge.EdgeConfig.TailArrowStart =
                new PointF((pts[0].X + pts[pts.Count - 1].X) / 2, edge.EdgeConfig.Converter.YYtoJJ(edge.EdgeConfig.Y));
            edge.EdgeConfig.RefreshMarkers();
            edge.EdgeConfig.LinePoints = new List<PointF> { pts[0], new PointF((pts[0].X + pts[pts.Count - 1].X) / 2, edge.EdgeConfig.Converter.YYtoJJ(edge.EdgeConfig.Y)), pts[pts.Count - 1] };
            g.DrawLines(pen, edge.EdgeConfig.LinePoints.ToArray());
        }

        public bool Contains(PointF point, Edge edge)
        {
            if (edge.EdgeConfig.LinePoints.Count == 0) return false;

            var path = new GraphicsPath();
            path.AddLines(edge.EdgeConfig.LinePoints.ToArray());
            Pen pen = edge.EdgeConfig.Selected ? edge.EdgeConfig.SelectedEdgePen : edge.EdgeConfig.EdgePen;
            return path.IsOutlineVisible(point, new Pen(pen.Color, pen.Width + 15));
        }

        public override string ToString()
        {
            return "Прямая линия";
        }
    }
}
