using SemanticNetworksLibrary.Semantic_Network;
using System.Drawing;

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
            if (node.Selected)
                foreach (PointF p in node.Marks)
                {
                    g.FillEllipse(Brushes.Black, p.X - 5, p.Y - 5, 10, 10);
                }
        }

        public static void DrawEdge(Graphics g, Edge edge, DrawConfig drawConfig)
        {
            edge.Shape.Draw(g, edge, drawConfig);
            Pen pen = edge.Selected || edge.Edit ? drawConfig.EdgeConfig.SelectedEdgePen : drawConfig.EdgeConfig.EdgePen;
            edge.ArrowHeadShape.Draw(
                g,
                pen,
                edge.HeadArrowStart, edge.End,
                drawConfig.Converter.UnscaledSize(drawConfig.EdgeConfig.ArrowSize)
                );
            edge.ArrowTailShape.Draw(
                g,
                pen,
                edge.TailArrowStart, edge.Start,
                drawConfig.Converter.UnscaledSize(drawConfig.EdgeConfig.ArrowSize)
            );

            if (edge.Edit)
            {
                foreach (PointF pt in edge.Markers.Values)
                {
                    SizeF s = drawConfig.Converter.UnscaledSize(drawConfig.EdgeConfig.MarkerSize);
                    g.DrawRectangle(new Pen(Color.DarkOrange, 5), pt.X - s.Width / 2, pt.Y - s.Height / 2, s.Width, s.Height);
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

        public static void Editing(Point p, SemanticNetwork semanticNetwork, DrawConfig drawConfig)
        {
            if (CheckEdge(p, semanticNetwork, drawConfig) != null)
            {
                CheckEdge(p, semanticNetwork, drawConfig).Edit = true;
            }
            else
            {
                foreach (var edge in semanticNetwork.Edges)
                {
                    edge.Edit = false;  
                }
            }
        }

        public static PointF CheckMark(int U, int V, Edge edge, DrawConfig drawConfig)
        {
            foreach (PointF p in edge.Markers.Values)
            {
                SizeF s = drawConfig.Converter.UnscaledSize(drawConfig.EdgeConfig.MarkerSize);
                RectangleF rect = new RectangleF(p.X - s.Width / 2, p.Y - s.Height / 2, s.Width, s.Height);
                if (rect.Contains(U, V))
                {
                    return p;
                }
            }
            return PointF.Empty;
        }

        public static PointF CheckMark(Point loc, Edge edge, DrawConfig drawConfig)
        {
            return CheckMark(loc.X, loc.Y, edge, drawConfig);
        }
    }
}
