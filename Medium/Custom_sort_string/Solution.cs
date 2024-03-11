using System.Text;

/// <summary>
/// https://leetcode.com/problems/custom-sort-string
/// </summary>
public class Solution {
	public string CustomSortString(string order, string s) {
		var sortOrder = new ushort[26];
		ushort weight = 1;
		foreach (char ch in order) {
			sortOrder[ch - 'a'] = weight++;
		}
		
		var charsFreqs = new ushort[26];
		foreach (char ch in s) {
			charsFreqs[ch - 'a'] += 1;
		}

		var sb = new StringBuilder(s.Length);
		
		foreach (char ch in order) {
			int charsCount = charsFreqs[ch - 'a'];
			if (charsCount > 0) {
				var chars = new char[charsCount];
				Array.Fill(chars, ch);
				sb.Append(chars);
				charsFreqs[ch - 'a'] = 0;
			}
		}

		for (int i = 0; i < charsFreqs.Length; i++) {
			if (charsFreqs[i] > 0) {
				var chars = new char[charsFreqs[i]];
				Array.Fill(chars, (char) (i + 'a'));
				sb.Append(chars);
			}
		}

		return sb.ToString();
	}
}