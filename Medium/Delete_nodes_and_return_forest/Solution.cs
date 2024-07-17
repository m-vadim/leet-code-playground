using LeetCode;

/// <summary>
///     https://leetcode.com/problems/delete-nodes-and-return-forest
/// </summary>
public class Solution {
	public IList<TreeNode> DelNodes(TreeNode root, int[] toDelete) {
		var deleted = new HashSet<int>(toDelete);
		var result = new List<TreeNode>();
		Dfs(root, true, deleted.Contains(root.val),  result, deleted);

		return result;
	}

	private void Dfs(TreeNode node, bool hasNoParent, bool nodeDeleted, List<TreeNode> result, HashSet<int> deletedSet) {
		bool hasLeft = node.left != null;
		bool leftDeleted = hasLeft && deletedSet.Contains(node.left.val);

		bool hasRight = node.right != null;
		bool rightDeleted = hasRight && deletedSet.Contains(node.right.val);

		if (hasLeft) {
			Dfs(node.left, nodeDeleted, leftDeleted, result, deletedSet);
		}

		if (hasRight) {
			Dfs(node.right, nodeDeleted, rightDeleted, result, deletedSet);
		}

		if (!nodeDeleted) {
			if (leftDeleted) {
				node.left = null;
			}
			if (rightDeleted) {
				node.right = null;
			}

			if (hasNoParent) {
				result.Add(node);
			}
		}
	}
}
