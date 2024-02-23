/// <summary>
/// https://leetcode.com/problems/kth-largest-element-in-an-array/
/// </summary>
public class Solution {
	public int FindKthLargest(int[] nums, int k) {
		var heap = new PriorityQueue<int, int>();
		foreach (int n in nums) {
			if (heap.Count < k) {
				heap.Enqueue(n, n);
			} else if (heap.Peek() < n) {
				heap.Dequeue();
				heap.Enqueue(n, n);
			}
		}
		
		return heap.Peek();
	}
}