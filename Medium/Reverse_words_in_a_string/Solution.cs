using System.Text;

namespace LeetCode; 

/// <summary>
/// https://leetcode.com/problems/reverse-words-in-a-string
/// </summary>
public class Solution {
	public string ReverseWords(string s) {
		var words = new Stack<Word>();
		int start = -1;
		for (int i = 0; i < s.Length; i++) {
			char c = s[i];
			if (c != ' ') {
				if (start < 0) {
					start = i;
				}
			}
			else {
				if (start >= 0) {
					words.Push(new Word(start, i - start));
					start = -1;
				}
			}
		}
		
		if (start >= 0) {
			words.Push(new Word(start, s.Length - start));
		}

		var sb = new StringBuilder();
		ReadOnlySpan<char> span = s.AsSpan();
		while (words.Count > 0) {
			Word word = words.Pop();
			sb.AppendFormat(span.Slice(word.Start, word.Length).ToString() + " ");
		}

		sb.Remove(sb.Length - 1, 1);
		
		return sb.ToString();
	}

	private record struct Word(int Start, int Length);
}