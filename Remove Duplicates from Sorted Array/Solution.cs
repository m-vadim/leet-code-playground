namespace LeetCode;

// https://leetcode.com/problems/remove-duplicates-from-sorted-array/
public sealed class Solution {
    public int RemoveDuplicates(int[] nums) {
        int nextDiff = 1;
        if (nums.Length == 1) {
            return nextDiff;
        }
        
        for (int i = 1; i < nums.Length; i++) {
            if (nums[i] != nums[i - 1]) {
                nums[nextDiff] = nums[i];
                nextDiff++;
            }
        }

        return nextDiff;
    }
}