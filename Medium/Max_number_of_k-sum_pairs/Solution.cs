/// <summary>
/// https://leetcode.com/problems/max-number-of-k-sum-pairs
/// </summary>
public class Solution {
	public int MaxOperations(int[] nums, int k) {
		int leftIndex = 0, rightIndex = nums.Length - 1;
		var operations = 0;
		Array.Sort(nums);
		
		while (leftIndex < rightIndex) {
			int left = nums[leftIndex];
			if (left >= k) {
				break;
			}
			
			int right = nums[rightIndex];
			if (right >= k) {
				rightIndex--;
				continue;
			}
			
			int numsSum = left + right;
			
			if (numsSum == k) {
				operations++;
				rightIndex--;
				leftIndex++;
				continue;
			}

			if (numsSum < k) {
				leftIndex++;
			}
			else {
				rightIndex--;
			}
		}

		return operations;
	}
	
	public int MaxOperationsMap(int[] nums, int k) {
		var map = new Dictionary<int, int>();
		int c = 0;
		foreach (int num in nums) {
			int diff = k - num;

			if (map.TryGetValue(diff, out int value) && value > 0) {
				c++;
				map[diff]--;
			}
			else {
				if (map.ContainsKey(num)) {
					map[num]++;
				}
				else {
					map.Add(num, 1);
				}
			}
		}

		return c;
	}
}