using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(BinaryTreeBuilder.Build(new int?[] { 1, 2, 3 })).Returns(25)
			.SetName("[1,2,3]");
		yield return new TestCaseData(BinaryTreeBuilder.Build(new int?[] { 4, 9, 0, 5, 1 }))
			.Returns(1026).SetName("[4,9,0,5,1]");
		yield return new TestCaseData(BinaryTreeBuilder.Build(new int?[] { 4, 9, 0, 5, 1, null, null, null, null, 7 }))
			.Returns(5452).SetName("[4,9,0,5,1,null, null, null, null, 7]");
	}

	[TestCaseSource(nameof(Cases))]
	public static int ReturnSumOfRootToLeafNumbers(TreeNode root) {
		return new Solution().SumNumbers(root);
	}
}
