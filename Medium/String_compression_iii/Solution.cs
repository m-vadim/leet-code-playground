using System.Text;

/// <summary>
/// https://leetcode.com/problems/string-compression-iii
/// </summary>
public sealed class Solution {
	public string CompressedString(string word) {
		const ushort counterLimit = 9;

		var sb = new StringBuilder();
		ushort counter = 1;
		char prev = word[0];
		for (int i = 1; i < word.Length; i++) {
			char current = word[i];
			if (current != prev || counter == counterLimit) {
				sb.Append($"{counter}{prev}");
				prev = current;
				counter = 1;
			} else {
				counter++;
			}
		}

		sb.Append($"{counter}{prev}");

		return sb.ToString();
	}
}
