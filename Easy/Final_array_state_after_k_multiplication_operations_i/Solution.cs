/// <summary>
///     https://leetcode.com/problems/final-array-state-after-k-multiplication-operations-i/
/// </summary>
public class Solution {
	public int[] GetFinalState(int[] nums, int k, int multiplier) {
		var indexesHeap = new PriorityQueue<int, Priority>(nums.Length, new PriorityComparer());
		for (var i = 0; i < nums.Length; i++) {
			indexesHeap.Enqueue(i, new Priority(nums[i], i));
		}

		while (k-- > 0) {
			var index = indexesHeap.Dequeue();
			nums[index] *= multiplier;
			indexesHeap.Enqueue(index, new Priority(nums[index], index));
		}

		return nums;
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
