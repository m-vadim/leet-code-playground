/// <summary>
/// https://leetcode.com/problems/minimum-number-of-operations-to-make-array-empty
/// </summary>
public class Solution {
	public int MinOperations(int[] nums) {
		var frequencyByNum = new Dictionary<int, int>();
		foreach (int num in nums) {
			frequencyByNum.TryGetValue(num, out int count);
			frequencyByNum[num] = count + 1;
		}

		var minOperations = 0;
		foreach ((int _, int frequency) in frequencyByNum) {
			if (frequency == 1) {
				return -1;
			}

			minOperations += MinOperations(frequency);
		}

		return minOperations;
	}
	
	public int MinOperationsSort(int[] nums) {
		if (nums.Length < 2) {
			return -1;
		}

		Array.Sort(nums);

		int count = 1, prev = nums[0], minOperations = 0;
		for (var index = 1; index < nums.Length; index++) {
			int num = nums[index];
			if (num == prev) {
				count += 1;
			}
			else {
				if (count == 1) {
					return -1;
				}

				minOperations += MinOperations(count);

				prev = num;
				count = 1;
			}
		}

		if (count == 1) {
			return -1;
		}
		
		minOperations += MinOperations(count);

		return minOperations;
	}
	
	private static int MinOperations(int frequency) {
		int by3 = frequency % 3;
		return by3 switch {
			0 => frequency / 3,
			_ => (frequency - by3) / 3 + 1
		};
	}
}