using System;
using System.Collections.Generic;

namespace HackerRank
{
    public class StackImp : AbsProblem, IProblem
    {
        UserInput userInput = new UserInput();

        public StackImp() : base("Stack Implementation")
        {
        }

        public void Begin()
        {
            CustomStack customStack = new CustomStack();

            int[] inputArry = userInput.intAryUserInput(4);
            string args = "1 2 3 4 5";
            int[] input = ConvertInputToInt(args);

            foreach (int element in input)
            {
                DisplayMessage("Element: " + element);
            }

            customStack.Push(inputArry[0]);
            customStack.Push(inputArry[1]);
            customStack.Push(inputArry[2]);
            customStack.Push(inputArry[3]);

            int data = customStack.Pop();

            DisplayMessage("Stack: " + data);
            DisplayMessage("Stack Size: " + customStack.Size);
            data = customStack.Pop();
            DisplayMessage("Stack: " + data);
            DisplayMessage("Stack Size: " + customStack.Size);
            data = customStack.Pop();
            DisplayMessage("Stack: " + data);
            DisplayMessage("isEmpty: " + customStack.isEmpty());
            DisplayMessage("Stack Size: " + customStack.Size);

            data = customStack.Pop();
            DisplayMessage("Stack: " + data);
            DisplayMessage("isEmpty: " + customStack.isEmpty());
            DisplayMessage("Stack Size: " + customStack.Size);

        }

        public int[] ConvertInputToInt(string args)
        {
            List<int> input = new List<int>();

            string[] argsData = args.Split(' ');
            foreach (string data in argsData)
            {
                Int32.TryParse(data, out int num);
                input.Add(num);
            }

            return input.ToArray();

        }

    }

    public class CustomStack : IDataHolder
    {
        private List<int> dataValue;

        //Constructor
        public CustomStack()
        {
            dataValue = new List<int>();
        }

        //Size Property
        private int mSize;
        //This Method will return int value which indicates the 
        //Size of the Stack
        public int Size
        {
            get
            {
                mSize = dataValue.Count;
                return mSize;
            }
        }

        //This Method will push int value 
        //int to int array
        public void Push(int data)
        {
            dataValue.Add(data);
        }

        //This Method will return int value which 
        //Has been pushed last
        public int Pop()
        {
            int data = 0;
            if (dataValue.Count > 0)
            {
                data = dataValue[dataValue.Count - 1];
                dataValue.RemoveAt(dataValue.Count - 1);
                return data;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        //This Method will return boolean value which indicates 
        //if the stack is Empty
        public bool isEmpty()
        {
            return dataValue.Count <= 0;
        }
    }

    public interface IDataHolder
    {
        void Push(int data);
        int Pop();
        bool isEmpty();
    }
}
