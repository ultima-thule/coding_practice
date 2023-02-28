using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_practice
{
    internal class EUL_4
    {

        public static bool IsPalindrome(int number)
        { 
            string palindrome = number.ToString();
            bool compared = true;
            int i = 0;
            int index2;
            while (compared && i < palindrome.Length / 2)
            {
                index2 = palindrome.Length - 1 - i;
                if (index2 < i || palindrome[i] != palindrome[index2])
                {
                    compared = false;
                }
                i++;
            }
            return compared;
        }

        public static void Run()
        {
            //Project EULER Problem 4
            /*
             * A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.
             * Find the largest palindrome made from the product of two 3-digit numbers.
            */

            int product;
            bool isPalindrome;
            int biggest = 0;

            for (int i = 999; i > 99; i--)
            {
                for (int j = 999; j > 99; j--)
                {
                    product = i * j;
                    isPalindrome = IsPalindrome(product);
                    Console.WriteLine($"Num1: {i}, num2: {j}, product: {product}, is palindrome: {isPalindrome}");

                    if (isPalindrome)
                    {
                        if (product > biggest)
                        {
                            biggest = product;
                        }
                    }
                }
            }
            Console.WriteLine(biggest);
        }
    }
}