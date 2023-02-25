using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace csharp_practice
{
    internal class CG_LogicGates
    {
        public static void Run()
        {
            Dictionary<string, bool[]> inData = new Dictionary<string, bool[]>();

            string[] inputs;
            int n = 2;
            int m = 3;

            string[] inputData = new string[] { "A __---___---___---___---___", "B ____---___---___---___---_" };
            string[] outputData = new string[] { "C AND A B", "D OR A B", "E XOR A B" };

            for (int i = 0; i < n; i++)
            {
                inputs = inputData[i].Split(' ');
                string inputName = inputs[0];
                string inputSignal = inputs[1];
                inData.Add(inputName, TransformInputSignal(inputSignal));
            }

            for (int i = 0; i < m; i++)
            {
                inputs = outputData[i].Split(' ');
                string outputName = inputs[0];
                string operation = inputs[1];
                string signalA = inputs[2];
                string signalB = inputs[3];

                Console.WriteLine($"{outputName} {Calculate(operation, inData[signalA], inData[signalB])}");
            }
        }

        private static string Calculate(string operation, bool[] signalA, bool[] signalB)
        {
            bool[] res = new bool[signalA.Length];
            string result = "";

            for (int i = 0; i < signalA.Length; i++)
            {
                bool argA = signalA[i];
                bool argB = signalB[i];
                bool stepResult = true;

                switch (operation)
                {
                    case "AND":
                        stepResult = argA & argB;
                        break;
                    case "OR":
                        stepResult = argA | argB;
                        break;
                    case "XOR":
                        stepResult = argA ^ argB;
                        break;
                    case "NAND":
                        stepResult = !(argA & argB);
                        break;
                    case "NOR":
                        stepResult = !(argA | argB);
                        break;
                    case "NXOR":
                        stepResult = !(argA ^ argB);
                        break;
                }
                result += TransformOutputSignal(stepResult);
           }

            return result;
        }

        private static string TransformOutputSignal(bool data)
        {
            return data ? "-" : "_"; 
        }

        private static bool[] TransformInputSignal(string inputSignal)
        {
            bool[] result = new bool[inputSignal.Length];
            for (int i = 0; i < inputSignal.Length; i++)
            {
                result[i] = (inputSignal[i] == '-');
            }
            return result;
        }
    }
}
