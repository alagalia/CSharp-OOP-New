using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Car
{
    class CarExam
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            Car car = new Car(int.Parse(input[0]), double.Parse(input[1]), double.Parse(input[2]));
            string line = Console.ReadLine();

            while (line != "END")
            {
                switch (line.Split()[0].Trim())
                {
                    case "Travel":
                        int distance = int.Parse(line.Split()[1]);
                        car.Travel(distance);
                        break;
                    case "Refuel":
                        double fuel = double.Parse(line.Split()[1]);
                        car.Refuel(fuel);
                        break;
                    case "Distance":
                        Console.WriteLine($"Total distance: {car.Distance():F1} kilometers");
                        break;
                    case "Time":
                        Console.WriteLine($"Total time: {car.Time()[0]} hours and {car.Time()[1]} minutes");
                        break;
                    case "Fuel":
                        Console.WriteLine($"Fuel left: {car.fuel:F1} liters");
                        break;
                }

                line = Console.ReadLine();
            }
        }
    }

    public class Car
    {
        //speed, fuel and fuel economy
        public int speed;

        public double fuel;

        public double fuelEconomy;

        private double distance;

        public Car(int speed, double fuel, double fuelEconomy)
        {
            this.speed = speed;
            this.fuel = fuel;
            this.fuelEconomy = fuelEconomy;
            this.distance = 0;
        }

        public void Travel(int distance)
        {
            if (distance * this.fuelEconomy / 100 > this.fuel)
            {
                double dist = this.fuel / this.fuelEconomy * 100;
                this.distance += dist;
                this.fuel = 0;
            }
            else
            {
                this.distance += distance;
                this.fuel -= distance * (this.fuelEconomy / 100);
            }
        }

        public void Refuel(double liters)
        {
            this.fuel += liters;
        }

        public double Distance()
        {
            return this.distance;
        }

        public int[] Time()
        {
            int hour = (int)this.distance / this.speed;
            int minutes = (int)((this.distance % this.speed) / 10) * 60;
            return new[] { hour, minutes };
        }
    }
}
