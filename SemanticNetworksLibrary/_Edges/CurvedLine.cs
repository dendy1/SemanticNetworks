using SemanticNetworksLibrary.Drawing;
using SemanticNetworksLibrary.Misc;
using SemanticNetworksLibrary.Semantic_Network;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace SemanticNetworksLibrary
{
    public class CurvedLine : IEdgeShape
    {
        public void Draw(Graphics g, Edge edge, DrawConfig drawConfig)
        {
            Pen pen = edge.Selected || edge.Edit ? drawConfig.EdgeConfig.SelectedEdgePen : drawConfig.EdgeConfig.EdgePen;

            edge.LinePoints = edge.RefreshPoints(drawConfig);

            List<PointF> bezierLine =
                DrawingAlghoritms.GetBezierCurveNodes(edge.Start, edge.CenterS, edge.CenterE, edge.End, 100 * 3 + 1);

            edge.HeadArrowStart = bezierLine[bezierLine.Count - 20];
            edge.TailArrowStart= bezierLine[20];

            edge.CenterS = edge.LinePoints[1];
            edge.CenterE = edge.LinePoints[2];

            edge.RefreshMarkers(drawConfig);

            g.DrawCurve(pen, edge.Start, edge.CenterS, edge.CenterE, edge.End, drawConfig.EdgeConfig.ArrowSize.Width, drawConfig.EdgeConfig.ArrowSize.Height, 100);
            g.DrawString(edge.ToString(), drawConfig.Converter.ToScreenFont(drawConfig.EdgeConfig.Font), new SolidBrush(drawConfig.EdgeConfig.FontColor), (edge.CenterS.X + edge.CenterE.X) / 2, drawConfig.Converter.YYtoJJ(edge.Y));
        }

        public bool Contains(PointF point, Edge edge, DrawConfig drawConfig)
        {
            if (edge.LinePoints.Count == 0) return false;

            var path = new GraphicsPath();
            path.AddBeziers(DrawingAlghoritms.GetBezierCurveNodes(edge.Start, edge.CenterS, edge.CenterE, edge.End, 100 * 3 + 1).ToArray());
            Pen pen = edge.Selected ? drawConfig.EdgeConfig.SelectedEdgePen : drawConfig.EdgeConfig.EdgePen;
            return path.IsOutlineVisible(point, new Pen(pen.Color, pen.Width + 15));
        }
    }
}
