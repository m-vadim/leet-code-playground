using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(BinaryTreeBuilder.Build(new int?[]
				{ 8, 3, 10, 1, 6, null, 14, null, null, 4, 7, 13 }))
			.Returns(7);
		yield return new TestCaseData(BinaryTreeBuilder.Build(new int?[] { 1, null, 2, null, 0, 3 })).Returns(3);
		yield return new TestCaseData(BinaryTreeBuilder.Build(new int?[]
				{ 2,4,3,1,null,0,5,null,6,null,null,null,7 }))
			.Returns(5);
	}

	[TestCaseSource(nameof(Cases))]
	public static int ReturnsMaxDiff(TreeNode root) {
		return new Solution().MaxAncestorDiff(root);
	}
}