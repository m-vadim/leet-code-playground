using LeetCode;

/// <summary>
///     https://leetcode.com/problems/create-binary-tree-from-descriptions/
/// </summary>
public class Solution {
	public TreeNode CreateBinaryTree(int[][] descriptions) {
		var map = new Dictionary<int, MarkedTreeNode>();

		foreach (int[] description in descriptions) {
			MarkedTreeNode node = GetNode(map, description[0]);
			MarkedTreeNode childNode = GetNode(map, description[1]);
			childNode.IsChild = true;

			if (description[2] == 1) {
				node.left = childNode;
			} else {
				node.right = childNode;
			}
		}

		foreach (MarkedTreeNode node in map.Values) {
			if (!node.IsChild) {
				return node;
			}
		}

		throw new InvalidOperationException("Tree root not found");
	}

	private static MarkedTreeNode GetNode(Dictionary<int, MarkedTreeNode> map, int key) {
		if (map.TryGetValue(key, out MarkedTreeNode node)) {
			return node;
		}

		node = new MarkedTreeNode(key);
		map.Add(key, node);
		return node;
	}
}

public sealed class MarkedTreeNode : TreeNode {
	public MarkedTreeNode(int val) : base(val) { }

	public bool IsChild { get; set; }
}
