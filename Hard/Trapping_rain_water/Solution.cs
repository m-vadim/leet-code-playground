/// <summary>
///     https://leetcode.com/problems/trapping-rain-water/
/// </summary>
public class Solution {
	public int Trap(int[] heights) {
		int trapped = 0;
		int left = 0, right = heights.Length - 1;
		int leftMax = heights[left], rightMax = heights[right];
		while (left < right) {
			if (leftMax <= rightMax) {
				left += 1;
				leftMax = Math.Max(leftMax, heights[left]);
				trapped += (leftMax - heights[left]);
			} else {
				right -= 1;
				rightMax = Math.Max(rightMax, heights[right]);
				trapped += (rightMax - heights[right]);
			}
		}

		return trapped;
	}
}
