namespace _
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(IsIsomorphic("egg", "add"));
            Console.WriteLine(IsIsomorphic("foo", "bar"));
            Console.WriteLine(IsIsomorphic("paper", "title"));

            // First wrong submission test case
            Console.WriteLine(IsIsomorphic("badc", "baba"));
        }

        public static bool IsIsomorphic(string s, string t)
        {
            if (s.Equals(t))
            {
                return true;
            }

            if (s.Length != t.Length)
            {
                return false;
            }

            var dic = new Dictionary<char, char>();
            var usedChars = new Dictionary<char, char>();

            for (int i = 0; i < s.Length; i++)
            {
                if (dic.ContainsKey(s[i]))
                {
                    if (t[i] != dic[s[i]])
                    {
                        return false;
                    }
                }
                else
                {
                    if (!usedChars.ContainsKey(t[i]))
                    {
                        dic.Add(s[i], t[i]);
                        usedChars.Add(t[i], t[i]);
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}

// https://leetcode.com/problems/isomorphic-strings/