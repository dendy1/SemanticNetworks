using SemanticNetworksLibrary.Drawing;
using SemanticNetworksLibrary.Misc;
using System.Collections.Generic;
using System.Drawing;

namespace SemanticNetworksLibrary.Semantic_Network
{
    public class Edge
    {
        public Relation Relation { get; set; }
        public Node NodeOne { get; set; }
        public Node NodeTwo { get; set; }
        public bool Selected { get; set; }

        public List<PointF> LinePoints { get; set; }
        public List<PointF> MovementPoints { get; set; }
        public float Y { get; set; }
        public float XStart { get; set; }
        public float XEnd { get; set; }
        public IEdgeShape Shape { get; set; }
        public IArrowShape ArrowHeadShape { get; set; }
        public IArrowShape ArrowTailShape { get; set; }

        public Edge(Relation Relation, Node NodeOne, Node NodeTwo, IEdgeShape shape, IArrowShape arrowTail, IArrowShape arrowHead)
        {
            this.Relation = Relation;
            this.NodeOne = NodeOne;
            this.NodeTwo = NodeTwo;
            ArrowHeadShape = arrowHead;
            ArrowTailShape = arrowTail;
            Shape = shape;
            LinePoints = new List<PointF>();
            MovementPoints = new List<PointF>();
        }

        public Node GetNeighbour(Node node)
        {
            if (node == NodeOne) return NodeTwo;
            if (node == NodeTwo) return NodeOne;
            return null;
        }

        public override string ToString()
        {
            return Relation.ToString();
        }

        public bool Contains(Point point, DrawConfig drawConfig)
        {
            return Shape.Contains(point, this, drawConfig);
        }

        public void Calculate(DrawConfig drawConfig)
        {
            Y = (NodeOne.Y + NodeTwo.Y) / 2;
            XStart = Drawing.Drawing.GetSizeF(NodeOne, drawConfig).Width / 2;
            XEnd = Drawing.Drawing.GetSizeF(NodeTwo, drawConfig).Width / 2;
            SetPoints(drawConfig);
        }

        public void SetPoints(DrawConfig drawConfig)
        {
            Pen pen = Selected ? drawConfig.EdgeConfig.SelectedEdgePen : drawConfig.EdgeConfig.EdgePen;
            Converter converter = drawConfig.Converter;

            Node startNode = NodeOne, endNode = NodeTwo;

            PointF start = new PointF(), end = new PointF(), centerS = new PointF(), centerE = new PointF();

            SizeF sizeStart = Drawing.Drawing.GetSizeF(startNode, drawConfig);
            SizeF sizeEnd = Drawing.Drawing.GetSizeF(endNode, drawConfig);

            start = new PointF(converter.XXtoII(startNode.X) - sizeStart.Width / 2 + XStart, converter.YYtoJJ(startNode.Y));
            end = new PointF(converter.XXtoII(endNode.X) - sizeEnd.Width / 2 + XEnd,
                converter.YYtoJJ(endNode.Y));

            if (startNode.Y < endNode.Y)
            {
                start = new PointF(converter.XXtoII(startNode.X) - sizeStart.Width / 2 + XStart, converter.YYtoJJ(startNode.Y) - sizeStart.Height / 2);
                end = new PointF(converter.XXtoII(endNode.X) - sizeEnd.Width / 2 + XEnd, converter.YYtoJJ(endNode.Y) + sizeEnd.Height / 2);
            }
            else if (startNode.Y >= endNode.Y)
            {
                start = new PointF(converter.XXtoII(startNode.X) - sizeStart.Width / 2 + XStart, converter.YYtoJJ(startNode.Y) + sizeStart.Height / 2);
                end = new PointF(converter.XXtoII(endNode.X) - sizeEnd.Width / 2 + XEnd, converter.YYtoJJ(endNode.Y) - sizeEnd.Height / 2);
            }

            centerS = new PointF(start.X, converter.YYtoJJ(Y));
            centerE = new PointF(end.X, converter.YYtoJJ(Y));

            LinePoints = new List<PointF>
            {
                start, centerS, centerE, end
            };
        }
    }
}
