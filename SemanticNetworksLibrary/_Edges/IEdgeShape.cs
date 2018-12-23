using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SemanticNetworksLibrary.Drawing;
using SemanticNetworksLibrary.Misc;
using SemanticNetworksLibrary.Semantic_Network;

namespace SemanticNetworksLibrary
{
    public interface IEdgeShape
    {
        void Draw(Graphics g, Edge edge, DrawConfig drawConfig);
        bool Contains(PointF point, Edge edge, DrawConfig drawConfig);
    }
}
