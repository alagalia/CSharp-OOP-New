using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Opinion_Poll
{
    class Opinion_Poll
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Person> persons = new List<Person>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string name = input[0];
                int age = int.Parse(input[1]);
                Person newPerson = new Person(age, name);
                persons.Add(newPerson);
            }
            var sorted = persons.Where(p => p.age > 30).OrderBy(p => p.name);

            foreach (Person person in sorted)
            {
                Console.WriteLine($"{person.name} - {person.age}");
            }
        }
        internal class Person
        {
            public string name;

            public int age;

            public Person()
            {
                this.age = 1;
                this.name = "No name";
            }

            public Person(int age)
                : this()
            {
                this.age = age;
            }

            public Person(int age, string name)
                : this(age)
            {
                this.name = name;
            }
        }

    }
}
