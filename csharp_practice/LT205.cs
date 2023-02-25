using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_practice
{
    internal class LT205
    {
        static bool UpdateDict(Dictionary<char, char> dict, char c1, char c2)
        {
            if (dict.ContainsKey(c1) && dict[c1] != c2)
            {
                return false;
            }
            else if (!dict.ContainsKey(c1))
            {
                dict.Add(c1, c2);
            }
            return true;
        }
        static bool CheckWords(string s, string t)
        {
            Dictionary<char, char> dict = new Dictionary<char, char>();
            Dictionary<char, char> dictRev = new Dictionary<char, char>();

            for (int i = 0; i < s.Length; i++)
            {
                if (!UpdateDict(dict, s[i], t[i])
                || !UpdateDict(dictRev, t[i], s[i]))
                {
                    return false;
                }
            }
            return true;
        }
        public static void Run()
        {
            string s = "badc", t = "baba";
            bool result = CheckWords(s, t);
        }
    }
}
