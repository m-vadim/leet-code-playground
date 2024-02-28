using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(BinaryTreeBuilder.Build(new int?[] { 2, 1, 3 })).Returns(1)
			.SetName("[2,1,3]");
		yield return new TestCaseData(BinaryTreeBuilder.Build(new int?[] { 1, 2, 3, 4, null, 5, 6, null, null, 7 }))
			.Returns(7).SetName("[1,2,3,4,null,5,6,null,null,7]");
	}

	[TestCaseSource(nameof(Cases))]
	public static int ReturnBottomLeftLeafValue(TreeNode root) {
		return new Solution().FindBottomLeftValue(root);
	}
	
	[TestCaseSource(nameof(Cases))]
	public static int ReturnBottomLeftLeafValueWithBFS(TreeNode root) {
		return new Solution().FindBottomLeftValueWithBFS(root);
	}
}