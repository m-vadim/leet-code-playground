using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(BinaryTreeBuilder.Build(new int?[] { 10, 5, 15, 3, 7, null, 18 }), 7, 15)
			.Returns(32);
		yield return new TestCaseData(BinaryTreeBuilder.Build(new int?[] { 10, 5, 15, 3, 7, 13, 18, 1, null, 6 }), 6,
			10).Returns(23);
	}

	[TestCaseSource(nameof(Cases))]
	public static int ReturnBinarySearchTreeNodesSumInRangeStack(TreeNode root, int low, int high) {
		return new Solution().RangeSumBSTStack(root, low, high);
	}
	
	[TestCaseSource(nameof(Cases))]
	public static int ReturnBinarySearchTreeNodesSumInRangeUsingRecursion(TreeNode root, int low, int high) {
		return new Solution().RangeSumBST(root, low, high);
	}
}