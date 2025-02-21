using LeetCode;

/// <summary>
///     https://leetcode.com/problems/find-elements-in-a-contaminated-binary-tree/
/// </summary>
public class FindElements {
	private readonly HashSet<int> _map = [];
	public FindElements(TreeNode root) {
		var queue = new Queue<TreeNode>();
		root.val = 0;
		queue.Enqueue(root);
		while (queue.Count > 0) {
			TreeNode p = queue.Dequeue();
			_map.Add(p.val);
			if (p.left != null) {
				p.left.val = 2 * p.val + 1;
				queue.Enqueue(p.left);
			}

			if (p.right != null) {
				p.right.val = 2 * p.val + 2;
				queue.Enqueue(p.right);
			}
		}
	}

	public bool Find(int target) {
		return _map.Contains(target);
	}
}
