using System;
using System.Collections.Generic;
using System.Text;

namespace CodeWars
{
    class NumberToEnglishWords
    {
        public static string NumberToEnglish(int n)
        {
            //Do Some Magic
            var result = "";
            var singular = new List<string>() {"" ,"one ","two ","three ","four ","five ","six ","seven ","eight ","nine " };
            var teens = new List<string>() {"", "eleven ","twelve ","thirteen ","fourteen ","fifteen ","sixteen ","seventeen ","eighteen ","nineteen " };
            var tens= new List<string>() { "","ten ","twenty ","thirty ","forty ","fifty ","sixty ","seventy ","eighty ","ninety "};
            var hundred = "hundred " ;
            var thousand = "thousand ";

            if (n < 0) return "";
            else if (n == 0) return "zero";
            else if (n > 10 && n < 20) return teens[n % 10];

           
           //check teens
            if ((n / 1000)>10 && (n / 1000) < 20) result = teens[(n / 1000) % 10];
            else
            {
                result += tens[(n / 1000) / 10];
                result += singular[(n / 1000) % 10];
            }

            if (result != "") result += thousand;
            result += singular[(n / 100) % 10];
            if (result != "" && (n / 100) % 10 != 0) result += hundred;

            //check teens
            if (n % 100 > 10 && n % 100 < 20) result += teens[(n % 100) % 10];
            else
            {
                result += tens[(n / 10) % 10];
                result += singular[n % 10];
            }
            return result.Trim();
        }

    }
}
