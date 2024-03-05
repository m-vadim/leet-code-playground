/// <summary>
/// https://leetcode.com/problems/unique-paths/
/// </summary>
public class Solution {
	public int UniquePaths(int m, int n) {
		int[][] grid = SetupField(m, n);
        int left, top;

        for (int row = 0; row < m; row++) {
	        for(int col = 0; col < n; col++ ) {
		        if (row == 0 && col == 0) {
			        continue;
		        }
		        
		        left = col > 0 ? grid[row][col - 1] : 0;
		        top = row > 0 ? grid[row - 1][col] : 0;
		        grid[row][col] = left + top;
	        }
        }

        return grid[^1][^1];
	}

	private static int[][] SetupField(int rows, int cols) {
		var grid = new int[rows][];
		for (var index = 0; index < grid.Length; index++) {
			grid[index] = new int[cols];
		}

		grid[0][0] = 1;

		return grid;
	}
}