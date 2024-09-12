using System;

namespace Fizz
{
    class Program
    {
        public static void FizzBuzz(int n)
        {
            for(int i = 1; i < n + 1; i++){
                if(i % 3 == 0 && i%5 == 0)
                Console.WriteLine("FizzBuzz");
                else if (i % 3 == 0 )
                    Console.WriteLine("Fizz");
                else if (i%5 == 0)
                    Console.WriteLine("Buzz");
                else
                    Console.WriteLine(i);
            }
        }

        static void Main(string[] args)
        {
            Program.FizzBuzz(10);
        }
    }
}