using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_18_12_23_Collection
{
    public class Point2D
    {
        public double X {get; set; }
        public double Y {get; set; }
        public double Z { get; set; }

        public Point2D(double x, double y) {
            this.X = x; this.Y = y; this.Z = Math.Sqrt(X * X + Y * Y);
        }

        public Point2D()
        {
            Random rand = new Random();
            X = rand.NextDouble() + rand.Next(0, 4);
            Y = rand.NextDouble() + rand.Next(0, 4);
            Z = Math.Sqrt(X*X + Y*Y);
        }

        public void PrintPoint2D()
        {
            Console.WriteLine($"X: {X},\t  Y: {Y}\t  Len: {Z}");
        }

       
        
    }
}
