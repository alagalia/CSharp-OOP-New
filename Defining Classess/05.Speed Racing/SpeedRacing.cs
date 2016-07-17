namespace _05.Speed_Racing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public static class SpeedRacing
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Regex.Split(Console.ReadLine(), @"\s+");
                string model = input[0];
                double fuelAmount = double.Parse(input[1]);
                double fuelCostFor1km = double.Parse(input[2]);
                Car newCar = new Car(model, fuelAmount, fuelCostFor1km);
                cars.Add(newCar);
            }

            string inputCommands = Console.ReadLine();

            while (inputCommands != "End")
            {
                string[] input = Regex.Split(inputCommands, @"\s+");
                string model = input[1];
                int amountOfKm = int.Parse(input[2]);
                cars.FirstOrDefault(c => c.model == model).Drive(amountOfKm);
                inputCommands = Console.ReadLine();
            }

            cars.ForEach(Console.WriteLine);
        }
    }

    public class Car
    {
        //Model, fuel amount, fuel cost for 1 kilometer and distance traveled
        public string model;

        private double fuelAmount;

        private double fuelCostFor1km;

        private int distanceTraveled;

        public Car(string model, double fuelAmount, double fuelCostFor1Km)
        {
            this.model = model;
            this.fuelAmount = fuelAmount;
            this.fuelCostFor1km = fuelCostFor1Km;
            this.distanceTraveled = 0;
        }
        
        public void Drive(int amountOfKm)
        {
            if (this.fuelCostFor1km * amountOfKm > this.fuelAmount)
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
            else
            {
                this.distanceTraveled += amountOfKm;
                this.fuelAmount -= this.fuelCostFor1km * amountOfKm;
            }
        }

        public override string ToString()
        {
            return $"{this.model} {this.fuelAmount:F2} {this.distanceTraveled}";
        }
    }
}
