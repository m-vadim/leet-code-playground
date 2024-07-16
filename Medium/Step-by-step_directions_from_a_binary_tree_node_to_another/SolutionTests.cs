using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(
			BinaryTreeSerializer.Serialize(new int?[] { 5, 1, 2, 3, null, 6, 4 }), 3, 6).Returns("UURL");
		yield return new TestCaseData(
			BinaryTreeSerializer.Serialize(new int?[] { 2, 1 }), 2, 1).Returns("L");
		yield return new TestCaseData(
			BinaryTreeSerializer.Serialize(new int?[] { 12, 13, 5, 1, 2, 3, null, 6, 4 }), 1, 2).Returns("UR");
	}

	[TestCaseSource(nameof(Cases))]
	public static string ReturnsDirections(TreeNode root, int startValue, int destValue) {
		return new Solution().GetDirections(root, startValue, destValue);
	}
}
