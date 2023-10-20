using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(new[] { 73, 74, 75, 71, 69, 72, 76, 73 }).Returns(
			new[] { 1, 1, 4, 2, 1, 1, 0, 0 });
		yield return new TestCaseData(new[] { 30, 40, 50, 60 }).Returns(new[] { 1, 1, 1, 0 });
	}

	[TestCaseSource(nameof(Cases))]
	public static int[] ReturnsDailyTemperatures(int[] temperatures) {
		return new Solution().DailyTemperatures(temperatures);
	}
}