using System;
using System.Collections;

namespace Algorithms
{
    /**
    *   Is a means of combining data
    *   from multiple datasets
    *   often involves some sort of filter / manipulation
    *   of the data in the process
    */
    class Aggregation
    {
        public static int[] MergeEvenValues(int[] arr1, int[] arr2)
        {
            ArrayList result = new ArrayList();
            AddEvenFromArray (arr1, result);
            AddEvenFromArray (arr2, result);

            return (int[]) result.ToArray(typeof (int));
        }

        //Helper functions
        public static void AddEvenFromArray(int[] arr, ArrayList list)
        {
            foreach (int n in arr)
            {
                if (n % 2 == 0) list.Add(n);
            }
        }

        public static int[] ReverseArray(int[] arr)
        {
            int[] reversed = new int[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                reversed[i] = arr[arr.Length - i - 1];
            }

            return reversed;
        }

        public static void ReverseInPlace(int[] arr)
        {
            int size = arr.Length;
            for (int i = 0; i < size / 2; i++)
            {
                //swap arr[i] with index(arr[input.length - i - 1])
                int temp = arr[i];
                arr[i] = arr[size - i - 1];
                arr[size - i - 1] = temp;
            }
            return;
        }

        /**
        *   Sample of rotating an array in place 
        *   as opposed to using a new array and return
        */
        public static void RotateLeft(int[] arr, int rotations)
        {
            int size = arr.Length;

            //loop for number of total rotations
            for (int i = 0; i < rotations; i++)
            {
                //take first item and save for last idex
                int temp = arr[0];

                //loop over array size - 1 // prevents overflow index
                for (int k = 0; k < size - 1; k++)
                {
                    //push each item down 1 index
                    arr[k] = arr[k + 1];
                }

                //append first item to end &  iter.
                arr[size - 1] = temp;
            }
        }

        /**
        *   Checks an Array for duplicate Values
        *   returns boolean value
        *   O(n) runtime
        */
        public static bool ContainsDuplicate(int[] nums)
        {
            HashSet<int> singles = new HashSet<int>();
            for(int i = 0; i < nums.Length;i++)
            {
                if (singles.Contains(nums[i]))
                    return true;
                singles.Add(nums[i]);
                
            }
            return false;
        }
    }
}
