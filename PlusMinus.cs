using System;
using System.IO;

namespace HackerRank
{
    public class PlusMinus : AbsProblem, IProblem
    {
        public PlusMinus() : base("Plus Minus Problem")
        {
        }

        /*
         * With Given Array and total element count,
         * get the ratio of positive, negative and zero 
         * within the array. 
         * 
         */
        public void Begin()
        {
            Console.WriteLine("Plus Minus Problem");
            Console.WriteLine("Enter Total Number Count");
            int n = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Numbers:");
            int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));

            getNumberRatio(arr);
        }

        static void getNumberRatio(int[] arr)
        {
            double positiveCount = 0;
            double negativeCount = 0;
            double zeroCount = 0;

            foreach (int num in arr)
            {
                if (num < 0)
                {
                    negativeCount++;
                }
                if (num > 0)
                {
                    positiveCount++;
                }
                if (num == 0)
                {
                    zeroCount++;
                }
            }

            double posRatio = positiveCount / (double)arr.Length;
            double negRatio = negativeCount / (double)arr.Length;
            double zeroRatio = zeroCount / (double)arr.Length;

            Console.WriteLine($"{posRatio.ToString("N6")}");
            Console.WriteLine($"{negRatio.ToString("N6")}");
            Console.WriteLine($"{zeroRatio.ToString("N6")}");
        }
    }
}
