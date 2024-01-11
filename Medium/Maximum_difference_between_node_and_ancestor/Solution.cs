using LeetCode;

public class Solution {
	public int MaxAncestorDiff(TreeNode root) {
		return Math.Max(Dfs(root.left, root.val, root.val), Dfs(root.right, root.val, root.val));
	}

	private int Dfs(TreeNode node, int min, int max) {
		if (node == null) {
			return -1;
		}
		
		min = Math.Min(min, node.val);
		max = Math.Max(max, node.val);

		int diff = Math.Abs(max - min);
		int bestLeft = Dfs(node.left, min, max);
		int bestRight = Dfs(node.right, min, max);

		return Math.Max(diff, Math.Max(bestLeft, bestRight));
	}
}