/// <summary>
/// https://leetcode.com/problems/binary-subarrays-with-sum
/// </summary>
public class Solution {
	public int NumSubarraysWithSum(int[] nums, int goal) {
		int count = 0, sum;

		for (int i = 0; i < nums.Length; i++) {
			sum = nums[i];
			if (sum == goal) {
				count++;
			}

			for (int j = i + 1; j < nums.Length; j++) {
				sum += nums[j];
				if (sum == goal) {
					count++;
				}
			}
		}
		
		return count;
	}
}