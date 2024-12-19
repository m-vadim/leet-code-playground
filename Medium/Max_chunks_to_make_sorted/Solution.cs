/// <summary>
///     https://leetcode.com/problems/max-chunks-to-make-sorted
/// </summary>
public sealed class Solution {
	public int MaxChunksToSorted(int[] arr) {
		int maxChunks = arr.Length, countingSum = 0;
		for (var index = 0; index < arr.Length; index++) {
			countingSum += arr[index];
			if (countingSum != NSum(index)) {
				maxChunks -= 1;
			}
		}

		return maxChunks;
	}

	private static int NSum(int n) {
		return n * (n + 1) / 2;
	}
}
