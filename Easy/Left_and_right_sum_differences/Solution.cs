/// <summary>
/// https://leetcode.com/problems/left-and-right-sum-differences/
/// </summary>
public sealed class Solution {
    public int[] LeftRightDifference(int[] nums) {
		int sum = 0;
		foreach (int n in nums) {
			sum += n;
		}

		int leftsum = 0, rightSum = sum;
		int[] result = new int[nums.Length];
		for (int i = 0; i < nums.Length; i++) {
			rightSum -= nums[i];
			result[i] = Math.Abs(rightSum - leftsum);
			leftsum += nums[i];
		}

		return result;
	}
}
