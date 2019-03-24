using System;
using System.Collections.Generic;

namespace HackerRank
{
    public class Trie
    {
        private Node mRoot;

        class Node
        {
            public Node ParentNode;
            public char Data;
            public List<Node> ChildrenNode;
            public int Depth;

            public Node(char chData, int iDepth, Node node)
            {
                ParentNode = node;
                Data = chData;
                Depth = iDepth;
                ChildrenNode = new List<Node>();
            }
        }

        public Trie(char chData)
        {
            mRoot = new Node(chData, 0, null);
        }

        public void Insert(char chData)
        {
            if (mRoot.Data != chData)
            {
                mRoot.ChildrenNode.Add(new Node(chData, 0, mRoot));
            }

        }
    }
}


