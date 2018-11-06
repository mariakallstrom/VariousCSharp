using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeWars
{
    class UnderScore
    {
        public static string ToUnderscore(string str)
        {
            var result = "";

            foreach (var c in str)
            {
                if (char.IsUpper(c))
                {
                    result += "_" + char.ToLower(c);
                }
                else
                {
                    result += c;
                }
            }
            if (result.First() == '_')
            {
                result = result.Substring(1);
            }
            return result;

        }
    }
}
