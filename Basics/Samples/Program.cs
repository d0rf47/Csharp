using System;
namespace mfalconi.Basics
{
    class Program
    {
        private static void MutateAndDisplay(MutablePoint p)
        {
            p.X = 100;
            Console.WriteLine($"Point mutated in a method: {p}");
        }
        ///Value Type Example
        static void Main(string[] args)
        {
            MutablePoint point1 = new(1, 2);
            var point2 = point1;
            point2.Y = 200;
            Console.WriteLine($"{nameof(point1)} after {nameof(point2)} is modified: {point1}");
            Console.WriteLine($"{nameof(point2)}: {point2}");

            MutateAndDisplay(point2);
            Console.WriteLine($"{nameof(point2)} after passing to a method: {point2}");
        }
    }
}
