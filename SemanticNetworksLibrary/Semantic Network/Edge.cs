using SemanticNetworksLibrary.Drawing;
using SemanticNetworksLibrary.Misc;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace SemanticNetworksLibrary.Semantic_Network
{
    public class Edge
    {
        public Relation Relation { get; set; }
        public Node NodeOne { get; set; }
        public Node NodeTwo { get; set; }
        public bool Selected { get; set; }
        public bool Edit { get; set; }
        public List<PointF> LinePoints { get; set; }
        public Dictionary<Utils.MarkerType, PointF> Markers { get; }
        public float Y { get; set; }
        public float XStart { get; set; }
        public float XEnd { get; set; }

        public EdgeConfig EdgeConfig { get; set; }
        public Converter Converter { get; set; }

        public IEdgeShape Shape { get; set; }
        public IArrowShape ArrowHeadShape { get; set; }
        public IArrowShape ArrowTailShape { get; set; }
        public PointF HeadArrowStart { get; set; }
        public PointF TailArrowStart { get; set; }
        public PointF CenterS { get; set; }
        public PointF CenterE { get; set; }

        public Edge(Relation Relation, Node NodeOne, Node NodeTwo, IEdgeShape shape, IArrowShape arrowTail, IArrowShape arrowHead)
        {
            this.Relation = Relation;
            this.NodeOne = NodeOne;
            this.NodeTwo = NodeTwo;
            ArrowHeadShape = arrowHead;
            ArrowTailShape = arrowTail;
            Shape = shape;
            LinePoints = new List<PointF>();
            Markers = new Dictionary<Utils.MarkerType, PointF>();
        }

        public override string ToString()
        {
            return Relation.ToString();
        }

        public bool Contains(Point point, DrawConfig drawConfig)
        {
            return Shape.Contains(point, this, drawConfig);
        }

        public void SetDefaultValues(DrawConfig drawConfig)
        {
            Y = (NodeOne.Y + NodeTwo.Y) / 2;
            XStart = Drawing.Drawing.GetSizeF(NodeOne, drawConfig).Width / 2 / drawConfig.Converter.Scale;
            XEnd = Drawing.Drawing.GetSizeF(NodeTwo, drawConfig).Width / 2 / drawConfig.Converter.Scale;
            LinePoints = RefreshPoints(drawConfig);

            Markers.Add(Utils.MarkerType.Center, new PointF((CenterE.X + End.X) / 2, drawConfig.Converter.YYtoJJ(Y)));
            Markers.Add(Utils.MarkerType.CenterStart, new PointF(Start.X, (Start.Y * CenterS.Y) / 2));
            Markers.Add(Utils.MarkerType.CenterEnd, new PointF(End.X, (End.Y * CenterE.Y) / 2));
        }

        public List<PointF> RefreshPoints(DrawConfig drawConfig)
        {
            List<PointF> pts = new List<PointF>();
            PointF start = new PointF(), end = new PointF();

            Converter converter = drawConfig.Converter;
            Node startNode = NodeOne, endNode = NodeTwo;

            SizeF sizeStart = Drawing.Drawing.GetSizeF(startNode, drawConfig);
            SizeF sizeEnd = Drawing.Drawing.GetSizeF(endNode, drawConfig);

            float startY = converter.YYtoJJ(startNode.Y), endY = converter.YYtoJJ(endNode.Y);

            if (converter.YYtoJJ(Y) > converter.YYtoJJ(startNode.Y) + sizeStart.Height / 2)
            {
                startY = converter.YYtoJJ(startNode.Y) + sizeStart.Height / 2;
            }
            else if (converter.YYtoJJ(Y) <= converter.YYtoJJ(startNode.Y) - sizeStart.Height / 2)
            {
                startY = converter.YYtoJJ(startNode.Y) - sizeStart.Height / 2;
            }

            if (converter.YYtoJJ(Y) > converter.YYtoJJ(endNode.Y) + sizeEnd.Height / 2)
            {
                endY = converter.YYtoJJ(endNode.Y) + sizeEnd.Height / 2;
            }
            else if (converter.YYtoJJ(Y) <= converter.YYtoJJ(endNode.Y) - sizeEnd.Height / 2)
            {
                endY = converter.YYtoJJ(endNode.Y) - sizeEnd.Height / 2;
            }

            start = new PointF(converter.XXtoII(startNode.X) - sizeStart.Width / 2 + XStart * drawConfig.Converter.Scale, startY);
            end = new PointF(converter.XXtoII(endNode.X) - sizeEnd.Width / 2 + XEnd * drawConfig.Converter.Scale, endY);
            CenterS = new PointF(start.X, converter.YYtoJJ(Y));
            CenterE = new PointF(end.X, converter.YYtoJJ(Y));
            HeadArrowStart = CenterE;
            TailArrowStart = CenterS;

            pts = new List<PointF>()
            {
                start, CenterS, CenterE, end
            };

            if (XEnd * drawConfig.Converter.Scale < 0)
            {
                pts[pts.Count - 1] = new PointF(converter.XXtoII(endNode.X) - sizeEnd.Width / 2 + XEnd * drawConfig.Converter.Scale,
                    converter.YYtoJJ(endNode.Y));
                pts.Add(new PointF(converter.XXtoII(endNode.X) - sizeEnd.Width / 2, converter.YYtoJJ(endNode.Y)));
                HeadArrowStart = pts[pts.Count - 2];
                CenterE = new PointF(HeadArrowStart.X, (HeadArrowStart.Y + pts[pts.Count - 3].Y) / 2);
            }
            else if (XEnd * drawConfig.Converter.Scale > sizeEnd.Width)
            {
                pts[pts.Count - 1] = new PointF(converter.XXtoII(endNode.X) - sizeEnd.Width / 2 + XEnd * drawConfig.Converter.Scale,
                    converter.YYtoJJ(endNode.Y));
                pts.Add(new PointF(converter.XXtoII(endNode.X) + sizeEnd.Width / 2, converter.YYtoJJ(endNode.Y)));
                HeadArrowStart = pts[pts.Count - 2];
                CenterE = new PointF(HeadArrowStart.X, (HeadArrowStart.Y + pts[pts.Count - 3].Y) / 2);
            }

            if (XStart * drawConfig.Converter.Scale < 0)
            {
                pts[0] = new PointF(converter.XXtoII(startNode.X) - sizeStart.Width / 2 + XStart * drawConfig.Converter.Scale, converter.YYtoJJ(startNode.Y));
                pts.Insert(0, new PointF(converter.XXtoII(startNode.X) - sizeStart.Width / 2, converter.YYtoJJ(startNode.Y)));
                TailArrowStart = pts[1];
                CenterS = new PointF(TailArrowStart.X, (TailArrowStart.Y + pts[2].Y) / 2);
            }
            else if (XStart * drawConfig.Converter.Scale > sizeStart.Width)
            {
                pts[0] = new PointF(converter.XXtoII(startNode.X) - sizeStart.Width / 2 + XStart * drawConfig.Converter.Scale, converter.YYtoJJ(startNode.Y));
                pts.Insert(0, new PointF(converter.XXtoII(startNode.X) + sizeStart.Width / 2, converter.YYtoJJ(startNode.Y)));
                TailArrowStart = pts[1];
                CenterS = new PointF(TailArrowStart.X, (TailArrowStart.Y + pts[2].Y) / 2);
            }

            return pts;
        }

        public void RefreshMarkers(DrawConfig drawConfig)
        {
            Markers[Utils.MarkerType.Center] = new PointF((CenterS.X + CenterE.X) / 2, drawConfig.Converter.YYtoJJ(Y));
            Markers[Utils.MarkerType.CenterStart] = CenterS;
            Markers[Utils.MarkerType.CenterEnd] = CenterE;
        }

        public PointF Start
        {
            get { return LinePoints[0]; }
            set { LinePoints[0] = new PointF(value.X, value.Y); }
        }

        public PointF End
        {
            get { return LinePoints[LinePoints.Count - 1]; }
            set { LinePoints[LinePoints.Count - 1] = new PointF(value.X, value.Y); }
        }
    }
}
