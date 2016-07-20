using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace _12.Rectangle_Intersection
{
    public class Rectangle_Intersection
    {
        public static void Main()
        {
            {
                var inputParameters =
                    Console.ReadLine()
                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

                var rectangles = new Dictionary<string, Rectangle>();

                var numberOfRectangles = inputParameters[0];
                for (int i = 0; i < numberOfRectangles; i++)
                {
                    var rectangleParameters = Console.ReadLine()
                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    var id = rectangleParameters[0];
                    var width = float.Parse(rectangleParameters[1]);
                    var height = float.Parse(rectangleParameters[2]);
                    var x = float.Parse(rectangleParameters[3]);
                    var y = float.Parse(rectangleParameters[4]);

                    rectangles[id] = new Rectangle(width, height, x, y);
                }

                var numberOfChecks = inputParameters[1];
                for (int i = 0; i < numberOfChecks; i++)
                {
                    var checkParameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    var firstRectangle = rectangles[checkParameters[0]];
                    var secondRectangle = rectangles[checkParameters[1]];

                    Console.WriteLine($"{firstRectangle.Intersects(secondRectangle).ToString().ToLower()}");
                }
            }
        }

        public class Rectangle
        {
            public float X { get; private set; }

            public float Y { get; private set; }

            public float Width { get; private set; }

            public float Height { get; private set; }

            public float Top => this.Y;

            public float Bottom => this.Y + this.Height;

            public float Left => this.X;

            public float Right => this.X + this.Width;

            public Rectangle(float width, float height, float x, float y)
            {
                this.X = x;
                this.Y = y;
                this.Width = width;
                this.Height = height;
            }

            public bool Intersects(Rectangle other)
            {
                return (other.Left <= this.Right && this.Left <= other.Right)
                       && (other.Top <= this.Bottom && this.Top <= other.Bottom);
            }
        }
    }
}
