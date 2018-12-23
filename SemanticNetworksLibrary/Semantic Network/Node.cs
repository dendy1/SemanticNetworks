using System.Collections.Generic;
using System.Drawing;
using SemanticNetworksLibrary.Drawing;
using SemanticNetworksLibrary.Misc;
using SemanticNetworksLibrary._Nodes;

namespace SemanticNetworksLibrary.Semantic_Network
{
    public class Node
    {
        public float X { get; set; }
        public float Y { get; set; }
        public string Concept { get; set; }
        public List<Edge> Neighbours { get; set; }
        public NodeConfig NodeConfig { get; set; }

        public PointF Position
        {
            get { return new PointF(X, Y); }
            set
            {
                X = value.X;
                Y = value.Y;
            }
        }

        public Node(string Concept, PointF position, NodeConfig nodeConfig)
        {
            this.Concept = Concept;
            this.X = position.X;
            this.Y = position.Y;
            Neighbours = new List<Edge>();
            NodeConfig = nodeConfig;
        }

        public bool Contains(Point point)
        {
            return NodeConfig.Shape.Contains(point, this);
        }

        public override string ToString()
        {
            return Concept;
        }
    }
}
