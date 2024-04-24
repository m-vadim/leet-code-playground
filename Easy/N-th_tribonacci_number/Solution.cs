/// <summary>
/// https://leetcode.com/problems/n-th-tribonacci-number
/// </summary>
public sealed class Solution {
	public int Tribonacci(int n) {
		if (n < 2) {
			return n;
		}

		int[] memo = { 0, 1, 1 };
		for (int i = 3; i <= n; i++) {
			int next = memo[0] + memo[1] + memo[2];
			memo[0] = memo[1];
			memo[1] = memo[2];
			memo[2] = next;
		}

		return memo[^1];
	}
}
