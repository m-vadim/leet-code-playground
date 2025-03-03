namespace LeetCode;

internal static class BinaryTreeConverter {
	public static TreeNode ToTree(int?[] nodes) {
		if (nodes.Length == 0) {
			throw new InvalidOperationException($"{nameof(nodes)} can not be empty");
		}

		if (!nodes[0].HasValue) {
			throw new InvalidOperationException("Root node can not be null");
		}

		var root = new TreeNode(nodes[0].Value);
		var q = new Queue<TreeNode>();
		q.Enqueue(root);

		for (var i = 1; i < nodes.Length; i += 2) {
			var left = nodes[i];
			var right = i + 1 < nodes.Length ? nodes[i + 1] : null;

			var prevRoot = q.Dequeue();
			if (left.HasValue) {
				prevRoot.left = new TreeNode(left.Value);
				q.Enqueue(prevRoot.left);
			}

			if (right.HasValue) {
				prevRoot.right = new TreeNode(right.Value);
				q.Enqueue(prevRoot.right);
			}
		}

		return root;
	}

	public static int?[] ToArray(TreeNode? root) {
		if (root == null) {
			return [];
		}

		var result = new List<int?>();
		var queue = new Queue<TreeNode?>();

		queue.Enqueue(root);

		while (queue.Count > 0) {
			var current = queue.Dequeue();

			if (current == null) {
				result.Add(null);
				continue;
			}

			result.Add(current.val);

			queue.Enqueue(current.left);
			queue.Enqueue(current.right);
		}

		for (var i = result.Count - 1; i >= 0; i--) {
			if (result[i] == null) {
				result.RemoveAt(i);
			} else {
				break;
			}
		}

		return result.ToArray();
	}
}
