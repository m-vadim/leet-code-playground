namespace LeetCode;

/// <summary>
/// https://leetcode.com/problems/increasing-triplet-subsequence
/// </summary>
public class Solution {
	public bool IncreasingTriplet(int[] nums) {
		if (nums.Length < 3) {
			return false;
		}

		int min = nums[0], max = -1, maxIndex = -1;

		for (var i = 1; i <= nums.Length - 2; i++) {
			int n = nums[i];

			if (n <= min) {
				min = n;
				continue;
			}

			if (i >= maxIndex) {
				max = nums[^1];
				maxIndex = nums.Length - 1;
				int j = maxIndex - 1;
				while (j > i) {
					if (nums[j] > max) {
						max = nums[j];
						maxIndex = j;
					}

					j--;
				}
			}

			if (n < max) {
				return true;
			}
		}

		return false;
	}
}