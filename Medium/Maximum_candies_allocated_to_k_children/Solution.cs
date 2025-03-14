/// <summary>
///     https://leetcode.com/problems/maximum-candies-allocated-to-k-children
/// </summary>
public class Solution {
	public int MaximumCandies(int[] candies, long k) {
		long total = 0;
		foreach (int pile in candies) {
			total += pile;
		}

		if (total < k) {
			return 0;
		}

		long max = total / k;
		long min = 1;

		while (min <= max) {
			long mid = min + (max - min) / 2;
			if (CanBeDistributed(candies, mid, k)) {
				min = mid + 1;
			} else {
				max = mid - 1;
			}
		}

		return (int)max;
	}

	private static bool CanBeDistributed(int[] candies, long candiesCount, long k) {
		int index = 0;
		while (index < candies.Length && k > 0) {
			k -= (candies[index] / candiesCount);
			index++;
		}

		return k < 1;
	}
}
