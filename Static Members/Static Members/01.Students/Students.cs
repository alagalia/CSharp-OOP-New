using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Students
{
    class Students
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            while (line != "End")
            {
                string[] arg = line.Split();
                switch (arg[1])
                {
                    case "Celsius":
                        float asFah = Converter.ConvertToFah(int.Parse(arg[0]));
                        Console.WriteLine($"{asFah:F2} Fahrenheit");
                        break;
                    case "Fahrenheit":
                        float asCel = Converter.ConvertToCel(int.Parse(arg[0]));
                        Console.WriteLine($"{asCel:F2} Celsius");
                        break;
                }
                line = Console.ReadLine();
            }

        }
    }
    public class Converter
    {
        public static float ConvertToFah(int cel)
        {
            float result = cel * (float)9 / 5 +32;
            return result;
        }

        public static float ConvertToCel(int far)
        {
            float result = ((float)far - 32) * ((float)5 / 9);
            return result;
        }
    }
}
