namespace LeetCode;

// https://leetcode.com/problems/kids-with-the-greatest-number-of-candies/description/
public class Solution {
	public IList<bool> KidsWithCandies(int[] candies, int extraCandies) {
		int max = 0;
		foreach (int c in candies) {
			if (c > max) {
				max = c;
			}
		}

		var result = new bool[candies.Length];
		for (var i = 0; i < candies.Length; i++) {
			result[i] = candies[i] + extraCandies >= max;
		}
		
		return result;
	}
}