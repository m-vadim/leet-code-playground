/// <summary>
///     https://leetcode.com/problems/zero-array-transformation-i/
/// </summary>
public class Solution {
	public bool IsZeroArray(int[] nums, int[][] queries) {
		var prefixSum = new int[nums.Length];

		foreach (var query in queries) {
			int from = query[0];
			int to = query[1];

			prefixSum[from] += 1;
			if (to + 1 < nums.Length) {
				prefixSum[to + 1] -= 1;
			}
		}

		var runningSum = 0;
		for (var index = 0; index < nums.Length; index++) {
			runningSum += prefixSum[index];
			if (nums[index] > runningSum) {
				return false;
			}
		}

		return true;
	}
}
