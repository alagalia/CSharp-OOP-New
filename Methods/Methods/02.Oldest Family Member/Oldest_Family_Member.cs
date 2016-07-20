using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Oldest_Family_Member
{
    using System.Reflection;

    class Oldest_Family_Member
    {
        static void Main(string[] args)
        {
            MethodInfo oldestMemberMethod = typeof(Family).GetMethod("GetOldestMember");
            MethodInfo addMemberMethod = typeof(Family).GetMethod("AddMember");
            if (oldestMemberMethod == null || addMemberMethod == null)
            {
                throw new Exception();
            }

            int n = int.Parse(Console.ReadLine());
            Family f = new Family();
            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine().Split();
                Person p = new Person(line[0], int.Parse(line[1]));
                
                f.AddMember(p);
            }
            Console.WriteLine(f.GetOldestMember());
        }
    }

    public class Person
    {
        public string name;
        public int age;

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public override string ToString()
        {
            return $"{this.name} {this.age}";
        }
    }

    public class Family
    {
        public List<Person> people;

        public Family()
        {
            this.people = new List<Person>();
        }

        public void AddMember(Person p)
        {
            this.people.Add(p);
        }
        public Person GetOldestMember()
        {
            int maxAge = this.people.Max(x => x.age);
            Person oldes = this.people.FirstOrDefault(p => p.age == maxAge);
            return oldes ;
        }
    }
}
