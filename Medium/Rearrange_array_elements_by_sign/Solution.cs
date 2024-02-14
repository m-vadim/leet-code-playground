/// <summary>
/// https://leetcode.com/problems/rearrange-array-elements-by-sign
/// </summary>
public class Solution {
	public int[] RearrangeArray(int[] nums) {
		var result = new int[nums.Length];
		int pos = 0, neg = 1;
		
		foreach (int num in nums) {
			if (num > 0) {
				result[pos] = num;
				pos+=2;
			}
			else {
				result[neg] = num;
				neg+=2;
			}
		}

		return result;
	}
}