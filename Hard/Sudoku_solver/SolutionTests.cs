using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(
			CreateSudoku(
			[
				["5", "3", ".", ".", "7", ".", ".", ".", "."],
				["6", ".", ".", "1", "9", "5", ".", ".", "."],
				[".", "9", "8", ".", ".", ".", ".", "6", "."],
				["8", ".", ".", ".", "6", ".", ".", ".", "3"],
				["4", ".", ".", "8", ".", "3", ".", ".", "1"],
				["7", ".", ".", ".", "2", ".", ".", ".", "6"],
				[".", "6", ".", ".", ".", ".", "2", "8", "."],
				[".", ".", ".", "4", "1", "9", ".", ".", "5"],
				[".", ".", ".", ".", "8", ".", ".", "7", "9"]
			]),
			CreateSudoku(
			[
				["5", "3", "4", "6", "7", "8", "9", "1", "2"],
				["6", "7", "2", "1", "9", "5", "3", "4", "8"],
				["1", "9", "8", "3", "4", "2", "5", "6", "7"],
				["8", "5", "9", "7", "6", "1", "4", "2", "3"],
				["4", "2", "6", "8", "5", "3", "7", "9", "1"],
				["7", "1", "3", "9", "2", "4", "8", "5", "6"],
				["9", "6", "1", "5", "3", "7", "2", "8", "4"],
				["2", "8", "7", "4", "1", "9", "6", "3", "5"],
				["3", "4", "5", "2", "8", "6", "1", "7", "9"]
			]));
	}

	[TestCaseSource(nameof(Cases))]
	public static void SolvesSudoku(char[][] sudoku, char[][] solution) {
		new Solution().SolveSudoku(sudoku);

		for (var i = 0; i < sudoku.Length; i++) {
			CollectionAssert.AreEqual(solution[i], sudoku[i]);
		}
	}

	private static char[][] CreateSudoku(string[][] rows) {
		var sudoku = new char[rows.Length][];
		for (var rowIndex = 0; rowIndex < sudoku.Length; rowIndex++) {
			var row = rows[rowIndex];
			sudoku[rowIndex] = new char[row.Length];

			for (var colIndex = 0; colIndex < row.Length; colIndex++) {
				sudoku[rowIndex][colIndex] = row[colIndex][0];
			}
		}

		return sudoku;
	}
}
