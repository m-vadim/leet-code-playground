/// <summary>
/// https://leetcode.com/problems/diagonal-traverse
/// </summary>
public class Solution {
	private static readonly Direction Up = new(-1, 1);
	private static readonly Direction Down = new(1, -1);

	public int[] FindDiagonalOrder(int[][] mat) {
		int rowIndex = 0, colIndex = 0;
		int rows = mat.Length, cols = mat[0].Length;
		Direction direction = Up;

		var result = new int[rows * cols];
		var resultIndex = 0;

		while (resultIndex < result.Length) {
			result[resultIndex] = mat[rowIndex][colIndex];
			resultIndex++;

			rowIndex += direction.Row;
			colIndex += direction.Col;
			if (rowIndex < 0 || rowIndex == rows || colIndex < 0 || colIndex == cols) {
				rowIndex -= direction.Row;
				colIndex -= direction.Col;

				if (direction == Up) {
					if (colIndex < cols - 1) {
						colIndex++;
					} else {
						rowIndex++;
					}

					direction = Down;
				} else {
					if (rowIndex < rows - 1) {
						rowIndex++;
					} else {
						colIndex++;
					}
					direction = Up;
				}
			}
		}

		return result;
	}

	private record struct Direction(int Row, int Col);
}
