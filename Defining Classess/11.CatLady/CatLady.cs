using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.CatLady
{
    class CatLady
    {
        static void Main()
        {
            string input = Console.ReadLine();
            List<Cat> allCats = new List<Cat>();
            while (input != "End")
            {
                string[] catInfo = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                switch (catInfo[0])
                {
                    case "StreetExtraordinaire":
                        Cat street = new StreetExtraordinaire("StreetExtraordinaire", catInfo[1], int.Parse(catInfo[2]));
                        allCats.Add(street);
                        break;
                    case "Siamese":
                        Cat siamese = new Siamese("Siamese", catInfo[1], int.Parse(catInfo[2]));
                        allCats.Add(siamese);
                        break;
                    case "Cymric":
                        Cat cymric = new Cymric("Cymric", catInfo[1], double.Parse(catInfo[2]));
                        allCats.Add(cymric);
                        break;
                }
                input = Console.ReadLine();
            }

            string nameOfCat = Console.ReadLine();
            Cat found = allCats.FirstOrDefault(c => c.name == nameOfCat);

            Console.WriteLine(found);
        }
    }

    public abstract class Cat
    {
        public string name;
        public string breed;

        protected Cat(string breed, string name)
        {
            this.breed = breed;
            this.name = name;
        }

        public override string ToString()
        {
            return $"{this.breed} {this.name}";
        }
    }

    public class Siamese : Cat
    {
        private int earSize;
        public Siamese(string breed, string name, int earSize)
            : base(breed, name)
        {
            this.earSize = earSize;
        }

        public override string ToString()
        {
            return base.ToString() + $" {this.earSize}";
        }
    }

    public class Cymric : Cat
    {
        private double furLength;
        public Cymric(string breed, string name, double furLength)
            : base(breed, name)
        {
            this.furLength = furLength;
        }

        public override string ToString()
        {
            return base.ToString() + $" {this.furLength:F2}";
        }
    }

    public class StreetExtraordinaire : Cat
    {
        private int decibelsOfMeows;
        public StreetExtraordinaire(string breed, string name, int decibelsOfMeows)
            : base(breed,name)
        {
            this.decibelsOfMeows = decibelsOfMeows;
        }

        public override string ToString()
        {
            return base.ToString() + $" {this.decibelsOfMeows}";
        }
    }
}
