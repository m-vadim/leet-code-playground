using LeetCode;

/// <summary>
/// https://leetcode.com/problems/delete-leaves-with-a-given-value
/// </summary>
public class Solution {
	public TreeNode RemoveLeafNodes(TreeNode root, int target) {
		if (Dfs(root, target)) {
			return null;
		}

		return root;
	}

	private bool Dfs(TreeNode node, int target) {
		if (node.left != null && Dfs(node.left, target)) {
			node.left = null;
		}

		if (node.right != null && Dfs(node.right, target)) {
			node.right = null;
		}

		return node.val == target && node.left == null && node.right == null;
	}
}
