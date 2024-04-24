using NUnit.Framework;

namespace LeetCode;

[TestFixture, Parallelizable]
internal class SolutionTests {
    private static IEnumerable<TestCaseData> Cases() {
        yield return new TestCaseData(1).Returns(1);
		yield return new TestCaseData(0).Returns(0);
		yield return new TestCaseData(4).Returns(4);
		yield return new TestCaseData(25).Returns(1389537);
    }

    [TestCaseSource(nameof(Cases))]
    public static int ReturnsTribonacciNumber(int n) {
        return new Solution().Tribonacci(n);
    }
}
