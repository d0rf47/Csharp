using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace First_Demo_ConsoleApp
{

    class Program
    {

        public static int equalizeArray(List<int> arr)
        {
            var groupedList = arr.GroupBy(item => item);
            int total = 0;
            int max = 0;
            foreach (var gl in groupedList)
            {
                if (gl.Count() > max)                
                    max = gl.Count();            

                if (max >= gl.Count() / 2)
                    total = arr.Count() - max;
                else
                    total = max;
            }
            return total;
        }
        static void Main(string[] args)
        {
            List<int> arr = new List<int>();
            int d = 0;
            if (args.Length > 1 || args.Length < 1)
                Console.WriteLine("No Input Detected!");
            else
            {
                string fileName = args[0];

                string[] words = File.ReadAllLines(fileName);                
                Array.ForEach(words[1].Split(' '), w =>
                {
                    arr.Add(Int32.Parse(w.ToString()));
                });

                Console.WriteLine(equalizeArray(arr));
            }
        }
    }


}


