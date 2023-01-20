namespace LeetCode;

public class Solution {
	public int LengthOfLongestSubstring(string s) {
		if (s.Length < 2) {
			return s.Length;
		}

		var hashset = new HashSet<char>();
		int maxLength = 0;

		for (int i = 0; i < s.Length; i++) {
			hashset.Add(s[i]);
			int next = i + 1;
			while (next < s.Length && hashset.Add(s[next])) {
				next += 1;
			}

			if (hashset.Count > maxLength) {
				maxLength = hashset.Count;
			}

			hashset.Clear();
		}

		return maxLength;
	}
}