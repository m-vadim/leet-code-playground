/// <summary>
/// https://leetcode.com/problems/minimum-increment-to-make-array-unique
/// </summary>
public class Solution {
	public int MinIncrementForUnique(int[] nums) {
		Array.Sort(nums);
		int moves = 0, lastNum = -1;
		for (var i = 0; i < nums.Length; i++) {
			var num = nums[i];
			if (num > lastNum) {
				lastNum = num;
				continue;
			}

			moves += lastNum - num + 1;
			num = lastNum + 1;
			lastNum = num;
		}

		return moves;
	}
}
