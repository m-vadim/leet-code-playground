using LeetCode;

/// <summary>
/// https://leetcode.com/problems/kth-largest-sum-in-a-binary-tree
/// </summary>
public class Solution {
	public long KthLargestLevelSum(TreeNode root, int k) {
		var q = new Queue<TreeNode>();
		q.Enqueue(root);

		var heap = new PriorityQueue<long, long>(k);

		while (q.Count > 0) {
			long sum = 0;
			var len = q.Count;
			while (len-- > 0) {
				var node = q.Dequeue();
				sum += node.val;
				if (node.left != null) {
					q.Enqueue(node.left);
				}
				if (node.right != null) {
					q.Enqueue(node.right);
				}
			}
			heap.Enqueue(sum, -sum);
		}

		if (heap.Count < k) {
			return -1;
		}

		while (k-- > 1) {
			heap.Dequeue();
		}

		return heap.Dequeue();
	}
}
