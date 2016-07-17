using System;
using System.Collections.Generic;
using System.Linq;
namespace _10.Family_Tree
{
    internal class Family_Tree
    {
        private static void Main()
        {
            string searchedPersonAsString = Console.ReadLine();
            List<string> allInput = new List<string>();
            string input = Console.ReadLine();
            while (input != "End")
            {
                allInput.Add(input);
                input = Console.ReadLine();
            }

            List<string> birthdays = allInput.Where(a => !a.Contains("-")).ToList();
            searchedPersonAsString = birthdays.FirstOrDefault(a => a.Contains(searchedPersonAsString));
            string[] searchedPersonInfo = searchedPersonAsString.Split();
            string sName = searchedPersonInfo[0] + " " + searchedPersonInfo[1];
            string sBorn = searchedPersonInfo[2];
            Person searched = new Person { name = sName, born = sBorn };

            List<string> connections = allInput.Where(a => a.Contains("-")).ToList();

            foreach (string s in connections)
            {
                if (s.IndexOf(sName) != -1 || s.IndexOf(sBorn) != -1)
                {
                    string[] inputInfo = s.Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                    string leftSide = inputInfo[0];
                    string rightSide = inputInfo[1];

                    Person child = new Person();
                    Person parent = new Person();
                    if (leftSide.Contains(sName) || leftSide.Contains(sBorn))
                    {
                        if (rightSide.IndexOf('/') != -1) //parent by date
                        {
                            child.born = rightSide.Trim();
                        }
                        else
                        {
                            child.name = rightSide.Trim();
                        }
                        searched.AddChild(child);
                    }

                    if (rightSide.Contains(sName) || rightSide.Contains(sBorn))
                    {
                        if (leftSide.IndexOf('/') != -1) //parent by date
                        {
                            parent.born = leftSide.Trim();
                        }
                        else
                        {
                            parent.name = leftSide.Trim();
                        }
                        searched.AddParent(parent);
                    }
                }
            }

            searched.children.ForEach(c =>
            {
                if (c.born == null)
                {
                    string birthdate = birthdays.FirstOrDefault(b => b.Contains(c.name));
                    c.born = birthdate.Split()[2];
                }
                else if (c.name == null)
                {
                    string[] name = birthdays.FirstOrDefault(b => b.Contains(c.born)).Split();
                    c.name = name[0] + " " + name[1];
                }
            });

            searched.parents.ForEach(s =>
            {
                if (s.born == null)
                {
                    string birthday = birthdays.FirstOrDefault(b => b.Contains(s.name)).Split()[2];
                    s.born = birthday;
                }
                else if (s.name == null)
                {
                    string[] name = birthdays.FirstOrDefault(b => b.Contains(s.born)).Split();
                    s.name = name[0] + " " + name[1];
                }
            });

            Console.WriteLine(searched.ToStringWithSibling());
        }

        public class Person
        {
            public List<Person> parents;

            public List<Person> children;

            public string name;

            public string born;

            public Person()
            {
                this.parents = new List<Person>();
                this.children = new List<Person>();
            }

            public Person(string name)
                : this()
            {
                this.name = name;
            }

            public void AddParent(Person parent)
            {
                this.parents.Add(parent);
            }

            public void AddChild(Person child)
            {
                this.children.Add(child);
            }

            public override string ToString()
            {
                return $"{this.name} {this.born}";
            }

            public string ToStringWithSibling()
            {
                string parents = this.parents.Count == 0 ? null : $"\n{string.Join("\n", this.parents)}";
                string children = this.children.Count == 0 ? null : $"\n{string.Join("\n", this.children)}";
                return $"{this}\nParents:{parents}\nChildren:{children}";
            }
        }
    }
}
