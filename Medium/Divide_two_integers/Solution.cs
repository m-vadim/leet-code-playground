// https://leetcode.com/problems/divide-two-integers/description/
public sealed class Solution {
	public int Divide(int dividend, int divisor) {
		long lDividend = dividend;
		long lDivisor = divisor;
		
		if (Math.Abs(lDivisor) == 1) {
			if (divisor == 1) {
				return dividend;
			}

			if (dividend == int.MinValue) {
				return int.MaxValue;
			}

			return -dividend;
		}

		long dvd = Math.Abs(lDividend), dvs = Math.Abs(lDivisor), ans = 0;
		int sign = dividend > 0 ^ divisor > 0 ? -1 : 1;
		while (dvd >= dvs) {
			long temp = dvs, m = 1;
			while (temp << 1 <= dvd) {
				temp <<= 1;
				m <<= 1;
			}
			dvd -= temp;
			ans += m;
		}
		return (int)(sign * ans);
	}
}