using LeetCode;

/// <summary>
/// https://leetcode.com/problems/even-odd-tree
/// </summary>
public class Solution {
	public bool IsEvenOddTree(TreeNode root) {
		if (IsEven(root.val)) {
			return false;
		}
		
		var prev = new NodeLevel(root, 0);
		
		var q = new Queue<NodeLevel>();
		q.Enqueue(new NodeLevel(root.left, 1));
		q.Enqueue(new NodeLevel(root.right, 1));
		
		while (q.Count > 0) {
			NodeLevel currentLevelNode = q.Dequeue();
			if (currentLevelNode.Node == null) {
				continue;
			}

			if (currentLevelNode.IsLevelEven) {
				if (IsEven(currentLevelNode.Node.val)) {
					return false;
				}
			} else if (!IsEven(currentLevelNode.Node.val)) {
				return false;
			}
			
			if (currentLevelNode.Level == prev.Level) {
				if (currentLevelNode.IsLevelEven) {
					if (currentLevelNode.Node.val <= prev.Node.val) {
						return false;
					}
				} else if (currentLevelNode.Node.val >= prev.Node.val) {
					return false;
				}
			}

			prev = currentLevelNode;

			q.Enqueue(new NodeLevel(currentLevelNode.Node.left, currentLevelNode.Level + 1));
			q.Enqueue(new NodeLevel(currentLevelNode.Node.right, currentLevelNode.Level + 1));
		}

		return true;
	}
	
	private static bool IsEven(int val) {
		return val % 2 == 0;
	}

	internal struct NodeLevel {
		public NodeLevel(TreeNode? node, int level) {
			Node = node;
			Level = level;
			IsLevelEven = Level % 2 == 0;
		}

		public TreeNode? Node { get; }
		public int Level { get; }
		public bool IsLevelEven { get; }
	}
}