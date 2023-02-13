// https://leetcode.com/problems/count-odd-numbers-in-an-interval-range/description/
public class Solution {
    public int CountOdds(int low, int high) {
        int count = (high - low) / 2;
        if (low % 2 == 1 || high % 2 == 1) {
            count+=1;
        }

        return count;
    }
}