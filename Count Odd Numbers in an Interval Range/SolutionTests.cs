using NUnit.Framework;

namespace LeetCode;

[TestFixture, Parallelizable]
internal class SolutionTests {
    private static IEnumerable<TestCaseData> Cases() {
        yield return new TestCaseData(3, 7).Returns(3);
        yield return new TestCaseData(8, 10).Returns(1);
        yield return new TestCaseData(2,9).Returns(4);
        yield return new TestCaseData(4, 11).Returns(4);
    }

    [TestCaseSource(nameof(Cases))]
    public static int ReturnsOddsCount(int low, int high) {
        return new Solution().CountOdds(low, high);
    }
}