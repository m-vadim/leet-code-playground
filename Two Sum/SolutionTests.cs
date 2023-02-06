using NUnit.Framework;

namespace LeetCode;

[TestFixture, Parallelizable]
internal class SolutionTests {
    private static IEnumerable<TestCaseData> Cases() {
        yield return new TestCaseData(new[] {2, 7, 11, 15}, 9).Returns(new[] {0, 1});
        yield return new TestCaseData(new[] {3, 2, 4}, 6).Returns(new[] {1, 2});
        yield return new TestCaseData(new[] {3, 3}, 6).Returns(new[] {0, 1});
    }

    [TestCaseSource(nameof(Cases))]
    public static int[] ReturnsTwoSum(int[] nums, int target) {
        return new Solution().TwoSum(nums, target);
    }
}