/// <summary>
///     https://leetcode.com/problems/minimum-operations-to-exceed-threshold-value-ii
/// </summary>
public class Solution {
	public int MinOperations(int[] nums, int k) {
		var pq = new PriorityQueue<int, int>();

		foreach (var n in nums) {
			pq.Enqueue(n, n);
		}

		var operations = 0;
		while (pq.Peek() < k) {
			int n1 = pq.Dequeue(), n2 = pq.Dequeue();
			n1 = Operation(n1, n2, k);
			pq.Enqueue(n1, n1);
			operations++;
		}

		return operations;
	}

	private static int Operation(int smaller, int bigger, int k) {
		// overflow
		if (bigger > k - smaller) {
			return k;
		}

		return smaller * 2 + bigger;
	}
}
