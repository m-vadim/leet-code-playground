namespace LeetCode;

/// <summary>
/// https://leetcode.com/problems/maximum-depth-of-binary-tree
/// </summary>
public class Solution {
	public int MaxDepth(TreeNode root) {
		if (root == null) {
			return 0;
		}
		
		if (root.right == null && root.left == null) {
			return 1;
		}

		return MaxDepthInternal(root);
	}

	private static int MaxDepthInternal(TreeNode node) {
		if (node.right == null && node.left == null) {
			return 1;
		}

		int leftDepth = 0;
		if (node.left != null) {
			leftDepth = MaxDepthInternal(node.left);
		}

		int rightDepth = 0;
		if (node.right != null) {
			rightDepth = MaxDepthInternal(node.right);
		}

		return 1 + Math.Max(leftDepth, rightDepth);
	}
}