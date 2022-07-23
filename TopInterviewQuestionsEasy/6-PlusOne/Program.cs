using System;
using System.Collections.Generic;

namespace _;

class Program
{
    static void Main(string[] args)
    {
        var digits = new int[] {1,2,3};
        Console.WriteLine(String.Join(',', PlusOne(digits)));
        digits = new int[] {1,9};
        Console.WriteLine(String.Join(',', PlusOne(digits)));
        digits = new int[] {9,9,9};
        Console.WriteLine(String.Join(',', PlusOne(digits)));
        digits = new int[] {9};
        Console.WriteLine(String.Join(',', PlusOne(digits)));
        digits = new int[] {1};
        Console.WriteLine(String.Join(',', PlusOne(digits)));
    }

    public static int[] PlusOne(int[] digits)
    {
        if (digits == null || !digits.Any())
        {
            return digits;
        }

        if (digits[digits.Length - 1] < 9)
        {
            digits[digits.Length - 1]++;
            return digits;
        }

        int sum = 0;
        int remainder = 1;

        for (int i = digits.Length - 1; i >= 0; i--)
        {
            sum = digits[i] + remainder;

            if (sum > 9)
            {
                remainder = sum % 10;
                if (remainder == 0)
                {
                    digits[i] = 0;
                    remainder = sum / 10;
                }
                else
                {
                    digits[i] = sum / 10;
                }
            }
            else
            {
                digits[i] = sum;
                remainder = 0;
            }
        }

        if (remainder > 0)
        {
            var addedResult = new int[digits.Length + 1];
            addedResult[0] = remainder;

            for (int i = 1; i < digits.Length; i++)
            {
                addedResult[i] = digits[i];
            }

            return addedResult;
        }
        else
        {
            return digits;
        }
    }
}