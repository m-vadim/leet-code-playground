using NUnit.Framework;

namespace LeetCode;

[TestFixture, Parallelizable]
internal class SolutionTests {
    private static IEnumerable<TestCaseData> Cases() {
        yield return new TestCaseData(25).Returns(5);
        yield return new TestCaseData(8).Returns(2);
        yield return new TestCaseData(24).Returns(4);
        yield return new TestCaseData(0).Returns(0);
        yield return new TestCaseData(1).Returns(1);
        yield return new TestCaseData(2).Returns(1);
        yield return new TestCaseData(3).Returns(1);
        yield return new TestCaseData(int.MaxValue).Returns(46340);
    }

    [TestCaseSource(nameof(Cases))]
    public static int ReturnsSqrtOfX(int num) {
        return new Solution().MySqrt(num);
    }
}