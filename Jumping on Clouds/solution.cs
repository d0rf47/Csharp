using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Demo_ConsoleApp
{

    class Program
    {
        public static int jumpingOnClouds(List<int> c)
        {
            int totalJumps = 0;
            int size = c.Count();
            int cloud = 0;
            for(int i = 0;i < size; i++)
            {
                if(cloud + 2 < size && c[cloud + 2] != 1)
                {
                    totalJumps++;
                    cloud += 2;
                }else if (cloud +1 < size && c[cloud + 1] != 1)
                {
                    totalJumps++;
                    cloud += 1;
                }

            }            
            return totalJumps;
        }
        static void Main(string[] args)
        {
            List<int> clouds = new List<int>
            {
                0, 0, 1, 0, 0, 1, 0 
            };

            Console.WriteLine(jumpingOnClouds(clouds));
        }
    }


}


