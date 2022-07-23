using System;
using System.Collections.Generic;

namespace _;

class Program
{
    static void Main(string[] args)
    {
        // 11:00AM
        var nums = new int[] {0,1,0,3,12};
        MoveZeroes(nums);
        Console.WriteLine(String.Join(',',nums));
        nums = new int[] {1,3,12,0,12};
        MoveZeroes(nums);
        Console.WriteLine(String.Join(',',nums));
        nums = new int[] {0,0,1,0,0};
        MoveZeroes(nums);
        Console.WriteLine(String.Join(',',nums));
        nums = new int[] {0,0};
        MoveZeroes(nums);
        Console.WriteLine(String.Join(',',nums));
        nums = new int[] {1,1,0,3,12};
        MoveZeroes(nums);
        Console.WriteLine(String.Join(',',nums));
        nums = new int[] {1,4,2,3,12};
        MoveZeroes(nums);
        Console.WriteLine(String.Join(',',nums));
    }

    public static void MoveZeroes(int[] nums)
    {
        int temp = 0,j = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] != 0)
            {
                temp = nums[j];
                nums[j] = nums[i];
                nums[i] = temp;
                j++;
            }
        }
    }
}