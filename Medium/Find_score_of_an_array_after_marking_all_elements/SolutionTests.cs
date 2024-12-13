using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(new int[] { 2, 1, 3, 4, 5, 2 }).Returns(7);
		yield return new TestCaseData(new int[] { 2, 3, 5, 1, 3, 2 }).Returns(5);
	}

	[TestCaseSource(nameof(Cases))]
	public static long ReturnsScoreAfterMark(int[] nums) {
		return new Solution().FindScore(nums);
	}
}
