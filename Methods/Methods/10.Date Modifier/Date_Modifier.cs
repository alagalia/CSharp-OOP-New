using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Date_Modifier
{
    class Date_Modifier
    {
        static void Main(string[] args)
        {
            int[] sartStr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] endStr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            DateTime start = new DateTime(sartStr[0], sartStr[1], sartStr[2]);
            DateTime end = new DateTime(endStr[0], endStr[1], endStr[2]);
            Console.WriteLine(DateModifier.CalculatesTheDifference(start, end));
        }
    }

    public class DateModifier
    {
        public static double CalculatesTheDifference(DateTime start, DateTime end)
        {
            TimeSpan interval = (end - start);
            return Math.Abs(interval.TotalHours);
        }
    }
}
