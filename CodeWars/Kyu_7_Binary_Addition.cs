using System;
using System.Collections.Generic;
using System.Text;

/*
Implement a function that adds two numbers together and returns their sum in binary.
The conversion can be done before, or after the addition.
The binary number returned should be a string.
*/
namespace CodeWars
{
    class Kyu_7_Binary_Addition
    {
        public static string AddBinary(int a, int b)
        {
            int c = a + b;
            string result = string.Empty;
            do
            {
                result = (c % 2) + result;
                c = c / 2;
            } while (c > 0);
            return result;
        }
    }
}
