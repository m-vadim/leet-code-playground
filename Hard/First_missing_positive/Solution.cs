namespace LeetCode;

/// <summary>
/// https://leetcode.com/problems/first-missing-positive
/// </summary>
public class Solution {
	public int FirstMissingPositive(int[] nums) {
		int limit = nums.Length + 1;
		for (var index = 0; index < nums.Length; index++) {
			if (nums[index] <= 0) {
				nums[index] = limit;
			}
		}

		foreach (int num in nums) {
			int absNum = Math.Abs(num);
			if (absNum < limit && nums[absNum - 1] > 0) {
				nums[absNum - 1] = -nums[absNum - 1];
			}
		}

		for (var index = 0; index < nums.Length; index++) {
			if (nums[index] > 0) {
				return index + 1;
			}
		}

		return limit;
	}
}