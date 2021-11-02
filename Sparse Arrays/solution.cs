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
        /*
         * Complete the 'matchingStrings' function below.
         *
         * The function is expected to return an INTEGER_ARRAY.
         * The function accepts following parameters:
         *  1. STRING_ARRAY strings
         *  2. STRING_ARRAY queries
         */
        public static List<int> matchingStrings(List<string> strings, List<string> queries)
        {
            List<int> count = new List<int>();
            int counter = 0;
            queries.ForEach((q) =>
            {
                strings.ForEach((s) =>
                {
                    if (s == q)
                        counter++;
                });
                count.Add(counter);
                counter = 0;
            });
            return count;
        }
        static void Main(string[] args)
        {
            List<string> strings = new List<string>();
            List<string> queries = new List<string>();
            string fileName = args[0];
            string[] words = File.ReadAllLines(fileName);
            int stringCount = Int32.Parse(words[0]);
            int i = 0;
            for(i = 1; i <= stringCount; i++)
            {
                strings.Add(words[i]);
            }

            for(i = i + 1; i < words.Length; i++)
            {
                queries.Add(words[i]);
            }
            List<int> result = matchingStrings(strings, queries);
            result.ForEach((r) =>
            {
                Console.WriteLine(r);
            });
        }
    }


}


