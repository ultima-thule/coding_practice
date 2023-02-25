using System;


namespace csharp_practice
{
    internal class LT372
    {
        public static void Run()
        {
            string s = "axc", t = "ahbgdc";

            int LastIndex = -1;
            bool found = true;

            for (int i = 0; i < s.Length; i++)
            {
                int index = t.IndexOf(s[i], LastIndex + 1);
                if (index >= 0 && index > LastIndex)
                {
                    LastIndex = index;
                    found = true;
                }
                else
                {
                    found = false;
                    break;
                }
            }
        }
    }
}