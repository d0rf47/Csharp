using System;
using System.Linq;
using System.Text;

namespace Algorithms
{
    class StringValidators
    {
                        
        public static bool isUpperCase(string s)
        {
            return s.All(char.IsUpper);
        }

        /**
        *   Validates string to check if
        *   it contains at least 
        *   1 letter, 1 upper and 1 lower case char
        */
        public static bool isPasswordSafe(string password)
        {
            return password.Any(char.IsDigit) && password.Any(char.IsUpper) && password.Any(char.IsLower);
        }

        public static string NormalizeString(string input)
        {
            return input.ToLower().Trim();
        }

        /**
        *   uses string builder to avoid performance issues
        *   since the String obj is immutable by default
        *   any operations which mutate a standard String Object
        *   return a new object with the changes --> stored as char[]
        *   string builder avoids these issues
        *   by dynamically expanding memory to accomdate the changes
        */
        public static string reverseStringVerbose(string input)
        {
            if(string.IsNullOrEmpty(input))
                return input;
            
            StringBuilder reversed = new StringBuilder(input.Length);

            for(int i = input.Length - 1; i >= 0; i--)
            {
                reversed.Append(input[i]);
            }

            return reversed.ToString();            
        }

        public static string reverseString(string input)
        {
            char[] s = input.ToCharArray();
            Array.Reverse(s);
            return new String(s);
        }

        public static string reverseEachWord(string input)
        {
            if(string.IsNullOrEmpty(input))
                return input;

            string[] strings = input.Split(' ');
            StringBuilder output = new StringBuilder((strings.Length - 1) * input.Length );

            for(int i = 0; i < strings.Length; i++)
            {
                output.Append(reverseString(strings[i]));
                output.Append(" ");
            }

            return output.ToString();
        }

    }
}