using System;
using System.Collections.Generic;

namespace _;

class Program
{
    static void Main(string[] args)
    {
        var num1 = new int[] {1,2,2,1};
        var num2 = new int[] {2,2};
        Console.WriteLine(String.Join(',',Intersect(num1, num2)));

        num1 = new int[] {4,9,5};
        num2 = new int[] {9,4,9,8,4};
        Console.WriteLine(String.Join(',',Intersect(num1, num2)));

        num1 = new int[] {1};
        num2 = new int[] {9,4,9,8,4};
        Console.WriteLine(String.Join(',',Intersect(num1, num2)));

        num1 = new int[] {1};
        num2 = new int[] {9,4,9,8,1};
        Console.WriteLine(String.Join(',',Intersect(num1, num2)));

        num1 = new int[] {};
        num2 = new int[] {};
        Console.WriteLine(String.Join(',',Intersect(num1, num2)));

        // Failed test case
        num1 = new int[] {2,1};
        num2 = new int[] {1,2};
        Console.WriteLine(String.Join(',',Intersect(num1, num2)));

        num1 = new int[] {4,9,5};
        num2 = new int[] {9,4,9,8,4};
        Console.WriteLine(String.Join(',',Intersect(num1, num2)));

        num1 = new int[] {3,1,2};
        num2 = new int[] {1,3};
        Console.WriteLine(String.Join(',',Intersect(num1, num2)));
    }

    public static int[] Intersect(int[] nums1, int[] nums2)
    {
        if (nums2.Length > nums1.Length)
        {
            var temp = nums1;
            nums1 = nums2;
            nums2 = temp;
        }

        var nonSortedIntersect = FindIntersect(nums1, nums2);
        Array.Sort(nums1);
        var sortedIntersect = FindIntersect(nums1,nums2);

        return sortedIntersect.Length > nonSortedIntersect.Length
            ? sortedIntersect
            : nonSortedIntersect;
    }

    public static int[] FindIntersect(int[] nums1, int[] nums2)
    {
        int startIndex = -1, endIndex = -1;
        int indexLength = -1;
        for (int i = 0; i < nums1.Length; i++)
        {
            if (nums1[i] == nums2[0])
            {
                int tempIndexLength = 1, tempEndIndex = i;

                for (int j = i+1,k = 1; j < nums1.Length && k < nums2.Length; j++,k++)
                {
                    if (nums1[j] == nums2[k])
                    {
                        tempIndexLength++;
                        tempEndIndex = j;
                    }
                    else
                    {
                        break;
                    }
                }

                if (tempIndexLength > indexLength)
                {
                    startIndex = i;
                    endIndex = tempEndIndex;
                    indexLength = tempIndexLength;
                }
            }
        }

        if (indexLength != -1)
        {
            var intersectArray = new int[(endIndex - startIndex) + 1];
            for (int i = startIndex,j = 0; i <= endIndex; i++)
            {
                intersectArray[j++] = nums1[i];
            }

            return intersectArray;
        }

        return new int[] {};
    }
}