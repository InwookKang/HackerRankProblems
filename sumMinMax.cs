using System;
using System.Collections;
using System.Linq;

namespace HackerRank
{
    public class sumMinMax : AbsProblem, IProblem
    {
        public sumMinMax() : base("Sum of Min and Max")
        {
        }

        public void Begin()
        {
            Console.WriteLine("Enter 5 numbers to work with: ");

            int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));

            getSumMinMax(arr);
        }

        private void getSumMinMax(int[] arr)
        {
            int max = arr.Max();
            int min = arr.Min();
            int sum = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }

            Console.WriteLine($"Minimum Sum: {sum - max} Maximum Sum: {sum - min}");
        }

    }
}
