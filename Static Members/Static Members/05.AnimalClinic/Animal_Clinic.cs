using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.AnimalClinic
{
    class Animal_Clinic
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            List<Animal> healted = new List<Animal>();
            List<Animal> rehabilitate = new List<Animal>();
            while (line != "End")
            {
                string[] input = line.Split();
                string name = input[0];
                string breed = input[1];
                string manipulation = input[2];
                switch (manipulation)
                {
                    case "heal":
                        Animal a = new Animal(name, breed);
                        Console.WriteLine($"Patient {Animal.PatientId}: [{name} ({breed})] has been healed!");
                        AnimalClinic.Heal();
                        healted.Add(a);
                        break;
                    case "rehabilitate":
                        Animal animal = new Animal(name, breed);
                        Console.WriteLine($"Patient {Animal.PatientId}: [{name} ({breed})] has been rehabilitated!");
                        AnimalClinic.Rehabilite();
                        rehabilitate.Add(animal);
                        break;
                }
                line = Console.ReadLine();
            }
            Console.WriteLine($"Total healed animals: {AnimalClinic.HealedAnimalsCount}");
            Console.WriteLine($"Total rehabilitated animals: {AnimalClinic.RehabilitedAnimalsCount}");

            line = Console.ReadLine();
            if (line == "heal")
            {
                string res = string.Join("\n", healted.Select(h=>h.Name + " " + h.Breed));
                Console.WriteLine(res);
            } else if (line == "rehabilitate")
            {
                string res = string.Join("\n", rehabilitate.Select(h => h.Name + " " + h.Breed));
                Console.WriteLine(res);
            }

        }
    }

    public class Animal
    {
        private string name;

        private string breed;

        public static int PatientId;

        public Animal(string name, string breed)
        {
            this.name = name;
            this.breed = breed;
            PatientId++;
        }

        public string Name => this.name;

        public string Breed => this.breed;

   }   

    public class AnimalClinic
    {
        public static string PatientId;
        public static int HealedAnimalsCount = 0;
        public static int RehabilitedAnimalsCount = 0;

        public static void Heal()
        {
            HealedAnimalsCount++;   
        }   

        public static void Rehabilite()
        {
            RehabilitedAnimalsCount++;
        }
    }
}
