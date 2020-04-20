using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

/*
We need to sum big numbers and we require your help.

Write a function that returns the sum of two numbers.
The input numbers are strings and the function must return a string.

Example
add("123", "321"); -> "444"
add("11", "99");   -> "110"
Notes
The input numbers are big.
The input is a string of only digits
The numbers are positives
*/
namespace CodeWars
{
    class Kyu_4_Adding_Big_Numbers
    {
        public static string Add(string a, string b)
        {
            IEnumerable<int> reverseNumbersOfA =
            a.Reverse().Select(n => (int)char.GetNumericValue(n));
            IEnumerable<int> reverseNumbersOfB =
            b.Reverse().Select(n => (int)char.GetNumericValue(n));
            string result = string.Empty;
            int temp = 0;
            for (int i = 0; i < Math.Max(reverseNumbersOfA.Count(), reverseNumbersOfB.Count()); i++)
            {
                int toAdd = GetNumberOfSequence(i, reverseNumbersOfA) +
                            GetNumberOfSequence(i, reverseNumbersOfB) + temp;
                if (toAdd > 9)
                    temp = 1;
                else
                    temp = 0;
                toAdd %= 10;
                result += toAdd;
            }
            result = temp > 0 ? result + temp : result;
            return new string(result.ToCharArray().Reverse().ToArray());
        }
        static int GetNumberOfSequence(int index, IEnumerable<int> sequence) => index >= sequence.Count() ? 0 : sequence.ElementAt(index);
    }
}