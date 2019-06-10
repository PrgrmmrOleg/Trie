using System;
using System.Collections.Generic;
using System.Text;

namespace PrefixTree
{
    internal class Node
    {
        internal Node(char name)
        {
            Name = name;
            Nodes = new List<Node>();
        }

        public char Name { get;}

        public List<Node> Nodes;

        public bool BreakLine { get; set; }
    }
}
