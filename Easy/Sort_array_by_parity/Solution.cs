namespace LeetCode;

// https://leetcode.com/problems/sort-array-by-parity/
public class Solution {
	public int[] SortArrayByParity(int[] nums) {
		int leftPointer = 0, rightPointer = nums.Length - 1;
		while (leftPointer < rightPointer) {
			if (nums[leftPointer] % 2 != 0) {
				if (nums[rightPointer] % 2 == 0) {
					(nums[leftPointer], nums[rightPointer]) = (nums[rightPointer], nums[leftPointer]);
					rightPointer--;
				}
				else {
					while (--rightPointer > leftPointer && nums[rightPointer] % 2 != 0) { }

					(nums[leftPointer], nums[rightPointer]) = (nums[rightPointer], nums[leftPointer]);
					rightPointer--;
				}
			}

			leftPointer++;
		}

		return nums;
	}
}