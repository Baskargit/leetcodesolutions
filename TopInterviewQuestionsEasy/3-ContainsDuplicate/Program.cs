using System;
using System.Collections.Generic;

namespace _;

class Program
{
    static void Main(string[] args)
    {
        var nums = new int[]{1,2,3,1};
        Console.WriteLine(ContainsDuplicate(nums));
        nums = new int[]{1,2,3,4};
        Console.WriteLine(ContainsDuplicate(nums));
        nums = new int[]{1,1,1,3,3,4,3,2,4,2};
        Console.WriteLine(ContainsDuplicate(nums));
    }

    public static bool ContainsDuplicate(int[] nums)
    {
        var list = new List<int>();

        for (int i = 0; i < nums.Length; i++)
        {
            if (list.Contains(nums[i]))
            {
                return true;
            }
            else
            {
                list.Add(nums[i]);
            }
        }

        // Check it is possible to solve in O(n)time and O(1)space

        return false;
    }
}