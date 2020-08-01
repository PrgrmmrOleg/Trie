using System;
using System.Collections.Generic;

namespace PrefixTree
{
    public class Tree
    {
        private List<Node> _nodes = new List<Node>();

        public Tree() {}

        public Tree(string[] words)
        {
            AddList(words);
        }

        public void AddList(string[] words)
        {
            foreach (var word in words)
            {
                Add(word);
            }
        }

        public void Add(string word)
        {
            Add(word, _nodes);
        }

        private void Add(string word, List<Node> nodes)
        {
            int wordLength = word.Length;
            if (wordLength > 0)
            {
                foreach (var node in nodes)
                {
                    if (node.Name == word[0])
                    {
                        if (wordLength == 1)
                        {
                            node.BreakLine = true;
                            return;
                        }
                        else
                        {
                            Add(word.Substring(1), node.Nodes);
                            return;
                        }
                    }
                }

                Node newNode = new Node(word[0]);

                if (wordLength == 1)
                {
                    newNode.BreakLine = true;
                    nodes.Add(newNode);
                    return;
                }
                else
                {
                    nodes.Add(newNode);
                    Add(word.Substring(1), newNode.Nodes);
                }
            }
        }

        public bool Contain(string word)
        {
            return Contain(word, _nodes);
        }

        private bool Contain(string word,List<Node> nodes)
        {
            int wordLength = word.Length;
            if (wordLength > 0)
            {
                foreach (var node in nodes)
                {
                    if (node.Name == word[0])
                    {
                        if (wordLength == 1 && node.BreakLine == true)
                        {
                            return true;
                        }
                        else
                        {
                            return Contain(word.Substring(1), node.Nodes);
                        }
                    }
                }
            }
            return false;
        }
    }
}
