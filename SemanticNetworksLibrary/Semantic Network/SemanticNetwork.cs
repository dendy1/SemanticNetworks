using System.Collections.Generic;
using System.Linq;
using SemanticNetworksLibrary.Drawing;

namespace SemanticNetworksLibrary.Semantic_Network
{
    public class SemanticNetwork
    {
        public string Name { get; set; }
        public List<Node> Nodes { get; set; }
        public List<Edge> Edges { get; set; }
        public List<Node> SelectedNodes { get; set; }
        public List<Relation> Relations { get; set; }

        public SemanticNetwork(List<Node> Nodes, List<Edge> Edges, string Name)
        {
            this.Nodes = Nodes;
            this.Edges = Edges;
            this.Relations = Relation.GetDefaultRelations();
            this.Name = Name;
            SelectedNodes = new List<Node>();
        }

        public void AddNode(Node Node)
        {
            Nodes.Add(Node);
        }

        public void DeleteNode(Node Node)
        {
            foreach (Edge e in Node.Neighbours)
            {
                DeleteEdge(e);
                if (Node.Neighbours.Count == 0) break;
            }
            Nodes.Remove(Node);
        }

        public void AddEdge(Edge Edge)
        {
            Edges.Add(Edge);
            Edge.NodeOne.Neighbours.Add(Edge);
            Edge.NodeTwo.Neighbours.Add(Edge);
        }

        public void DeleteEdge(Edge Edge)
        {
            Edge.NodeOne.Neighbours.Remove(Edge);
            Edge.NodeTwo.Neighbours.Remove(Edge);
            Edges.Remove(Edge);
        }

        public void Deselect()
        {
            DeSelectNodes();
            DeSelectEdges();
        }

        public void DeSelectNodes()
        {
            foreach (Node s in Nodes)
                s.NodeConfig.Selected = false;
        }

        public void DeSelectEdges()
        {
            foreach (Edge edge in Edges)
                edge.EdgeConfig.Selected = false;
        }

        public Node SelectedNode
        {
            get
            {
                foreach (var VARIABLE in Nodes)
                {
                    if (VARIABLE.NodeConfig.Selected) return VARIABLE;
                }
                return null;
            }
        }

        public Edge SelectedEdge
        {
            get
            {
                foreach (var edge in Edges)
                {
                    if (edge.EdgeConfig.Selected) return edge;
                }
                return null;
            }
        }

        public Edge EditingEdge
        {
            get
            {
                foreach (var edge in Edges)
                {
                    if (edge.EdgeConfig.Edit) return edge;
                }
                return null;
            }
        }
    }
}
