namespace LeetCode;

/// <summary>
/// https://leetcode.com/problems/restore-the-array-from-adjacent-pairs
/// </summary>
public class Solution {
	public int[] RestoreArray(int[][] adjacentPairs) {
		var dict = new Dictionary<int, GraphNode>(adjacentPairs.Length + 1);

		foreach (int[] pair in adjacentPairs) {
			if (!dict.TryGetValue(pair[0], out GraphNode one)) {
				one = new GraphNode(pair[0]);
				dict.Add(pair[0], one);
			}

			if (!dict.TryGetValue(pair[1], out GraphNode other)) {
				other = new GraphNode(pair[1]);
				dict.Add(pair[1], other);
			}
			
			one.Nodes.Enqueue(other);
			other.Nodes.Enqueue(one);
		}

		GraphNode start = null;
		foreach (KeyValuePair<int,GraphNode> node in dict) {
			if (node.Value.Nodes.Count == 1) {
				start = node.Value;
				break;
			}
		}

		int[] result = new int[dict.Count];
		result[0] = start.Value;
		start = start.NextFrom(start.Value);
		
		for (int index = 1; index < result.Length - 1; index++) {
			result[index] = start.Value;
			start = start.NextFrom(result[index - 1]);;
		}

		result[^1] = start.Value;
		
		return result;
	}
}

internal class GraphNode {
	public GraphNode(int value) {
		Value = value;
		Nodes = new Queue<GraphNode>(2);
	}

	public int Value { get; }
	public Queue<GraphNode> Nodes { get; }

	public GraphNode NextFrom(int val) {
		GraphNode node = Nodes.Dequeue();
		if (node.Value != val) {
			return node;
		}

		return Nodes.Dequeue();
	}
}