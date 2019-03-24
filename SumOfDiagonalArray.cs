using System.IO;
using System;


namespace HackerRank
{
    public class SumOfDiagonalArray : AbsProblem, IProblem
    {
        public SumOfDiagonalArray() : base("Sum Of Diagonal Array")
        {

        }

        public void Begin()
        {
            Console.WriteLine("Diagonal Sum Problem");
            Console.WriteLine("Enter Number for Dimemsion:");

            int n = Convert.ToInt32(Console.ReadLine());

            int[][] arr = new int[n][];

            Console.WriteLine("Enter Numbers:");
            for (int i = 0; i < n; i++)
            {
                arr[i] = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
            }

            int result = diagonalDifference(arr, n);

            Console.WriteLine($"Answer: {result}");
        }

        // Complete the diagonalDifference function below.
        static int diagonalDifference(int[][] arr, int count)
        {
            int LRSum = GetLRSum(arr, count);
            int RLSum = GetRLSum(arr, count);

            return Math.Abs(LRSum - RLSum);
        }

        static int GetDiagonalSum(bool leftToRight, int[][] arr, int dimensions)
        {
            int rowCount = dimensions;
            int colCount = dimensions;
            int rowSelector = rowCount;
            int colSelector = 0;
            int sum = 0;

            if (leftToRight)
            {
                for (rowSelector -= rowCount; rowSelector < rowCount; rowSelector++)
                {
                    sum += arr[rowSelector][rowSelector];
                }
            }
            else
            {
                for (rowSelector = rowCount - 1; rowSelector < rowCount && rowSelector >= 0; rowSelector--)
                {
                    sum += arr[rowSelector][colSelector];
                    colSelector++;
                }
            }

            return sum;
        }

        static int GetLRSum(int[][] arr, int count)
        {
            return GetDiagonalSum(true, arr, count);
        }

        static int GetRLSum(int[][] arr, int count)
        {
            return GetDiagonalSum(false, arr, count);
        }
    }
}
