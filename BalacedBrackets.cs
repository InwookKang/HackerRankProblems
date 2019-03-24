using System;
using System.Collections.Generic;

namespace HackerRank
{
    public class BalacedBrackets : AbsProblem, IProblem
    {
        public BalacedBrackets() : base("Balancing Brackets")
        {
        }

        public void Begin()
        {
            do
            {
                DisplayMessage("How Many Bracket Sets?");
                int iUserInput = GetUserIntInput();

                string[] strBrackets = GetUserAryStringInput();
                for (int i = 0; i < iUserInput; i++)
                {
                    DisplayMessage(IsBracketMatch(strBrackets[i]) ? "YES" : "NO");
                }


            } while (base.RunAgain());
        }

        public bool IsBracketMatch(string strBrackets)
        {
            bool bReturn = false;
            Stack<char> stackBrackets = new Stack<char>();

            foreach (var chBracket in strBrackets)
            {
                if (IsOpenBracket(chBracket))
                {
                    stackBrackets.Push(chBracket);
                    bReturn = true;
                }
                else
                {
                    if (stackBrackets.Count <= 0)
                    {
                        bReturn = false;
                        break;
                    }
                    char chPopped = stackBrackets.Pop();
                    if (!IsMatchingBracket(chPopped, chBracket))
                    {
                        bReturn = false;
                        break;
                    }
                }

            }
            return bReturn;
        }

        public bool IsOpenBracket(char chBracket)
        {
            bool bStatus = false;

            if (chBracket == '{' ||
               chBracket == '(' ||
                chBracket == '[')
            {
                bStatus = true;
            }

            return bStatus;
        }

        public bool IsMatchingBracket(char chPopped, char chBracket)
        {
            bool bStatus = false;
            switch (chPopped)
            {
                case '{':
                    {
                        if (chBracket == '}')
                        {
                            bStatus = true;
                        }
                        break;
                    }
                case '[':
                    {
                        if (chBracket == ']')
                        {
                            bStatus = true;
                        }
                        break;
                    }
                case '(':
                    {
                        if (chBracket == ')')
                        {
                            bStatus = true;
                        }
                        break;
                    }


            }
            return bStatus;
        }

    }
}
