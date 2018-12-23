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
        public void Draw(Graphics g, Edge edge, DrawConfig drawConfig)
        {
            Pen pen = edge.Selected || edge.Edit ? drawConfig.EdgeConfig.SelectedEdgePen : drawConfig.EdgeConfig.EdgePen;

            List<PointF> pts = edge.RefreshPoints(drawConfig);

            edge.HeadArrowStart = edge.TailArrowStart =
                new PointF((pts[0].X + pts[pts.Count - 1].X) / 2, drawConfig.Converter.YYtoJJ(edge.Y));
            edge.RefreshMarkers(drawConfig);
            edge.LinePoints = new List<PointF> { pts[0], new PointF((pts[0].X + pts[pts.Count - 1].X) / 2, drawConfig.Converter.YYtoJJ(edge.Y)), pts[pts.Count - 1] };
            g.DrawLines(pen, edge.LinePoints.ToArray());
        }

        public bool Contains(PointF point, Edge edge, DrawConfig drawConfig)
        {
            if (edge.LinePoints.Count == 0) return false;

            var path = new GraphicsPath();
            path.AddLines(edge.LinePoints.ToArray());
            Pen pen = edge.Selected ? drawConfig.EdgeConfig.SelectedEdgePen : drawConfig.EdgeConfig.EdgePen;
            return path.IsOutlineVisible(point, new Pen(pen.Color, pen.Width + 15));
        }
    }
}
