using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Demo_ConsoleApp
{

    class Program
    {
        public static int sumHourGlass(List<List<int>> arr)
        {
            //ensures that if the greatest sum is a negative number it returns the correct value
            int maxSum = -2147483648;            
            int tempSum = 0;
            int pos3Cnt = 1;
            int pos1Cnt = 1;

            for (int row = 1; row < 5; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    tempSum += arr[row - 1][pos3Cnt - 1];
                    tempSum += arr[row + 1][pos3Cnt - 1];
                    pos3Cnt++;
                }
                pos3Cnt -= 2;
                tempSum += arr[row][pos1Cnt];
                pos1Cnt++;
                
                if (pos3Cnt < 7)
                    row -= 1;

                if (pos3Cnt == 5)
                {
                    pos3Cnt = 1;
                    row++;
                }
                
                if (pos1Cnt == 5)
                    pos1Cnt = 1;

                if (tempSum > maxSum)
                    maxSum = tempSum;
                
                tempSum = 0;
            }
            return maxSum;
        }
        static void Main(string[] args)
        {            
            List<List<int>> arr = new List<List<int>>
            {
                new List<int> {-9, -9, -9,  1, 1, 1, },
                new List<int> { 0, -9,  0,  4, 3, 2 },
                new List<int> { -9, -9, -9,  1, 2, 3 },
                new List<int> { 0,  0,  8,  6, 6, 0 },
                new List<int> { 0,  0,  0, -2, 0,0 },
                new List<int> { 0,  0,  1,  2, 4, 0 }
            };

            List<List<int>> arr2 = new List<List<int>>
            {
                new List<int> { 1, 1, 1, 0, 0, 0 },
                new List<int> { 0, 1, 0, 0, 0, 0 },
                new List<int> { 1, 1, 1, 0, 0, 0 },
                new List<int> {0, 9, 2, -4, -4, 0 },
                new List<int> { 0, 0, 0, -2, 0, 0 },
                new List<int> { 0, 0, -1, -2, -4, 0 }
            };

            Console.WriteLine(sumHourGlass(arr));
            Console.WriteLine(sumHourGlass(arr2));
        }
    }


}


