/// <summary>
///     https://leetcode.com/problems/jump-game/
/// </summary>
public class Solution {
	public bool CanJump(int[] nums) {
		if (nums.Length == 1) {
			return true;
		}

		int destination = nums.Length - 1, fromIndex = destination - 1;
		while (fromIndex > 0) {
			if (CanReach(fromIndex, destination, nums[fromIndex])) {
				destination = fromIndex;
			}
			fromIndex--;
		}

		return CanReach(fromIndex, destination, nums[fromIndex]);
	}

	private static bool CanReach(int fromIndex, int toIndex, int jump) {
		return (toIndex - fromIndex) <= jump;
	}
}
