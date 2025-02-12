/// <summary>
///     https://leetcode.com/problems/max-sum-of-a-pair-with-equal-sum-of-digits
/// </summary>
public class Solution {
	public int MaximumSum(int[] nums) {
		var twoBiggestNumberBySum = new Dictionary<int, int[]>();
		int max = -1;
		foreach (int n in nums) {
			int sum = GetDigitsSum(n);
			if (!twoBiggestNumberBySum.TryGetValue(sum, out int[] twoNumbers)) {
				twoBiggestNumberBySum.Add(sum, [n, -1]);
				continue;
			}

			if (n > twoNumbers[1]) {
				if (n > twoNumbers[0]) {
					twoNumbers[1] = twoNumbers[0];
					twoNumbers[0] = n;
				} else {
					twoNumbers[1] = n;
				}

				max = Math.Max(max, twoNumbers[0] + twoNumbers[1]);
			}
		}

		return max;
	}

	private static int GetDigitsSum(int num) {
		if (num < 10) {
			return num;
		}

		int sum = 0;
		while (num > 9) {
			sum += num % 10;
			num /= 10;
		}

		return sum + num;
	}
}
