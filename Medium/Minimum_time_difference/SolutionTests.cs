using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(new[] { new[] { "23:59", "00:00" } }).Returns(1);
		yield return new TestCaseData(new[] { new[] { "00:00", "23:59", "00:00" } }).Returns(0);
	}

	[TestCaseSource(nameof(Cases))]
	public static int ReturnsMinDiff(string[] timePoints) {
		return new Solution().FindMinDifference(timePoints);
	}
}
