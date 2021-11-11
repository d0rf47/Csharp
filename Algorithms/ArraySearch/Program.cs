using System;
using Algorithms;
namespace ArraySearch
{
    class Program
    {

        static void Main(string[] args)
        {
            int size = 1234567891;
            int value = size + 9;
            int[] arr = new int[size];
            timer t = new timer();
            
            for(int i = 0; i < size; i++)
            {
                arr[i] = i + 10;                
            }
            t.stopwatch.Start();
            Console.WriteLine(Searches.IterativeBinarySearch(arr,value));
            t.stopwatch.Stop();
            Console.WriteLine($"Iterative Binary Search O(logn). array of length {size} to find value  {value}, elapsed time = {t.stopwatch.ElapsedMilliseconds } m.seconds");
            t.stopwatch.Reset();
            t.stopwatch.Start();
            Console.WriteLine(Searches.IterativeBinarySearch2(arr,value));
            t.stopwatch.Stop();
            Console.WriteLine($"Linear Search O(n). array of length {size} to find value  {value}, elapsed time = {t.stopwatch.ElapsedMilliseconds} m.seconds");
            
        }
    }
}
