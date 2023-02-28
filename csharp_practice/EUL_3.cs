using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_practice
{
    internal class EUL_3
    {
        public static void Run()
        {
            //Project EULER Problem 3
            /*
             * The prime factors of 13195 are 5, 7, 13 and 29.
             * What is the largest prime factor of the number 600851475143 ?
            */
            long n = 600851475143;
            int factor = 2;
            List<int> list = new List<int>();
            
            while (n > 1)
            {
                while (n % factor == 0)
                {
                    n /= factor;
                    list.Add(factor);
                }
                factor++;
            }

            Console.WriteLine(list.Max());
        }
    }
}