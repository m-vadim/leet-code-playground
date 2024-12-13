/// <summary>
///     https://leetcode.com/problems/find-score-of-an-array-after-marking-all-elements/
/// </summary>
public class Solution {
	public long FindScore(int[] nums) {
		long sum = 0;
		var indexesHeap = new PriorityQueue<int, Priority>(nums.Length, new PriorityComparer());
		for (var i = 0; i < nums.Length; i++) {
			indexesHeap.Enqueue(i, new Priority(nums[i], i));
		}

		while (indexesHeap.Count > 0) {
			var index = indexesHeap.Dequeue();
			var val = nums[index];

			if (val < 0) {
				continue;
			}

			sum += val;
			nums[index] = -val;
			if (index < nums.Length - 1 && nums[index + 1] > 0) {
				nums[index + 1] = -nums[index + 1];
			}

			if (index > 0 && nums[index - 1] > 0) {
				nums[index - 1] = -nums[index - 1];
			}
		}

		return sum;
	}
}

internal record struct Priority(int Value, int Index);

internal sealed class PriorityComparer : IComparer<Priority> {
	public int Compare(Priority x, Priority y) {
		if (x.Value == y.Value) {
			return x.Index < y.Index ? -1 : 1;
		}

		return x.Value < y.Value ? -1 : 1;
	}
}
