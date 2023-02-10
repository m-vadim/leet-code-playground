using NUnit.Framework;

namespace LeetCode;

[TestFixture, Parallelizable]
internal class SolutionTests {
    private static IEnumerable<TestCaseData> Cases() {
        yield return new TestCaseData(new[] {-1, 0, 1, 2, -1, -4}).Returns(new[] {new[] {-1, -1, 2}, new[] {-1, 0, 1}});
        yield return new TestCaseData(new[] {0, 1, 1}).Returns(new List<List<int>>());
        yield return new TestCaseData(new[] {-1, 0, 1}).Returns(new[] {new[] {-1, 0, 1}});
        yield return new TestCaseData(new[] {0, 0, 0}).Returns(new[] {new[] {0, 0, 0}});
        yield return new TestCaseData(new[] {0, 0, 0, 0}).Returns(new[] {new[] {0, 0, 0}});
        yield return new TestCaseData(new[] {-1, 0, 1, 2, -1, -4, -2, -3, 3, 0, 4}).Returns(new[] {
            new[] {-4, 0, 4}, new[] {-4, 1, 3}, new[] {-3, -1, 4}, new[] {-3, 0, 3}, new[] {-3, 1, 2},
            new[] {-2, -1, 3}, new[] {-2, 0, 2}, new[] {-1, -1, 2}, new[] {-1, 0, 1}
        });
    }

    [TestCaseSource(nameof(Cases))]
    public static IList<IList<int>> ReturnsThreeSum(int[] nums) {
        return new Solution().ThreeSum(nums);
    }
}