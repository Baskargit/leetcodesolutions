using System;
using System.Collections.Generic;

namespace _2_FindPivotIndex
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(PivotIndex(new int[] {1,7,3,6,5,6}));
            Console.WriteLine(PivotIndex(new int[] {1,2,3}));
        }

        public static int PivotIndex(int[] nums)
        {
            int wholeSum = 0, runningSum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                wholeSum += nums[i];
            }

            for (int i = 0; i < nums.Length; i++)
            {
                wholeSum -= nums[i];
                
                if (wholeSum == runningSum)
                {
                    return i;
                }

                runningSum += nums[i];
            }

            return -1;
        }
    }
}

// Link: https://leetcode.com/problems/find-pivot-index/