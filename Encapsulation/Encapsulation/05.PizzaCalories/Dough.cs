namespace _05.PizzaCalories
{
    using System;
    using System.Linq;

    public class Dough
    {
        private string flourType;

        private string bakingTechnique;

        private double weight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public double Weight
        {
            get { return this.weight; }
            set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                this.weight = value;
            }
        }

        public string BakingTechnique
        {
            get { return this.bakingTechnique; }
            set
            {
                string[] bakingTechniques = { "crispy", "chewy", "homemade" };
                if (!bakingTechniques.Contains(value.ToLowerInvariant()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.bakingTechnique = value;
            }
        }

        public string FlourType
        {
            get { return this.flourType; }
            set
            {
                string[] types = { "white", "wholegrain" };
                if (!types.Contains(value.ToLowerInvariant()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                this.flourType = value;
            }
        }

        public double GetCalories()
        {
            double flourTypeCals = this.FlourTypeCals();
            double bakingTechniqueCals = this.BakingTechniqueCals();
            double cal = 2 * this.weight * flourTypeCals * bakingTechniqueCals;
            return cal;
        }

        private double BakingTechniqueCals()
        {
            switch (this.bakingTechnique.ToLower())
            {
                case "crispy": return 0.9;
                case "chewy": return 1.1;
                case "homemade": return 1.0;
                default: return 1.0;
            }
        }

        private double FlourTypeCals()
        {
            switch (this.flourType.ToLower())
            {
                case "white":
                    return 1.5;
                case "wholegrain":
                    return 1.0;
                default:
                    return 1.0;
            }
        }
    }

}