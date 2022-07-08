using System;
using System.Collections.Generic;

namespace _
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(IsSubsequence("abc","ahbgdc"));
            Console.WriteLine(IsSubsequence("axc","ahbgdc"));
            Console.WriteLine(IsSubsequence("aec","abcde"));

            // Firt failed testcase
            // Missed scenario => Still chars in 's', but no more chars in 't'
            Console.WriteLine(IsSubsequence("aaaaaa","bbaaaa"));
        }

        public static bool IsSubsequence(string s, string t)
        {
            if (s!=t)
            {
                int previousTPos = 0;
                bool isMatchFound = false;

                for (int i = 0; i < s.Length; i++)
                {
                    if (previousTPos >= t.Length)
                    {
                        return false;
                    }

                    for (; previousTPos < t.Length; previousTPos++)
                    {
                        if (t[previousTPos] == s[i])
                        {
                            isMatchFound = true;
                            previousTPos++;
                            break;
                        }
                    }

                    if (isMatchFound)
                    {
                        isMatchFound = false;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    
        public bool IsSubsequenceTwoPointerApproach(string s, string t)
        {
            // Below tracker variables are the two pointers => sp(s pointer) => tp(t pointer)
            var sp = 0;
            var tp = 0;

            while (sp < s.Length && tp < t.Length) {
                if (s[sp] == t[tp]) {
                    sp++;
                    tp++;
                }
                else {
                    tp++;
                }
            }
            return sp == s.Length;
        }
    }
}

// https://leetcode.com/problems/is-subsequence