using SemanticNetworksLibrary.Drawing;
using SemanticNetworksLibrary.Semantic_Network;
using System.Drawing;

namespace SemanticNetworksLibrary._Nodes
{
    public interface INodeShape
    {
        void Draw(Graphics g, Node node, DrawConfig drawConfig);
        bool Contains(Point point, Node n, DrawConfig drawConfig);
        void CalculateMarks(Node n, DrawConfig drawConfig);
    }
}
