using System.Text;

/// <summary>
/// https://leetcode.com/problems/integer-to-roman
/// </summary>
public class Solution {
	public string IntToRoman(int num) {
		string s = num.ToString();
		int i = s.Length - 1, mul = 1;

		var sb = new StringBuilder();
		while (i >= 0) {
			sb.Insert(0, GetRoman(s[i] - 48, mul));
			mul *= 10;
			i--;
		}

		return sb.ToString();
	}

	private static string GetRoman(int n, int multiplier) {
		(char one, char five, char ten) = GetSymbolsByMultiplier(multiplier);
		if (n < 4) {
			return new string(one, n);
		}

		if (n == 4) {
			return $"{one}{five}";
		}

		if (n < 9) {
			return $"{five}{new string(one, n - 5)}";
		}

		return $"{one}{ten}";
	}

	private static (char One, char Five, char Ten) GetSymbolsByMultiplier(int mul) {
		return mul switch {
			1 => (One: 'I', Five: 'V', Ten: 'X'),
			10 => (One: 'X', Five: 'L', Ten: 'C'),
			100 => (One: 'C', Five: 'D', Ten: 'M'),
			1000 => (One: 'M', Five: '\0', Ten: '\0'),
			_ => throw new InvalidOperationException()
		};
	}
}