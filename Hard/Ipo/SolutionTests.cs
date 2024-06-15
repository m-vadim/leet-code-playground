using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(2, 0, new[] { 1, 2, 3 }, new[] { 0, 1, 1 })
			.Returns(4);
		yield return new TestCaseData(3, 0, new[] { 1, 2, 3 }, new[] { 0, 1, 2 })
			.Returns(6);
	}

	[TestCaseSource(nameof(Cases))]
	public static int ReturnsMaxProfit(int k, int w, int[] profits, int[] capital) {
		return new Solution().FindMaximizedCapital(k, w, profits, capital);
	}
}
