using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SemanticNetworksLibrary.Semantic_Network;

namespace SemanticNetworksLibrary._Nodes
{
    public class None : INodeShape
    {
        public bool Contains(Point point, Node node)
        {
            return false;
        }

        public void Draw(Graphics g, Node node)
        {

        }

        public override string ToString()
        {
            return "Нет";
        }
    }
}
