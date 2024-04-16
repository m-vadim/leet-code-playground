using LeetCode;

/// <summary>
/// https://leetcode.com/problems/add-one-row-to-tree
/// </summary>
public class Solution {
	private int _depth;
	private int _val;

	public TreeNode AddOneRow(TreeNode root, int val, int depth) {
		if (depth == 1) {
			return new TreeNode(val, root);
		}

		_depth = depth - 1;
		_val = val;

		Dfs(root, 1);

		return root;
	}

	private void Dfs(TreeNode node, int currentDepth) {
		if (node == null) {
			return;
		}

		if (currentDepth < _depth) {
			Dfs(node.left, currentDepth + 1);
			Dfs(node.right, currentDepth + 1);
		} else {
			node.left = new TreeNode(_val, node.left);
			node.right = new TreeNode(_val, null, node.right);
		}
	}

	public TreeNode AddOneRowBFS(TreeNode root, int val, int depth) {
		if (depth == 1) {
			return new TreeNode(val, root);
		}

		var st = new Queue<DepthTreeNode>();
		st.Enqueue(new DepthTreeNode(root, 1));
		while (st.Count > 0) {
			var depthNode = st.Dequeue();
			if (depthNode.Depth < depth - 1) {
				if (depthNode.OriginNode.left != null) {
					st.Enqueue(new DepthTreeNode(depthNode.OriginNode.left, depthNode.Depth + 1));
				}

				if (depthNode.OriginNode.right != null) {
					st.Enqueue(new DepthTreeNode(depthNode.OriginNode.right, depthNode.Depth + 1));
				}
			} else {
				var node = depthNode.OriginNode;
				node.left = new TreeNode(val, node.left);
				node.right = new TreeNode(val, null, node.right);
			}
		}

		return root;
	}
}

internal sealed class DepthTreeNode {
	public DepthTreeNode(TreeNode originNode, int depth) {
		OriginNode = originNode;
		Depth = depth;
	}

	public TreeNode OriginNode { get; }
	public int Depth { get; }
}
