using LeetCode;

/// <summary>
/// https://leetcode.com/problems/cousins-in-binary-tree-ii
/// </summary>
public class Solution {
	public TreeNode ReplaceValueInTree(TreeNode root) {
		var list = new List<TreeNode> { root };
		root.val = 0;
		if (root.left != null) {
			root.left.val = 0;
		}
		if (root.right != null) {
			root.right.val = 0;
		}

		while (list.Count > 0) {
			var sum = 0;
			var len = list.Count;
			for (var i = 0; i < len; i++) {
				var node = list[i];
				if (node.left != null) {
					sum += node.left.val;
				}
				if (node.right != null) {
					sum += node.right.val;
				}
			}

			for (var i = 0; i < len; i++) {
				var node = list[i];
				int val = sum - (node.left?.val ?? 0) - (node.right?.val ?? 0);

				if (node.left != null) {
					node.left.val = val;
					list.Add(node.left);
				}
				if (node.right != null) {
					node.right.val = val;
					list.Add(node.right);
				}
			}

			list.RemoveRange(0, len);
		}

		return root;
	}
}
