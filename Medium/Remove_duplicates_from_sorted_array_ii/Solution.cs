namespace LeetCode;

/// <summary>
/// https://leetcode.com/problems/remove-duplicates-from-sorted-array-ii
/// </summary>
public sealed class Solution {
    public int RemoveDuplicates(int[] nums) {
	    int prev = nums[0], count = 1, k = 1;
	    for (int i = 1; i < nums.Length; i++) {
		    int n = nums[i];
		    if (n == prev) {
			    if (count < 2) {
				    count++;
				    k++;
			    }
			    else {
				    nums[i] = int.MaxValue;
			    }
		    }
		    else {
			    count = 1;
			    prev = n;
			    k++;
		    }
	    }

	    int i1 = 1, num;
	    while (true) {
		    while (i1 < nums.Length &&  nums[i1] != int.MaxValue) {
			    i1++;
		    }

		    num = i1 + 1;
		    while (num < nums.Length && nums[num] == int.MaxValue) {
			    num++;
		    }

		    if (i1 == nums.Length || num == nums.Length) {
			    break;
		    }
		    
		    (nums[i1], nums[num]) = (nums[num], nums[i1]);
		    i1++;
	    }

	    return k;
    }
}