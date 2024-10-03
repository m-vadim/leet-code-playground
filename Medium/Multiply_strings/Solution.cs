using System.Text;

/// <summary>
/// https://leetcode.com/problems/multiply-strings/
/// </summary>
public sealed class Solution {
	public string Multiply(string num1, string num2) {
		if (num1[0] == '0' || num2[0] == '0') {
			return "0";
		}

		if (num1 == "1" || num2 == "1") {
			return num1 == "1" ? num2 : num1;
		}

		ReadOnlySpan<char> bigger, smaller;
		if (num1.Length >= num2.Length) {
			bigger = num1.AsSpan();
			smaller = num2.AsSpan();
		} else {
			bigger = num2.AsSpan();
			smaller = num1.AsSpan();
		}

		var surplus = 0;
		var i = smaller.Length - 1;
		string result = string.Empty;

		while (i >= 0) {
			result = string.IsNullOrEmpty(result)
				? MultiplyByDigit(bigger, CharToDigit(smaller[i]), surplus)
				: TwoSum(result.AsSpan(), MultiplyByDigit(bigger, CharToDigit(smaller[i]), surplus));

			surplus += 1;
			i--;
		}

		return result;
	}

	public static string MultiplyByDigit(ReadOnlySpan<char> num, ushort digit, int additionalZero) {
		if (digit == 0) {
			return "0";
		}

		var i = num.Length - 1;
		var sb = new StringBuilder();

		if (additionalZero > 0) {
			sb.Insert(0, Enumerable.Repeat('0', additionalZero).ToArray());
		}

		int surplus = 0;
		while (i >= 0) {
			int m = CharToDigit(num[i]) * digit;
			m += surplus;
			surplus = 0;

			if (i == 0) {
				sb.Insert(0, m);
			} else {
				sb.Insert(0, m % 10);
				surplus += m / 10;
			}
			i--;
		}

		return sb.ToString();
	}

	public static string TwoSum(ReadOnlySpan<char> num1, ReadOnlySpan<char> num2) {
		int n1Pointer = num1.Length - 1, n2Pointer = num2.Length - 1;
		var sb = new StringBuilder();

		int surplus = 0;
		while (true) {
			int sum = (n1Pointer >= 0 ? CharToDigit(num1[n1Pointer--]) : 0) + (n2Pointer >= 0 ? CharToDigit(num2[n2Pointer--]) : 0);
			sum += surplus;

			if (n1Pointer >= 0 || n2Pointer >= 0) {
				sb.Insert(0, sum % 10);
				surplus = sum / 10;
			} else {
				sb.Insert(0, sum);
				break;
			}
		}

		return sb.ToString();
	}

	private static ushort CharToDigit(char ch) {
		return (ushort)(ch - 48);
	}
}
