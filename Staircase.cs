using System;
using System.Collections;
using System.Text;

namespace HackerRank
{
    public class Staircase : AbsProblem, IProblem
    {
        public Staircase() : base("Staircase Problem")
        {
        }

        public void Begin()
        {
            Console.WriteLine("Enter Number if Stair Level:");
            int n = Convert.ToInt32(Console.ReadLine());

            createHashStaircase(n);
        }

        static void createHashStaircase(int count)
        {
            StringBuilder build = new StringBuilder();

            for (int lineCount = 1; lineCount <= count; lineCount++)
            {
                for (int spaceCount = (count - lineCount); spaceCount < count && spaceCount != 0; spaceCount--)
                {
                    build.Append(" ");
                }
                for (int hashCount = 1; hashCount <= lineCount; hashCount++)
                {
                    build.Append("#");
                }
                if (lineCount != count)
                {
                    build.Append("\n");
                }
            }

            Console.WriteLine(build.ToString());
        }
    }
}
