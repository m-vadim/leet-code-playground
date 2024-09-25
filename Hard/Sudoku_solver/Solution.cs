namespace LeetCode;

/// <summary>
/// https://leetcode.com/problems/sudoku-solver/description/
/// </summary>
public sealed class Solution {
	private const char Unknown = '.';
	private static readonly char[] AllOptions = [
		'1', '2', '3', '4', '5', '6', '7', '8', '9'
	];

	public void SolveSudoku(char[][] sudoku) {
		char[][] allPossibleSolutions = new char[81][];
		for (int i = 0; i < 81; i++) {
			var sudokuIndex = new SudokuIndex(i);
			var value = sudoku[sudokuIndex.Row][sudokuIndex.Col];
			allPossibleSolutions[i] = value == Unknown ? GetPossibleDigitsForPosition(sudoku, sudokuIndex) : [];
		}

		Solve(sudoku, 0, allPossibleSolutions);
	}

	private static bool Solve(char[][] sudoku, int index, char[][] allPossibleSolutionsPerIndex) {
		while (index < 81) {
			var sudokuIndex = new SudokuIndex(index);
			var value = sudoku[sudokuIndex.Row][sudokuIndex.Col];
			if (value != Unknown) {
				index++;
				continue;
			}

			var indexSolutions = allPossibleSolutionsPerIndex[index];
			if (indexSolutions.Length == 0) {
				return false;
			}

			var solved = false;
			foreach (char solution in indexSolutions) {
				if (!IsValidSolutionForPosition(sudoku, sudokuIndex, solution)) {
					continue;
				}

				sudoku[sudokuIndex.Row][sudokuIndex.Col] = solution;
				solved = solved || Solve(sudoku, index + 1, allPossibleSolutionsPerIndex);
				if (solved) {
					break;
				}
			}

			if (!solved) {
				sudoku[sudokuIndex.Row][sudokuIndex.Col] = Unknown;
				return false;
			}

			index++;
		}

		return true;
	}

	private static bool IsValidSolutionForPosition(char[][] sudoku, SudokuIndex index, char value) {
		var segmentIterator = new SegmentIterator(index.Row, index.Col);
		for (ushort i = 0; i < 9; i++) {
			if (i != index.Col && sudoku[index.Row][i] == value) {
				return false;
			}

			if (i != index.Row && sudoku[i][index.Col] == value) {
				return false;
			}

			var (segmentRowIndex, segmentColIndex) = segmentIterator.Next();

			if (segmentRowIndex != index.Row && segmentColIndex != index.Col &&
				sudoku[segmentRowIndex][segmentColIndex] == value) {
				return false;
			}
		}

		return true;
	}

	private static char[] GetPossibleDigitsForPosition(char[][] sudoku, SudokuIndex index) {
		var seen = new HashSet<char>(9);
		var segmentIterator = new SegmentIterator(index.Row, index.Col);
		for (ushort i = 0; i < 9; i++) {
			if (i != index.Col && sudoku[index.Row][i] != Unknown) {
				seen.Add(sudoku[index.Row][i]);
			}

			if (i != index.Row && sudoku[i][index.Col] != Unknown) {
				seen.Add(sudoku[i][index.Col]);
			}

			var (segmentRowIndex, segmentColIndex) = segmentIterator.Next();

			if (segmentRowIndex != index.Row && segmentColIndex != index.Col &&
				sudoku[segmentRowIndex][segmentColIndex] != Unknown) {
				seen.Add(sudoku[segmentRowIndex][segmentColIndex]);
			}
		}

		return AllOptions.Except(seen).ToArray();
	}

	private struct SegmentIterator {
		private int _startRow;
		private int _startCol;

		public SegmentIterator(int elRowIndex, int elColIndex) {
			_startRow = elRowIndex - elRowIndex % 3;
			_startCol = elColIndex - elColIndex % 3;
		}

		public (int segmentRowIndex, int segmentColIndex) Next() {
			var iterator = (row: _startRow, col: _startCol);

			_startCol++;
			if (_startCol % 3 == 0) {
				_startCol -= 3;
				_startRow++;
			}

			return iterator;
		}
	}
}

internal record struct SudokuIndex {
	public SudokuIndex(int index) {
		Row = index / 9;
		Col = index - 9 * Row;
	}

	public int Row { get; }
	public int Col { get; }
}
