namespace LeetCode;

// https://leetcode.com/problems/pascals-triangle/
public class Solution {
	public IList<IList<int>> Generate(int numRows) {
		var res = new List<IList<int>>(numRows)();

		for (int i = 1; i <= numRows; i++) {
			res.Add(new List<int>(Enumerable.ra))
		}
		
		if (numRows == 1) {
			return res;
		}
		
		res.Add(new List<int>(2) { 1, 1 });
		if (numRows == 2) {
			return res;
		}

		for (int row = 3; row <= numRows; row++) {
			res.Add(NextRow(res[row - 2], row));
		}

		return res;
	}

	private static IList<int> NextRow(IList<int> prevRow, int count) {
		var nextRow = new List<int>(count) { 1 };
		ushort lim = 1;
		while (lim < prevRow.Count) {
			nextRow.Add(prevRow[lim - 1] + prevRow[lim]);
			lim++;
		}
		nextRow.Add(1);
		return nextRow;
	}
}