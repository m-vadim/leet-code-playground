/// <summary>
/// https://leetcode.com/problems/search-in-rotated-sorted-array
/// </summary>
public sealed class Solution {
	public int Search(int[] nums, int target) {
		int pivotIndex = FindPivotIndex(nums);

		if (pivotIndex == 0) {
			return BinSearch(nums, target, 0, nums.Length - 1);
		}

		int min = nums[pivotIndex], max = nums[pivotIndex - 1];

		if (target <= max && target >= nums[0]) {
			return BinSearch(nums, target, 0, pivotIndex);
		}

		if (target >= min && target <= nums[^1]) {
			return BinSearch(nums, target, pivotIndex, nums.Length - 1);
		}

		return -1;
	}

	private static int FindPivotIndex(int[] nums) {
		int left = 0, right = nums.Length - 1;
		var pivot = 0;

		while (left < right) {
			var mid = (right + left) / 2;

			if (mid > 0 && nums[mid - 1] > nums[mid]) {
				pivot = mid;
				break;
			}

			if (mid < nums.Length - 1 && nums[mid] > nums[mid + 1]) {
				pivot = mid + 1;
				break;
			}

			if (nums[left] < nums[mid]) {
				left = mid;
			} else {
				right = mid;
			}
		}

		return pivot;
	}

	private static int BinSearch(int[] nums, int target, int left, int right) {
		int res = -1;
		while (left <= right) {
			var m = (right + left) / 2;
			if (nums[m] == target) {
				res = m;
				break;
			}

			if (nums[m] < target) {
				left = m + 1;
			} else {
				right = m - 1;
			}
		}

		return res;
	}
}
