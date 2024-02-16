/// <summary>
/// https://leetcode.com/problems/least-number-of-unique-integers-after-k-removals
/// </summary>
public class Solution {
	public int FindLeastNumOfUniqueInts(int[] arr, int k) {
		IReadOnlyDictionary<int, int> frequencyByNumber = CalculateFrequencies(arr);

		int uniqueNumbers = frequencyByNumber.Count;
		foreach (int frequency in frequencyByNumber.OrderBy(fbn => fbn.Value).Select(fbn => fbn.Value)) {
			if (frequency <= k) {
				uniqueNumbers--;
				k -= frequency;
			}
			else {
				break;
			}
		}

		return uniqueNumbers;
	}

	private static IReadOnlyDictionary<int, int> CalculateFrequencies(int[] nums) {
		var map = new Dictionary<int, int>();
		foreach (int n in nums) {
			if (map.TryGetValue(n, out int count)) {
				map[n] = count + 1;
			}
			else {
				map.Add(n, 1);
			}
		}

		return map;
	}
}