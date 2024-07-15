using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(
			new int[][] { [1, 2, 1], [2, 3, 0], [3, 4, 1] },
			BinaryTreeSerializer.Serialize(new int?[] { 1, 2, null, null, 3, 4 })).SetName("[1, 2, 1], [2, 3, 0], [3, 4, 1]");
		yield return new TestCaseData(
			new int[][] { [20, 15, 1], [20, 17, 0], [50, 20, 1], [50, 80, 0], [80, 19, 1] },
			BinaryTreeSerializer.Serialize(new int?[] { 50, 20, 80, 15, 17, 19 })).SetName("[20, 15, 1], [20, 17, 0], [50, 20, 1], [50, 80, 0], [80, 19, 1]");
	}

	[TestCaseSource(nameof(Cases))]
	public static void ReturnsTree(int[][] descriptions, TreeNode expected) {
		var resultTree = new Solution().CreateBinaryTree(descriptions);

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
