/// <summary>
///     https://leetcode.com/problems/count-servers-that-communicate
/// </summary>
public class Solution {
	public int CountServers(int[][] grid) {
		var rows = new short[grid.Length];
		var cols = new short[grid[0].Length];

		for (int row = 0; row < grid.Length; row++) {
			for (int col = 0; col < cols.Length; col++) {
				if (grid[row][col] == 1) {
					rows[row]++;
					cols[col]++;
				}
			}
		}

		int count = 0;
		for (int row = 0; row < grid.Length; row++) {
			for (int col = 0; col < cols.Length; col++) {
				if (grid[row][col] == 1 && (rows[row] > 1 || cols[col] > 1 )) {
					count++;
				}
			}
		}

		return count;
	}
}
