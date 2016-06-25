using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.RawData
{
    using System.Text.RegularExpressions;

    public static class RawData
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < n; i++)
            {
                //“<Model> <EngineSpeed> <EnginePower> <CargoWeight> <CargoType> <Tire1Pressure> <Tire1Age> <Tire2Pressure> <Tire2Age> <Tire3Pressure> <Tire3Age> <Tire4Pressure> <Tire4Age>”
                string[] input = Regex.Split(Console.ReadLine(), @"\s+");
                string model = input[0];
                Engine engine = new Engine(int.Parse(input[1]), int.Parse(input[2]));
                Cargo cargo = new Cargo(int.Parse(input[3]), input[4]);

                Tire tire1 = new Tire(double.Parse(input[5]), int.Parse(input[6]));
                Tire tire2 = new Tire(double.Parse(input[7]), int.Parse(input[8]));
                Tire tire3 = new Tire(double.Parse(input[9]), int.Parse(input[10]));
                Tire tire4 = new Tire(double.Parse(input[11]), int.Parse(input[12]));

                Car newCar = new Car(model, engine, cargo);
                newCar.AddTire(tire1);
                newCar.AddTire(tire2);
                newCar.AddTire(tire3);
                newCar.AddTire(tire4);

                cars.Add(newCar);
            }

            string filter = Console.ReadLine();
            List<Car> filtered;
            if (filter == "fragile")
            {
                filtered =
                    cars.Where(c => c.cargo.cargoType == filter && c.tires.FirstOrDefault(t => t.pressure < 1) != null).ToList();
            }
            else
            {
                filtered = cars.Where(c => c.cargo.cargoType == "flamable" && c.engine.enginePower > 250).ToList();
            }

            filtered.ForEach(Console.WriteLine);
        }
    }

    public class Car
    {
        public string model;

        public Engine engine;

        public Cargo cargo;

        public List<Tire> tires;

        public Car(string model, Engine engine, Cargo cargo)
        {
            this.model = model;
            this.engine = engine;
            this.cargo = cargo;
            this.tires = new List<Tire>();
        }

        public void AddTire(Tire tire)
        {
            this.tires.Add(tire);
        }

        public override string ToString()
        {
            return $"{this.model}";
        }
    }
    public class Tire
    {
        public double pressure;

        public int age;

        public Tire(double pressure, int age)
        {
            this.pressure = pressure;
            this.age = age;
        }
    }

    public class Cargo
    {
        //<CargoWeight> <CargoType>
        public int cargoWeight;

        public string cargoType;

        public Cargo(int cargoWeight, string cargoType)
        {
            this.cargoWeight = cargoWeight;
            this.cargoType = cargoType;
        }

    }

    public class Engine
    {
        public int engineSpeed;

        public int enginePower;

        public Engine(int engineSpeed, int enginePower)
        {
            this.engineSpeed = engineSpeed;
            this.enginePower = enginePower;
        }

    }
}
