using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeWars
{
    class CountingChangeCombination
    {
        public static int CountCombinations(int money, int[] coins)
        {
            var count = 0;

            for (int i = 1; i <= money; i++)
            {
                foreach (var com in GetCombinations(coins, i))
                {
                    if (com.Aggregate((a, b) => a + b) == money)
                    {
                        count++;
                    }
               
                }
            }
          
            return count;
        }


        static IEnumerable<IEnumerable<T>>
     GetCombinations<T>(IEnumerable<T> list, int length) where T : IComparable
        {
            if (length == 1) return list.Select(t => new T[] { t });
            return GetCombinations(list, length - 1)
                .SelectMany(t => list.Where(o => o.CompareTo(t.Last()) >= 0),
                    (t1, t2) => t1.Concat(new T[] { t2 }));
        }
    }
}

//  CountCombinations(4, new[] {1,2}) // => 3
//  CountCombinations(10, new[] {5,2,3}) // => 4
//  CountCombinations(11, new[] {5,7}) //  => 0


