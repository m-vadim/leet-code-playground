namespace LeetCode;

/// <summary>
/// https://leetcode.com/problems/maximum-average-subarray-i
/// </summary>
public class Solution {
	public double FindMaxAverage(int[] nums, int k) {
		double maxAvg = 0, divider = k;

		for (var i = 0; i < k; i++) {
			maxAvg += nums[i];
		}
		
		maxAvg /= divider;
		double windowAverage = maxAvg;

		for (int i = k; i < nums.Length; i++) {
			windowAverage = windowAverage + (nums[i] / divider) - (nums[i - k] / divider) ;
			maxAvg = Math.Max(windowAverage, maxAvg);
		}

		return maxAvg;
	}
}