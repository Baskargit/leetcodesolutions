using System;
using System.Collections.Generic;

namespace _;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(fibrecursive(45));
    }

    public static ulong fibrecursive(uint n)
    {
        if (n == 0 || n == 1)
        {
            return n;
        }

        return fibrecursive(n - 1) + fibrecursive(n - 2);
    }

    public static ulong fibnaive(uint n)
    {
        if (n == 0 || n == 1)
        {
            return n;
        }

        ulong num1 = 0, num2 = 1;
        ulong temp = num2;
        while (n > 1)
        {
            temp = num2;
            num2 += num1;
            num1 = temp;
            n--;
        }

        return num2;
    }
}