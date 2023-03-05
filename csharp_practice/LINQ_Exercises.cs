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

        //Take the following string "Davis, Clyne, Fonte, Hooiveld, Shaw, Davis, Schneiderlin, Cork, Lallana, Rodriguez, Lambert"
        //and give each player a shirt number, starting from 1, to create a string of the form: "1. Davis, 2. Clyne, 3. Fonte" etc
        public static void Exercise2()
        {
            string input = "Davis, Clyne, Fonte, Hooiveld, Shaw, Davis, Schneiderlin, Cork, Lallana, Rodriguez, Lambert";

            var result = string.Join(", ", 
                input.Split(", ")
                .Select((player, index) => $"{index + 1}. {player}")
                .ToArray());

            Console.WriteLine(result);
        }

        //Take the following string "Jason Puncheon, 26/06/1986; Jos Hooiveld, 22/04/1983; Kelvin Davis, 29/09/1976; Luke Shaw, 12/07/1995; Gaston Ramirez, 02/12/1990; Adam Lallana, 10/05/1988"
        //and turn it into an IEnumerable of players in order of age (bonus to show the age in the output)
        public static void Exercise3()
        {
            string input = "Jason Puncheon, 26/06/1986; Jos Hooiveld, 22/04/1983; Kelvin Davis, 29/09/1976; Luke Shaw, 12/07/1995; Gaston Ramirez, 02/12/1990; Adam Lallana, 10/05/1988";

            var result = string.Join(", ", input.Split("; ")
                .Select(player => new
                {
                    Name = player.Split(", ")[0],
                    Age = (DateTime.Today - DateTime.Parse(player.Split(", ")[1])).Days / 365
                }).OrderBy(p => p.Age).Select(p => $"{p.Name}: {p.Age}").ToArray());
            Console.WriteLine(result);
        }

    }
}