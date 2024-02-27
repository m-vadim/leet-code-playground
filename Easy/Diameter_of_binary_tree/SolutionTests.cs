using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(BinaryTreeBuilder.Build(new int?[] { 1, 2, 3, 4, 5 })).Returns(3)
			.SetName("[1, 2, 3, 4, 5]");
		yield return new TestCaseData(BinaryTreeBuilder.Build(new int?[] { 1, 2 })).Returns(1).SetName("[1, 2]");
		yield return new TestCaseData(BinaryTreeBuilder.Build(new int?[] {
			4, -7, -3, null, null, -9, -3, 9, -7, -4, null, 6, null, -6, -6, null, null, 0, 6, 5, null, 9, null, null,
			-1, -4, null, null, null, -2
		})).Returns(8);
	}

	[TestCaseSource(nameof(Cases))]
	public static int ReturnBinaryTreeLongestPathBetweenNodes(TreeNode root) {
		return new Solution().DiameterOfBinaryTree(root);
	}
}