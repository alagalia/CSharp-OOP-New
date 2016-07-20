using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Pizza_Time
{
    using System.Text.RegularExpressions;

    class Pizza_Time
    {
        static void Main(string[] args)
        {
            string[] line = Console.ReadLine().Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries);
            Pizza[] pizzasList = new Pizza[line.Length];
            string pattern = @"(\d+)(\w+)";
            Regex regex = new Regex(pattern);
            for (int i = 0; i < pizzasList.Length; i++)
            {
                Match match = regex.Match(line[i]);
                int group = int.Parse(match.Groups[1].Value);
                string name = match.Groups[2].Value;
                Pizza pizza = new Pizza(name, group);
                pizzasList[i] = pizza;
            }
            
            foreach (var kv in OrderInfo(pizzasList.ToArray()))
            {
                Console.WriteLine($"{kv.Key} - {string.Join((string)", ", kv.Value)}");
            }
        }

        public static SortedDictionary<int, List<string>> OrderInfo(Pizza[] pizzas)
        {
            SortedDictionary<int, List<string>> dict = new SortedDictionary<int, List<string>>();
            foreach (Pizza s in pizzas)
            {
                if (!dict.ContainsKey(s.group))
                {
                    dict[s.group] = new List<string>();
                }
                dict[s.group].Add(s.name);
            }

            return dict;
        }
    }

    public class Pizza
    {
        public string name;

        public int group;
        
        public Pizza(string name, int group)
        {
            this.name = name;
            this.group = group;
        }
    }
}
