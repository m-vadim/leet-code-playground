/// <summary>
/// https://leetcode.com/problems/fraction-addition-and-subtraction
/// </summary>
public sealed class Solution {
	private const char Plus = '+';
	private const char Minus = '-';
	private const char Division = '/';

	public string FractionAddition(string expression) {
		Fraction[] fractions = GetFractions(expression.AsSpan());
		var result = fractions[0];
		for (var i = 1; i < fractions.Length; i++) {
			result = Calculate(result, fractions[i]);
		}

		ReduceFraction(result);

		return result.ToString();
	}

	private static void ReduceFraction(Fraction fraction) {
		if (fraction.Denominator == 1) {
			return;
		}

		if (fraction.Numerator == 0) {
			fraction.Denominator = 1;
			return;
		}

		var gcd = GetGCD(fraction.Numerator, fraction.Denominator);
		fraction.Numerator /= gcd;
		fraction.Denominator /= gcd;
	}

	private static int GetGCD(int a, int b) {
		if (a == b) {
			return a;
		}

		while (a != 0 && b != 0) {
			if (a > b) {
				a %= b;
			} else {
				b %= a;
			}
		}

		return a == 0 ? b : a;
	}

	private static Fraction Calculate(Fraction a, Fraction b) {
		if (a.Denominator != b.Denominator) {
			a.Numerator *= b.Denominator;
			b.Numerator *= a.Denominator;
			a.Denominator = b.Denominator = a.Denominator * b.Denominator;
		}

		var num = (a.IsNegative ? -a.Numerator : a.Numerator) + (b.IsNegative ? -b.Numerator : b.Numerator);
		return new Fraction(Math.Abs(num), a.Denominator, num < 0);
	}

	private static Fraction[] GetFractions(ReadOnlySpan<char> expSpan) {
		var signs = new List<int>();
		if (expSpan[0] != Minus) {
			signs.Add(-1);
		}

		for (var i = 0; i < expSpan.Length; i++) {
			if (expSpan[i] == Plus || expSpan[i] == Minus) {
				signs.Add(i);
			}
		}

		var fractions = new Fraction[signs.Count];
		for (var i = 0; i < signs.Count; i++) {
			var currentSign = signs[i];
			var nextSign = i + 1 == signs.Count ? expSpan.Length : signs[i + 1];
			ReadOnlySpan<char> fractionSpan = expSpan.Slice(currentSign + 1, nextSign - currentSign - 1);
			fractions[i] = ExtractFraction(fractionSpan, currentSign >= 0 ? expSpan[currentSign] : Plus);
		}

		return fractions;
	}

	private static Fraction ExtractFraction(ReadOnlySpan<char> fractionSpan, char sign) {
		var fractionIndex = -1;
		for (var i = 0; i < fractionSpan.Length; i++) {
			if (fractionSpan[i] == Division) {
				fractionIndex = i;
				break;
			}
		}

		ReadOnlySpan<char> num = fractionSpan.Slice(0, fractionIndex);
		ReadOnlySpan<char> denom = fractionSpan.Slice(fractionIndex + 1, fractionSpan.Length - fractionIndex - 1);

		return new Fraction(int.Parse(num), int.Parse(denom), sign == Minus);
	}

	private record Fraction {
		public Fraction(int numerator, int denominator, bool isNegative) {
			Numerator = numerator;
			Denominator = denominator;
			IsNegative = isNegative;
		}

		public int Numerator { get; set; }
		public int Denominator { get; set; }
		public bool IsNegative { get; }

		public override string ToString() {
			return IsNegative
				? $"-{Numerator}/{Denominator}"
				: $"{Numerator}/{Denominator}";
		}
	}
}
