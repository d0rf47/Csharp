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

        public static List<int> rotateLeft(int d, List<int> arr)
        {
            List<int> tmp = new List<int>(arr);
            int index = 0;
            for(int i = 0; i < arr.Count; i++)
            {

                if (i - d < 0)
                {
                    index = arr.Count + i - d;
                }
                else
                    index = i - d;
                tmp[index] = arr[i];
            }

            return tmp;
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
                d = Int32.Parse(words[0].Split(' ')[1].ToString());
                Array.ForEach(words[1].Split(' '), w =>
                {
                    arr.Add(Int32.Parse(w.ToString()));
                });

                rotateLeft(d, arr).ForEach((i) =>
                {
                    Console.Write(i + " ");
                });
            }
        }
    }


}


