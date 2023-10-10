namespace LeetCode;

/// <summary>
/// https://leetcode.com/problems/find-pivot-index
/// </summary>
public class Solution {
	public int PivotIndex(int[] nums) {
		int sum = 0;
		foreach (int n in nums) {
			sum += n;
		}

		int leftSum = 0;
		for (var index = 0; index < nums.Length; index++) {
			sum -= nums[index];
			if (leftSum == sum) {
				return index;
			}
			
			leftSum += nums[index];
		}
		
		return -1;
	}
}