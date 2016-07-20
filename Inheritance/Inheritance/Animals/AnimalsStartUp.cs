using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    public class AnimalsStartUp
    {
        static void Main()
        {

            var animal = Console.ReadLine();

            while (!animal.Equals("Beast!"))
            {
                try
                {
                    var animalInfo = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    var animalName = animalInfo[0];
                    var animalAge = int.Parse(animalInfo[1]);
                    var animalGender = animalInfo[2];
                   
                    switch (animal)
                    {
                        case "Dog":
                            var dog = new Dog(animalName, animalAge, animalGender);
                            Console.Write(dog);
                            dog.ProduceSound();
                            break;
                        case "Frog":
                            var frog = new Frog(animalName, animalAge, animalGender);
                            Console.Write(frog);
                            frog.ProduceSound();
                            break;
                        case "Cat":
                            var cat = new Cat(animalName, animalAge, animalGender);
                            Console.Write(cat);
                            cat.ProduceSound();
                            break;
                        case "Kitten":
                            var kitten = new Kitten(animalName, animalAge, "Female");
                            Console.Write(kitten);
                            kitten.ProduceSound();
                            break;
                        case "Tomcat":
                            var tomcat = new Tomcat(animalName, animalAge, "Male");
                            Console.Write(tomcat);
                            tomcat.ProduceSound();
                            break;
                        case "Animal":
                            Console.WriteLine("Not implemented!");
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input!");
                }

                animal = Console.ReadLine();
            }
        }
    }

    public abstract class Animal
    {
        private string name;

        private int age;

        private string gander;


        public Animal(string name, int age, string gander)
        {
            this.Name = name;
            this.Age = age;
            this.Gander = gander;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }

                this.name = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException();
                }

                this.age = value;
            }
        }

        public virtual string Gander
        {
            get
            {
                return this.gander;
            }
            set
            {
                if (!value.Equals("Male") && !value.Equals("Female"))
                {
                    throw new InvalidOperationException();
                }

                this.gander = value;
            }
        }

        public abstract void ProduceSound();
    }

    public class Cat : Animal
    {
        public Cat(string name, int age, string gander)
            : base(name, age, gander)
        {
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine("Cat");
            result.AppendLine($"{this.Name} {this.Age} {this.Gander}");
            return result.ToString();
        }

        public override void ProduceSound()
        {
            Console.WriteLine("MiauMiau");
        }
    }

    public class Kitten : Cat
    {
        public Kitten(string name, int age, string gander)
            : base(name, age, gander)
        {
        }

        public override string Gander
        {
            get { return base.Gander; }
            set
            {
                if (value != "Female")
                {
                    throw new InvalidOperationException();
                }

                base.Gander = value;
            }
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Miau");
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine("Kitten");
            result.AppendLine($"{this.Name} {this.Age} {this.Gander}");

            return result.ToString();
        }

    }

    public class Tomcat : Cat
    {
        public Tomcat(string name, int age, string gander)
            : base(name, age, gander)
        {
        }

        public override string Gander
        {
            get { return base.Gander; }
            set
            {
                if (value != "Male")
                {
                    throw new InvalidOperationException();
                }

                base.Gander = value;
            }
        }
        public override void ProduceSound()
        {
            Console.WriteLine("Give me one million b***h");
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine("Tomcat");
            result.AppendLine($"{this.Name} {this.Age} {this.Gander}");

            return result.ToString();
        }
    }

    public class Dog : Animal
    {
        public Dog(string name, int age, string gander)
            : base(name, age, gander)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("BauBau");
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine("Dog");
            result.AppendLine($"{this.Name} {this.Age} {this.Gander}");

            return result.ToString();
        }
    }

    public class Frog : Animal
    {
        public Frog(string name, int age, string gander)
            : base(name, age, gander)
        {
        }
        public override void ProduceSound()
        {
            Console.WriteLine("Frogggg");
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine("Frog");
            result.AppendLine($"{this.Name} {this.Age} {this.Gander}");

            return result.ToString();
        }
    }
}
