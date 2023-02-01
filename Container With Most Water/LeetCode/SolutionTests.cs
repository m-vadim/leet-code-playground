using NUnit.Framework;

namespace LeetCode;

[TestFixture, Parallelizable]
internal class SolutionTests {
    private static IEnumerable<TestCaseData> Cases() {
        yield return new TestCaseData(new[] {new[] {1, 8, 6, 2, 5, 4, 8, 3, 7}}).Returns(49);
        yield return new TestCaseData(new[] {new[] {1, 1}}).Returns(1);
        yield return new TestCaseData(new[] {new[] {1, 4, 1, 4, 1, 1}}).Returns(8);
    }

    [TestCaseSource(nameof(Cases))]
    public static int ReturnsMaxArea(int[] height) {
        return new Solution().MaxArea(height);
    }
}