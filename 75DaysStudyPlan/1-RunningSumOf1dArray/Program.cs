using System;
using System.Collections.Generic;

namespace _1_RunningSumOf1dArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = RunningSum(new int[]{1,2,3,4});
            Console.WriteLine(String.Join(',', result));
        }

        public static int[] RunningSum(int[] nums) 
        {
            var result = new List<int>();
            int previousSum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                previousSum += nums[i];
                result.Add(previousSum);
            }
            return result.ToArray();
        }
    }
}

// Link: https://leetcode.com/problems/running-sum-of-1d-array/
// Date: July 7th 2022
