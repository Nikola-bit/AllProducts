using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppProducts
{
    public static class Trunc
    {
        public static string Truncate(this string value, int maxChars)
        {
            return value.Length <= maxChars ? value : value.Substring(0, maxChars) + "...";
        }
    }
}
