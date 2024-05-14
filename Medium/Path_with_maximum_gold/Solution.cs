/// <summary>
/// https://leetcode.com/problems/path-with-maximum-gold
/// </summary>
public class Solution {
	public int GetMaximumGold(int[][] grid) {
		int rows = grid.Length,
			cols = grid[0].Length,
			maxGold = 0;

		for (var row = 0; row < rows; row++) {
			for (var col = 0; col < cols; col++) {
				maxGold = Math.Max(maxGold, MaxGoldFromPosition(row, col, grid));
			}
		}

		return maxGold;
	}

	private int MaxGoldFromPosition(int row, int col, IReadOnlyList<int[]> grid) {
		int gold = grid[row][col];
		if (gold == 0) {
			return 0;
		}

		grid[row][col] *= -1;
		int max = gold;

		// left
		if (col > 0 && grid[row][col - 1] > 0) {
			max = Math.Max(max, gold + MaxGoldFromPosition(row, col - 1, grid));
		}

		// top
		if (row > 0 && grid[row - 1][col] > 0) {
			max = Math.Max(max, gold + MaxGoldFromPosition(row - 1, col, grid));
		}

		// right
		if (col < grid[0].Length - 1  && grid[row][col + 1] > 0) {
			max = Math.Max(max, gold + MaxGoldFromPosition(row, col + 1, grid));
		}

		// bottom
		if (row < grid.Count - 1  && grid[row + 1][col] > 0) {
			max = Math.Max(max, gold + MaxGoldFromPosition(row + 1, col, grid));
		}

		grid[row][col] *= -1;

		return max;
	}
}
