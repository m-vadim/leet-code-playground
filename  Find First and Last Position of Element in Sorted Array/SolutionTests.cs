using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(new[] { 5, 7, 7, 8, 8, 10 }, 8).Returns(new[] { 3, 4 });
		yield return new TestCaseData(new[] { 5, 7, 7, 8, 8, 10 }, 6).Returns(new[] { -1, -1 });
		yield return new TestCaseData(new[] { 5, 5, 7, 8, 8, 10 }, 5).Returns(new[] { 0, 1 });
		yield return new TestCaseData(Array.Empty<int>(), 6).Returns(new[] { -1, -1 });
	}

	[TestCaseSource(nameof(Cases))]
	public static int[] ReturnsFirstLastPositions(int[] nums, int target) {
		return new Solution().SearchRange(nums, target);
	}
}