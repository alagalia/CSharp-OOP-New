namespace Animals
{
    using System;

    //public class Animal
    //{
    //    private string name;

    //    private string age;

    //    private string gander;


    //    public Animal(string name, string age, string gander)
    //    {
    //        this.Name = name;
    //        this.Age = age;
    //        this.Gander = gander;
    //    }

    //    public string Name
    //    {
    //        get
    //        {
    //            return this.name;
    //        }
    //        set
    //        {
    //            if (string.IsNullOrWhiteSpace(value))
    //            {
    //                throw new ArgumentException("Invalid input!");
    //            }

    //            this.name = value;
    //        }
    //    }

    //    public string Age
    //    {
    //        get
    //        {
    //            return this.age;
    //        }
    //        set
    //        {
    //            if (string.IsNullOrWhiteSpace(value) || int.Parse(value) < 1)
    //            {
    //                throw new ArgumentException("Invalid input!");
    //            }

    //            this.age = value;
    //        }
    //    }

    //    public virtual string Gander
    //    {
    //        get
    //        {
    //            return this.gander;
    //        }
    //        set
    //        {
    //            bool valid = !(value == "Male" || value == "Female");
    //            if (string.IsNullOrWhiteSpace(value) || valid)
    //            {
    //                throw new ArgumentException("Invalid input!");
    //            }

    //            this.gander = value;
    //        }
    //    }

    //    public virtual string ProduceSound()
    //    {
    //        return "Not implemented!";
    //    }  
    //}
}