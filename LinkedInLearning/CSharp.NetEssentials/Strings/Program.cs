// C# code​​​​​​‌‌​​​​​‌‌‌‌‌​‌‌​​‌​​‌‌​​​ below
using System;
using System.Text;


namespace Falconi.Csharp.NetEssentials
{
    /// <summary>
    /// 
    /// </summary>
    public class Answer {        

        /// <summary>
        /// alt method (more efficient)
        /// return $"{the_date.Year}--{the_date.Month}--{the_date.Day}"
        /// </summary>
        /// <param name="the_date"></param>
        /// <returns></returns>
        public static string FormatDateTime(DateTime the_date) {
            // Your code goes here
            string pattern = @"yyyy--M--d";            
            return the_date.ToString(pattern);
        }

        /// <summary>
        /// Alt Solution
        /// return String.Join(".", strs).ToUpper()
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public static string FormatJoinStrings(string[] strs) {
            // Your code goes here
            StringBuilder sb = new();
            for(int i = 0; i < strs.Length; i++)
            {
                sb.Append(strs[i].ToUpper());
                if(i < strs.Length - 1)
                {
                    sb.Append('.');
                }

            }
            return sb.ToString();
        }
    }

    /// <summary>
    /// Explanations
    /// Ex 1.
    /// From Geminai
    /// Let's compare the two methods in terms of their BigO complexity:
    /// 
    /// Method 1: String.Join(".", strs).ToUpper()
    /// String.Join(".", strs) concatenates the strings with a period separator. This operation is O(n) where n is the total length of all strings combined.
    /// .ToUpper() converts the entire resulting string to uppercase, which is also O(n) since it processes each character once.
    /// Total Complexity: O(n)
    ///
    /// Method 2: Using StringBuilder
    ///
    /// Initializing StringBuilder is O(1).
    /// The for loop iterates over each string in the array, appending each string and a period if it's not the last element. This involves:
    /// sb.Append(strs[i].ToUpper()) which is O(m) for each string of length m.
    /// sb.Append('.') which is O(1).
    ///
    /// The loop runs strs.Length times, so the complexity is O(n) where n is the total length of all strings combined.
    /// Total Complexity: O(n)
    ///
    ///
    /// Conclusion:
    /// Both methods have a similar BigO complexity of O(n). However, in practice, the StringBuilder approach might be slightly more efficient due to fewer intermediate allocations and transformations. The String.Join method creates an intermediate string that is then converted to uppercase, potentially leading to more memory usage and processing time compared to building the final string directly with StringBuilder.
    ///
    /// Ex 2.
    /// Comparing the Performance of Two String Formatting Methods
    /// Let’s break down the two approaches, analyze their time complexity (Big-O), and understand which is more efficient.
    ///
    /// Method 1: Using String.Join and ToUpper
    /// return String.Join(".", strs).ToUpper();
    /// Step 1: String.Join(".", strs)
    /// String.Join iterates over the strs array and concatenates the strings using a separator ("." in this case).
    /// The time complexity of String.Join is O(n), where n is the total number of strings in strs. This is because each element is processed once, and the separator is added between them. The total length of the resulting string will be proportional to the sum of the lengths of the strings plus the separators.
    /// Step 2: ToUpper()
    /// After the join operation, ToUpper() is called on the entire resulting string.
    /// This operation requires iterating over each character in the resulting string, so the time complexity of ToUpper() is O(m), where m is the total length of the joined string.
    /// Thus, the overall time complexity for this method is:
    ///
    /// O(n) for the join operation, where n is the number of strings.
    /// O(m) for the ToUpper() operation, where m is the total length of all the strings combined (this is a linear function of the size of the input).
    /// Since m (the total length of the string) is proportional to n (the number of strings), the time complexity is approximately O(n). But since m is directly tied to the sum of the string lengths, the total complexity is O(n + m), which simplifies to O(m) when n is proportional to m.
    ///
    /// Method 2: Using StringBuilder and Loop
    /// StringBuilder sb = new();
    /// for (int i = 0; i < strs.Length; i++)
    /// {
    ///     sb.Append(strs[i].ToUpper());
    ///     if (i < strs.Length - 1)
    ///     {
    ///         sb.Append('.');
    ///     }
    /// }
    /// return sb.ToString();
    /// Step 1: Loop Through the Array and ToUpper()
    ///
    /// This method loops through each element of the strs array and converts each string to uppercase using ToUpper().
    /// Calling ToUpper() on each string in strs[i] is O(k), where k is the length of the string strs[i]. Therefore, this step has a time complexity of O(n * k), where n is the number of elements in the array and k is the average length of the strings.
    /// Step 2: Append to StringBuilder
    ///
    /// Appending each string and the separator (if necessary) to the StringBuilder is an O(1) operation for each append (amortized cost due to internal resizing of the StringBuilder if required).
    /// The loop runs n times, and each iteration has an O(1) complexity for appending the string and the period.
    /// Step 3: ToString()
    ///
    /// Finally, sb.ToString() creates the final string. Since the StringBuilder already contains all the pieces of the final string, the time complexity of this operation is O(m), where m is the total length of the string after appending.
    /// Thus, the overall time complexity for this method is:
    ///
    /// O(n * k) for converting each string to uppercase (where n is the number of strings and k is the average length of each string).
    /// O(m) for the final ToString() call.
    /// Big-O Comparison
    /// Method 1: String.Join + ToUpper
    /// The overall complexity is O(n + m), where n is the number of strings and m is the total length of all the strings combined.
    ///
    /// Method 2: StringBuilder + Loop
    /// The overall complexity is O(n * k + m), where n is the number of strings, k is the average length of each string, and m is the total length of the final concatenated string.
    ///
    /// Which Method is More Efficient?
    /// String.Join() is generally more efficient because it internally optimizes the concatenation process and avoids multiple intermediate allocations. The String.Join method concatenates all strings in one go, and only one additional operation (ToUpper()) is needed afterward.
    ///
    /// StringBuilder requires an explicit loop through the array with an additional ToUpper() call on each element. This results in more granular operations and possibly more intermediate allocations for the uppercase versions of the strings. The final ToString() call also requires building the final string, which can be less efficient compared to a single Join() operation.
    ///
    /// Conclusion
    /// Method 1 (String.Join()) is generally more efficient in terms of both time complexity and memory management. It avoids the need to manually handle string concatenation, and the ToUpper() operation is performed only once after the join.
    /// Method 2 (StringBuilder) has more overhead due to looping through the array and applying ToUpper() to each string, which results in a higher time complexity if the average length of the strings is significant.
    /// Thus, Method 1 is more efficient, especially when dealing with larger arrays of strings or strings of varying lengths.
    ///
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // This is how your code will be called.
            // You can edit this code to try different testing cases.
            string[] test_strs = new string[] {"Join", "these", "strings", "together"};
            DateTime test_date = new DateTime(2035, 11, 29);

            string learnerResult1 = Answer.FormatDateTime(test_date);
            string learnerResult2 = Answer.FormatJoinStrings(test_strs);

            Console.WriteLine(learnerResult1);
            Console.WriteLine(learnerResult2);
        }
    }

}
