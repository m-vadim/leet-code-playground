namespace LeetCode; 

/// <summary>
/// https://leetcode.com/problems/string-compression/
/// </summary>
public class Solution {
	public int Compress(char[] chars) {
		char prev = chars[0];
		int charCount = 0, storeIndex = 0;
		foreach (char ch in chars) {
			if (ch == prev) {
				charCount++;
			}
			else {
				chars[storeIndex++] = prev;
				if (charCount > 1) {
					foreach (char digit in charCount.ToString()) {
						chars[storeIndex++] = digit;
					}
				}

				prev = ch;
				charCount = 1;
			}
		}
		
		chars[storeIndex++] = prev;
		if (charCount > 1) {
			foreach (char digit in charCount.ToString()) {
				chars[storeIndex++] = digit;
			}
		}

		return storeIndex;
	}
}