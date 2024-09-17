using System;

namespace Sorting
{
    class Program
    {
        /// <summary>
        /// Bubble Sort has to iteration through the array n^2 times
        /// each iteration brings another order of sort
        /// inner loops decreases with each outer iteration to account
        /// for the bubbled up value reaching its proper position
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int BubbleSort(int[] arr)
        {
            for(int i = 0; i < arr.Length - 1; i++){              
                bool swapped = false;  
                for(int j = 0; j < arr.Length - i - 1; j++){
                    if(arr[j] > arr[j + 1]){
                        int temp = arr[j];                        
                        arr[j] = arr[j + 1];
                        arr[j + 1]= temp;               
                        swapped = true;     
                    }                    
                }
                if(!swapped)
                    break;
            }
            foreach(var i in arr) Console.WriteLine(i);
            return 0;
        }
        
        /// <summary>
        /// Basic Selection Sort Algo
        /// sorts in place by finding the lowest value
        /// and adding it to the end of the sorted section
        /// swapping the first out of place item after the
        /// sorted section
        /// O(n^2) time complexity
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int SelectionSort(int[] arr){
            int swaps = 0;
            int len = arr.Length;
            int min;

            for(int i = 0; i < len - 1; i++){
                min = i;
                for(int j = i + 1; j < len;j++){
                    if(arr[j] < arr[min])
                        min = j;
                }
                
                if(min != i){
                    int temp = arr[min];
                    arr[min] = arr[i];
                    arr[i] = temp;
                    swaps++;
                }
            }
            return swaps;
        }

        /// <summary>
        /// cycle decomposition method
        /// relies on representation of the input array
        /// as disjoint cycles where each cycle represents
        /// a sequence of elements that need to be swapped 
        /// the length of said cycle provides the number of 
        /// swaps required.
        /// required a presort of KV pairs of value/index
        /// and tracking which positions of the array
        /// have already been visited & therefore sorted.
        /// 
        /// O(n log n) time complexity
        /// /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        static int minimumSwaps(int[] arr) {

            int swaps = 0;
            int len = arr.Length;
            //track which items are visited and sorted
            bool[] visited = new bool[len];
            //pair the array values with their index & sort by value
            var ValIndex = arr.Select((value, index) => new {value, index})
                            .OrderBy(vi => vi.value)
                            .ToArray();

            //traverse the array
            for(int i = 0; i < len; i++)
            {
                if(visited[i] || ValIndex[i].index == i){
                    // item is sorted or been checked skip
                    continue;
                }

                int cycleSize = 0;
                int j = i;
                //start from unvisited item and count cycles
                while (!visited[j])
                {
                    visited[j] = true;           
                    //move to next item in cycle so we dont go in order we get the next index 
                    //based on what the order should be         
                    j = ValIndex[j].index;
                    cycleSize++;
                }
                if(cycleSize > 1)
                    swaps += cycleSize - 1;
            }
            return swaps;
        }

        public static void Main(string[] args){
            // int[] arr = [7, 12, 9, 11, 3];            
            // Program.BubbleSort(arr);      
            int[] arr1 = [4,3,1,2];
            int[] arr2 = [2,3,4,1,5];
            int[] arr3 = [1, 3, 5, 2, 4, 6, 7];
            int i = Program.SelectionSort(arr1);
            Console.WriteLine(i);
        }
    }
}