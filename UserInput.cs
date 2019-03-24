using System;
using System.Collections.Generic;

namespace HackerRank
{
    public class UserInput : IUserInput
    {
        /// <summary>
        /// Ints the user input.
        /// </summary>
        /// <returns>The user input.</returns>
        public int intUserInput()
        {
            DisplayMessage("Enter Number: ");
            int iReturn;
            Int32.TryParse(Console.ReadLine(), out iReturn);

            return iReturn;
        }

        /// <summary>
        /// Strings the user input.
        /// </summary>
        /// <returns>The user input.</returns>
        public string strUserInput()
        {
            DisplayMessage("Enter string: ");
            return Console.ReadLine();
        }

        /// <summary>
        /// Ints the ary user input.
        /// </summary>
        /// <returns>The ary user input.</returns>
        /// <param name="iSize">I size.</param>
        public int[] intAryUserInput(int iSize)
        {
            DisplayMessage("Enter Numbers seperated by [SPACE]");
            List<int> iListReturn = new List<int>();
            string strInput = Console.ReadLine();
            string[] strArray = strInput.Split(" ");

            foreach (string str in strArray)
            {
                Int32.TryParse(str, out int iNum);
                iListReturn.Add(iNum);
            }

            return iListReturn.ToArray();
        }

        /// <summary>
        /// Displaies the message.
        /// </summary>
        /// <param name="strMsg">String message.</param>
        private void DisplayMessage(string strMsg)
        {
            Console.WriteLine(strMsg);
        }

    }
}
