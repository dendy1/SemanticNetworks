using SemanticNetworksLibrary.Drawing;
using System.Drawing;

namespace SemanticNetworksLibrary.Semantic_Network
{
    public class Edge
    {
        public Relation Relation { get; set; }
        public Node NodeOne { get; set; }
        public Node NodeTwo { get; set; }
        public EdgeConfig EdgeConfig { get; set; }

        public Edge(Relation Relation, Node NodeOne, Node NodeTwo, EdgeConfig edgeConfig)
        {
            this.Relation = Relation;
            this.NodeOne = NodeOne;
            this.NodeTwo = NodeTwo;
            EdgeConfig = edgeConfig;
            EdgeConfig.SetDefaultValues(NodeOne, NodeTwo);
        }

        public bool Contains(Point point)
        {
            return EdgeConfig.Shape.Contains(point, this);
        }

        public override string ToString()
        {
            return Relation.ToString();
        }
    }
}
