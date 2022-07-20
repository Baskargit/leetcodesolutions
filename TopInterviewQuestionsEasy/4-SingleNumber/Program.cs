using System;
using System.Collections.Generic;

namespace _;

class Program
{
    static void Main(string[] args)
    {
        var nums = new int[] {2,2,1};
        Console.WriteLine(SingleNumber(nums));
        nums = new int[] {4,1,2,1,2};
        Console.WriteLine(SingleNumber(nums));
        nums = new int[] {1};
        Console.WriteLine(SingleNumber(nums));
    }

    public static int SingleNumber(int[] nums)
    {
        // Can be futher memory optimized by using HashSet
        int num = 0, temp = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            temp = nums[i];
            nums[i] = nums[i] != 0 ? 0 : -1;
            
            if (!nums.Contains(temp))
            {
                nums[i] = temp;
                num = temp;
                break;
            }

            nums[i] = temp;
        }

        return num;
    }
}