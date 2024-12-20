using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(BinaryTreeConverter.ToTree([2, 3, 5, 8, 13, 21, 34]), new int?[] { 2, 5, 3, 8, 13, 21, 34 });
		yield return new TestCaseData(BinaryTreeConverter.ToTree([0, 1, 2, 0, 0, 0, 0, 1, 1, 1, 1, 2, 2, 2, 2]), new int?[] { 0, 2, 1, 0, 0, 0, 0, 2, 2, 2, 2, 1, 1, 1, 1 });
	}

	[TestCaseSource(nameof(Cases))]
	public static void ReturnsReversedOddLevelsTree(TreeNode root, int?[] expected) {
		TreeNode reverseOddLevels = new Solution().ReverseOddLevels(root);

		Assert.That(BinaryTreeConverter.ToArray(reverseOddLevels), Is.EqualTo(expected));
	}
}
