using NUnit.Framework;

namespace LeetCode;

[TestFixture, Parallelizable]
internal class SolutionTests {
    private static IEnumerable<TestCaseData> Cases() {
        yield return new TestCaseData("YYNY").Returns(2);
        yield return new TestCaseData("NNNN").Returns(0);
        yield return new TestCaseData("N").Returns(0);
    }

    [TestCaseSource(nameof(Cases))]
    public static int ReturnsBestClosingTime(string customers) {
        return new Solution().BestClosingTime(customers);
    }
}