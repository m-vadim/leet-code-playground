namespace LeetCode;

/// <summary>
/// https://leetcode.com/problems/container-with-most-water/
/// </summary>
public sealed class Solution {
	public int MaxArea(int[] height) {
		int max = 0;
		int left = 0, right = height.Length - 1;
		while (left < right) {
			int area = (right - left) * Math.Min(height[left], height[right]);
			max = Math.Max(max, area);

			if (height[left] < height[right]) {
				left++;
			} else {
				right--;
			}
		}


		return max;
	}
}
