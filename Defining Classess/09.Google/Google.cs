using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Google
{
    using System.Text.RegularExpressions;

    public class Google
    {
        public static void Main()
        {
            string line = Console.ReadLine();
            List<Person> persons = new List<Person>();
            while (line != "End")
            {
                List<string> input = Regex.Split(line.Trim(), @"\s+").ToList();
                Person person = new Person((input[0]));
                string additionalInfo = string.Join(" ", input.GetRange(2, input.Count - 2));

                switch (input[1])
                {
                    case "company":
                        if (persons.Exists(p => p.name == input[0]))
                        {
                            persons.FirstOrDefault(p => p.name == input[0]).company = additionalInfo;
                        }
                        else
                        {
                            person = new Person(input[0]);
                            person.company = additionalInfo;
                            persons.Add(person);
                        }

                        break;
                    case "pokemon":
                        if (persons.Exists(p => p.name == input[0]))
                        {
                            persons.FirstOrDefault(p => p.name == input[0]).AddPokemon(additionalInfo);
                        }
                        else
                        {
                            person.AddPokemon(additionalInfo);
                            persons.Add(person);
                        }
                        break;
                    case "parents":
                        if (persons.Exists(p => p.name == input[0]))
                        {
                            persons.FirstOrDefault(p => p.name == input[0]).AddParent(additionalInfo);
                        }
                        else
                        {
                            person.AddParent(additionalInfo);
                            persons.Add(person);
                        }
                        break;
                    case "children":
                        if (persons.Exists(p => p.name == input[0]))
                        {
                            persons.FirstOrDefault(p => p.name == input[0]).AddChild(additionalInfo);
                        }
                        else
                        {
                            person.AddChild(additionalInfo);
                            persons.Add(person);
                        }
                        break;
                    case "car":
                        if (persons.Exists(p => p.name == input[0]))
                        {
                            persons.FirstOrDefault(p => p.name == input[0]).car = additionalInfo;
                        }
                        else
                        {
                            person.car = additionalInfo;
                            persons.Add(person);
                        }
                        break;
                }
                line = Console.ReadLine();
            }
            string filter = Console.ReadLine();
            Person filtered = persons.FirstOrDefault(p => p.name == filter);
            Console.WriteLine(filtered);
        }

    }

    public class Person
    {
        public string name;
        public string company;
        public string car;
        public List<string> pokemons;
        public List<string> parents;
        public List<string> children;

        public Person(string name)
        {
            this.name = name;
            this.pokemons = new List<string>();
            this.parents = new List<string>();
            this.children = new List<string>();
        }

        public void AddPokemon(string pokemon)
        {
            this.pokemons.Add(pokemon);
        }

        public void AddParent(string parent)
        {
            this.parents.Add(parent);
        }

        public void AddChild(string child)
        {
            this.children.Add(child);
        }

        public override string ToString()
        {
            string company = this.company == null ? null : "\n" + this.company.Split()[0] + " " + this.company.Split()[1] + $" {decimal.Parse(this.company.Split()[2]):F2}";
            string car = this.car == null ? null : "\n" + this.car;
            string pokemons = this.pokemons.Count == 0 ? null : "\n" + string.Join("\n", this.pokemons);
            string parents = this.parents.Count == 0 ? null : "\n" + string.Join("\n", this.parents);
            string children = this.children.Count == 0 ? null : "\n" + string.Join("\n", this.children);
            return $"{this.name}" +
                $"\nCompany:{company}" +
                $"\nCar:{car}" +
                $"\nPokemon:{pokemons}" +
                $"\nParents:{parents}" + 
                $"\nChildren:{children}";
        }
    }
}
