using LeetCode;

/// <summary>
///     https://leetcode.com/problems/reverse-odd-levels-of-binary-tree/
/// </summary>
public class Solution {
	public TreeNode ReverseOddLevels(TreeNode root) {
		var q = new Queue<TreeNode>();
		var orderedValues = new Stack<int>();
		q.Enqueue(root);
		orderedValues.Push(root.val);

		int level = 1;
		uint itemsOnLevel = 1;

		while (q.Count > 0) {
			TreeNode node = q.Dequeue();

			if (level % 2 == 0) {
				node.val = orderedValues.Pop();
			}

			if (node.left != null) {
				q.Enqueue(node.left);
				q.Enqueue(node.right);

				if (level % 2 == 1) {
					orderedValues.Push(node.left.val);
					orderedValues.Push(node.right.val);
				}
			}

			itemsOnLevel -= 1;
			if (itemsOnLevel == 0) {
				level += 1;
				itemsOnLevel = Pow2(level - 1);
			}
		}

		return root;
	}

	private static uint Pow2(int val) => (uint)(1 << val);
}


