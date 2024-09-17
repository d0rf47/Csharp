using System;
using System.Numerics;

namespace PiCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Compute the value of pi using the Bailey-Borwein-Plouffe formula
            BigInteger pi = 0;
            for (int i = 0; i < 10; i++)
            {
                pi += (BigInteger)Math.Pow(16, -i) *
                        (4 / (8 * i + 1) - 2 / (8 * i + 4) -
                         1 / (8 * i + 5) - 1 / (8 * i + 6));
            }

            // Extract the last 10 digits of pi
            string piString = pi.ToString().Substring(pi.ToString().Length - 10);

            Console.WriteLine($"The last 10 digits of pi are: {piString}");
        }
    }
}