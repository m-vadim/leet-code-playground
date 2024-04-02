/// <summary>
/// https://leetcode.com/problems/isomorphic-strings
/// </summary>
public class Solution {
	public bool IsIsomorphic(string s, string t) {
		var dict = new Dictionary<char, char>();
		var mapped = new HashSet<char>();
		
		for(int i = 0; i < s.Length; i++) {
			char si = s[i];

			if (dict.TryGetValue(si, out char replace)) {
				if (replace != t[i]) {
					return false;
				}
			} else {
				dict.Add(si, t[i]);
				if (!mapped.Add(t[i])) {
					return false;
				}
			}
		}

		return true;
	}
}