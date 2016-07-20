using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.BeerCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            while (line != "End")
            {
                int[] input = line.Split().Select(int.Parse).ToArray();
                int bought = input[0];
                int drank = input[1];
                BeerCounter.BuyBeer(bought);
                BeerCounter.DrinkBeer(drank);
                line = Console.ReadLine();
            }
            Console.WriteLine(BeerCounter.beerInStock + " " + BeerCounter.beersDrankCount);
        }
    }

    public class BeerCounter
    {
        public static int beerInStock = 0;
        public static int beersDrankCount = 0;

        public static void BuyBeer(int bottlesCount)
        {
            beerInStock += bottlesCount;
        }

        public static void DrinkBeer(int bottlesCount)
        {
            beersDrankCount += bottlesCount;
            beerInStock -= bottlesCount;
        }
    }
}
