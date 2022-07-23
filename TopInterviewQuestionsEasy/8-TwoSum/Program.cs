using System;
using System.Collections.Generic;

namespace _;

class Program
{
    static void Main(string[] args)
    {
        var nums = new int[] {2,7,11,15};
        Console.WriteLine(String.Join(',',TwoSum(nums,9)));
        nums = new int[] {3,2,4};
        Console.WriteLine(String.Join(',',TwoSum(nums,6)));
        nums = new int[] {3,3};
        Console.WriteLine(String.Join(',',TwoSum(nums,6)));
        nums = new int[] {-1,-2,-3,-4,-5};
        Console.WriteLine(String.Join(',',TwoSum(nums,-8)));
    }

    // O(n) solution
    public static int[] TwoSum(int[] nums, int target)
    {
        var dic = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            if (dic.ContainsKey(target - nums[i]))
            {
                return new int[] {dic[target - nums[i]], i};
            }
            else
            {
                // NLS: Newly learned syntax
                // Not necessary to use Add and TryAdd here
                // If exists value will be replaced and not will be created
                dic[nums[i]] = i;
            }
        }

        return new int[2];
    }

    // O(n2) => Approximate
    public static int[] TwoSumBig_O_NSquare(int[] nums, int target)
    {
        var result = new int[2];
        var dic = new Dictionary<int, List<int>>();

        // O(n)
        for (int i = 0; i < nums.Length; i++)
        {
            if (dic.ContainsKey(nums[i]))
            {
                dic[nums[i]].Add(i);
            }
            else
            {
                dic.Add(nums[i], new List<int>{i});
            }
        }

        // O(n)
        int val = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            val = target - nums[i];

            if (dic.ContainsKey(val) && dic[val].Any(x => x > i))
            {
                result[0] = i;
                result[1] = dic[val].Where(x => x > i).First();
                break;
            }
        }

        return result;
    }

    // Bruteforce
    public static int[] TwoSumBruteforce(int[] nums, int target)
    {
        var result = new int[2];

        // O(n)
        for (int i = 0; i < nums.Length; i++)
        {
            // O(?)
            for (int j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] + nums[j] == target)
                {
                    result[0] = i;
                    result[1] = j;
                    i = nums.Length + 1;
                    break;
                }
            }
        }

        return result;
    }
}