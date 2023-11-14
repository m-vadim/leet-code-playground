/// <summary>
/// https://leetcode.com/problems/unique-length-3-palindromic-subsequences
/// </summary>
public class Solution {
	public int CountPalindromicSubsequence(string s) {
		var firstCharMarker = new bool[26];
        
		int count = 0;
		for(int start  = 0; start < s.Length; start++) {
			char ch = s[start];
			if (firstCharMarker[ch - 97]) {
				continue;
			}

			var secondCharMarker = new bool[26];
			for(int y = start + 1; y < s.Length; y++) {
				char chY = s[y];
				if (secondCharMarker[chY - 97]) {
					continue;
				}

				for(int z = y + 1; z < s.Length; z++) {
					if (s[z] == ch) {
						count++;
						break;
					}
				}

				secondCharMarker[chY - 97] = true;
			}
            
			firstCharMarker[ch - 97] = true;
		}

		return count;
	}
}