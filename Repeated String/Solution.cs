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
        public static long repeatedString(string s, long n)
        {
            if (s == "a")
                return n;

            long a = 0, b = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'a') 
                    a++;                 
                if (i < n % s.Length && s[i] == 'a')
                    b++;
            }
            return n / s.Length * a + b;
        }

        static void Main(string[] args)
        {            
            string s10 = "ojowrdcpavatfacuunxycyrmpbkvaxyrsgquwehhurnicgicmrpmgegftjszgvsgqavcrvdtsxlkxjpqtlnkjuyraknwxmnthfpt";
            long i10 = 685118368975;            
            string s11 = "babbaabbabaababaaabbbbbbbababbbabbbababaabbbbaaaaabbaababaaabaabbabababaabaabbbababaabbabbbababbaabb";
            long i11 = 860622337747;            
            string s14 = "aadcdaccacabdaabadadaabacdcbcacabbbadbdadacbdadaccbbadbdcadbdcacacbcacddbcbbbaaccbaddcabaacbcaabbaaa";
            long i14 = 942885108885;            
            string s17 = "bab";
            long i17 = 725261545450;            
            string s18 = "beeaabc";
            long i18 = 711560125001;
            
            Console.WriteLine(repeatedString(s10, i10));
            Console.WriteLine(repeatedString(s11, i11));
            Console.WriteLine(repeatedString(s14, i14));
            Console.WriteLine(repeatedString(s17, i17));
            Console.WriteLine(repeatedString(s18, i18));

        }
    }


}


