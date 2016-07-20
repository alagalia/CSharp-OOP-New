namespace _03.Last_Digit_Name
{
    using System;
    using System.Linq;

    public class Last_Digit_Name
    {
        public static void Main()
        {
            int num = int.Parse(Console.ReadLine()); 
            Console.WriteLine(Number.LastDig(num));
        }
    }

    public class Number
    {
        public static string LastDig(int n)
        {
            int pos = int.Parse(n.ToString().Last().ToString());
            return converter[pos];
        }

        private static string[] converter =
           {
                "zero", "one", "two", "three", "four", "five", "six", "seven", "eight",
                "nine",
            };
    }
}
