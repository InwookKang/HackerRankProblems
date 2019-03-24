using System;
using System.Linq;

namespace HackerRank
{
    public class BirthdayCakeCandles : AbsProblem, IProblem
    {
        public BirthdayCakeCandles() : base("Birthday Cake Candles Problem")
        {
        }

        /// <summary>
        /// Begin this instance.
        /// </summary>
        public void Begin()
        {
            int arCount = Convert.ToInt32(Console.ReadLine());

            int[] ar = Array.ConvertAll(Console.ReadLine().Split(' '), arTemp => Convert.ToInt32(arTemp));

            int result = MaxCandleBlowOut(ar);

            Console.WriteLine($"{result}");

        }

        private int MaxCandleBlowOut(int[] ar)
        {
            int answer = 0;
            int tallest = ar.Max();

            foreach (int num in ar)
            {
                if (tallest == num)
                {
                    answer++;
                }
            }

            return answer;
        }
    }
}
