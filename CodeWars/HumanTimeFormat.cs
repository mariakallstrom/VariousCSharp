using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CodeWars
{
    class HumanTimeFormat
    {
        public static string FormatDuration(int seconds)
        {
            var result = "";
            int y, d, h, m = 0;
            if(seconds <= 0)
            {
                return "now";
            }
            y = seconds / 31556926;
            if(y != 0)
            {
                seconds = seconds % 31556926;
                if(y == 1)
                {
                    result = y.ToString() + " year,";
                }
                else
                {
                    result = y.ToString() + " years,";
                }
            }
            d = seconds / 86400;
            if(d != 0)
            {
                seconds = seconds % 86400;
                if (d == 1)
                {
                    result += " " + d.ToString() + " day,";
                }
                else
                {
                    result += " " + d.ToString() + " days,";
                }
            }
            h = seconds / 3600;
            if (h != 0)
            {
                seconds = seconds % 3600;
                if (h == 1)
                {
                    result += " " + h.ToString() + " hour,";
                }
                else
                {
                    result += " " + h.ToString() + " hours,";
                }
            }
            m = seconds / 60;
            if (m != 0)
            {
                seconds = seconds % 60;
                if (m == 1)
                {
                    result += " " + m.ToString() + " minute,";
                }
                else
                {
                    result += " " + m.ToString() + " minutes,";
                }
            }
            if(seconds != 0)
            {
                if (seconds == 1)
                {
                    result += " " + seconds.ToString() + " second,";
                }
                else
                {
                    result += "" + seconds.ToString() + " seconds,";
                }
            }
            var commas = result.ToCharArray().Where(x => x == ',').Count();
            if(commas == 1)
            {
                result = result.Substring(0, result.Length - 1);
            }
            if(commas == 2)
            {
                int index = result.IndexOf(',');
                result = string.Concat(result.Substring(0, index), " and ", result.Substring(index + 1));
                result = result.Substring(0, result.Length -1);
            }
            if(commas == 3)
            {
                int index = result.IndexOf(',', result.IndexOf(',') +1);
                result = string.Concat(result.Substring(0, index), " and ", result.Substring(index + 1));
                result = result.Substring(0, result.Length -1);
            }
            if (commas == 4)
            {
                int index = result.IndexOf(',', result.IndexOf(',', result.IndexOf(',') +1) + 1);
                result = string.Concat(result.Substring(0, index), " and ", result.Substring(index + 1));
                result = result.Substring(0, result.Length -1);
            }
            if (commas == 5)
            {
                int index = result.IndexOf(',', result.IndexOf(',', result.IndexOf(',', result.IndexOf(',') +1) + 1) + 1);
                result = string.Concat(result.Substring(0, index), " and ", result.Substring(index + 1));
                result = result.Substring(0, result.Length -1);
            }
            result = result.Replace("  ", " ");
            return result.Trim();
        }

        public static string FormatDurationBestPractise(int seconds)
        {
            //Enter Code here
            string s = "";
            int sec = seconds;
            int[] divArr = { 60 * 60 * 24 * 365, 60 * 60 * 24, 60 * 60, 60, 1 };
            string[] nameArr = { "year", "day", "hour", "minute", "second" };

            if (seconds == 0)
            {
                s = "now";
            }

            for (int i = 0; i < divArr.Length; i++)
            {
                int k = sec / divArr[i];
                sec = sec % divArr[i];
                if (k != 0)
                {
                    string pref = "";
                    if (s != "")
                    {
                        if (sec == 0)
                        {
                            pref = " and ";
                        }
                        else
                        {
                            pref = ", ";
                        }
                    }
                    s = s + pref + k.ToString() + " " + nameArr[i];
                    s += k > 1 ? "s" : "";
                }
            }
            return s;
        }
    }
}
