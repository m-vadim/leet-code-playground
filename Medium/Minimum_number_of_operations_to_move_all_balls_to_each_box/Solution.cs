/// <summary>
///     https://leetcode.com/problems/minimum-number-of-operations-to-move-all-balls-to-each-box
/// </summary>
public class Solution {
	public int[] MinOperations(string boxes) {
		ReadOnlySpan<char> sp = boxes.AsSpan();
		var result = new int[boxes.Length];

		int totalBalls = GetBallFromBox(sp, 0);

		for (var i = 1; i < result.Length; i++) {
			result[i] = result[i - 1] + totalBalls;
			totalBalls += GetBallFromBox(sp, i);
		}

		totalBalls = GetBallFromBox(sp, boxes.Length - 1);
		int memo = 0;
		for (var i = result.Length - 2; i >= 0; i--) {
			memo += totalBalls;
			result[i] += totalBalls;
			totalBalls += GetBallFromBox(sp, i);
		}

		return result;
	}

	private static int GetBallFromBox(ReadOnlySpan<char> boxes, int boxIndex) => boxes[boxIndex] - 48;
}
