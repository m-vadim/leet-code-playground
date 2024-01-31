/// <summary>
/// https://leetcode.com/problems/remove-element
/// </summary>
public class Solution {
	public int RemoveElement(int[] nums, int val) {
		int right = nums.Length - 1, left = 0;

		while (left < nums.Length) {
			while (left < nums.Length && nums[left] != val) {
				left++;
			}
			
			while (right > 0 && nums[right] == val) {
				right--;
			}

			if (left >= right) {
				break;
			}

			(nums[left], nums[right]) = (nums[right], nums[left]);
		}

		return left;
	}
}