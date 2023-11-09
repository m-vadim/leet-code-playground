using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(BinaryTreeBuilder.Build(new int?[] { 3, 9, 20, null, null, 15, 7 })).Returns(3);
		yield return new TestCaseData(BinaryTreeBuilder.Build(new int?[] { 1, null, 2 })).Returns(2);
	}

	[TestCaseSource(nameof(Cases))]
	public static int ReturnBinaryTreeMaxDepth(TreeNode root) {
		return new Solution().MaxDepth(root);
	}
}