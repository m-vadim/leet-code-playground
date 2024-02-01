/// <summary>
/// https://leetcode.com/problems/divide-array-into-arrays-with-max-difference
/// </summary>
public class Solution {
	public int[][] DivideArray(int[] nums, int k) {
		Array.Sort(nums);
        
		int arrayIndex = 0, index = 0, len = nums.Length / 3;
		var results = new int[len][];

		while (arrayIndex < len) {
			int bigger = nums[index + 2], smaller = nums[index];
			if (bigger - smaller > k) {
				return Array.Empty<int[]>();
			}

			results[arrayIndex] = [smaller, nums[index + 1], bigger];
			arrayIndex++;
			index += 3;
		}

		return results;
	}
}