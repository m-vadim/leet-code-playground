using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(new[] { 1, 2, 3, 4 }).Returns(new[] { 24, 12, 8, 6 });
		yield return new TestCaseData(new[] { -1, 1, 0, -3, 3 }).Returns(new[] { 0, 0, 9, 0, 0 });
		yield return new TestCaseData(new[] { 1, 2, 3, 4, 5 }).Returns(new[] { 120, 60, 40, 30, 24 });
		yield return new TestCaseData(new[] { 1, 2, 3, 4, 5, 6 }).Returns(new[] { 720, 360, 240, 180, 144, 120 });
	}

	[TestCaseSource(nameof(Cases))]
	public static int[] ReturnsProductOfArrayExceptSelf(int[] nums) {
		return new Solution().ProductExceptSelf(nums);
	}
}