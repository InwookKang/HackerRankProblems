using System;
using System.Collections.Generic;
using System.Text;
namespace HackerRank
{
    public class RotateArray : AbsProblem, IProblem
    {
        private UserInput userInput = new UserInput();
        /*
         * Problem From: 
         * https://www.hackerrank.com/challenges/ctci-array-left-rotation/problem
         * 
         */
        public RotateArray() : base("Rotate Array Problem.")
        {
        }

        /// <summary>
        /// Begin this instance.
        /// </summary>
        public void Begin()
        {
            do
            {
                DisplayMessage("Enter Number of Elements to Enter.");
                int iNumElements = userInput.intUserInput();
                DisplayMessage("Enter Number of Rotations");
                int iNumRotation = userInput.intUserInput();

                int[] iArryNums = userInput.intAryUserInput(iNumElements);

                BeginRotateArray(iNumElements, iNumRotation, iArryNums);

                DisplayMessage("New Array: " + ConvertIntArrayToString(iArryNums));
            } while (base.RunAgain());
        }

        public void BeginWithRandom()
        {
            do
            {
                DisplayMessage("Enter Number of Elements to Enter.");
                int iNumElements = userInput.intUserInput();
                DisplayMessage("Enter Number of Rotations");
                int iNumRotation = userInput.intUserInput();

                int[] iArryNums = getRandomNumbers(iNumElements);

                DisplayMessage("Random Number Array: " + ConvertIntArrayToString(iArryNums));

                //Rotate Array
                BeginRotateArray(iNumElements, iNumRotation, iArryNums);

                DisplayMessage(System.Environment.NewLine + "New Array: " + ConvertIntArrayToString(iArryNums));
            } while (base.RunAgain());
        }

        /// <summary>
        /// Gets int array filled with random numbers from 1 to 100.
        /// </summary>
        /// <param name="iNumCount">I number count.</param>
        private int[] getRandomNumbers(int iNumCount)
        {
            List<int> retList = new List<int>();
            for (int i = 0; i < iNumCount; i++)
            {
                retList.Add(RandomNumber.getRadomNumber(100));
            }

            return retList.ToArray();
        }

        /// <summary>
        /// Converts the int array to string.
        /// </summary>
        /// <returns>The int array to string.</returns>
        /// <param name="iArray">I array.</param>
        private string ConvertIntArrayToString(int[] iArray)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (int i in iArray)
            {
                stringBuilder.Append(i + " ");
            }
            return stringBuilder.ToString();
        }

        /// <summary>
        /// Begins the rotate array.
        /// </summary>
        /// <returns>The rotate array.</returns>
        /// <param name="iNumEle">I number ele.</param>
        /// <param name="iNumRotation">I number rotation.</param>
        /// <param name="iArryNums">I arry nums.</param>
        private int[] BeginRotateArray(int iNumEle, int iNumRotation, int[] iArryNums)
        {
            int iTemp, iOuter, iCalculation, iCurrentValue = 0;
            int iGCD = GCD(iNumEle, iNumRotation);

            //No Rotation need to be done as the 
            //Number of Rotations is the same
            //As the Length of Array
            if (iNumEle % iNumRotation == 0)
            {
                return iArryNums;
            }

            //Outer Loop
            for (iOuter = 0; iOuter < iGCD; iOuter++)
            {
                iCurrentValue = iOuter;
                iTemp = iArryNums[iOuter];

                while (true)
                {
                    //Get Value of Next Element to Point to
                    iCalculation = GetCalculation(iCurrentValue, iNumRotation, iNumEle);

                    if (iCalculation == iOuter)
                    {
                        break;
                    }

                    //Swap Array Elements
                    iArryNums[iCurrentValue] = iArryNums[iCalculation];
                    iCurrentValue = iCalculation;
                }
                iArryNums[iCurrentValue] = iTemp;
            }
            return iArryNums;
        }


        /// <summary>
        /// Gets the calculation.
        /// </summary>
        /// <returns>The calculation.</returns>
        /// <param name="iNum1">I num1.</param>
        /// <param name="iNum2">I num2.</param>
        /// <param name="iNum3">I num3.</param>
        private int GetCalculation(int iNum1, int iNum2, int iNum3)
        {
            int iRet = 0;

            iRet = (iNum1 + iNum2) % iNum3;

            return iRet;
        }

        /// <summary>
        /// GCD will determine Number of Sets 
        /// </summary>
        /// <returns>The gcd.</returns>
        /// <param name="a">The alpha component.</param>
        /// <param name="b">The blue component.</param>
        private int GCD(int a, int b)
        {
            if (b == 0)
            {
                return a;
            }
            return GCD(b, a % b);
        }
    }
}
