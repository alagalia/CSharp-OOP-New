using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.Drawing_tool
{
    class Program
    {
        static void Main(string[] args)
        {
            string shape = Console.ReadLine();
            switch (shape)
            {
                case "Rectangle":
                    int width = int.Parse(Console.ReadLine());
                    int height = int.Parse(Console.ReadLine());
                    Rectangle rec = new Rectangle(width, height);
                    rec.Draw();
                    break;
                case "Square":
                    Square sq = new Square(int.Parse(Console.ReadLine()));
                    sq.Draw();
                    break;
            }
        }
    }

    public abstract class Shape
    {
        public abstract void Draw();
    }

    public class Rectangle : Shape
    {
        public int width;

        public int height;

        public Rectangle(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public override void Draw()
        {
            Console.WriteLine("|" + new string('-', this.width) + "|");
            for (int i = 0; i < this.height - 2; i++)
            {
                Console.WriteLine("|" + new string(' ', this.width) + "|");
            }

            Console.WriteLine("|" + new string('-', this.width) + "|");
        }

    }

    public class Square : Rectangle
    {
        public Square(int width)
            : base(width, width)
        {
        }
    }
}
