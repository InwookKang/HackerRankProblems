using System;
using System.Collections.Generic;
namespace HackerRank
{
    public class Anagrams : AbsProblem, IProblem
    {
        public Anagrams() : base("Anagrams Problem")
        {

        }

        public void Begin()
        {
            UserInput userInput = new UserInput();
            do
            {
                string strFirstWord = "rat";
                string strSecondWord = "rrr";

                int iNumCharDeleted = getAnagramCharCount(strFirstWord, strSecondWord);
                DisplayMessage("Number of Characters Deleted: " + iNumCharDeleted);
            } while (base.RunAgain());
        }

        public int getAnagramCharCount(string str1, string str2)
        {
            int iTotalLetters = str1.Length + str2.Length;
            //Base Case
            if (str1 == str2)
            {
                return 0;
            }

            var dictStr1 = AddToDictionary(str1);
            var dictStr2 = AddToDictionary(str2);
            int iMatchCount = 0;

            foreach (char ch in dictStr1.Keys)
            {
                if (dictStr2.ContainsKey(ch))
                {
                    int iMatches = 0;
                    if (dictStr1[ch] == dictStr2[ch])
                    {
                        iMatches = 2 * dictStr1[ch];
                    }
                    else
                    {
                        iMatches = dictStr1[ch] > dictStr2[ch] ? dictStr2[ch] : dictStr1[ch];
                        iMatches *= 2;
                    }
                    iMatchCount += iMatches;
                }
            }
            return iTotalLetters - iMatchCount;
        }

        private Dictionary<char, int> AddToDictionary(string str)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            foreach (var ch in str)
            {
                if (dict.ContainsKey(ch))
                {
                    dict[ch]++;
                }
                else
                {
                    dict.Add(ch, 1);
                }
            }
            return dict;
        }
    }
}