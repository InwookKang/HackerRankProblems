using System;
using System.Collections.Generic;

namespace HackerRank
{
    public class IceCreamParlor : AbsProblem, IProblem
    {
        public IceCreamParlor() : base("Ice Cream Parlor Calculation")
        {

        }

        public void Begin()
        {
            do
            {
                //Get How many trips 
                DisplayMessage("Enter Number of Trips");
                int numOfTrips = GetUserIntInput();

                for (int i = 0; i < numOfTrips; i++)
                {
                    //Get How much money to spend
                    DisplayMessage("Enter Money To Spend.");
                    int amountOfMoney = GetUserIntInput();

                    //Get Num of Ice Cream Choices
                    DisplayMessage("Enter Number of Ice Cream Choices.");
                    int iceCreamChoices = GetUserIntInput();

                    //Get price for each ice cream
                    DisplayMessage("Enter Prices of Ice Cream");
                    int[] pricesOfIceCream = GetUserAryIntInput(iceCreamChoices);

                    int[] iceCreamToGet = CalculateIceCreamToGet(amountOfMoney, pricesOfIceCream);

                    DisplayMessage("Get Ice Cream: " + iceCreamToGet[0] + ", " + iceCreamToGet[1]);

                }

            } while (base.RunAgain());
        }
        public int[] CalculateIceCreamToGet(int amountOfMoney, int[] priceForIceCream)
        {
            int temp = amountOfMoney;
            List<int> iceCreamIndex = new List<int>();
            int counter = 0;
            for (int i = 0; i < priceForIceCream.Length; i++)
            {
                if (priceForIceCream[i] < amountOfMoney)
                {
                    temp -= priceForIceCream[i];
                    iceCreamIndex.Add(i + 1);
                    counter++;
                    if (temp < 0)
                    {
                        counter--;
                        iceCreamIndex.Remove(i);
                        temp += priceForIceCream[i];
                    }

                    if (temp == 0 &&
                        iceCreamIndex.Count == 2)
                    {
                        break;
                    }
                }

            }

            return iceCreamIndex.ToArray();
        }
    }
}
