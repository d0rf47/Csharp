using System;

namespace ArraySearch
{    
    class Searches

    {
        /**
        *   Searches an array in sequential order
        *   returns null if value not found
        *   
        *   Common examples in C# libs
        *   Array.Find()
        *   Array.FindAll()
        */
        public static long? LinearSearch(long[] input, long n)
        {
            foreach(long current in input)
            {
                if(n == current)
                    return n;
            }
            return null;
        }

        /**
        *   Used to reduce runtime of searching
        *   can only be used on SORTED datasets
        *   
        */
        public static int? RecursiveBinarySearch(int[] input, int n)
        {

            if (input.Length == 1)
            {
                if (input[0] == n)
                    return n;
                else
                    return null;
            }
            int index = input.Length / 2;
            if (input[index] > n)            
                return RecursiveBinarySearch(input[0..index], n);            
            else            
                return RecursiveBinarySearch(input[index..], n);            
        }

        /**
        *   Logarighmic runtime O(logn)
        */
        public static bool IterativeBinarySearch(int[] input, long n)
        {
            long min = 0;
            long max = input.Length - 1;

            while(min <= max)
            {
                long mid = (min + max) / 2;

                if(n == input[mid])
                    return true;
                else if(n < input[mid])
                    max = mid - 1;
                else
                    min = mid + 1;
            }

            return false;
        }

        /**
        *   diff implementation
        *   slower runtime
        *   O(n)
        */
        public static bool IterativeBinarySearch2(int[] input, int n)
        {
            if (input.Length == 1)
            {
                if (input[0] == n)
                    return true;
                return false;
            };

            int index;
            while (input.Length > 2)
            {
                index = input.Length / 2;
                
                if (input[index] > n)                
                    input = input[0..index];                                 
                else                
                    input = input[index..];                                                 
            }

            if (input[0] == n || (input.Length == 2 && input[1] == n))
                return true;
            return false;
        }
    }

    
}