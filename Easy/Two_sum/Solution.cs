// https://leetcode.com/problems/two-sum/
public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        var h = new HashSet<int>();
        for (int i = 0; i < nums.Length; i++) {
            if (h.Contains(nums[i])) {
                for (int y = 0; y < i + 1; y++) {
                    if (nums[y] + nums[i] == target) {
                        return new[] {y, i};
                    }
                }
            }

            h.Add(target - nums[i]);
        }

        return Array.Empty<int>();
    }
}