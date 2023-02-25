using System;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
namespace csharp_practice
{
    internal class CG_AsciiArt
    {
        static Dictionary<char, string[]> SeparateLetters(string[] readRows, int width, int height)
        {
            Dictionary<char, string[]> result = new Dictionary<char, string[]>();
            string pattern = "ABCDEFGHIJKLMNOPQRSTUVWXYZ?";
            string[] letterPattern;

            for (int i = 0; i < pattern.Length; i ++)
            {
                letterPattern = new string[height];
                for (int j = 0; j < height; j++)
                {
                    letterPattern[j] = readRows[j][(i*width)..((i+1)*width)];
                }

                result.Add(pattern[i], letterPattern);
            }

            return result;
        }

        static void AppendRow(string[] results, string[] letterPattern)
        {
            for (int i = 0; i < results.Length; i++)
            {
                results[i] += letterPattern[i];
            }
        }

        static string[] MergeResult(string text, int height, Dictionary<char, string[]> letterPatterns)
        {
            string[] resultRow = new string[height];
            text = text.ToUpper();
            foreach (char c in text)
            {
                if (letterPatterns.ContainsKey(c))
                {
                    AppendRow(resultRow, letterPatterns[c]);
                }
                else
                {
                    AppendRow(resultRow, letterPatterns['?']);
                }
            }
            return resultRow;
        }

        static void WriteResult(string[] resultRow)
        { 
            for (int i = 0; i<resultRow.Length; i++)
            {
                Console.WriteLine(resultRow[i]);
            }
        }

        public static void Run()
        {
            int L = 4;
            int H = 5;
            string T = "ASIA";

            string[] rows = new string[5] { 
                " #  ##   ## ##  ### ###  ## # # ###  ## # # #   # # ###  #  ##   #  ##   ## ### # # # # # # # # # # ### ### ", 
                "# # # # #   # # #   #   #   # #  #    # # # #   ### # # # # # # # # # # #    #  # # # # # # # # # #   #   # ", 
                "### ##  #   # # ##  ##  # # ###  #    # ##  #   ### # # # # ##  # # ##   #   #  # # # # ###  #   #   #   ## ", 
                "# # # # #   # # #   #   # # # #  #  # # # # #   # # # # # # #    ## # #   #  #  # # # # ### # #  #  #       ", 
                "# # ##   ## ##  ### #    ## # # ###  #  # # ### # # # #  #  #     # # # ##   #  ###  #  # # # #  #  ###  #  "
            };

            // Write an answer using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");

            Dictionary<char, string[]> letterPatterns = SeparateLetters(rows, L, H);

            string[] resultRow = MergeResult(T, H, letterPatterns);
            WriteResult(resultRow);


            Console.WriteLine("answer");
        }
    }
}