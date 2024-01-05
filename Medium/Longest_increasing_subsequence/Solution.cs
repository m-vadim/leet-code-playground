namespace LeetCode;

/// <summary>
/// https://leetcode.com/problems/longest-increasing-subsequence
/// </summary>
public class Solution {
    public int LengthOfLIS(int[] nums) {
        var lisCountToTheLeft = new int[nums.Length];
        lisCountToTheLeft[0] = 1;

        int max = 1, lis = 1;
        
        for (int i = 1; i < nums.Length; i++) {
            int current = nums[i];
            if (current != nums[i - 1]) {
                lis = 1;
                for (int y = 0; y < i; y++) {
                    if (nums[y] < current) {
                        lis = Math.Max(lis, lisCountToTheLeft[y] + 1);
                    }
                }
            }
            else {
                lis = lisCountToTheLeft[i - 1];
            }

            lisCountToTheLeft[i] = lis;
            max = Math.Max(max, lis);
        }

        return max;
    }
}