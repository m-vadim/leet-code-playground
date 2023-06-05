using NUnit.Framework;

namespace LeetCode;

[TestFixture, Parallelizable]
internal class SolutionTests {
    private static IEnumerable<TestCaseData> Cases() {
        yield return new TestCaseData(38).Returns(2);
        yield return new TestCaseData(0).Returns(0);
        yield return new TestCaseData(7).Returns(7);
        yield return new TestCaseData(505).Returns(1);
        yield return new TestCaseData(1352).Returns(2);
    }

    [TestCaseSource(nameof(Cases))]
    public static int ReturnsDigitsSum(int number) {
        return new Solution().AddDigits(number);
    }
}