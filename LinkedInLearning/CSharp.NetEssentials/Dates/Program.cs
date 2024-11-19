namespace Falconi.Csharp.NetEssentials
{
    /// <summary>
    /// Parse Date strings and return the difference in Days
    /// If the date string provided is invalid
    /// return int.MaxValue
    /// </summary>
    public class Answer {
        static DateTime today = DateTime.Now;
    
        public static int CalcHowManyDays(string date_str) {
            // Your code goes here.
            var result = new DateTime();
            bool success = DateTime.TryParse(date_str, out result);
            if(success){
               return (today - result).Days;
            }else{
                return int.MaxValue;
            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            var learnerResult = new List<int>();

            string[] test_dates = { 
                "July 4, 1776",
                "12/25/2025",
                "April 1",
                "Not a date",
                "Feb 14, 2036",
                "1/2020",
                "Sat, 18 Aug 2018"
            };

            foreach (string date in test_dates) {
                learnerResult.Add(Answer.CalcHowManyDays(date));
                Console.WriteLine(learnerResult.Last());
            }
        }
    }
}
