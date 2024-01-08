using LeetCode;

/// <summary>
/// https://leetcode.com/problems/range-sum-of-bst
/// </summary>
public class Solution {
	private int _sum;
	
	public int RangeSumBST(TreeNode root, int low, int high) {
		TraverseAndSum(root, low, high);
		return _sum;
	}

	private void TraverseAndSum(TreeNode node, int low, int high) {
		if (node == null) {
			return;
		}
		
		if (node.val >= low && node.val <= high) {
			_sum += node.val;
		}
		
		if (node.val > low) {
			TraverseAndSum(node.left, low, high);
		}

		if (node.val < high) {
			TraverseAndSum(node.right, low, high);
		}
	}

	public int RangeSumBSTStack(TreeNode root, int low, int high) {
		int sum = 0;
		var treeStack = new Stack<TreeNode>();
		while (root != null || treeStack.Count > 0) {
			while (root != null) {
				treeStack.Push(root);
				if (root.left != null && root.val > low) {
					root = root.left;
				}
				else {
					root = null;
				}
			}

			root = treeStack.Pop();
			if (root.val >= low && root.val <= high) {
				sum += root.val;
			}

			if (root.right != null && root.val < high) {
				root = root.right;
			}
			else {
				root = null;
			}
		}

		return sum;
	}
}