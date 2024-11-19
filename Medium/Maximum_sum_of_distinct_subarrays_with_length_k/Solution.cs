/// <summary>
///     https://leetcode.com/problems/maximum-sum-of-distinct-subarrays-with-length-k
/// </summary>
public class Solution {
	public long MaximumSubarraySum(int[] nums, int k) {
		int left = 0, index = 0;
		var hs = new HashSet<int>(k);
		long sum = 0, result = 0;

		while (index < nums.Length) {
			int el = nums[index];
			if (hs.Count == k) {
				result = Math.Max(sum, result);
			}

			while (hs.Contains(el) || hs.Count == k) {
				hs.Remove(nums[left]);
				sum -= nums[left];
				left++;
			}

			hs.Add(el);
			sum += el;
			index++;
		}

		if (hs.Count == k) {
			result = Math.Max(sum, result);
		}

		return result;
	}
}
