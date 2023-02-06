using NUnit.Framework;

namespace LeetCode;

[TestFixture, Parallelizable]
internal class SolutionTests {
    private static IEnumerable<TestCaseData> Cases() {
        yield return new TestCaseData(new[] {2, 5, 1, 3, 4, 7}, 3).Returns(new[] {2, 3, 5, 4, 1, 7});
        yield return new TestCaseData(new[] {1, 2, 3, 4, 4, 3, 2, 1}, 4).Returns(new[] {1, 4, 2, 3, 3, 2, 4, 1});
    }

    [TestCaseSource(nameof(Cases))]
    public static int[] ShufflesArray(int[] nums, int n) {
        return new Solution().Shuffle(nums, n);
    }

    [TestCaseSource(nameof(Cases))]
    public static int[] ShufflesArrayNaive(int[] nums, int n) {
        return new Solution().ShuffleNaive(nums, n);
    }
}