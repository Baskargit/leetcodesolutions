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

        // Failed test cases
        // Reason : Not understood the problem correctly. Only focused on the output and chaned existing code according to the failed test cases
        // Learning: Read problem more than twice and do not write or update code as per failed test cases
        num1 = new int[] {2,1};
        num2 = new int[] {1,2};
        Console.WriteLine(String.Join(',',Intersect(num1, num2)));

        num1 = new int[] {3,1,2};
        num2 = new int[] {1,3};
        Console.WriteLine(String.Join(',',Intersect(num1, num2)));

        num1 = new int[] {1,2,2,1};
        num2 = new int[] {1,1};
        Console.WriteLine(String.Join(',',Intersect(num1, num2)));

        num1 = new int[] {1,2};
        num2 = new int[] {1,1};
        Console.WriteLine(String.Join(',',Intersect(num1, num2)));

        num1 = new int[] {4,7,9,7,6,7};
        num2 = new int[] {5,0,0,6,1,6,2,2,4};
        Console.WriteLine(String.Join(',',Intersect(num1, num2)));

        num1 = new int[] {9,3,7};
        num2 = new int[] {6,4,1,0,0,4,4,8,7};
        Console.WriteLine(String.Join(',',Intersect(num1, num2)));

        num1 = new int[] {3,1,2};
        num2 = new int[] {1,1};
        Console.WriteLine(String.Join(',',Intersect(num1, num2)));
    }

    public static int[] Intersect(int[] nums1, int[] nums2)
    {
        if (nums2.Length < nums1.Length)
        {
            var temp = nums1;
            nums1 = nums2;
            nums2 = temp;
        }

        var dic = new Dictionary<int, int>();
        var list = new List<int>();

        for (int i = 0; i < nums1.Length; i++)
        {
            if (dic.ContainsKey(nums1[i]))
            {
                dic[nums1[i]]++;
            }
            else
            {
                dic.Add(nums1[i],1);
            }
        }

        for (int i = 0; i < nums2.Length; i++)
        {
            if (dic.ContainsKey(nums2[i]))
            {
                list.Add(nums2[i]);

                if (dic[nums2[i]] - 1 == 0)
                {
                    dic.Remove(nums2[i]);
                }
                else
                {
                    dic[nums2[i]]--;
                }
            }

            if (dic.Count <= 0)
            {
                break;
            }
        }

        return list.ToArray();
    }

    public static int[] FindIntersect(int[] nums1, int[] nums2)
    {
        int startIndex = -1, endIndex = -1;
        int indexLength = -1;
        for (int i = 0; i < nums1.Length; i++)
        {
            for (int l = 0; l < nums2.Length; l++)
            {
                if (nums1[i] == nums2[l])
                {
                    // Right side intersection
                    int tempIndexLength = 1, tempEndIndex = l;
                    bool isMathFound = false;

                    for (int j = i+1,k = l + 1; j < nums1.Length && k < nums2.Length; j++)
                    {
                        if (nums1[j] == nums2[k])
                        {
                            tempIndexLength++;
                            tempEndIndex = k;
                            isMathFound = true;
                            k++;
                        }
                        else
                        {
                            if (isMathFound)
                            {
                                break;
                            }
                        }
                    }

                    if (tempIndexLength > indexLength)
                    {
                        startIndex = 0;
                        endIndex = tempEndIndex;
                        indexLength = tempIndexLength;
                    }

                    // Leftside intersection
                    tempIndexLength = 1;
                    tempEndIndex = l;
                    isMathFound = false;

                    for (int j = i - 1, k = l + 1; j >= 0 && k < nums2.Length; j--)
                    {
                        if (nums1[j] == nums2[k])
                        {
                            tempIndexLength++;
                            tempEndIndex = k;
                            isMathFound = true;
                            k++;
                        }
                        else
                        {
                            if (isMathFound)
                            {
                                break;
                            }
                        }
                    }

                    if (tempIndexLength > indexLength)
                    {
                        startIndex = l;
                        endIndex = tempEndIndex;
                        indexLength = tempIndexLength;
                    }
                }
            }
        }

        if (indexLength > 0)
        {
            var intersectArray = new int[(endIndex - startIndex) + 1];
            for (int i = startIndex,j = 0; i <= endIndex; i++)
            {
                intersectArray[j++] = nums2[i];
            }

            return intersectArray;
        }

        return new int[] {};
    }
}

// https://leetcode.com/explore/featured/card/top-interview-questions-easy/92/array/674/