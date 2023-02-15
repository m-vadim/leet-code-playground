using NUnit.Framework;

namespace LeetCode;

[TestFixture, Parallelizable]
internal class SolutionTests {
    private static IEnumerable<TestCaseData> Cases() {
        yield return new TestCaseData(new[] {1, 2, 0, 0}, 34).Returns(new[] {1, 2, 3, 4});
        yield return new TestCaseData(new[] {1, 3}, 988).Returns(new[] {1, 0, 0, 1});
        yield return new TestCaseData(new[] {9, 9, 9, 9, 9, 9, 9, 9, 9, 9}, 1).Returns(new[]
            {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0});
    }

    [TestCaseSource(nameof(Cases))]
    public static IList<int> AddsToArrayForm(int[] num, int k) {
        return new Solution().AddToArrayForm(num, k);
    }
}