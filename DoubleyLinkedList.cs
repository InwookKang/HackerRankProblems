using System;
using System.Text;

namespace HackerRank
{
    public class DoubleyLinkedList : AbsProblem, IProblem
    {
        private class Node
        {
            public int data;
            public Node next;
            public Node prev;

            public Node(int data)
            {
                this.data = data;
                next = null;
                prev = null;
            }

            public Node(int data, Node prevNode)
            {
                this.data = data;
                next = null;
                prev = prevNode;
            }
        }
        private Node mHeadNode;
        private Node mCurrentNode;

        public DoubleyLinkedList() : base("Doubley Linked List")
        {

        }

        public void Begin()
        {
            do
            {
                UserChoice();
                DisplayLinkedList();
            } while (base.RunAgain());
        }

        private void UserChoice()
        {
            DisplayMessage("Current List: ");
            DisplayLinkedList();
            DisplayMessage("What would you like to do? ");
            DisplayMessage("1. Enter Numbers to Linked List");
            DisplayMessage("2. Delete Number");
            DisplayMessage("3. Pre-Pend to Linked List");
            DisplayMessage("4. Erase All Data");

            int iUserChoice = GetUserIntInput();

            switch (iUserChoice)
            {
                case 1:
                    {
                        DisplayMessage("How Many Numbers?");
                        int iSize = GetUserIntInput();
                        DisplayMessage("Enter Numbers.");
                        int[] intArryInput = GetUserAryIntInput(iSize);

                        InsertNumbersToLinkedList(intArryInput);
                        break;
                    }
                case 2:
                    {
                        DisplayMessage("Enter Number to Delete");
                        int iUserInput = GetUserIntInput();

                        Delete(iUserChoice);
                        break;
                    }
                case 3:
                    {
                        DisplayMessage("Enter Data to PrePend");
                        int iUserInput = GetUserIntInput();

                        Prepend(iUserInput);
                        break;
                    }
                case 4:
                    {
                        DeleteAllData();
                        break;
                    }
                default:
                    {
                        DisplayMessage("Invalid Choice");
                        break;
                    }
            }
        }

        private void DeleteAllData()
        {
            mHeadNode = null;
        }

        private void DisplayLinkedList()
        {
            Node tempNode = mHeadNode;
            StringBuilder strbld = new StringBuilder();
            if (mHeadNode == null)
            {
                DisplayMessage("Linked List is Empty");
                return;
            }
            while (tempNode != null)
            {
                strbld.Append(tempNode.data);
                if (tempNode.next != null)
                {
                    strbld.Append("->");
                }
                tempNode = tempNode.next;
            }
            DisplayMessage(strbld.ToString());
        }

        private void InsertNumbersToLinkedList(int[] intArray)
        {
            for (int i = 0; i < intArray.Length; i++)
            {
                Insert(intArray[i]);
            }
        }

        private void Insert(int num)
        {
            if (mHeadNode == null)
            {
                mHeadNode = new Node(num);
                return;
            }
            mCurrentNode = mHeadNode;
            while (mCurrentNode.next != null)
            {
                mCurrentNode = mCurrentNode.next;
            }
            mCurrentNode.next = new Node(num);
        }

        private void Delete(int num)
        {
            bool bFound = false;
            //Base Case
            if (mHeadNode.data == num)
            {
                DisplayMessage("Head Node Deleted");
                mHeadNode = mHeadNode.next;
                return;
            }

            Node tempNode = mHeadNode;
            while (tempNode != null)
            {
                //End of Linked List
                if (tempNode.data == num)
                {
                    bFound = true;
                    //Delete Node
                    tempNode.next = tempNode.next.next;
                }
                tempNode = tempNode.next;
            }
            if (bFound)
            {
                DisplayMessage("Deleted Node");
            }
            else
            {
                DisplayMessage("Node with " + num + "Not Found");
            }
        }

        private void Prepend(int num)
        {
            Node newNode = new Node(num);
            newNode.next = mHeadNode;
            mHeadNode = newNode;
        }
    }
}
