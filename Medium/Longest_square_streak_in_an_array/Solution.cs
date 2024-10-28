/// <summary>
/// https://leetcode.com/problems/longest-square-streak-in-an-array
/// </summary>
public class Solution {
	public int LongestSquareStreak(int[] nums) {
		Array.Sort(nums);
		var seen = new HashSet<int>(nums.Length);

		int streak = 0, maxStreak = 1;
		foreach (var num in nums) {
			if (num > 46340) {
				break;
			}

			if (seen.Contains(num)) {
				continue;
			}

			streak = 1;
			var pow = num * num;
			while (Array.BinarySearch(nums, pow) > 0) {
				streak++;
				seen.Add(pow);
				pow = pow * pow;
			}
			maxStreak = Math.Max(streak, maxStreak);
		}

		return maxStreak == 1 ? -1 : maxStreak;
	}
}
