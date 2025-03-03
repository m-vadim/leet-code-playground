/// <summary>
///     https://leetcode.com/problems/partition-array-according-to-given-pivot
/// </summary>
public class Solution {
	public int[] PivotArray(int[] nums, int pivot) {
		int smallerNumberIndex = 0, largerNumberIndex = nums.Length - 1;
		var result = new int[nums.Length];

		int leftPointer = 0, rightPointer = largerNumberIndex;
		while (leftPointer < nums.Length) {
			if (nums[leftPointer] < pivot) {
				result[smallerNumberIndex++] = nums[leftPointer];
			}

			if (nums[rightPointer] > pivot) {
				result[largerNumberIndex--] = nums[rightPointer];
			}

			leftPointer++;
			rightPointer--;
		}

		while (smallerNumberIndex <= largerNumberIndex) {
			result[smallerNumberIndex++] = pivot;
		}

		return result;
	}
}
