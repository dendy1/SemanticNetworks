using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemanticNetworksLibrary.Semantic_Network
{
    public class Relation
    {
        public string Name { get; set; }

        public Relation(string Name)
        {
            this.Name = Name;
        }

        public override string ToString()
        {
            return Name;
        }

        public static List<Relation> GetDefaultRelations()
        {
            return new List<Relation>()
            {
                new Relation("Является"),
                new Relation("Имеет"),
                new Relation("Есть")
            };
        }
    }
}
