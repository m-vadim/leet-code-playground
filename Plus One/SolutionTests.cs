using NUnit.Framework;

namespace LeetCode;

[TestFixture, Parallelizable]
internal class SolutionTests {
    private static IEnumerable<TestCaseData> Cases() {
        yield return new TestCaseData(new[] {1, 2, 3}).Returns(new[] {1, 2, 4});
        yield return new TestCaseData(new[] {9, 9, 9}).Returns(new[] {1, 0, 0, 0});
    }

    [TestCaseSource(nameof(Cases))]
    public static int[] ReturnsArrayPlusOne(int[] digits) {
        return new Solution().PlusOne(digits);
    }
}