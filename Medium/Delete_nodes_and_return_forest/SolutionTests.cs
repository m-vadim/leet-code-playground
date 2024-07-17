using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(
			BinaryTreeSerializer.Serialize([1, 2, 3, 4, 5, 6, 7]),
			new[] { 3, 5 },
			new Dictionary<int, TreeNode> {
				{ 1, BinaryTreeSerializer.Serialize([1, 2, null, 4]) },
				{ 6, BinaryTreeSerializer.Serialize([6]) },
				{ 7, BinaryTreeSerializer.Serialize([7]) }
			});
	}

	[TestCaseSource(nameof(Cases))]
	public static void ReturnsForest(TreeNode root, int[] toDelete, IDictionary<int, TreeNode> expected) {
		var actual = new Solution().DelNodes(root, toDelete);

		Assert.That(actual.Count, Is.EqualTo(expected.Count), message: "Expected nodes count does not match actual nodes collection length");
		foreach (var node in actual) {
			Assert.That(expected.ContainsKey(node.val), Is.True);
			Assert.That(CompareTree(root, expected[root.val]), Is.True);
		}
	}

	private static bool CompareTree(TreeNode left, TreeNode right) {
		var q1 = new Queue<TreeNode?>();
		q1.Enqueue(left);

		var q2 = new Queue<TreeNode?>();
		q2.Enqueue(right);

		while (q1.Count > 0 && q2.Count > 0) {
			var node1 = q1.Dequeue();
			var node2 = q2.Dequeue();

			if (node1.val != node2?.val) {
				return false;
			}

			if (node1.left != null) {
				q1.Enqueue(node1.left);
			}

			if (node1.right != null) {
				q1.Enqueue(node1.right);
			}

			if (node2.left != null) {
				q2.Enqueue(node1.left);
			}

			if (node2.right != null) {
				q2.Enqueue(node2.right);
			}
		}

		return q1.Count == q2.Count && q1.Count == 0;
	}
}
