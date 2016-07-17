using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ClassBox
{
    using System.Reflection;

    public class ClassBox
    {
        static void Main(string[] args)
        {

            Type boxType = typeof(Box);
            FieldInfo[] fields = boxType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            Console.WriteLine(fields.Count());

            double length = double.Parse(Console.ReadLine());

            double width = double.Parse(Console.ReadLine());

            double height = double.Parse(Console.ReadLine());

            try
            {
                Box b = new Box(length, width, height);
                Console.WriteLine($"Surface Area - {b.GetSurfaceArea():F2}");
                Console.WriteLine($"Lateral Surface Area - {b.GetLateralSurface():F2}");
                Console.WriteLine($"Volume - {b.GetVolume():F2}");
            }
            catch (ArgumentException ae)
            {

                Console.WriteLine(ae.Message);
            }
           
        }
    }

    public class Box
    {
        private double length;

        private double width;

        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Height
        {
            get
            {
                return this.height;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(this.Height)} cannot be zero or negative.") ;
                }
                this.height = value;
            }
        }

        public double Width
        {
            get
            {
                return this.width;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(this.Width)} cannot be zero or negative.");
                }
                this.width = value;
            }
        }

        public double Length
        {
            get
            {
                return this.length;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(this.Length)} cannot be zero or negative.");
                }
                this.length = value;
            }
        }

        public double GetSurfaceArea()
        {
            //Surface Area = 2lw + 2lh + 2wh
            return 2 * this.Length * this.Width + 2 * this.Length * this.Height + 2 * this.Width * this.Height;
        }

        public double GetLateralSurface()
        {
            //Lateral Surface Area = 2lh + 2wh
            return (2 * this.Length * this.Height) + (2 * this.Width * this.Height);
        }

        public double GetVolume()
        {
            return this.Length * this.Width * this.Height;
        }
    }
    
}
