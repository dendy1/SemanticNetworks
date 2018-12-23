using SemanticNetworksLibrary.Drawing;
using SemanticNetworksLibrary.Misc;
using SemanticNetworksLibrary.Semantic_Network;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace SemanticNetworksLibrary
{
    public class BrokenLine : IEdgeShape
    {
        public void Draw(Graphics g, Edge edge, DrawConfig drawConfig)
        {
            Pen pen = edge.Selected || edge.Edit ? drawConfig.EdgeConfig.SelectedEdgePen : drawConfig.EdgeConfig.EdgePen;

            edge.LinePoints = edge.RefreshPoints(drawConfig);
            edge.RefreshMarkers(drawConfig);

            g.DrawLines(pen, edge.LinePoints.ToArray());
            g.DrawString(edge.ToString(), drawConfig.Converter.ToScreenFont(drawConfig.EdgeConfig.Font), new SolidBrush(drawConfig.EdgeConfig.FontColor), (edge.CenterS.X + edge.CenterE.X) / 2, drawConfig.Converter.YYtoJJ(edge.Y));
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
