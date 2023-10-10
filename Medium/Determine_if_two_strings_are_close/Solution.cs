namespace LeetCode; 

/// <summary>
/// https://leetcode.com/problems/determine-if-two-strings-are-close
/// </summary>
public class Solution {
	public bool CloseStrings(string word1, string word2) {
		if (word1.Length != word2.Length) {
			return false;
		}

		int[] charFreq = new int[26];
		foreach(char ch in word1) {
			charFreq[ch - 97] += 1;
		}
		
		int[] charFreq2 = new int[26];
		foreach(char ch in word2) {
			charFreq2[ch - 97] += 1;
		}

		for (ushort i = 0; i < 26; i++) {
			if (charFreq[i] == 0 && charFreq2[i] > 0 || charFreq2[i] == 0 && charFreq[i] > 0) {
				return false;
			}
		}
		
		Array.Sort(charFreq);
		Array.Sort(charFreq2);

		return charFreq.SequenceEqual(charFreq2);
	}
}