/// <summary>
///     https://leetcode.com/problems/word-break/
/// </summary>
public class Solution {
	public bool WordBreak(string s, IList<string> wordDict) {
		bool[] solutions = new bool[s.Length + 1];
		solutions[^1] = true;

		ReadOnlySpan<char> sSpan = s.AsSpan();

		for (int i = s.Length - 1; i >= 0; i--) {
			foreach (string word in wordDict) {
				if (IsMatch(sSpan, i, word)) {
					solutions[i] = solutions[i + word.Length];
				}

				if (solutions[i]) {
					break;
				}
			}
		}

		return solutions[0];
	}

	private static bool IsMatch(ReadOnlySpan<char> s, int position, string word) {
		if (position + word.Length > s.Length) {
			return false;
		}

		for (int i = 0; i < word.Length; i++) {
			if (word[i] != s[position + i]) {
				return false;
			}
		}

		return true;
	}
}
