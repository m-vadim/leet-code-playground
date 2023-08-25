// https://leetcode.com/problems/product-of-array-except-self/
namespace LeetCode; 

public class Solution {
	public int[] ProductExceptSelf(int[] nums) {
		int len = nums.Length;
		var output = new int[len];
		
		int product = nums[0];
		for (int i = 1; i < len; i++) {
			output[i] = product;
			product *= nums[i];
		}

		product = nums[^1];
		for (int i = len - 2; i > 0; i--) {
			output[i] *= product;
			product *= nums[i];
		}

		output[0] = product;
		
		return output;
	}
}
