using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(BinaryTreeSerializer.Serialize(new int?[] { 1, 2, 3, 2, null, 2, 4 }), 2, BinaryTreeSerializer.Serialize(new int?[] { 1, null, 3, null, 4 }));
		yield return new TestCaseData(BinaryTreeSerializer.Serialize(new int?[] { 1, 3, 3, 3, 2 }), 3, BinaryTreeSerializer.Serialize(new int?[] { 1, 3, null, null, 2 }));
	}

	[TestCaseSource(nameof(Cases))]
	public static void ReturnsTree(TreeNode root, int target, TreeNode expected) {
		var resultTree = new Solution().RemoveLeafNodes(root, target);

		Assert.That(CompareTree(resultTree, expected), Is.True);
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
