using LeetCode;

/// <summary>
/// https://leetcode.com/problems/diameter-of-binary-tree
/// </summary>
public class Solution {
	private int _max = 0;
	
	public int DiameterOfBinaryTree(TreeNode root) {
		DFS(root);
		return _max;
	}

	private int DFS(TreeNode node) {
		if (node == null) {
			return 0;
		}

		int l = node.left == null ? 0 : 1 + DFS(node.left);
		int r = node.right == null ? 0  : 1 + DFS(node.right);

		_max = Math.Max(_max, l + r);
		
		return Math.Max(l, r);
	}
}