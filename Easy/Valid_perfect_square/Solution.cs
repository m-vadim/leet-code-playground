/// <summary>
/// https://leetcode.com/problems/perfect-squares/
/// </summary>
public class Solution {
	public bool IsPerfectSquare(int n) {
		int l = 1, r = n, mid, sq;

		while (true) {
			mid = (r + l) / 2;
			if (mid > (int.MaxValue / mid)) {
				r = mid;
				continue;
			}

			sq = mid * mid;
			if (sq == n) {
				return true;
			}

			if (mid == r || mid == l) {
				break;
			}

			if (sq > n) {
				r = mid;
			} else {
				l = mid;
			}
		}

		return false;
	}
}
