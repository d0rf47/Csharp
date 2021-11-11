using System;
using Algorithms;
namespace ArraySearch
{
    class Program
    {

        static void Main(string[] args)
        {
            long size = 1234567890;
            long value = size + 9;
            long[] arr = new long[size];
            timer t = new timer();
            
            for(long i = 0; i < size; i++)
            {
                arr[i] = i + 10;                
            }
            t.stopwatch.Start();
            Console.WriteLine(Searches.IterativeBinarySearch(arr,value));
            t.stopwatch.Stop();
            Console.WriteLine($"Iterative Binary Search O(logn). array of length {size} to find value  {value}, elapsed time = {t.stopwatch.ElapsedMilliseconds } m.seconds");
            t.stopwatch.Reset();
            t.stopwatch.Start();
            Console.WriteLine(Searches.LinearSearch(arr,value));
            t.stopwatch.Stop();
            Console.WriteLine($"Linear Search O(n). array of length {size} to find value  {value}, elapsed time = {t.stopwatch.ElapsedMilliseconds} m.seconds");
            
        }
    }
}
