using System;
using System.Collections.Generic;

namespace _;

class Program
{
    static void Main(string[] args)
    {
        // 5:36 -
        int k = 3;
        var array = new int[]{1,2,3,4,5,6,7};
        Rotate(array, k);
        Console.WriteLine(string.Join(',',array));

        // k = 1;
        // array = new int[]{-1,-100,3,99};
        // Rotate(array, k);
        // Console.WriteLine(string.Join(',',array));

        // k = 2;
        // array = new int[]{-1,-100,3,99};
        // Rotate(array, k);
        // Console.WriteLine(string.Join(',',array));

        // k = 3;
        // array = new int[]{-1,-100,3,99};
        // Rotate(array, k);
        // Console.WriteLine(string.Join(',',array));

        // k = 4;
        // array = new int[]{-1,-100,3,99};
        // Rotate(array, k);
        // Console.WriteLine(string.Join(',',array));

        // k = 786;
        // array = new int[]{-1,-100,3,99};
        // Rotate(array, k);
        // Console.WriteLine(string.Join(',',array));
    }

    public static void Rotate(int[] nums, int k)
    {
        if (k == 0 || nums == null || nums.Length == 0 || k == nums.Length)
        {
            return;
        }

        int rotate = k % nums.Length;

        while (rotate > 0)
        {
            int lastNum = nums[nums.Length - 1];
            for (int i = 0; i < nums.Length; i++)
            {
                int temp = nums[i];
                nums[i] = lastNum;
                lastNum = temp;
            }
            rotate--;
        }
    }
}