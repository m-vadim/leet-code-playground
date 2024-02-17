/// <summary>
/// https://leetcode.com/problems/spiral-matrix/
/// </summary>
public class Solution {
	public IList<int> SpiralOrder(int[][] matrix) {
		if (matrix.Length == 1) {
			return EnumerateSingleRow(matrix);
		}

		if (matrix[0].Length == 1) {
			return EnumerateSingleColumn(matrix);
		}

		return EnumerateMatrix(matrix);
	}

	private static int[] EnumerateSingleRow(IReadOnlyList<int[]> matrix) {
		return matrix[0];
	}

	private static int[] EnumerateSingleColumn(IReadOnlyList<int[]> matrix) {
		var result = new int[matrix.Count];
		for (var i = 0; i < matrix.Count; i++) {
			result[i] = matrix[i][0];
		}

		return result;
	}

	private static int[] EnumerateMatrix(IReadOnlyList<int[]> matrix) {
		int iterations = 0, 
			top = 0, 
			left = 0, 
			right = matrix[0].Length - 1, 
			bot = matrix.Count - 1;
		
		var result = new int[matrix.Count * matrix[0].Length];
		while (iterations < result.Length) {
			// Go right 
			for (int i = left; i <= right && iterations < result.Length; i++) {
				result[iterations++] = matrix[top][i];
			}
			top++;

			// Go down
			for (int j = top; j <= bot && iterations < result.Length; j++) {
				result[iterations++] = matrix[j][right];
			}
			right--;

			// Go left
			for (int i = right; i >= left && iterations < result.Length; i--) {
				result[iterations++] = matrix[bot][i];
			}
			bot--;

			// Go up
			for (int i = bot; i >= top && iterations < result.Length; i--) {
				result[iterations++] = matrix[i][left];
			}
			left++;
		}

		return result;
	}
}