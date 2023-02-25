using System;

namespace csharp_practice
{
    internal class HR_3MW1T1
    {

        /*
         * Complete the 'plusMinus' function below.
         *
         * The function accepts INTEGER_ARRAY arr as parameter.
         */

        public static void plusMinus(List<int> arr)
        {
            double countNeg = 0.0;
            double countZero = 0.0;
            double countPos = 0.0;

            foreach (int i in arr)
            {
                if (i == 0)
                {
                    countZero += 1;
                }
                else if (i > 0)
                {
                    countPos += 1;
                }
                else
                {
                    countNeg += 1;
                }
            }
            double arrCount = (double)arr.Count;

            Console.WriteLine($"{(countPos / arrCount):F6}");
            Console.WriteLine($"{(countNeg / arrCount):F6}");
            Console.WriteLine($"{(countZero / arrCount):F6}");
        }

        public static void Run()
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

            HR_3MW1T1.plusMinus(arr);
        }
    }
}