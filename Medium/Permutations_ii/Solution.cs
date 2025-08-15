/// <summary>
/// https://leetcode.com/problems/permutations-ii/
/// </summary>
public class Solution {
	public IList<IList<int>> PermuteUnique(int[] nums) {
		var freqs = new Dictionary<int, int>();
		foreach (int num in nums) {
			if (freqs.TryGetValue(num, out int count)) {
				freqs[num] = count + 1;
			} else {
				freqs[num] = 1;
			}
		}
		var result = new List<IList<int>>();
		Permute(nums.Length, result, new List<int>(3), freqs);
		return result;
	}

	private static void Permute(int size, IList<IList<int>> result, List<int> permutation, Dictionary<int, int> freqs) {
		if (permutation.Count == size) {
			result.Add(permutation.ToArray());
		}

		foreach (KeyValuePair<int, int> n in freqs) {
			if (n.Value > 0) {
				permutation.Add(n.Key);
				freqs[n.Key]--;
				Permute(size, result, permutation, freqs);
				permutation.RemoveAt(permutation.Count - 1);
				freqs[n.Key]++;
			}
		}
	}
}
