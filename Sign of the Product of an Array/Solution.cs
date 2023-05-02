namespace LeetCode;

// https://leetcode.com/problems/sign-of-the-product-of-an-array/description/
public class Solution {
	public int ArraySign(int[] nums) {
		bool isNegative = false;
		foreach (int n in nums) {
			if (n == 0) {
				return 0;
			}

			if (n < 0) {
				isNegative = !isNegative;
			}
		}

		return isNegative ? -1 : 1;
	}
}