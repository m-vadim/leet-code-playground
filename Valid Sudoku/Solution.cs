namespace LeetCode;

// https://leetcode.com/problems/valid-sudoku/
public class Solution {
	public bool IsValidSudoku(char[][] board) {
		for (ushort rowIndex = 0; rowIndex < 9; rowIndex++) {
			for (ushort columnIndex = 0; columnIndex < 9; columnIndex++) {
				char s = board[rowIndex][columnIndex];

				if (s == '.') {
					continue;
				}

				if (!IsValid(board, rowIndex, columnIndex, board[rowIndex][columnIndex])) {
					return false;
				}
			}
		}

		return true;
	}

	private static bool IsValid(char[][] board, ushort elRowIndex, ushort elColIndex, char el) {
		var segmentIterator = new SegmentIterator(elRowIndex, elColIndex);
		for (ushort i = 0; i < 9; i++) {
			if (i != elColIndex && board[elRowIndex][i] == el) {
				return false;
			}

			if (i != elRowIndex && board[i][elColIndex] == el) {
				return false;
			}

			(int segmentRowIndex, int segmentColIndex) = segmentIterator.Next();

			if (segmentRowIndex != elRowIndex && segmentColIndex != elColIndex &&
			    board[segmentRowIndex][segmentColIndex] == el) {
				return false;
			}
		}

		return true;
	}

	private struct SegmentIterator{
		private int _startRow;
		private int _startCol;
    
		public SegmentIterator(ushort elRowIndex, ushort elColIndex) {
			_startRow = (elRowIndex - (elRowIndex % 3));
			_startCol = (elColIndex - (elColIndex % 3));
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