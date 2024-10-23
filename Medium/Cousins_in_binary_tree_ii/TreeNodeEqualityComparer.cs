namespace LeetCode;

internal sealed class TreeNodeEqualityComparer : IEqualityComparer<TreeNode> {
	public bool Equals(TreeNode x, TreeNode y) {
		if (ReferenceEquals(x, y)) {
			return true;
		}

		var q1 = new Queue<TreeNode?>();
		q1.Enqueue(x);

		var q2 = new Queue<TreeNode?>();
		q2.Enqueue(y);

		while (q1.Count > 0 && q2.Count > 0) {
			var node1 = q1.Dequeue();
			var node2 = q2.Dequeue();

			if (node1.val != node2?.val) {
				return false;
			}

			if (node1.left != null) {
				q1.Enqueue(node1.left);
			}

			if (node1.right != null) {
				q1.Enqueue(node1.right);
			}

			if (node2.left != null) {
				q2.Enqueue(node1.left);
			}

			if (node2.right != null) {
				q2.Enqueue(node2.right);
			}
		}

		return q1.Count == q2.Count && q1.Count == 0;
	}

	public int GetHashCode(TreeNode? obj) {
		if (obj is null) {
			return 0;
		}

		return obj.val.GetHashCode();
	}
}
