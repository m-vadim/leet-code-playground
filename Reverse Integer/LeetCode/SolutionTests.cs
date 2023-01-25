using NUnit.Framework;

namespace LeetCode;

[TestFixture, Parallelizable]
internal class SolutionTests {
    private static IEnumerable<TestCaseData> Cases() {
        yield return new TestCaseData(123).Returns(321);
        yield return new TestCaseData(5005).Returns(5005);;
        yield return new TestCaseData(7).Returns(7);
        yield return new TestCaseData(0).Returns(0);
        yield return new TestCaseData(-123).Returns(-321);
        yield return new TestCaseData(120).Returns(21);
        yield return new TestCaseData(10000).Returns(1);
        yield return new TestCaseData(2147483647).Returns(0);
        yield return new TestCaseData(-2147483648).Returns(0);
        yield return new TestCaseData(1463847412).Returns(2147483641);
    }
    
    [TestCaseSource(nameof(Cases))]
    public static int ReturnsInvertedInt(int number) {
        return new Solution().Reverse(number);
    }
}