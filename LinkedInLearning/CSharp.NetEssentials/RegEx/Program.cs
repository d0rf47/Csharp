using System.Text.RegularExpressions;
using System.Diagnostics;

namespace Falconi.Csharp.NetEssentials
{
    public class Program
    {
        static readonly int MAX_REGEX_TIME = 1000;
        static TimeSpan timeout = TimeSpan.FromMilliseconds(MAX_REGEX_TIME);
        static string teststr1 = "The quick brown Fox jumps over the lazy Dog";
        static string teststr2 = "the quick brown fox jumps over the lazy dog";
        static string teststr3 = "the quick browN fox jumps over tHe lazy dog";
        static string errorStr = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
        static Regex CapWords = new(@"[A-Z]\w+");  // Check for Words with Capital letters
        static Regex BadRegEx = new(@"(a+a+)+b", RegexOptions.None, timeout);
        static Stopwatch sw;

        static string[] test_strs = {
            "12/25/2030",
            "1/1/2020",
            "Juneuary 6",
            "07/28/1980",
            "3/15/99"
        };

        public static void Main(string[] args)
        {
            // Console.WriteLine("Bool outputs");
            // Console.WriteLine(CapWords.IsMatch(teststr1));
            // Console.WriteLine(CapWords.IsMatch(teststr2));
            // Console.WriteLine(CapWords.IsMatch(teststr3));

            // Console.WriteLine("Inner Word Capitalization Matching");
            // Match match = CapWords.Match(teststr3);
            // while (match.Success)
            // {
            //     Console.WriteLine($"'{match.Value}' found at pos {match.Index}");
            //     match = match.NextMatch();
            // }

            // Console.WriteLine("Match Collection Example");
            // MatchCollection matches = CapWords.Matches(teststr1);

            // foreach (var m in matches)
            // {
            //     Console.WriteLine(m);
            // }

            // Console.WriteLine("Replacements");
            // Console.WriteLine(CapWords.Replace(teststr1, "***"));

            // // This is a Delegate which can be passed into replace as an argument allowing for
            // // replacement logic to be used when performing replacements
            // string ToUpperCase(Match m)
            // {
            //     string s = m.ToString();
            //     return s.ToUpper();
            // }
            // Console.WriteLine(CapWords.Replace(teststr1, new MatchEvaluator(ToUpperCase)));


            // Console.WriteLine("Bad Regex Performance examples");

            // try
            // {
            //     sw = Stopwatch.StartNew();
            //     matches = BadRegEx.Matches(errorStr);
            //     sw.Stop();
            //     Console.WriteLine($"Found {matches.Count} matches in {sw.ElapsedMilliseconds}");
            // }
            // catch (Exception e)
            // {
            //     Console.WriteLine(e.Message);
            // }

            foreach (var s in test_strs)
            {
                Console.WriteLine(Answer.ReverseDate(s));
            }
        }
    }

}
