using System;
using System.Collections.Generic;
using System.Text;

/*
As you may know, once women pass their teens,
they should only be celebrated for their 20th or 21st birthday, forever.
With some maths skills, that's totally possible - you only 
need to select the correct number base!

For example, if she turns 32, that's exactly 20 - in base 16...
Already 39? That's just 21, in base 19!

Your task is to translate the given age to the much desired 20 (or 21) years,
and indicate the number base, in the format specified below.

Note: input will be always > 21

Examples:
32  -->  "32? That's just 20, in base 16!"
39  -->  "39? That's just 21, in base 19!"
*/

namespace CodeWars
{
    class Kyu_7_Happy_Birthday_Darling
    {
        //n = 2*x + 1 //21
        //n = 2*x //20
        public string WomensAge(int n)
        {
            bool even = n % 2 == 0;
            return $"{n}? That's just {(even ? 20 : 21)}, in base {(even? n / 2 :(n - 1) / 2)}!";
        }
    }
}
