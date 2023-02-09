using NUnit.Framework;

namespace LeetCode;

[TestFixture, Parallelizable]
internal class SolutionTests {
    private static IEnumerable<TestCaseData> Cases() {
        yield return new TestCaseData(1).Returns(1);
        yield return new TestCaseData(2).Returns(2);
        yield return new TestCaseData(3).Returns(3);
        yield return new TestCaseData(4).Returns(5);
        yield return new TestCaseData(5).Returns(8);
        yield return new TestCaseData(6).Returns(13);
        yield return new TestCaseData(45).Returns(1836311903);
    }

    [TestCaseSource(nameof(Cases))]
    public static int ReturnsClimbStairsCached(int num) {
        return new Solution().ClimbStairsCached(num);
    }

    [TestCaseSource(nameof(Cases))]
    public static int ReturnsClimbStairsNaive(int num) {
        return new Solution().ClimbStairsNaive(num);
    }

    [TestCaseSource(nameof(Cases))]
    public static int ReturnsClimbStairsTable(int num) {
        return new Solution().ClimbStairsTable(num);
    }
}