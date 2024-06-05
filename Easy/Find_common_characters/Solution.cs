/// <summary>
/// https://leetcode.com/problems/find-common-characters
/// </summary>
public class Solution {
	public IList<string> CommonChars(string[] words) {
		var map = new int[26];
		for (var i = 0; i < 26; i++) {
			map[i] = int.MaxValue;
		}

		foreach (var word in words) {
			var wordMap = new int[26];
			foreach (var ch in word) {
				wordMap[ch - 'a'] += 1;
			}

			for (var i = 0; i < 26; i++) {
				map[i] = Math.Min(map[i], wordMap[i]);
			}
		}

		var result = new List<string>(26);
		for (var i = 0; i < 26; i++) {
			var ch = (char)(i + 'a');
			for (var y = 0; y < map[i]; y++) {
				result.Add(ch.ToString());
			}
		}

		return result;
	}
}
