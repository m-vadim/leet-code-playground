using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(BinaryTreeBuilder.Build(new int?[]
				{ 1, 10, 4, 3, null, 7, 9, 12, 8, 6, null, null, 2 })).Returns(true)
			.SetName("[1, 10, 4, 3, null, 7, 9, 12, 8, 6, null, null, 2]");
		yield return new TestCaseData(BinaryTreeBuilder.Build(new int?[] { 5, 4, 2, 3, 3, 7 }))
			.Returns(false).SetName("[5, 4, 2, 3, 3, 7]");
	}

	[TestCaseSource(nameof(Cases))]
	public static bool ReturnTrueWhenTreeIsEvenOdd(TreeNode root) {
		return new Solution().IsEvenOddTree(root);
	}
}