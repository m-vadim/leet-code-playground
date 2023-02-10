using NUnit.Framework;

namespace LeetCode;

[TestFixture, Parallelizable]
internal class SolutionTests {
    private static IEnumerable<TestCaseData> Cases() {
        yield return new TestCaseData(new[] {7, 1, 5, 3, 6, 4}).Returns(5);
        yield return new TestCaseData(new[] {7, 6, 4, 3, 1}).Returns(0);
        yield return new TestCaseData(new[] {3, 1, 5, 6, 7}).Returns(6);
    }

    [TestCaseSource(nameof(Cases))]
    public static int ReturnsMaxProfit(int[] prices) {
        return new Solution().MaxProfit(prices);
    }
}