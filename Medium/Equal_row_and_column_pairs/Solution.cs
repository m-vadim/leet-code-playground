/// <summary>
/// https://leetcode.com/problems/equal-row-and-column-pairs
/// </summary>
public class Solution {
	public int EqualPairs(int[][] grid) {
		var rowFreqPerHash = new Dictionary<int, int>(grid.Length);

		foreach (int[] row in grid) {
			var rowHash = 0;
			for (int j = 0; j < grid.Length; j++) {
				rowHash = CombineHashCodes(rowHash, row[j]);
			}

			if (rowFreqPerHash.ContainsKey(rowHash)) {
				rowFreqPerHash[rowHash] += 1;
			}
			else {
				rowFreqPerHash.Add(rowHash, 1);
			}
		}

		var pairs = 0;
		for (var i = 0; i < grid.Length; i++) {
			var colHash = 0;
			var arr = new int[grid.Length];

			for (int j = 0; j < grid.Length; j++) {
				colHash = CombineHashCodes(colHash, grid[j][i]);
				arr[j] = grid[j][i];
			}

			if (rowFreqPerHash.TryGetValue(colHash, out int freq)) {
				pairs += freq;
			}
		}

		return pairs;
	}

	private static int CombineHashCodes(int h1, int h2) {
		return ((h1 << 5) + h1) ^ h2;
	}
}