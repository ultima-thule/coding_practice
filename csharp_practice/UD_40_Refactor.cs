using System;

namespace csharp_practice
{
    interface IQuadraticFunctionRootsCalculator
    {
        void Calculate();
    }

    internal class ConsoleReader
    {
        internal static double ReadVariable(string varName)
        {
            double result;
            string? input;
            do
            {
                Console.WriteLine($"Enter {varName}");
                input = Console.ReadLine();
                if (!double.TryParse(input, out result))
                {
                    Console.WriteLine("Invalid format, please try again.");
                }
            }
            while (!double.TryParse(input, out result));
            return result;
        }
    }


    internal class Roots
    {
        private List<double> _roots;
        public Roots()
        {
            _roots = new List<double>();
        }

        public void AddRoot(double root)
        {
            _roots.Add(root);
        }

        public bool AreTwo() => _roots.Count == 2;

        public bool IsOne() => _roots.Count == 1;

        public bool IsZero() => _roots.Count == 0;

        public double? GetItem(int index)
        {
            if (_roots.Count > index)
            {
                return _roots[index];
            }
            return null;
        }
    }

        internal static class MathUtils
    {
        internal static Roots CalculateRoots(double a, double b, double c)
        {
            Roots roots = new Roots();

            double delta = MathUtils.CalculateDelta(a, b, c);

            if (delta > 0)
            {
                roots.AddRoot(CalculateSingleRoot(a, b, delta, false));
                roots.AddRoot(CalculateSingleRoot(a, b, delta, true));
            }
            else if (delta == 0)
            {
                roots.AddRoot(CalculateSingleRoot(a, b, delta, true));
            }
            return roots;
        }

        private static double CalculateSingleRoot(double a, double b, double delta, bool positive)
        {
            if (positive)
            {
                return (-b + Math.Sqrt(delta)) / (2 * a);
            }
            return (-b - Math.Sqrt(delta)) / (2 * a);
        }

        internal static double CalculateDelta(double a, double b, double c)
        {
            return b * b - (4 * a * c);
        }
    }

    internal class UD_40_Refactor : IQuadraticFunctionRootsCalculator
    {
        public void Calculate()
        {
            bool doCalculate = true;
            while (doCalculate)
            {
                Console.WriteLine("Quadratic Function: y = ax^2 + bx + c");

                double a = ConsoleReader.ReadVariable("a");
                double b = ConsoleReader.ReadVariable("b");
                double c = ConsoleReader.ReadVariable("c");

                PrintRoots(a, b, c);

                doCalculate = DoCalculateAgaing();
            }
        }

        private static void PrintRoots(double a, double b, double c)
        {
            Roots roots = MathUtils.CalculateRoots(a, b, c);

            if (roots.AreTwo())
            {
                Console.WriteLine("Two roots:");
                Console.WriteLine(roots.GetItem(0));
                Console.WriteLine(roots.GetItem(1));
            }
            else if (roots.IsOne())
            {
                Console.WriteLine("One root:");
                Console.WriteLine(roots.GetItem(0));
            }
            else
            {
                Console.WriteLine("Zero roots.");
            }
        }

        private static bool DoCalculateAgaing()
        {
            bool repeatCalculation = false;
            bool goodInput = false;
            string? input;

            Console.WriteLine("Run calculation again? Enter Y or N");
            do
            {
                input = Console.ReadLine();
                if (input != "Y" && input != "N")
                {
                    Console.WriteLine("Invalid format, please try again. Enter Y or N");
                } 
                else
                {
                    goodInput = true;
                    repeatCalculation = (input == "Y");
                }
            }
            while (!goodInput);
            
            return repeatCalculation;
        }


        
    }
}