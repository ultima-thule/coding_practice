using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_practice
{
    internal class CG_SudokuValidator
    {

        static int CalcJ(int j)
        {
            if (j >= 0 && j <= 2)
            { 
                return 0;
            }
            if (j >= 3 && j <= 5)
            {
                return 1;
            }
            return 2;
        }

        static bool ValidateRowsCols(int[,] input)
        {
            bool result = true;
            HashSet<int> rows = new HashSet<int>();
            HashSet<int> cols = new HashSet<int>();
            HashSet<int> section = new HashSet<int>();
            for (int i = 0; result && i < input.GetLength(0); i++)
            {
                for (int j = 0; j < input.GetLength(1); j++)
                {
                    rows.Add(input[i,j]);
                    cols.Add(input[j, i]);
                    section.Add(input[CalcJ(j), (j % 3)]);
                }
                Console.WriteLine($"Rows: {rows.Count}, cols: {cols.Count}, sections: {section.Count}");
                result &= (rows.Count == 9);
                result &= (cols.Count == 9);
                result &= (section.Count == 9);
                rows.Clear();
                cols.Clear();
                section.Clear();
            }
            return result;
        }
               

        static bool CheckIsValid(int[,] input)
        {
            return ValidateRowsCols(input);
        }

        public static void Run()
        {
            int[,] input = new int[9, 9] {
            //    {1,2,3,4,5,6,7,8,9}, 
            //    {4,5,6,7,8,9,1,2,3},
            //    {7,8,9,1,2,3,4,5,6},
            //    {9,1,2,3,4,5,6,7,8},
            //    {3,4,5,6,7,8,9,1,2},
            //    {6,7,8,9,1,2,3,4,5},
            //    {8,9,1,2,3,4,5,6,7},
            //    {2,3,4,5,6,7,8,9,1},
            //    {5,6,7,8,9,1,2,3,4}
            //};
                {1, 5, 2, 4, 8, 9, 3, 7, 6},
                {2, 4, 6, 8, 9, 5, 7, 1, 3},
                {3, 8, 7, 9, 2, 4, 6, 5, 5},
                {4, 6, 8, 3, 7, 1, 2, 9, 5},
                {5, 9, 2, 8, 6, 3, 4, 1, 1},
                {6, 2, 5, 9, 4, 8, 1, 3, 7},
                {7, 3, 9, 2, 5, 6, 8, 4, 1},
                {8, 7, 3, 5, 1, 2, 9, 6, 4},
                {9, 1, 4, 6, 3, 7, 5, 8, 2}
            };

            // Write an answer using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");

            Console.WriteLine(CheckIsValid(input));
            
        }
    }
}
