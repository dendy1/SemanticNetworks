using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using SemanticNetworksLibrary.Semantic_Network;
using SemanticNetworksLibrary.Misc;

namespace SemanticNetworksLibrary.Drawing
{
    public class DrawConfig
    {
        public Converter Converter { get; set; }
        public EdgeConfig EdgeConfig { get; set; }
        public NodeConfig NodeConfig { get; set; }
        
        public DrawConfig(Converter converter, NodeConfig nodeConfig, EdgeConfig edgeConfig)
        {
            Converter = converter;
            NodeConfig = nodeConfig;
            EdgeConfig = edgeConfig;
        }
    }
}
