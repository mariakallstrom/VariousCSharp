using System;
using System.Collections.Generic;
using System.Text;

namespace CodeWars
{
    class DeadFish
    {
        public static int[] Parse(string data)
        {
            // Return the output array, and ignore all non-op characters
            var result = new List<int>();
            var sum = 0;
            var list = data.ToCharArray();
            foreach (var item in list)
            {
                if(item == 'i')
                {
                    sum += 1;
                }
                if (item == 'd')
                {
                    sum -= 1;
                }
                if (item == 's')
                {
                    sum *= sum;
                }
                if (item == 'o')
                {
                    result.Add(sum);
                }
            }
            return result.ToArray();
        }
    }
}
