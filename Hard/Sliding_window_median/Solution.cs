/// <summary>
/// https://leetcode.com/problems/sliding-window-median/
/// </summary>
public sealed class Solution {
	public double[] MedianSlidingWindow(int[] nums, int k) {
		var list = new double[nums.Length - k + 1];
		var window = new List<int>(nums[0..k]);
		window.Sort();

		var useMean = window.Count % 2 == 0;
		var mid = window.Count / 2;
		list[0] = FindMedianInSortedNums(window, useMean, mid);

		for (var i = 1; i <= nums.Length - k; i++) {
			ShiftWindow(window, nums[i - 1], nums[i + k - 1]);
			list[i] = FindMedianInSortedNums(window, useMean, mid);
		}

		return list.ToArray();
	}

	private static void ShiftWindow(List<int> window, int elementToRemove, int elementToInsert) {
		var i = window.BinarySearch(elementToRemove);
		window.RemoveAt(i);

		i = 0;
		while (i < window.Count) {
			if (window[i] >= elementToInsert) {
				break;
			}

			i++;
		}
		window.Insert(i, elementToInsert);
	}

	private static double FindMedianInSortedNums(List<int> nums, bool useMean, int mid) {
		if (useMean) {
			return nums[mid] / 2d + nums[mid - 1] / 2d;
		}

		return nums[mid];
	}
}
