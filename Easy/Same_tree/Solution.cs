using LeetCode;

/// <summary>
/// https://leetcode.com/problems/same-tree
/// </summary>
public class Solution {
	public bool IsSameTree(TreeNode left, TreeNode right) {
		var queueLeft = new Queue<TreeNode>();
		var queueRight = new Queue<TreeNode>();

		queueLeft.Enqueue(left);
		queueRight.Enqueue(right);

		while (queueLeft.Count > 0 && queueRight.Count > 0) {
			TreeNode l = queueLeft.Dequeue();
			TreeNode r = queueRight.Dequeue();

			if (l == null && r == null) {
				continue;
			}

			if (l == null || r == null || l.val != r.val) {
				return false;
			}

			queueLeft.Enqueue(l.left);
			queueLeft.Enqueue(l.right);

			queueRight.Enqueue(r.left);
			queueRight.Enqueue(r.right);
		}

		return true;
	}

	public bool IsSameTreeRecursion(TreeNode left, TreeNode right) {
		if (left == null && right == null) {
			return true;
		}

		if (left == null || right == null) {
			return false;
		}

		return left.val == right.val && IsSameTree(left.left, right.left) && IsSameTree(left.right, right.right);
	}
}