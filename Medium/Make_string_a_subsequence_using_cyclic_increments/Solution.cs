/// <summary>
///     https://leetcode.com/problems/make-string-a-subsequence-using-cyclic-increments
/// </summary>
public class Solution {
	public bool CanMakeSubsequence(string str1, string str2) {
		if (str2.Length > str1.Length) {
			return false;
		}

		int index = 0, str2Index = 0;
		while (index < str1.Length && str2Index < str2.Length) {
			if (Matched(str1[index], str2[str2Index])) {
				str2Index++;
			}

			index++;
		}

		return str2Index == str2.Length;
	}

	private static bool Matched(char ch1, char ch2) => ch1 == ch2 || NextChar(ch1) == ch2;

	private static char NextChar(char ch) => ch == 'z' ? 'a' : (char)(ch + 1);
}
