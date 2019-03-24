using System;
using System.Collections.Generic;

namespace HackerRank
{
    public abstract class AbsProblem : IProblem
    {
        private string mProblemName;
        private UserInput mUserInput = new UserInput();

        public AbsProblem(string strProblemName)
        {
            mProblemName = strProblemName;
            DisplayMessage(mProblemName);
        }

        public void DisplayMessage(string strMessage)
        {
            Console.WriteLine(strMessage);
        }

        public bool RunAgain()
        {
            //New Line
            DisplayMessage("");
            DisplayMessage("Run Again? Enter 1 for Yes");

            bool bRunAgain = false;
            UserInput input = new UserInput();

            if (input.intUserInput() == 1)
            {
                bRunAgain = true;
            }

            return bRunAgain;
        }

        public int GetUserIntInput()
        {
            return mUserInput.intUserInput();
        }

        public int[] GetUserAryIntInput(int iSize)
        {
            return mUserInput.intAryUserInput(iSize);
        }

        public string[] GetUserAryStringInput()
        {
            string strInput = mUserInput.strUserInput();
            string[] straryReturn = strInput.Split(' ');

            return straryReturn;
        }

        public string GetUserStringInput()
        {
            return GetUserStringInput();
        }

        public void Begin()
        {
            throw new NotImplementedException();
        }
    }
}