using System;
namespace HackerRank
{
    public class SaveThePrisioner : AbsProblem, IProblem
    {
        public SaveThePrisioner() : base("Save The Prisioner")
        {
        }

        public void Begin()
        {
            Console.WriteLine("Enter Number of Test Cases");
            int t = Convert.ToInt32(Console.ReadLine());


            for (int tItr = 0; tItr < t; tItr++)
            {
                Console.WriteLine("Enter Number of Prisioners, Candy and Starting Position");
                string[] nms = Console.ReadLine().Split(' ');

                int n = Convert.ToInt32(nms[0]);

                int m = Convert.ToInt32(nms[1]);

                int s = Convert.ToInt32(nms[2]);

                int result = solution(n, m, s);

                Console.WriteLine($"{result}");
            }
        }

        private int solution(int n, int m, int s)
        {
            return ((s - 1) + (m - 1)) % n + 1;
        }


        private int saveThePrisoner(int numPrisioner, int numCandy, int startPoint)
        {
            int finalPosition = 0;

            finalPosition = numCandy % numPrisioner;
            if (finalPosition == 0)
            {
                return numPrisioner;
            }
            finalPosition = finalPosition + (startPoint - 1);

            if (finalPosition > numPrisioner)
            {
                finalPosition = finalPosition % numPrisioner;
            }


            return finalPosition;
        }
    }
}
