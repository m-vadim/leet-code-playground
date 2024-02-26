using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(BinaryTreeBuilder.Build(new int?[] { 1, 2, 3 }),
			BinaryTreeBuilder.Build(new int?[] { 1, 2, 3 })).Returns(true);
		yield return new TestCaseData(BinaryTreeBuilder.Build(new int?[] { 1, 2 }),
			BinaryTreeBuilder.Build(new int?[] { 1, null, 2 })).Returns(false);
		yield return new TestCaseData(BinaryTreeBuilder.Build(new int?[] { 1, 2, 1 }),
			BinaryTreeBuilder.Build(new int?[] { 1, 1, 2 })).Returns(false);
		yield return new TestCaseData(BinaryTreeBuilder.Build(new int?[] { 1 }),
			BinaryTreeBuilder.Build(new int?[] { 1, null, 2 })).Returns(false);
	}

	[TestCaseSource(nameof(Cases))]
	public static bool ReturnTrueWhenTreesAreSame(TreeNode left, TreeNode right) {
		return new Solution().IsSameTree(left, right);
	}

	[TestCaseSource(nameof(Cases))]
	public static bool ReturnTrueWhenTreesAreSameUsingRecursion(TreeNode left, TreeNode right) {
		return new Solution().IsSameTreeRecursion(left, right);
	}
}