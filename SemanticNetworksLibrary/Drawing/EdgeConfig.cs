using SemanticNetworksLibrary.Misc;
using SemanticNetworksLibrary.Semantic_Network;
using System.Collections.Generic;
using System.Drawing;

namespace SemanticNetworksLibrary.Drawing
{
    public class EdgeConfig
    {
        public Converter Converter { get; set; }
        // Конфигурация стрелок
        public IArrowShape ArrowHeadShape { get; set; }
        public IArrowShape ArrowTailShape { get; set; }
        public SizeF ArrowSize { get; set; }
        // Маркеры
        public Dictionary<Utils.MarkerType, PointF> Markers { get; }
        public SizeF MarkerSize { get; set; }
        public float Y { get; set; }
        public float XStart { get; set; }
        public float XEnd { get; set; }
        // Вспомогательные точки
        public PointF HeadArrowStart { get; set; }
        public PointF TailArrowStart { get; set; }
        public PointF CenterS { get; set; }
        public PointF CenterE { get; set; }
        // Перо для рисования
        public Pen EdgePen { get; set; }
        public Pen SelectedEdgePen { get; set; }
        // Шрифт надписи
        public Font Font { get; set; }
        public Color FontColor { get; set; }
        // Форма ребра
        public IEdgeShape Shape { get; set; }
        // Опорные точки
        public List<PointF> LinePoints { get; set; }
        // Флаги
        public bool Selected { get; set; }
        public bool Edit { get; set; }
        public EdgeConfig(IEdgeShape shape, IArrowShape headShape, IArrowShape tailShape, SizeF arrowSize, SizeF markerSize, Pen edgepen, Pen selectededgepen, Font font, Color fontcolor, Converter c)
        {
            Shape = shape;
            ArrowHeadShape = headShape;
            ArrowTailShape = tailShape;
            ArrowSize = arrowSize;
            MarkerSize = markerSize;
            EdgePen = edgepen;
            SelectedEdgePen = selectededgepen;
            Font = font;
            FontColor = fontcolor;
            LinePoints = new List<PointF>();
            Markers = new Dictionary<Utils.MarkerType, PointF>();
            Converter = c;
        }


        public void SetDefaultValues(Node NodeOne, Node NodeTwo)
        {
            Y = (NodeOne.Y + NodeTwo.Y) / 2;
            XStart = Drawing.GetSizeF(NodeOne).Width / 2 / Converter.Scale;
            XEnd = Drawing.GetSizeF(NodeTwo).Width / 2 / Converter.Scale;
            LinePoints = RefreshPoints(NodeOne, NodeTwo);

            Markers.Add(Utils.MarkerType.Center, new PointF((CenterE.X + End.X) / 2, Converter.YYtoJJ(Y)));
            Markers.Add(Utils.MarkerType.CenterStart, new PointF(Start.X, (Start.Y + CenterS.Y) / 2));
            Markers.Add(Utils.MarkerType.CenterEnd, new PointF(End.X, (End.Y + CenterE.Y) / 2));
        }

        public List<PointF> RefreshPoints(Node NodeOne, Node NodeTwo)
        {
            List<PointF> pts = new List<PointF>();
            PointF start = new PointF(), end = new PointF();

            Converter converter = Converter;
            Node startNode = NodeOne, endNode = NodeTwo;

            SizeF sizeStart = Drawing.GetSizeF(startNode);
            SizeF sizeEnd = Drawing.GetSizeF(endNode);

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

            start = new PointF(converter.XXtoII(startNode.X) - sizeStart.Width / 2 + XStart * Converter.Scale, startY);
            end = new PointF(converter.XXtoII(endNode.X) - sizeEnd.Width / 2 + XEnd * Converter.Scale, endY);
            CenterS = new PointF(start.X, converter.YYtoJJ(Y));
            CenterE = new PointF(end.X, converter.YYtoJJ(Y));
            HeadArrowStart = CenterE;
            TailArrowStart = CenterS;

            pts = new List<PointF>()
            {
                start, CenterS, CenterE, end
            };

            if (XEnd * Converter.Scale < 0)
            {
                pts[pts.Count - 1] = new PointF(converter.XXtoII(endNode.X) - sizeEnd.Width / 2 + XEnd * Converter.Scale,
                    converter.YYtoJJ(endNode.Y));
                pts.Add(new PointF(converter.XXtoII(endNode.X) - sizeEnd.Width / 2, converter.YYtoJJ(endNode.Y)));
                HeadArrowStart = pts[pts.Count - 2];
                CenterE = new PointF(HeadArrowStart.X, (HeadArrowStart.Y + pts[pts.Count - 3].Y) / 2);
            }
            else if (XEnd * Converter.Scale > sizeEnd.Width)
            {
                pts[pts.Count - 1] = new PointF(converter.XXtoII(endNode.X) - sizeEnd.Width / 2 + XEnd * Converter.Scale,
                    converter.YYtoJJ(endNode.Y));
                pts.Add(new PointF(converter.XXtoII(endNode.X) + sizeEnd.Width / 2, converter.YYtoJJ(endNode.Y)));
                HeadArrowStart = pts[pts.Count - 2];
                CenterE = new PointF(HeadArrowStart.X, (HeadArrowStart.Y + pts[pts.Count - 3].Y) / 2);
            }

            if (XStart * Converter.Scale < 0)
            {
                pts[0] = new PointF(converter.XXtoII(startNode.X) - sizeStart.Width / 2 + XStart * Converter.Scale, converter.YYtoJJ(startNode.Y));
                pts.Insert(0, new PointF(converter.XXtoII(startNode.X) - sizeStart.Width / 2, converter.YYtoJJ(startNode.Y)));
                TailArrowStart = pts[1];
                CenterS = new PointF(TailArrowStart.X, (TailArrowStart.Y + pts[2].Y) / 2);
            }
            else if (XStart * Converter.Scale > sizeStart.Width)
            {
                pts[0] = new PointF(converter.XXtoII(startNode.X) - sizeStart.Width / 2 + XStart * Converter.Scale, converter.YYtoJJ(startNode.Y));
                pts.Insert(0, new PointF(converter.XXtoII(startNode.X) + sizeStart.Width / 2, converter.YYtoJJ(startNode.Y)));
                TailArrowStart = pts[1];
                CenterS = new PointF(TailArrowStart.X, (TailArrowStart.Y + pts[2].Y) / 2);
            }

            return pts;
        }

        public void RefreshMarkers()
        {
            Markers[Utils.MarkerType.Center] = new PointF((CenterS.X + CenterE.X) / 2, Converter.YYtoJJ(Y));
            Markers[Utils.MarkerType.CenterStart] = new PointF(CenterS.X, (Converter.YYtoJJ(Y) + Start.Y) / 2);
            Markers[Utils.MarkerType.CenterEnd] = new PointF(CenterE.X, (Converter.YYtoJJ(Y) + End.Y) / 2);
        }

        public PointF Start
        {
            get { if (LinePoints.Count == 0) return PointF.Empty; return LinePoints[0]; }
            set { LinePoints[0] = new PointF(value.X, value.Y); }
        }

        public PointF End
        {
            get
            {
                if (LinePoints.Count == 0) return PointF.Empty;
                return LinePoints[LinePoints.Count - 1];
            }
            set { LinePoints[LinePoints.Count - 1] = new PointF(value.X, value.Y); }
        }
    }
}
