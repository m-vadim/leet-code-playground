/// <summary>
/// https://leetcode.com/problems/combination-sum-ii
/// </summary>
public class Solution {
	public IList<IList<int>> CombinationSum2(int[] candidates, int target) {
		Array.Sort(candidates);

		List<IList<int>> combinations = [];
		FindCombinations(candidates, 0, target, [], combinations);

		return combinations;
	}

	private static void FindCombinations(int[] candidates, int startIndex, int target, List<int> combination, ICollection<IList<int>> combinations) {
		var prev = -1;
		for (var index = startIndex; index < candidates.Length; index++) {
			var candidate = candidates[index];
			if (candidate > target) {
				break;
			}

			if (prev == candidate) {
				continue;
			}

			combination.Add(candidate);
			if (candidate == target) {
				combinations.Add(new List<int>(combination));
			} else {
				FindCombinations(candidates, index + 1, target - candidate, combination, combinations);
			}
			combination.RemoveAt(combination.Count - 1);
			prev = candidate;
		}
	}
}
