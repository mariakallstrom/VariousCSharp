using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeWars
{
    class BubbleSort
    {
        public static int[] BubbleSortOnce(int[] input)
        {
            var list = input.ToList();
 
            for (int i = 0; i < list.Count -1; i++)
            {
                if(list[i] > list[i +1])
                {
                    list = Swap(list, i, i + 1);
                }
            }
            return list.ToArray();
        }

        public static List<int> Swap(List<int> list, int indexA, int indexB)
        {
            var tmp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = tmp;
            return list;
        }
    }
}
