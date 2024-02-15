/// <summary>
/// https://leetcode.com/problems/find-polygon-with-the-largest-perimeter
/// </summary>
public class Solution {
	public long LargestPerimeter(int[] nums) {
		Array.Sort(nums);
		int len = nums.Length;
		var prefix = new long[len];
		prefix[0] = nums[0];
		
		for(int i = 1; i < len; i++) {
			prefix[i] = prefix[i - 1] + nums[i];
		}
        
		for(int i = len - 1; i > 1; i--) {
			if (nums[i] < prefix[i - 1]) {
				return prefix[i];
			}
		}
		
		return -1;
	}
}