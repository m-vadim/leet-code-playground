/// <summary>
///     https://leetcode.com/problems/count-the-hidden-sequences
/// </summary>
public sealed class Solution {
	public int NumberOfArrays(int[] differences, int lower, int upper) {
		int hiddenVal = lower, min = lower, max = lower;
		foreach (int diff in differences) {
			hiddenVal += diff;
			min = Math.Min(min, hiddenVal);
			max = Math.Max(max, hiddenVal);

			if (max > upper || ((lower - min) + max) > upper) {
				return 0;
			}
		}

		if (min < lower) {
			max += (lower - min);
		}

		return max <= upper ? upper - max + 1 : 0;
	}
}
