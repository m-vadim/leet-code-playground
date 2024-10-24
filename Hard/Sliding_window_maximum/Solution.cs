/// <summary>
///     https://leetcode.com/problems/sliding-window-maximum/
/// </summary>
public sealed class Solution {
	public int[] MaxSlidingWindow(int[] nums, int k) {
		LinkedList<int> q = BuildDoubleEndQueue(nums[..k]);

		var maxArray = new int[nums.Length - k + 1];
		maxArray[0] = q.First.Value;

		for (var i = 1; i < maxArray.Length; i++) {
			var oldOne = nums[i - 1];
			if (q.First.Value == oldOne) {
				q.RemoveFirst();
			}

			var newOne = nums[i + k - 1];
			while (q.Count > 0 && newOne > q.Last.Value) {
				q.RemoveLast();
			}
			q.AddLast(newOne);

			maxArray[i] = q.First.Value;
		}

		return maxArray;
	}

	private static LinkedList<int> BuildDoubleEndQueue(Span<int> nums) {
		LinkedList<int> q = new();

		int max = int.MinValue, maxIndex = 0;
		for (var index = 0; index < nums.Length; index++) {
			var n = nums[index];
			if (n > max) {
				max = n;
				maxIndex = index;
			}
		}

		for (var index = maxIndex; index < nums.Length; index++) {
			var n = nums[index];
			while (q.Count > 0 && q.Last.Value < n) {
				q.RemoveLast();
			}
			q.AddLast(n);
		}

		return q;
	}
}
