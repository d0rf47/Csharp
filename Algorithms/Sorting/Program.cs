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
                        int t1 = arr[j];                        
                        arr[j] = arr[j + 1];
                        arr[j + 1]= t1;               
                        swapped = true;     
                    }                    
                }
                if(!swapped)
                    break;
            }
            foreach(var i in arr) Console.WriteLine(i);
            return 0;
        }

        static int swapHelper(int[] arr, int swapCnt){
            //Console.WriteLine($"arr len {arr.Length}");
            if(arr.Length < 2)
                return swapCnt;         
                foreach(var i in arr) Console.Write($"{i}, ");
            Console.WriteLine();
            var arr2 = arr[..];
            int min = 2147483647;
            int max = 1;
            int minPos = 0;
            int maxPos = 0;            
            for(int i = 0; i < arr.Length; i++){                              
                if(arr[i] <= min){
                    min = arr[i];
                    minPos = i;
                }
                if(arr[i] >= max ){
                    max = arr[i];
                    maxPos = i;
                }
            }
            // Console.WriteLine(minPos);                        
            // Console.WriteLine(maxPos);
            if(arr2[0] != arr[minPos]){                
                arr2[0] = arr[minPos];                
                arr2[1] = arr[0];
                swapCnt++;
            }
            if(arr2[arr.Length - 1] != arr[maxPos]){                
                arr2[arr.Length - 1] = arr[maxPos];           
                arr2[arr.Length - 2] = arr[arr.Length - 1];     
                swapCnt++;
            }
            foreach(var i in arr2) Console.Write($"{i}, ");
            Console.WriteLine();
            int[] returnArr = new int[arr2.Length - 2];
            for(int i = 0; i < arr2.Length - 2;  i++){
                returnArr[i] = arr2[i+1];
            }
            // foreach(var i in returnArr) Console.Write($"{i}, ");
            // Console.WriteLine();

            if(returnArr.Length == 3)
            {
                if(returnArr[0] < arr2[0] || returnArr[0] > arr2[2])
                    swapCnt++;
            }

            return Program.swapHelper(returnArr, swapCnt);

            //try swaping min and max and re iterate list
        }
        static int minimumSwaps(int[] arr) {
            return swapHelper(arr, 0);
        }

        public static void Main(string[] args){
            // int[] arr = [7, 12, 9, 11, 3];            
            // Program.BubbleSort(arr);      
            int[] arr2 = [2,3,4,1,5];
            int[] arr3 = [1, 3, 5, 2, 4, 6, 7];
            int i = Program.minimumSwaps(arr3);
            Console.WriteLine(i);
        }
    }
}