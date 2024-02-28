using LeetCode;

/// <summary>
/// https://leetcode.com/problems/find-bottom-left-tree-value
/// </summary>
public class Solution {
	public int FindBottomLeftValue(TreeNode root) {
		var lev = new LevelLeft(1, root.val);
		DFS(root, lev, lev.Level + 1);

		return lev.Value;
	}

	private void DFS(TreeNode node, LevelLeft bottomLeft, int nextLevel) {
		if (node == null) {
			return;
		}

		if (nextLevel > bottomLeft.Level) {
			bottomLeft.Update(node.val);
		}

		DFS(node.left, bottomLeft, nextLevel + 1);
		DFS(node.right, bottomLeft, nextLevel + 1);
	}

	public int FindBottomLeftValueWithBFS(TreeNode root) {
		var nodesQ = new Queue<LevelTreeNode>();
		nodesQ.Enqueue(new LevelTreeNode(1, root));

		var lev = new LevelLeft(1, root.val);

		while (nodesQ.Count > 0) {
			LevelTreeNode current = nodesQ.Dequeue();
			if (current.Node == null) {
				continue;
			}

			nodesQ.Enqueue(new LevelTreeNode(current.Level + 1, current.Node.left));
			nodesQ.Enqueue(new LevelTreeNode(current.Level + 1, current.Node.right));

			if (current.Level > lev.Level) {
				lev.Update(current.Node.val);
			}
		}

		return lev.Value;
	}

	internal sealed class LevelLeft {
		public LevelLeft(int level, int value) {
			Level = level;
			Value = value;
		}

		public int Level { get; private set; }
		public int Value { get; private set; }

		public void Update(int val) {
			Level += 1;
			Value = val;
		}
	}

	internal sealed class LevelTreeNode {
		public LevelTreeNode(int level, TreeNode? node) {
			Level = level;
			Node = node;
		}

		public int Level { get; }
		public TreeNode? Node { get; }
	}
}