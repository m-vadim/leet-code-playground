
/// <summary>
/// https://leetcode.com/problems/greatest-common-divisor-of-strings
/// </summary>
public class Solution {
	public string GcdOfStrings(string str1, string str2) {
		if (str1 + str2 != str2 + str1) {
			return string.Empty;
		}

		return str1.Substring(0, GetGDC(str1.Length, str2.Length));
	}

	private static int GetGDC(int a, int b) {
		if (a == b) {
			return a;
		}

		while (a != 0 && b != 0) {
			if (a > b) {
				a %= b;
			}
			else {
				b %= a;
			}
		}

		return a == 0 ? b : a;
	}
}