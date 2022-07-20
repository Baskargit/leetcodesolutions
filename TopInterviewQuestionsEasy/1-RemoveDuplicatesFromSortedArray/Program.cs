using System;
using System.Collections.Generic;

namespace _;

class Program
{
    static void Main(string[] args)
    {
        // Took 15mins to solve
        var array = new int[] {1,1,2,2,3,6};
        int k = RemoveDuplicates(array);
        Console.WriteLine(k + " " +string.Join(',',array));
        array = new int[] {1,2,3,6};
        k = RemoveDuplicates(array);
        Console.WriteLine(k + " " +string.Join(',',array));
        array = new int[] {0,0,1,1,1,2,2,3,3,4};
        k = RemoveDuplicates(array);
        Console.WriteLine(k + " " +string.Join(',',array));
    }

    public static int RemoveDuplicates(int[] nums)
    {
        if (nums == null || nums.Length == 0)
        {
            return 0;
        }

        int k = 1;
        int currentNum = nums[0];

        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] != currentNum)
            {
                nums[k++] = nums[i];
                currentNum = nums[i];
            }
        }

        return k;
    }
}

// https://leetcode.com/explore/featured/card/top-interview-questions-easy/92/array/727/