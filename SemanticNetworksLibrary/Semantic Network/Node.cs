using System.Collections.Generic;
using System.Drawing;
using SemanticNetworksLibrary.Drawing;
using SemanticNetworksLibrary._Nodes;

namespace SemanticNetworksLibrary.Semantic_Network
{
    public class Node
    {
        public float X { get; set; }
        public float Y { get; set; }
        public string Concept { get; set; }
        public bool Selected { get; set; }
        public bool Editing { get; set; }
        public List<Edge> Neighbours { get; set; }
        public List<PointF> Marks { get; set; }
        public INodeShape Shape { get; set; }

        public PointF Position
        {
            get { return new PointF(X, Y); }
            set
            {
                X = value.X;
                Y = value.Y;
            }
        }

        public Node(string Concept, PointF position, INodeShape shape)
        {
            this.Concept = Concept;
            this.X = position.X;
            this.Y = position.Y;
            Shape = shape;
            Neighbours = new List<Edge>();
            Marks = new List<PointF>();
        }

        public bool Contains(Point point, DrawConfig drawConfig)
        {
            return Shape.Contains(point, this, drawConfig);
        }

        public override string ToString()
        {
            return Concept;
        }
    }
}
