﻿namespace _02.Creating_Constructors
{
    using System;
    using System.Reflection;

    public class Creating_Constructors
    {
        public static void Main(string[] args)
        {
            Type personType = typeof(Person);
            ConstructorInfo emptyCtor = personType.GetConstructor(new Type[] { });
            ConstructorInfo ageCtor = personType.GetConstructor(new[] { typeof(int) });
            ConstructorInfo nameAgeCtor = personType.GetConstructor(new[] { typeof(string), typeof(int) });
            bool swapped = false;
            if (nameAgeCtor == null)
            {
                nameAgeCtor = personType.GetConstructor(new[] { typeof(int), typeof(string) });
                swapped = true;
            }

            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            Person basePerson = (Person)emptyCtor.Invoke(new object[] { });
            Person personWithAge = (Person)ageCtor.Invoke(new object[] { age });
            Person personWithAgeAndName = swapped ? (Person)nameAgeCtor.Invoke(new object[] { age, name }) : (Person)nameAgeCtor.Invoke(new object[] { name, age });

            Console.WriteLine("{0} {1}", basePerson.name, basePerson.age);
            Console.WriteLine("{0} {1}", personWithAge.name, personWithAge.age);
            Console.WriteLine("{0} {1}", personWithAgeAndName.name, personWithAgeAndName.age);
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