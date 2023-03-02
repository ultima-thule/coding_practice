using System;   
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace csharp_practice
{
    internal class LINQ_Exercises
    {
        public static void PrintList(IEnumerable<int> list)
        {
            Console.Write("[");
            foreach (var s in list)
            {
                Console.Write($"{s} "); 
            }
            Console.WriteLine("]");
        }

        /*Given an array of integers, write a query that returns list of numbers greater than 30 and less than 100.
        Expected input and output
        [67, 92, 153, 15] → 67, 92*/

        public static void Exercise1()
        {
            List<int> list = new List<int>() { 67, 92, 153, 15 };

            IEnumerable<int> result = list.Where(x => x > 30 && x < 100);
            PrintList(result);
        }
    }

}
