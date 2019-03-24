using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank
{
    public class CommonChar : AbsProblem, IProblem
    {
        UserInput userInput = new UserInput();

        public CommonChar() : base("Common Characters in String")
        {
        }

        public void Begin()
        {
            string str1 = userInput.strUserInput();
            string str2 = userInput.strUserInput();

            StringBuilder commonCharacters = new StringBuilder();

            //Dictionary that will hold counts of each characters 
            Dictionary<char, int> charCountMap = new Dictionary<char, int>();
            //str1 = str1.ToLower();
            //str2 = str2.ToLower();

            string normalizeStr1 = RemoveDup(str1);
            string normalizeStr2 = RemoveDup(str2);

            MapCharToCount(normalizeStr1, ref charCountMap);
            MapCharToCount(normalizeStr2, ref charCountMap);

            foreach (KeyValuePair<char, int> countMap in charCountMap)
            {
                if (countMap.Value >= 2)
                {
                    commonCharacters.Append(countMap.Key);
                }
            }

            DisplayMessage(commonCharacters.ToString());
        }

        private void MapCharToCount(string input, ref Dictionary<char, int> map)
        {
            foreach (char character in input)
            {
                if (!map.ContainsKey(character))
                {
                    map.Add(character, 1);
                }
                else
                {
                    map[character]++;
                }
            }

        }

        //Returns string without any duplicate characters
        private string RemoveDup(string input)
        {
            StringBuilder newString = new StringBuilder();
            Dictionary<char, int> map = new Dictionary<char, int>();

            foreach (char character in input)
            {
                if (!map.ContainsKey(character))
                {
                    map.Add(character, 1);
                }
                else
                {
                    map[character]++;
                }
            }

            foreach (KeyValuePair<char, int> countMap in map)
            {
                if (countMap.Value < 2)
                {
                    newString.Append(countMap.Key);
                }
            }

            return newString.ToString();
        }

    }
}
