using System;
using System.Collections.Generic;
using System.Linq;
namespace HackerRank
{
    public class RansomNoteGenerator : AbsProblem, IProblem
    {
        public RansomNoteGenerator() : base("Ransom Note Problem")
        {

        }

        public void Begin()
        {
            int iMagWordCount = 0;
            int iRansomWordCount = 0;
            do
            {
                DisplayMessage("Enter Number of Words from Magazine and Number of words for Ransom Message");
                int[] userInput = GetUserAryIntInput(2);

                iMagWordCount = userInput[0];
                iRansomWordCount = userInput[1];

                //DisplayMessage("Enter Words for Magazine separated by [SPACE]");
                // string[] strMag = GetUserAryStringInput();

                //DisplayMessage("Enter Words for Random separated by [SPACE]");
                // string[] strRandom = GetUserAryStringInput();

                //string[] strMagTest = { "apgo", "clm", "w", "lxkvg", "mwz", "elo", "bg", "elo", "lxkvg", "elo", "apgo", "apgo", "w", "elo", "bg" };
                //string[] strRansomTest = { "elo", "lxkvg", "bg", "mwz", "clm", "w", "ddd" };

                string[] strMagTest = { "o", "l", "x", "imjaw", "bee", "khmla", "v", "o", "v", "o", "imjaw", "l", "khmla", "imjaw", "x" };
                string[] strRansomTest = { "imjaw", "l", "khmla", "x", "imjaw", "o", "l", "l", "o", "khmla", "v", "bee", "o", "o", "imjaw", "imjaw", "o" };

                bool bStatus = IsValidMagInput(iMagWordCount, iRansomWordCount, strMagTest, strRansomTest);
                DisplayMessage(bStatus ? "Magazine Words are Valid" : "Magazine Words are NOT Valid");
            } while (base.RunAgain());
        }

        private bool IsValidMagInput(int iMagWordCount, int iRandsomWordCount, string[] strMag, string[] strRansom)
        {
            bool bStatus = true;

            if (iMagWordCount >= iRandsomWordCount)
            {
                Dictionary<string, int> dictMagWords = new Dictionary<string, int>();

                InsertIntoDictionary(dictMagWords, strMag);

                foreach (string str in strRansom)
                {
                    if (dictMagWords.ContainsKey(str))
                    {
                        dictMagWords[str]--;

                        if (dictMagWords[str] < 0)
                        {
                            bStatus = false;
                            break;
                        }
                    }
                    else
                    {
                        bStatus = false;
                        break;
                    }
                }
            }
            else
            {
                bStatus = false;
            }

            return bStatus;
        }

        private void InsertIntoDictionary(Dictionary<string, int> dict, string[] strArray)
        {

            foreach (string str in strArray)
            {
                if (!string.IsNullOrWhiteSpace(str))
                {
                    if (dict.ContainsKey(str))
                    {
                        dict[str]++;
                    }
                    else
                    {
                        dict.Add(str, 1);
                    }
                }
            }
        }
    }
}
