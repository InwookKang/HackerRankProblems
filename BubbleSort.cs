using System;
using System.Text;

namespace HackerRank
{
    public class BubbleSort : AbsProblem, IProblem
    {
        public BubbleSort() : base("Bubble Sort")
        {
        }

        public void Begin()
        {
            do
            {
                int iUserInput = GetUserIntInput();
                int[] iUserArrayInput = GetUserAryIntInput(iUserInput);

                int iNumSwaps = PerformBubbleSort(iUserArrayInput);
                DisplayAnswer(iNumSwaps, iUserArrayInput[0], iUserArrayInput[iUserInput - 1]);
                DisplaySortedArray(iUserArrayInput);
            } while (base.RunAgain());
        }

        public void DisplayAnswer(int iNumSwaps, int iFirst, int iLast)
        {
            DisplayMessage("Array is sorted in " + iNumSwaps + " swaps.");
            DisplayMessage("First Element: " + iFirst);
            DisplayMessage("Last Element: " + iLast);
        }

        public void DisplaySortedArray(int[] iSortedArray)
        {
            StringBuilder strBld = new StringBuilder();

            foreach (int i in iSortedArray)
            {
                strBld.Append(i + " ");
            }

            DisplayMessage("Sorted Array: " + strBld.ToString());
        }

        public int PerformBubbleSort(int[] iData)
        {
            int iNumSwaps = 0;

            for (int i = 0; i < iData.Length; i++)
            {
                for (int j = 0; j < iData.Length - 1; j++)
                {
                    if (iData[j] > iData[j + 1])
                    {
                        SwapNumbers(iData, j, j + 1);
                        iNumSwaps++;
                    }
                }
            }

            return iNumSwaps;
        }

        public void SwapNumbers(int[] iData, int iFirst, int iSecond)
        {
            int iTemp = iData[iFirst];
            iData[iFirst] = iData[iSecond];
            iData[iSecond] = iTemp;
        }
    }
}
