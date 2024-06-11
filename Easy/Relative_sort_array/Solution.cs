/// <summary>
/// https://leetcode.com/problems/relative-sort-array
/// </summary>
public class Solution {
	public int[] RelativeSortArray(int[] arr1, int[] arr2) {
		var map = new Dictionary<int, int>(arr2.Length);
		foreach (int n in arr2) {
			map.Add(n, 0);
		}

		foreach (int n in arr1) {
			if (map.ContainsKey(n)) {
				map[n] += 1;
			}
		}

		Array.Sort(arr1);

		var result = new int[arr1.Length];
		int resultIndex = 0;
		for (int i = 0; i < arr2.Length; i++) {
			int num = arr2[i];
			int count = map[num];
			for (int y = 1; y <= count; y++) {
				result[resultIndex++] = num;
			}
		}

		for (int i = 0; i < arr1.Length; i++) {
			if (!map.ContainsKey(arr1[i])) {
				result[resultIndex++] = arr1[i];
			}
		}

		return result;
	}
}
