/// <summary>
/// https://leetcode.com/problems/clone-graph
/// </summary>
public class Solution {
	public Node CloneGraph(Node node) {
		if (node == null) {
			return null;
		}

		var copyMap = new Dictionary<int, Node>();
		Traverse(node, copyMap);

		return copyMap[1];
	}

	private static void Traverse(Node node, Dictionary<int, Node> marked) {
		if (marked.ContainsKey(node.val)) {
			return;
		}

		var copy = new Node(node.val, []);
		marked.Add(node.val, copy);

		foreach (Node n in node.neighbors) {
			Traverse(n, marked);
			copy.neighbors.Add(marked[n.val]);
		}
	}
}
