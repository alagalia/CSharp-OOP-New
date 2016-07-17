namespace _07Car_Salesman
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class CarSalesman
    {
       public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Regex.Split(Console.ReadLine().Trim(), @"\s+");
                Engine engine = new Engine(input[0], int.Parse(input[1]));
                if (input.Count() > 3)
                {
                    engine.displacement = int.Parse(input[2]);
                    engine.efficiency = input[3];
                }
                else if(input.Count() == 3)
                {
                    int value;
                    if (int.TryParse(input[2], out value))
                    {
                        engine.displacement = value;
                    }
                    else
                    {
                        engine.efficiency = input[2];
                    }
                }
                engines.Add(engine);
            }

            int m = int.Parse(Console.ReadLine());
            for (int i = 0; i < m; i++)
            {
                string[] input = Regex.Split(Console.ReadLine().Trim(), @"\s+");
                string model = input[0];
                string engineModel = input[1];
                Engine engine = engines.FirstOrDefault(e => e.model == engineModel);
                Car car = new Car(model, engine);
                if (input.Count() == 4)
                {
                    car.weight = int.Parse(input[2]);
                    car.color = input[3];
                }
                else if (input.Count() == 3)
                {
                    int value;
                    if (int.TryParse(input[2], out value))
                    {
                        car.weight = value;
                    }
                    else
                    {
                        car.color = input[2];
                    }
                }
                cars.Add(car);
            }
            cars.ForEach(Console.WriteLine);
        }
    }

    public class Car
    {
        public string model;

        public Engine engine;

        public int weight;

        public string color;

        public Car(string model, Engine engine)
        {
            this.model = model;
            this.engine = engine;
            this.weight = -1;
            this.color = "n/a";
        }

        public Car(string model, Engine engine, int weight, string color)
            : this(model, engine)
        {
            this.weight = weight;
            this.color = color;
        }

        public override string ToString()
        {
            string weight = this.weight == -1 ? "n/a" : this.weight.ToString();
            return $"{this.model}:\n{this.engine}\n  Weight: {weight}\n  Color: {this.color}";
        }
    }

    public class Engine
    {
        public string model;

        public int power;

        public int displacement;

        public string efficiency;

        public Engine(string model, int power)
        {
            this.model = model;
            this.power = power;
            this.displacement = -1;
            this.efficiency = "n/a";
        }

        public Engine(string model, int power, int displacement, string efficiency)
            : this(model, power)
        {
            this.displacement = displacement;
            this.efficiency = efficiency;
        }

        public override string ToString()
        {
            string displacement = this.displacement == -1 ? "n/a" : this.displacement.ToString();
            return $"  {this.model}:\n    Power: {this.power}\n    Displacement: {displacement}\n    Efficiency: {this.efficiency}";
        }
    }


}
