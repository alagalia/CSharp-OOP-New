using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.PizzaCalories
{
    public class Pizza
    {
        private string name;
        private int numberOfToppings;
        private List<Topping> toppings;
        private Dough dough;

        public Pizza(string name, int numberOfToppings, Dough dough)
        {
            this.Name = name;
            this.NumberOfToppings = numberOfToppings;
            this.Dough = dough;
            this.toppings = new List<Topping>();
        }

        public int NumberOfToppings
        {
            get { return this.numberOfToppings; }
            set
            {
                if (value < 0 || value > 10)
                {
                    throw new ArgumentException("Number of toppings should be in range [0..10].");
                }

                this.numberOfToppings = value;
            }
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 1 || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                this.name = value;
            }
        }

        public Dough Dough
        {
            get
            {
                return this.dough;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Dough cannot be null.");
                }

                this.dough = value;
            }
        }

        public void AddTopping(Topping topping)
        {
            this.toppings.Add(topping);
        }

        public double GetTotalCalories()
        {
            double result = 0.0;
            result += this.Dough.GetCalories();
            result += this.toppings.Sum(topping => topping.GetCalories());
            return result;
        }
    }

}
