using System;


namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = {-8,2,3,-9,11,-20};
            int[] arr2 = {0,-2,-9,-39,39,10,7};

            int[] arr3 = Aggregation.MergeEvenValues(arr1,arr2);
            int[] arr4 = {1,2,3,4,5,6};
            Aggregation.RotateLeft(arr4,1);
            
            foreach (int i in  arr4)
                Console.WriteLine(i);
        }
    }
}
