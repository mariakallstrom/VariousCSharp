using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeWars
{
    public class MeasureLiterUnits
    {
        public static int MeasureFourLiters01()
        {
            var bath = new List<int>();
            var fourLiters = 0;

            for (int i = 0; i < 2; i++)
            {
                var b3 = new int[3];
                var b5 = new int[5];

                for (int j = 0; j < b5.Length; j++)
                {
                    b5[j] = j + 1;
                }
                for (int k = 0; k < b3.Length; k++)
                {
                    b3[k] = b5[k];
                    var list = b5.ToList();
                    list.Remove(b5.Last());
                    b5 = list.ToArray();
                }
                bath.Add(b5.Length);


            }
            foreach (var item in bath)
            {
                fourLiters += item;
            }


            return fourLiters;

        }

        public static void MeasureFourLiters02()
        {
            var fourLiters = 0;
            //three liters bottle
            var b3 = 0;
            //five liters bottle
            var b5 = 0;
            //Bathtub infinity liters
            var bath = new List<int>();

            for (int i = 0; i < 2; i++)
            {
                //step 1. Fill 5 liters into 3 liters bottle
                b5 = 5;
                //step 2. Add 3 liters to 3 liters bottle
                b3 = 3;
                //step 3. Remove 3 liters from 5 liters bottle
                b5 = b5 - b3;
                //step 4. Add 2 liters in 5 liters bottle to the bath
                bath.Add(b5);
                //step 5. Remove the 2 liters from five liters bottle
                b5 = 0;
                //step 6. Remove water from 3 liters bottle
                b3 = 0;
                // Do it again
            }
            foreach (var item in bath)
            {
                fourLiters += item;
            }
            Console.WriteLine(fourLiters);
        }

        public static int MeasureFourLiters03()
        {
            var fourLiters = 0;
            var b3 = 0;
            var b5 = 0; ;
            var bath = 0;

            for (int i = 0; i < 2; i++)
            {
                b5 = 5;
                bath += b5;
            }
            for (int i = 0; i < 2; i++)
            {
                b3= 3;
                bath -= b3;
            }

            fourLiters = bath;
            return fourLiters;
        }

        public static void MeasureOneLiters()
        {
            var bath = MeasureFourLiters03();
            var b3 = 0;
                b3 = 3;
                bath -= b3;

            var oneLiter = bath;
            Console.WriteLine(oneLiter);
        }
    }
}

//3 liter  

//5 liter

//fyll 5 liters flaskan med vatten.Häll över 3 liter i 3 litersflaskan.Då är det två liter kvar i 5 liters flaskan. Häll det i badkaret.
//Häll ut 3 litersflaskan så den är tom.

//Gör om samma sak en gång till.

//Då finns det 4 liter i badkaret.

//Fyll 5 liters flaskan med badkarets 4 liter och häller över det i 3 liters flaskan, då är det 1 liter kvar i 5 liters flaskan.
