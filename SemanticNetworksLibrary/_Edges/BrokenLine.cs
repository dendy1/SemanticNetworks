using SemanticNetworksLibrary.Semantic_Network;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace SemanticNetworksLibrary
{
    public class BrokenLine : IEdgeShape
    {
        public void Draw(Graphics g, Edge edge)
        {
            Pen pen = edge.EdgeConfig.Selected || edge.EdgeConfig.Edit ? edge.EdgeConfig.SelectedEdgePen : edge.EdgeConfig.EdgePen;

            edge.EdgeConfig.LinePoints = edge.EdgeConfig.RefreshPoints(edge.NodeOne, edge.NodeTwo);
            edge.EdgeConfig.RefreshMarkers();

            g.DrawLines(pen, edge.EdgeConfig.LinePoints.ToArray());
            g.DrawString(edge.ToString(), edge.EdgeConfig.Converter.ToScreenFont(edge.EdgeConfig.Font), new SolidBrush(edge.EdgeConfig.FontColor), (edge.EdgeConfig.CenterS.X + edge.EdgeConfig.CenterE.X) / 2, edge.EdgeConfig.Converter.YYtoJJ(edge.EdgeConfig.Y));
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
            return "Ломаная линия";
        }
    }
}
