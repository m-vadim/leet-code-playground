using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(BinaryTreeSerializer.Serialize([5, 4, 9, 1, 10, null, 7]), BinaryTreeSerializer.Serialize([0, 0, 0, 7, 7, null, 11]));
	}

	[TestCaseSource(nameof(Cases))]
	public static void ReturnsUpdatedTree(TreeNode root, TreeNode expected) {
		var result = new Solution().ReplaceValueInTree(root);

		Assert.That(new TreeNodeEqualityComparer().Equals(result, expected), Is.EqualTo(true));
	}
}
