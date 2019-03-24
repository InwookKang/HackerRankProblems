using System;
using System.Collections.Generic;

namespace HackerRank
{
    public class ApplesAndOranges : AbsProblem, IProblem
    {
        public ApplesAndOranges() : base("Apples and Oranges Problem")
        {
        }

        public void Begin()
        {
            Console.WriteLine("Enter House Locations: ");
            string[] st = Console.ReadLine().Split(' ');

            int s = Convert.ToInt32(st[0]);

            int t = Convert.ToInt32(st[1]);

            Console.WriteLine("Enter Tree Locations: ");
            string[] ab = Console.ReadLine().Split(' ');

            int a = Convert.ToInt32(ab[0]);

            int b = Convert.ToInt32(ab[1]);

            Console.WriteLine("Enter Amount of Apples and Oranges: ");
            string[] mn = Console.ReadLine().Split(' ');

            int m = Convert.ToInt32(mn[0]);

            int n = Convert.ToInt32(mn[1]);

            Console.WriteLine("Enter Apple Locations: ");
            int[] apples = Array.ConvertAll(Console.ReadLine().Split(' '), applesTemp => Convert.ToInt32(applesTemp));

            Console.WriteLine("Enter Orange Locations: ");
            int[] oranges = Array.ConvertAll(Console.ReadLine().Split(' '), orangesTemp => Convert.ToInt32(orangesTemp));


            countApplesAndOranges(s, t, a, b, apples, oranges);
        }

        private void countApplesAndOranges(int houseLocationA, int houseLocationB, int sourceA, int sourceB, int[] appleDistance, int[] orangeDistance)
        {
            List<int> appleCollections = new List<int>();
            List<int> orangeCollections = new List<int>();

            appleCollections = getFinalLocations(appleDistance, sourceA, houseLocationA, houseLocationB);
            orangeCollections = getFinalLocations(orangeDistance, sourceB, houseLocationA, houseLocationB);

            Console.WriteLine($"{appleCollections.Count}");
            Console.WriteLine($"{orangeCollections.Count}");
        }

        private List<int> getFinalLocations(int[] distanceCollections, int source, int locA, int locB)
        {
            List<int> finalLocations = new List<int>();
            int finalLocation = 0;

            foreach (int dist in distanceCollections)
            {
                finalLocation = dist + source;
                if (isInRange(locA, locB, finalLocation))
                {
                    finalLocations.Add(finalLocation);
                }
            }

            return finalLocations;
        }

        private bool isInRange(int locA, int locB, int fruitLocation)
        {
            bool inRange = false;

            if (fruitLocation <= locB &&
                fruitLocation >= locA)
            {
                inRange = true;
            }
            return inRange;
        }

    }
}
