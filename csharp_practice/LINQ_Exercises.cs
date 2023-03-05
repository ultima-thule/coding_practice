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
        //Take the following string "4:12,2:43,3:51,4:29,3:24,3:14,4:46,3:25,4:52,3:27"
        //which represents the durations of songs in minutes and seconds, and calculate
        //the total duration of the whole album
        public static void Exercise4()
        {
            string input = "4:12,2:43,3:51,4:29,3:24,3:14,4:46,3:25,4:52,3:27";

            var results = input.Split(",")
                .Select(song => new
                {
                    Seconds = int.Parse(song.Split(":")[0]) * 60 + int.Parse(song.Split(":")[1])
                })
                .Sum(song => song.Seconds).ToString();

            Console.WriteLine($"{int.Parse(results) / 60}:{int.Parse(results) % 60}");
        }

        public static void Exercise5()
        {
            //Create an enumerable sequence of strings in the form "x,y" representing all the points on a 3x3 grid.
            //e.g. output would be: 0,0 0,1 0,2 1,0 1,1 1,2 2,0 2,1 2,2

            var result = Enumerable.Range(0, 3).SelectMany(x => Enumerable.Range (0, 3).Select (y => $"{x},{y}"));
            Console.WriteLine(result);
        }

        //Take the following string "00:45,01:32,02:18,03:01,03:44,04:31,05:19,06:01,06:47,07:35" which represents the times (in minutes and seconds)
        //at which a swimmer completed each of 10 lengths. Turn this into an IEnumerable of TimeSpan objects containing the time taken to swim each length
        //(e.g. first length was 45 seconds, second was 47 seconds etc)
        public static void Exercise6() 
        {
            string input = "00:45,01:32,02:18,03:01,03:44,04:31,05:19,06:01,06:47,07:35";
            var times = input.Split(",")
                .Select(record => TimeSpan.FromSeconds(int.Parse(record.Split(":")[0]) * 60 + int.Parse(record.Split(":")[1])));

            var results = times.Zip(times.Skip(1), (first, second) => second - first);
        }

        //Take the following string "2,5,7-10,11,17-18" and turn it into an IEnumerable of integers: 2 5 7 8 9 10 11 17 18
        public static void Exercise7()
        {
            string input = "2,5,7-10,11,17-18";
            var result = input.Split(",")
                .Select(n => n.Split("-"))
                .Select(p => new { First = int.Parse(p.First()), Last = int.Parse(p.Last()) })
                .SelectMany(x => Enumerable.Range(x.First, x.Last - x.First + 1));
            
            Console.WriteLine(result);
        }
    }
}