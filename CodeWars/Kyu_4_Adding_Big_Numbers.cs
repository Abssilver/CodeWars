using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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