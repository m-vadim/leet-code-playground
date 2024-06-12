/// <summary>
/// https://leetcode.com/problems/sort-colors
/// </summary>
public class Solution {
	public void SortColors(int[] nums) {
		var count = new int[3];
		foreach (var color in nums) {
			count[color] += 1;
		}

		var start = 0;
		for (var i = 0; i <= 2; i++) {
			if (count[i] > 0) {
				Array.Fill(nums, i, start, count[i]);
				start += count[i];
			}
		}
	}
}
