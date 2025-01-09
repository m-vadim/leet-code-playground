/// <summary>
///     https://leetcode.com/problems/word-search/
/// </summary>
public class Solution {
	private const char Visited = '0';

	public bool Exist(char[][] board, string word) {
		var letters = word.ToCharArray();
		for (var index = 0; index < board.Length; index++) {
			for (var y = 0; y < board[index].Length; y++) {
				if (board[index][y] == word[0] && Dfs(index, y, board, 0, letters)) {
					return true;
				}
			}
		}

		return false;
	}

	private static bool Dfs(int row, int col, char[][] board, int letterIndex, char[] word) {
		if (row < 0 || row == board.Length || col < 0 || col == board[0].Length) {
			return false;
		}

		char boardLetter = board[row][col];
		if (boardLetter == Visited) {
			return false;
		}

		bool matched = false;
		if (boardLetter == word[letterIndex]) {
			if (letterIndex == word.Length - 1) {
				return true;
			}

			board[row][col] = Visited;

			matched = Dfs(row - 1, col, board, letterIndex + 1, word) ||
				   Dfs(row, col + 1, board, letterIndex + 1, word) ||
				   Dfs(row + 1, col, board, letterIndex + 1, word) ||
				   Dfs(row, col - 1, board, letterIndex + 1, word);

			board[row][col] = boardLetter;
		}

		return matched;
	}
}
