using System.Drawing;
using SemanticNetworksLibrary.Drawing;
using SemanticNetworksLibrary.Semantic_Network;

namespace SemanticNetworksLibrary._Edges
{
    public class NoneEdge : IEdgeShape
    {
        public void Draw(Graphics g, Edge edge, DrawConfig drawConfig)
        {
            
        }

        public bool Contains(Point point, Edge e, DrawConfig drawConfig)
        {
            return false;
        }
    }
}
