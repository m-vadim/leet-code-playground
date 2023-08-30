// https://leetcode.com/problems/maximum-subarray

public class Solution {
	public int MaxSubArray(int[] nums) {
		int globalMaximum = nums[0];
		var localMaximum = 0;

		foreach (int num in nums) {
			localMaximum = Math.Max(num, num + localMaximum);

			if (localMaximum > globalMaximum) globalMaximum = localMaximum;
		}

		return globalMaximum;
	}

	public int MaxSubArrayBrute(int[] nums) {
		int globalMaximum = nums[0];
		for (var i = 0; i < nums.Length; i++) {
			int sum = nums[i], localMaximum = sum;

			for (int j = i + 1; j < nums.Length; j++) {
				sum += nums[j];
				if (sum > localMaximum) localMaximum = sum;
			}

			if (localMaximum > globalMaximum) globalMaximum = localMaximum;
		}

		return globalMaximum;
	}
}