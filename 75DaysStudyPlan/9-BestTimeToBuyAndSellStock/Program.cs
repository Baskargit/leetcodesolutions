using System;
using System.Collections.Generic;

namespace _
{
    class Program
    {
        static void Main(string[] args)
        {
            // 7:57AM
            int[] prices = new int[]{7,1,5,3,6,4};
            Console.WriteLine(MaxProfit(prices));
            prices = new int[]{7,6,4,3,1};
            Console.WriteLine(MaxProfit(prices));
        }

        // Naive approach
        public static int MaxProfit(int[] prices)
        {
            int maxProfit = 0;
            int currentProfit = 0;
            for (int i = 0; i < prices.Length; i++)
            {
                for (int j = i+1; j < prices.Length; j++)
                {
                    currentProfit = prices[j] - prices[i];
                    maxProfit = currentProfit > maxProfit ? currentProfit : maxProfit;
                }
            }

            return maxProfit;
        }

        public static int MaxProfitRecursive(int[] prices, int i, int j)
        {
            if (i < prices.Length)
            {
                int maxProfit = 0;

                if (j < prices.Length)
                {
                    
                }

                return MaxProfitRecursive(prices, i+1, i+2);
            }
            
            return 0;
        }
    }
}