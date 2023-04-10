namespace LeetCode;

// https://leetcode.com/problems/find-first-and-last-position-of-element-in-sorted-array/description/
public class Solution {
	public int[] SearchRange(int[] nums, int target) {
		int[] res = { -1, -1 };
		
		if (nums.Length == 0) {
			return res;
		}

		int low = 0, high = nums.Length-1;
		int startingPosition = LowerBound(nums, low, high, target);
		int endingPosition = LowerBound(nums, low, high, target + 1) - 1;
		if(startingPosition < nums.Length && nums[startingPosition] == target) {
			res[0] = startingPosition;
			res[1] = endingPosition;
			return res;
		}
		

		return res;
	}
	
	private static int LowerBound(int[] nums, int low, int high, int target){
		while(low <= high){
			int mid = (low + high) >> 1;
			if(nums[mid] < target){
				low = mid + 1;
			}
			else{
				high = mid - 1;
			}
		}
		return low;
	}
}