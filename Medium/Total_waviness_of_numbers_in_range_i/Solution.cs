/// <summary>
/// https://leetcode.com/problems/total-waviness-of-numbers-in-range-i
/// </summary>
public sealed class Solution {
	public int TotalWaviness(int num1, int num2) {
		int total = 0;
		for (int i = num1; i <= num2; i++) {
			total += CalculateNumberWaviness(i);
		}

		return total;
	}

	private static int CalculateNumberWaviness(int num) {
		if (num < 100) {
			return 0;
		}

		string numStr = num.ToString();
		int waviness = 0, diff1, diff2;
		for (int i = 1; i < numStr.Length - 1; i++) {
			diff1 = numStr[i] - numStr[i - 1];
			diff2 = numStr[i] - numStr[i + 1];
			if ((diff1 > 0 && diff2 > 0) || (diff1 < 0 && diff2 < 0)) {
				waviness++;
			}
		}

		return waviness;
	}
}
