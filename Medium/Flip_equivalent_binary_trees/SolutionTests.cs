using System.Globalization;
using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(
			BinaryTreeSerializer.Serialize([1, 2, 3, 4, 5, 6, null, null, null, 7, 8]), BinaryTreeSerializer.Serialize([1, 3, 2, null, 6, 4, 5, null, null, null, null, 8, 7]))
			.SetName("[1, 2, 3, 4, 5, 6, null, null, null, 7, 8] vs [1, 3, 2, null, 6, 4, 5, null, null, null, null, 8, 7]")
			.Returns(true);
		yield return new TestCaseData(
			(TreeNode)null, (TreeNode)null)
			.SetName("[] vs []")
			.Returns(true);
		yield return new TestCaseData(
			(TreeNode)null, BinaryTreeSerializer.Serialize([1]))
			.SetName("[] vs [1]")
			.Returns(false);
		yield return new TestCaseData(
			BinaryTreeSerializer.Serialize([1, 2, 3]), BinaryTreeSerializer.Serialize([1, 2, null, 3]))
			.SetName("[1, 2, 3] vs [1, 2, null, 3]")
			.Returns(false);
		yield return new TestCaseData(
				BinaryTreeSerializer.Serialize([6, 1, 0]), BinaryTreeSerializer.Serialize([6, null, 1]))
			.SetName("[6, 1, 0] vs [6, null, 1]")
			.Returns(false);
	}

	[TestCaseSource(nameof(Cases))]
	public static bool ReturnsTrueWhenTreesAreFlipEquivalent(TreeNode? node1, TreeNode? node2) {
		return new Solution().FlipEquiv(node1, node2);
	}
}
