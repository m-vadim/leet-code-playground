namespace LeetCode;

public sealed class BinaryTreeSerializer {
	public static TreeNode Serialize(int?[] nodes) {
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
}
