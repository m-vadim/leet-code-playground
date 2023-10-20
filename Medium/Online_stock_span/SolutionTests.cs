using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(new[] { 100, 80, 60, 70, 60, 75, 85 }).Returns(
			new[] { 1, 1, 1, 2, 1, 4, 6 });
		yield return new TestCaseData(new[] { 31, 41, 48, 59, 79 }).Returns(
			new[] { 1, 2, 3, 4, 5 });
	}

	[TestCaseSource(nameof(Cases))]
	public static int[] ReturnsDailyStockSpan(int[] prices) {
		var stockSpanner = new StockSpanner();

		return prices.Select(price => stockSpanner.Next(price)).ToArray();
	}
}