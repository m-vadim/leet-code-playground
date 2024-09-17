using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(BuildGraph([[2,4], [1,3], [2,4], [1,3]]));
	}

	[TestCaseSource(nameof(Cases))]
	public static void ReturnsDeepCopy(Node node) {
		Node deepCopy = new Solution().CloneGraph(node);

		Assert.IsFalse(ReferenceEquals(node, deepCopy));
	}

	[Test]
	public static void ReturnsDeepCopyWhenSourceIsNull() {
		Node deepCopy = new Solution().CloneGraph(null);

		Assert.IsNull(deepCopy);
	}

	private static Node BuildGraph(IList<int[]> values) {
		var nodes = new Node[values.Count];

		for (int i = 0; i < values.Count; i++) {
			nodes[i] = new Node(i + 1, new List<Node>());
		}

		for (int i = 0; i < values.Count; i++) {
			Node node = nodes[i];
			foreach (int nodeVal in values[i]) {
				node.neighbors.Add(nodes[nodeVal - 1]);
			}
		}

		return nodes[0];
	}
}
