using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(BinaryTreeBuilder.Build(new int?[]
				{ 2,3,1,3,1,null,1 }))
			.Returns(2);
		yield return new TestCaseData(BinaryTreeBuilder.Build(new int?[] { 2,1,1,1,3,null,null,null,null,null,1 })).Returns(1);
	}

	[TestCaseSource(nameof(Cases))]
	public static int ReturnsCountOfPaths(TreeNode root) {
		return new Solution().PseudoPalindromicPaths(root);
	}
}