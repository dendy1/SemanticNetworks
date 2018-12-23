using SemanticNetworksLibrary.Drawing;
using SemanticNetworksLibrary.Semantic_Network;
using System.Drawing;
using SemanticNetworksLibrary.Misc;

namespace SemanticNetworksLibrary._Nodes
{
    public interface INodeShape
    {
        void Draw(Graphics g, Node node);
        bool Contains(Point point, Node node);
    }
}
