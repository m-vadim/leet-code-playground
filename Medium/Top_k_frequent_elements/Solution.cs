namespace LeetCode;

// https://leetcode.com/problems/top-k-frequent-elements/description/
public class Solution {
	public int[] TopKFrequent(int[] nums, int k) {
		var map = new Dictionary<int, int>();
		foreach (int n in nums) {
			if (map.ContainsKey(n)) {
				map[n] += 1;
			}
			else {
				map.Add(n, 1);
			}
		}

		var queue = new PriorityQueue<int, int>(k, DescCountComparer.Instance);
		foreach ((int key, int value) in map) {
			queue.Enqueue(key, value);
		}

		var result = new int[k];
		while (k > 0) {
			result[k - 1] = queue.Dequeue();
			k--;
		}

		return result;
	}
}

internal class DescCountComparer : IComparer<int> {
	public static readonly DescCountComparer Instance = new();
	public int Compare(int x, int y) {
		if (x == y) {
			return 0;
		}

		if (x > y) {
			return -1;
		}

		return 1;
	}
}