/// <summary>
/// https://leetcode.com/problems/interval-list-intersections/
/// </summary>
public class Solution {
	public int[][] IntervalIntersection(int[][] firstList, int[][] secondList) {
		int firstPointer = 0, secondPointer = 0;
		List<int[]> result = [];

		while (firstPointer < firstList.Length && secondPointer < secondList.Length) {
			int[] f = firstList[firstPointer];
			int[] s = secondList[secondPointer];

			if (f[0] == s[0] && f[1] == s[1]) { // Same
				result.Add(f);
				firstPointer++;
				secondPointer++;
				continue;
			}

			if (f[1] < s[1]) { // first starts earlier
				firstPointer++;
			} else {
				secondPointer++;
			}

			if (TryGetInterSection(f, s, out int[] intersection)) {
				result.Add(intersection);
			}
		}

		return result.ToArray();
	}

	private static bool TryGetInterSection(int[] first, int[] second, out int[] intersection) {
		if (first[1] < second[0] || second[1] < first[0]) {
			intersection = [];
			return false;
		}

		intersection = [Math.Max(first[0], second[0]), Math.Min(first[1], second[1])];
		return true;
	}
}
