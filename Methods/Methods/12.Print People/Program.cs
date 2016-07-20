using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.Print_People
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> ps = new List<Person>();
            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] personInfo = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                Person p = new Person(personInfo[0], int.Parse(personInfo[1]), personInfo[2]);
                ps.Add(p);
                input = Console.ReadLine();
            }

           ps.Sort();
            Console.WriteLine(string.Join("\n", ps));
        }
    }

    public class Person : IComparable<Person>
    {
        private int age;

        private string name;

        private string occupation;

        public Person(string name, int age, string occupation)
        {
            this.age = age;
            this.name = name;
            this.occupation = occupation;
        }

        public int Age => this.age;
        public string Name => this.name;
        public string Occupation => this.occupation;

        public int CompareTo(Person other)
        {
            return this.age.CompareTo(other.age);
        }

        public override string ToString()
        {
            string person = $"{this.name} - age: {this.age}, occupation: {this.occupation}";
            return person;
        }
    }
}
