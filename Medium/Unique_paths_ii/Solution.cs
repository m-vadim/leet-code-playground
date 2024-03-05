/// <summary>
/// https://leetcode.com/problems/unique-paths-ii/
/// </summary>
public class Solution {
	public int UniquePathsWithObstacles(int[][] obstacleGrid) {
		if (obstacleGrid[^1][^1] == 1 || obstacleGrid[0][0] == 1) {
			return 0;
		}
		
		int rows = obstacleGrid.Length;
		int cols = obstacleGrid[0].Length;

		obstacleGrid[0][0] = 1;
		int left, top;
		for (var row = 0; row < rows; row++) {
			for (var col = 0; col < cols; col++) {
				if (row == 0 && col == 0) {
					continue;
				}

				if (obstacleGrid[row][col] == 1) {
					obstacleGrid[row][col] = -1;
					continue;
				}

				left = col > 0 && obstacleGrid[row][col - 1] > 0 ? obstacleGrid[row][col - 1] : 0;
				top = row > 0 && obstacleGrid[row - 1][col] > 0 ? obstacleGrid[row - 1][col] : 0;
				obstacleGrid[row][col] = left + top;
			}
		}
		
		return obstacleGrid[^1][^1];;
	}
}
