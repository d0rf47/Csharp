using System.Text.RegularExpressions;

namespace Falconi.Csharp.NetEssentials
{
    public class Answer
    {
        const string pattern = @"\/";
        public static string ReverseDate(string date_str)
        {
            DateTime date;
            if (!DateTime.TryParse(date_str, out date))
            {
                return "";
            }
            var split = Regex.Split(date_str, pattern);
            string output = "";
            foreach (var s in split)
                // {
                //     Console.WriteLine(s);
                // }
                if (split.Length > 2)
                {
                    output = $"{split[2]}-{split[0]}-{split[1]}";
                }
            return output;
        }
    }
}
