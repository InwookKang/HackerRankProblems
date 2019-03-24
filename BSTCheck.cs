using System;
namespace HackerRank
{
    class Node
    {
        public int data = 0;
        public Node Left = null;
        public Node Right = null;
    }

    public class BSTCheck : AbsProblem, IProblem
    {

        /*
         * 
         *  The  value of every node in a node's left subtree is less than the data value of that node.
         *  The  value of every node in a node's right subtree is greater than the data value of that node.
         *
         */
        public BSTCheck() : base("BST Validation")
        {
        }

        public void Begin()
        {

        }

        bool checkBST(Node root)
        {
            //Seed of Min and Max value 
            return CheckNode(root, -2147483648, 2147483647);
        }

        bool CheckNode(Node node, int min, int max)
        {
            if (node == null)
            {
                return true;
            }
            else
            {
                return min < node.data &&
                       max > node.data &&
                       CheckNode(node.Left, min, node.data) &&
                       CheckNode(node.Right, node.data, max);
            }
        }
    }
}
