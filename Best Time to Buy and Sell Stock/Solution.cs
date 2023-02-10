// https://leetcode.com/problems/best-time-to-buy-and-sell-stock/

namespace LeetCode; 

public class Solution {
    public int MaxProfit(int[] prices) {
        int previousMaxPrice = 0;
        int maxProfit = 0;

        for (int i = prices.Length - 1; i >= 0; i--) {
            int thisDayPrice = prices[i];
            if (thisDayPrice > previousMaxPrice) {
                previousMaxPrice = thisDayPrice;
                continue;
            }

            int diff = (previousMaxPrice - thisDayPrice);
            if (diff > maxProfit) {
                maxProfit = diff;
            }
        }

        return maxProfit;
    }
}