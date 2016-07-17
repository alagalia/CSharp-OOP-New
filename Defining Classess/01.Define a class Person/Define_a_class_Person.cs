namespace _01.Define_a_class_Person
{
    using System;
    using System.Reflection;

    public class Define_a_class_Person
    {
        public static void Main()
        {
            Type personType = typeof(Person);
            FieldInfo[] fields = personType.GetFields(BindingFlags.Public | BindingFlags.Instance);
            Console.WriteLine(fields.Length);
        }

    }

    internal class Person
    {
        public string Name;

        public int Age;
    }
}
