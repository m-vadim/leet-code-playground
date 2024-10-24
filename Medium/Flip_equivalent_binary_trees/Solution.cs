#nullable disable
using LeetCode;

/// <summary>
/// https://leetcode.com/problems/flip-equivalent-binary-trees
/// </summary>
public class Solution {
	public bool FlipEquiv(TreeNode root1, TreeNode root2) {
		return TraverseEquality(root1, root2);
	}

	private static bool TraverseEquality(TreeNode node1, TreeNode node2) {
		if (node1 == null && node2 == null) {
			return true;
		}

		if (node1 == null || node2 == null) {
			return false;
		}

		if (node1.val != node2.val) {
			return false;
		}

		if (TraverseEquality(node1.left, node2.left)) {
			return TraverseEquality(node1.right, node2.right);
		}

		return TraverseEquality(node1.left, node2.right) && TraverseEquality(node1.right, node2.left);
	}
}
