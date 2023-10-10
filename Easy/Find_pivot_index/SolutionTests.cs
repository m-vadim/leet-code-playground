using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(new[] { 1, 7, 3, 6, 5, 6 }).Returns(3);
		yield return new TestCaseData(new[] { 1, 2, 3 }).Returns(-1);
		yield return new TestCaseData(new[] { 2, 1, -1 }).Returns(0);
		yield return new TestCaseData(new[] { -1, -1, 0, 0, -1, -1 }).Returns(2);
		yield return new TestCaseData(new[] { -1, -1, 0, 1, 1, 0 }).Returns(5);
	}

	[TestCaseSource(nameof(Cases))]
	public static int ReturnsLeftMostPivotIndex(int[] nums) {
		return new Solution().PivotIndex(nums);
	}
}