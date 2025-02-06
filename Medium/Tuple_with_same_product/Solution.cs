/// <summary>
///     https://leetcode.com/problems/tuple-with-same-product
/// </summary>
public class Solution {
	public int TupleSameProduct(int[] nums) {
		var map = new Dictionary<int, int>();

		int n1, n2;
		for (int i = 0; i < nums.Length; i++) {
			n1 = nums[i];
			for(int y = i + 1; y < nums.Length; y++) {
				n2 = nums[y];
				if (n2 != n1) {
					map[n1 * n2] = map.GetValueOrDefault(n1 * n2) + 1;
				}
			}
		}

		n1 = 0;
		foreach ((int _, int count) in map) {
			if (count > 1) {
				n1 += PairsCount(count);
			}
		}

		return n1 * 8;
	}

	private static int PairsCount(int n) {
		n = n - 1;
		return (n * (n + 1)) / 2;
	}
}
