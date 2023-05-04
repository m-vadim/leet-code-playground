namespace LeetCode;

// https://leetcode.com/problems/rotate-image/
public class Solution {
	public void Rotate(int[][] matrix) {
		Transpose(matrix);
		foreach (int[] t in matrix) Reverse(t);
	}

	private static void Transpose(int[][] matrix) {
		for (var i = 0; i < matrix.Length; i++)
		for (int j = i + 1; j < matrix.Length; j++)
			(matrix[i][j], matrix[j][i]) = (matrix[j][i], matrix[i][j]);
	}

	private static void Reverse(int[] arr) {
		int right = arr.Length - 1;
		var left = 0;
		while (right > left) {
			(arr[left], arr[right]) = (arr[right], arr[left]);
			right--;
			left++;
		}
	}
}