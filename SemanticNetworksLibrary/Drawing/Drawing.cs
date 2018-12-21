using SemanticNetworksLibrary.Semantic_Network;
using System.Drawing;
using System.Linq;

namespace SemanticNetworksLibrary.Drawing
{
    public static class Drawing
    {
        public static void DrawSemanticNetwork(Graphics g, SemanticNetwork semanticNetwork, DrawConfig drawConfig)
        {
            foreach (Edge edge in semanticNetwork.Edges)
            {
                DrawEdge(g, edge, drawConfig);
            }

            foreach (Node node in semanticNetwork.Nodes)
            {
                DrawNode(g, node, drawConfig);
            }
        }

        public static void DrawNode(Graphics g, Node node, DrawConfig drawConfig)
        {
            node.Shape.Draw(g, node, drawConfig);
            node.CalclulateMarks(drawConfig);
            if (node.Selected)
                foreach (PointF p in node.Marks)
                {
                    g.FillEllipse(Brushes.Black, p.X - 5, p.Y - 5, 10, 10);
                }
        }

        public static void DrawEdge(Graphics g, Edge edge, DrawConfig drawConfig)
        {
            edge.Shape.Draw(g, edge, drawConfig);

            Pen pen = edge.Selected ? drawConfig.EdgeConfig.SelectedEdgePen : drawConfig.EdgeConfig.EdgePen;
            edge.ArrowHeadShape.Draw(
                g,
                pen,
                edge.LinePoints[edge.LinePoints.Count - 2], edge.LinePoints.Last(),
                drawConfig.EdgeConfig.ArrowSize
                );
            edge.ArrowTailShape.Draw(
                g,
                pen,
                edge.LinePoints[1], edge.LinePoints[0],
                drawConfig.EdgeConfig.ArrowSize
            );

            if (edge.Selected)
            {
                foreach (var VARIABLE in edge.MovementPoints)
                {
                    g.DrawEllipse(drawConfig.EdgeConfig.EdgePen, VARIABLE.X - 15 / 2, VARIABLE.Y - 15 / 2, 15, 15);
                }
            }
        }
    
        public static Node CheckNode(int U, int V, SemanticNetwork sn, DrawConfig drawConfig)
        {
            foreach (Node node in sn.Nodes)
            {
                if (node.Contains(new Point(U, V), drawConfig))
                {
                    node.Selected = true;
                    return node;
                }
            }
            return null;
        }

        public static Node CheckNode(Point p, SemanticNetwork sn, DrawConfig drawConfig)
        {
            return CheckNode(p.X, p.Y, sn, drawConfig);
        }

        public static SizeF GetSizeF(Node n, DrawConfig drawConfig)
        {
            using (Bitmap bmp = new Bitmap(1, 1))
            using (Graphics g = Graphics.FromImage(bmp))
            {
                SizeF size = g.MeasureString(n.Concept, drawConfig.Converter.ToScreenFont(drawConfig.NodeConfig.Font));
                return size;
            }
        }

        public static Edge CheckEdge(Point p, SemanticNetwork semanticNetwork, DrawConfig drawConfig)
        {
            foreach (Edge e in semanticNetwork.Edges)
            {
                if (e.Contains(p, drawConfig))
                {
                    e.Selected = true;
                    return e;
                }
            }
            return null;
        }

        public static Edge CheckEdge(int U, int V, SemanticNetwork semanticNetwork, DrawConfig drawConfig)
        {
            return CheckEdge(new Point(U, V), semanticNetwork, drawConfig);
        }

        public static void Select(int U, int V, SemanticNetwork semanticNetwork, DrawConfig drawConfig)
        {
            if (CheckNode(U, V, semanticNetwork, drawConfig) != null)
            {
                CheckNode(U, V, semanticNetwork, drawConfig).Selected = true;
            }
            else if (CheckEdge(U, V, semanticNetwork, drawConfig) != null)
            {
                CheckEdge(U, V, semanticNetwork, drawConfig).Selected = true;
            }
            else
            {
                semanticNetwork.Deselect();
            }
        }

        public static void Select(Point p, SemanticNetwork semanticNetwork, DrawConfig drawConfig)
        {
            Select(p.X, p.Y, semanticNetwork, drawConfig);
        }

        public static PointF CheckMark(int U, int V, Edge edge, DrawConfig drawConfig)
        {
            foreach (var VARIABLE in edge.MovementPoints)
            {
                Rectangle rect = new Rectangle(
                    (int)VARIABLE.X - drawConfig.EdgeConfig.MarkSize.Width / 2, 
                    (int)VARIABLE.Y - drawConfig.EdgeConfig.MarkSize.Height / 2,
                    drawConfig.EdgeConfig.MarkSize.Width,
                    drawConfig.EdgeConfig.MarkSize.Height
                    );
                if (rect.Contains(U, V))
                    return VARIABLE;
            }
            return PointF.Empty;
        }

        public static PointF CheckMark(Point loc, Edge edge, DrawConfig drawConfig)
        {
            return CheckMark(loc.X, loc.Y, edge, drawConfig);
        }
    }
}
