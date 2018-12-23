using System.Collections.Generic;
using System.Drawing;
using SemanticNetworksLibrary.Drawing;
using SemanticNetworksLibrary.Misc;
using SemanticNetworksLibrary.Semantic_Network;

namespace SemanticNetworksLibrary._Edges
{
    public class None : IEdgeShape
    {
        public void Draw(Graphics g, Edge edge)
        {
            
        }

        public bool Contains(PointF point, Edge edge)
        {
            return false;
        }

        public override string ToString()
        {
            return "Нет линии";
        }
    }
}
