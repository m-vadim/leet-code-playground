/// <summary>
///     https://leetcode.com/problems/minimized-maximum-of-products-distributed-to-any-store
/// </summary>
public sealed class Solution {
	public int MinimizedMaximum(int n, int[] quantities) {
		int min = 1, max = 0;
		foreach (int quantity in quantities) {
			max = Math.Max(max, quantity);
		}

		if (quantities.Length == n) {
			return max;
		}

		while (min < max) {
			var mid = (max + min) / 2;
			if (CanDistribute(mid, quantities, n)) {
				max = mid;
			} else {
				min = mid + 1;
			}
		}

		return min;
	}

	private static int Ceil(int a, int b) {
		return (a + b - 1) / b;
	}

	private static bool CanDistribute(int val, int[] quantities, int storesCount) {
		foreach (var q in quantities) {
			storesCount -= Ceil(q, val);
			if (storesCount < 0) {
				return false;
			}
		}

		return true;
	}
}
