using SemanticNetworksLibrary.Semantic_Network;
using System.Drawing;

namespace SemanticNetworksLibrary.Drawing
{
    public static class Drawing
    {
        public static void DrawSemanticNetwork(Graphics g, SemanticNetwork semanticNetwork)
        {
            foreach (Edge edge in semanticNetwork.Edges)
            {
                DrawEdge(g, edge);
            }

            foreach (Node node in semanticNetwork.Nodes)
            {
                DrawNode(g, node);
            }
        }

        public static void DrawNode(Graphics g, Node node)
        {
            node.NodeConfig.Shape.Draw(g, node);
        }

        public static void DrawEdge(Graphics g, Edge edge)
        {
            edge.EdgeConfig.Shape.Draw(g, edge);
            Pen pen = edge.EdgeConfig.Selected || edge.EdgeConfig.Edit ? edge.EdgeConfig.SelectedEdgePen : edge.EdgeConfig.EdgePen;
            edge.EdgeConfig.ArrowHeadShape.Draw(
                g,
                pen,
                edge.EdgeConfig.HeadArrowStart, edge.EdgeConfig.End,
                edge.EdgeConfig.Converter.ToScreenSize(edge.EdgeConfig.ArrowSize)
                );
            edge.EdgeConfig.ArrowTailShape.Draw(
                g,
                pen,
                edge.EdgeConfig.TailArrowStart, edge.EdgeConfig.Start,
                edge.EdgeConfig.Converter.ToScreenSize(edge.EdgeConfig.ArrowSize)
            );

            if (edge.EdgeConfig.Edit)
            {
                foreach (PointF pt in edge.EdgeConfig.Markers.Values)
                {
                    SizeF s = edge.EdgeConfig.Converter.ToScreenSize(edge.EdgeConfig.MarkerSize);
                    g.DrawRectangle(new Pen(Color.DarkOrange, 2), pt.X - s.Width / 2, pt.Y - s.Height / 2, s.Width, s.Height);
                }
            }
        }
    
        public static Node CheckNode(int U, int V, SemanticNetwork sn)
        {
            foreach (Node node in sn.Nodes)
            {
                if (node.Contains(new Point(U, V)))
                {
                    node.NodeConfig.Selected = true;
                    return node;
                }
            }
            return null;
        }

        public static Node CheckNode(Point p, SemanticNetwork sn)
        {
            return CheckNode(p.X, p.Y, sn);
        }

        public static SizeF GetSizeF(Node n)
        {
            using (Bitmap bmp = new Bitmap(1, 1))
            using (Graphics g = Graphics.FromImage(bmp))
            {
                SizeF size = g.MeasureString(n.Concept, n.NodeConfig.Converter.ToScreenFont(n.NodeConfig.Font));
                return size;
            }
        }

        public static Edge CheckEdge(Point p, SemanticNetwork semanticNetwork)
        {
            foreach (Edge edge in semanticNetwork.Edges)
            {
                if (edge.Contains(p))
                {
                    edge.EdgeConfig.Selected = true;
                    return edge;
                }
            }
            return null;
        }

        public static Edge CheckEdge(int U, int V, SemanticNetwork semanticNetwork)
        {
            return CheckEdge(new Point(U, V), semanticNetwork);
        }

        public static void Select(int U, int V, SemanticNetwork semanticNetwork)
        {
            if (CheckNode(U, V, semanticNetwork) != null)
            {
                CheckNode(U, V, semanticNetwork).NodeConfig.Selected = true;
            }
            else if (CheckEdge(U, V, semanticNetwork) != null)
            {
                CheckEdge(U, V, semanticNetwork).EdgeConfig.Selected = true;
            }
            else
            {
                semanticNetwork.Deselect();
            }
        }

        public static void Select(Point p, SemanticNetwork semanticNetwork)
        {
            Select(p.X, p.Y, semanticNetwork);
        }

        public static void Editing(Point p, SemanticNetwork semanticNetwork)
        {
            if (CheckEdge(p, semanticNetwork) != null)
            {
                CheckEdge(p, semanticNetwork).EdgeConfig.Edit = true;
            }
            else
            {
                foreach (var edge in semanticNetwork.Edges)
                {
                    edge.EdgeConfig.Edit = false;  
                }
            }
        }

        public static PointF CheckMark(int U, int V, Edge edge)
        {
            foreach (PointF p in edge.EdgeConfig.Markers.Values)
            {
                SizeF s = edge.EdgeConfig.Converter.ToScreenSize(edge.EdgeConfig.MarkerSize);
                RectangleF rect = new RectangleF(p.X - s.Width / 2, p.Y - s.Height / 2, s.Width, s.Height);
                if (rect.Contains(U, V))
                {
                    return p;
                }
            }
            return PointF.Empty;
        }

        public static PointF CheckMark(Point loc, Edge edge)
        {
            return CheckMark(loc.X, loc.Y, edge);
        }
    }
}
