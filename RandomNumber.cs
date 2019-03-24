using System;

namespace HackerRank
{
    public class RandomNumber
    {
        public RandomNumber()
        {

        }

        public static int getRadomNumber(int iRange)
        {
            Random random = new Random();

            return random.Next(1, iRange);
        }
    }
}
