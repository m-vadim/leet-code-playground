using System.Runtime.CompilerServices;

namespace LeetCode; 

/// <summary>
/// https://leetcode.com/problems/decoded-string-at-index
/// </summary>
public class Solution {
	public string DecodeAtIndex(string s, long k) {
		long length = 0;
		int index = 0;
		while (length < k) {
			char ch = s[index];
			if (char.IsDigit(ch)) {
				length *= CharToDigit(ch);
			}
			else {
				length += 1;
			}
			index++;
		}

		for (int i = index - 1; i >= 0; i--) {
			char ch = s[i];
			if (char.IsDigit(ch)) {
				length /= CharToDigit(ch);;
				k %= length;
			} else {
				if (k == 0 || k == length) {
					return ch.ToString();
				}
				
				length -= 1;
			}
		}

		return string.Empty;
	}

	private const char Zero = '0';
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static ushort CharToDigit(char ch) {
		return (ushort)(ch - Zero);
	} 
}