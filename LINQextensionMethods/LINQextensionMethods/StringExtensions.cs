using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQextensionMethods
{
   public static class StringExtensions
    {
        public static string ToFirstUpperRestLower(this string input)
        {
            if (string.IsNullOrEmpty(input)) return input;
            if (input.Length == 1) return input.ToUpper();
            return input.Substring(0, 1).ToUpper()
                   + input.Substring(1).ToLower();
        }
    }
}
