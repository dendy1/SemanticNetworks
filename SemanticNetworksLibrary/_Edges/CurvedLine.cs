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

        public void Draw(Graphics g, Edge edge)
        {
            Pen pen = edge.EdgeConfig.Selected || edge.EdgeConfig.Edit ? edge.EdgeConfig.SelectedEdgePen : edge.EdgeConfig.EdgePen;

            edge.EdgeConfig.LinePoints = edge.EdgeConfig.RefreshPoints(edge.NodeOne, edge.NodeTwo);

            List<PointF> bezierLine =
                DrawingAlghoritms.GetBezierCurveNodes(edge.EdgeConfig.Start, edge.EdgeConfig.CenterS, edge.EdgeConfig.CenterE, edge.EdgeConfig.End, 100 * 3 + 1);

            edge.EdgeConfig.HeadArrowStart = bezierLine[bezierLine.Count - 20];
            edge.EdgeConfig.TailArrowStart= bezierLine[20];

            //edge.EdgeConfig.CenterS = edge.EdgeConfig.LinePoints[1];
            //edge.EdgeConfig.CenterE = edge.EdgeConfig.LinePoints[2];

            edge.EdgeConfig.RefreshMarkers();

            g.DrawCurve(pen, edge.EdgeConfig.Start, edge.EdgeConfig.CenterS, edge.EdgeConfig.CenterE, edge.EdgeConfig.End, edge.EdgeConfig.ArrowSize.Width, edge.EdgeConfig.ArrowSize.Height, 100);
            g.DrawString(edge.ToString(), edge.EdgeConfig.Converter.ToScreenFont(edge.EdgeConfig.Font), new SolidBrush(edge.EdgeConfig.FontColor), (edge.EdgeConfig.CenterS.X + edge.EdgeConfig.CenterE.X) / 2, edge.EdgeConfig.Converter.YYtoJJ(edge.EdgeConfig.Y));
        }

        public bool Contains(PointF point, Edge edge)
        {
            if (edge.EdgeConfig.LinePoints.Count == 0) return false;

            var path = new GraphicsPath();
            path.AddBeziers(DrawingAlghoritms.GetBezierCurveNodes(edge.EdgeConfig.Start, edge.EdgeConfig.CenterS, edge.EdgeConfig.CenterE, edge.EdgeConfig.End, 100 * 3 + 1).ToArray());
            Pen pen = edge.EdgeConfig.Selected ? edge.EdgeConfig.SelectedEdgePen : edge.EdgeConfig.EdgePen;
            return path.IsOutlineVisible(point, new Pen(pen.Color, pen.Width + 15));
        }

        public override string ToString()
        {
            return "Кривая линия";
        }
    }
}
