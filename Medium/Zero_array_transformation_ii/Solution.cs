/// <summary>
///     https://leetcode.com/problems/zero-array-transformation-ii
/// </summary>
public class Solution {
	public int MinZeroArray(int[] nums, int[][] queries) {
		int left = 0, right = queries.Length - 1;

		if (IsZeroArray(nums, queries, -1)) {
			return 0;
		}

		if (!IsZeroArray(nums, queries, right)) {
			return -1;
		}

		while (left <= right) {
			var mid = left + (right - left) / 2;
			if (IsZeroArray(nums, queries, mid)) {
				right = mid - 1;
			} else {
				left = mid + 1;
			}
		}

		return left + 1;
	}

	private static bool IsZeroArray(int[] nums, int[][] queries, int limitIndex) {
		var prefixSum = new int[nums.Length + 1];

		int from, to, value;
		for (var i = 0; i <= limitIndex; i++) {
			var query = queries[i];
			from = query[0];
			to = query[1];
			value = query[2];

			prefixSum[from] += value;
			prefixSum[to + 1] -= value;
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
