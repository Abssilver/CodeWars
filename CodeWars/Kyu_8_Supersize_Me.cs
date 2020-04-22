using System;
using System.Collections.Generic;
using System.Text;

/*
Write a function that rearranges an integer into its largest possible value.

Kata.SuperSize(123456) //654321
Kata.SuperSize(105) // 510
Kata.SuperSize(12) // 21
*/

namespace CodeWars
{
    class Kyu_8_Supersize_Me
    {
        public long SuperSize(long num)
        {
            string str = num.ToString();
            char[] digits = str.ToCharArray();
            bool change = true;
            while (change)
            {
                change = false;
                for (int i = 0; i < digits.Length - 1; i++)
                {
                    if ((int)digits[i] < (int)digits[i + 1])
                    {
                        char tmp = digits[i];
                        digits[i] = digits[i + 1];
                        digits[i + 1] = tmp;
                        change = true;
                    }
                }
            }
            string output = string.Join("", digits);
            return long.Parse(output);
        }
    }
}
