using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bag;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.bag = new List<Product>();
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                this.name = value;
            }
        }

        public decimal Money
        {
            get { return this.money; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                this.money = value;
            }
        }

        public List<Product> Bag => this.bag;

        public void BuyProduct(Product product)
        {
            if (product.Price > this.money)
            {
                throw new InvalidOperationException($"{this.name} can't afford {product.Name}");
            }

            this.money -= product.Price;
            this.bag.Add(product);
        }
        
    }

    public class Product
    {
        private string name;
        private decimal price;

        public Product(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                this.name = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                this.price = value;
            }
        }

        public override string ToString()
        {
            return this.name;
        }
    }

    class ShoppingSpree
    {
        static void Main()
        {
            Dictionary<string, Person> persons = new Dictionary<string, Person>();
            Dictionary<string, Product> products = new Dictionary<string, Product>();

            string[] personsInfo = Console.ReadLine().Split(new[] { '=', ';' }, StringSplitOptions.RemoveEmptyEntries);
            try
            {
                for (int i = 0; i < personsInfo.Length - 1; i += 2)
                {
                    string name = personsInfo[i];
                    decimal money = decimal.Parse(personsInfo[i + 1]);
                    try
                    {
                        Person p = new Person(name, money);
                        persons.Add(name, p);
                    }
                    catch (ArgumentOutOfRangeException orex)
                    {
                        Console.WriteLine(orex.ParamName);
                        return;
                    }
                }


                string[] productsInfo = Console.ReadLine().Split(new[] { '=', ';' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < productsInfo.Length - 1; i += 2)
                {
                    string name = productsInfo[i];
                    decimal cost = decimal.Parse(productsInfo[i + 1]);
                    try
                    {
                        Product product = new Product(name, cost);
                        products.Add(name, product);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return;
                    }
                }

                string cmd = Console.ReadLine();

                while (cmd != "END")
                {
                    string[] token = cmd.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    string personName = token[0];
                    string productName = token[1];
                    try
                    {
                        Product p = products[productName];
                        Person person = persons[personName];
                        person.BuyProduct(p);
                        Console.WriteLine($"{personName} bought {productName}");
                    }
                    catch (InvalidOperationException ioe)
                    {
                        Console.WriteLine(ioe.Message);
                    }
                    cmd = Console.ReadLine();
                }

                foreach (var person in persons.Keys)
                {
                    string productsAsString = persons[person].Bag.Count == 0
                                          ? "Nothing bought"
                                          : string.Join(", ", persons[person].Bag);
                    Console.WriteLine($"{person} - {productsAsString}");
                }
            }
            catch (ArgumentException ae)
            {

                Console.WriteLine(ae.Message);
            }
        }




    }
}
