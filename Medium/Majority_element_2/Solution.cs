/// <summary>
/// https://leetcode.com/problems/majority-element-ii
/// </summary>
public class Solution {
	public IList<int> MajorityElement(int[] nums) {
		ushort count1 = 0, count2 = 0;
		int candidate1 = 0, candidate2 = 0;

		foreach (int num in nums) {
			if (count1 == 0 && num != candidate2) {
				candidate1 = num;
				count1 = 1;
			} else if (count2 == 0 && num != candidate1) {
				candidate2 = num;
				count2 = 1;
			}else if (num == candidate1) {
				count1++;
			} else if (num == candidate2) {
				count2++;
			}
			else {
				count1--;
				count2--;
			}
		}

		int threshold = nums.Length / 3;
		count1 = 0;
		count2 = 0;
		
		foreach (int num in nums) {
			if (num == candidate1) {
				count1++;
			} else if (num == candidate2) {
				count2++;
			}
		}
		
		var result = new List<int>(2);
		if (count1 > threshold) {
			result.Add(candidate1);
		}

		if (count2 > threshold) {
			result.Add(candidate2);
		}

		return result;
	}
	
	public IList<int> MajorityElementBySort(int[] nums) {
		var result = new List<int>();

		Array.Sort(nums);

		int c = 1, prev = nums[0], threshold = nums.Length / 3;
		for(int i = 1; i < nums.Length; i++) {
			if (nums[i] == prev) {
				c++;
			} else {
				if (c > threshold) {
					result.Add(prev);
				}
                
				prev = nums[i];
				c = 1;
			}
		}

		if (c > threshold) {
			result.Add(prev);
		}

		return result;
	}
}