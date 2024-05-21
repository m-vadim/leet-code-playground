/// <summary>
/// https://leetcode.com/problems/subsets
/// </summary>
public class Solution {
	public IList<IList<int>> Subsets(int[] nums) {
		var subsets = new List<IList<int>>();
		GenerateSubsets(nums, 0, [], subsets);
		return subsets;
	}

	private static void GenerateSubsets(int[] nums, int index, List<int> currentSubset, List<IList<int>> subsets) {
		if (index == nums.Length) {
			subsets.Add(new List<int>(currentSubset));
			return;
		}

		currentSubset.Add(nums[index]);
		GenerateSubsets(nums, index + 1, currentSubset, subsets);

		currentSubset.RemoveAt(currentSubset.Count - 1);
		GenerateSubsets(nums, index + 1, currentSubset, subsets);
	}
}
