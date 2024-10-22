using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(BinaryTreeSerializer.Serialize([1, 2, null, 3]), 1).Returns(3);
		yield return new TestCaseData(BinaryTreeSerializer.Serialize([1, 2, null, 3]), 5).Returns(-1);
		yield return new TestCaseData(BinaryTreeSerializer.Serialize([5, 8, 9, 2, 1, 3, 7, 4, 6]), 2).Returns(13);
		yield return new TestCaseData(BinaryTreeSerializer.Serialize([897935, 796748, 528909, null, null, null, 905326, 706311, null, null, 282251, null, 139169]), 4)
			.Returns(706311);
	}

	[TestCaseSource(nameof(Cases))]
	public static long ReturnsKLargestSum(TreeNode root, int k) {
		return new Solution().KthLargestLevelSum(root, k);
	}
}
