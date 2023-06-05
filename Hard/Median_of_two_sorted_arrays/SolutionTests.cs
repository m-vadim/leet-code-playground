using NUnit.Framework;

namespace LeetCode;

[TestFixture, Parallelizable]
internal class SolutionTests {
    private static IEnumerable<TestCaseData> EvenCases() {
        yield return new TestCaseData(new[] {1, 3}, new[] {2}).Returns(2d);
        yield return new TestCaseData(new[] {3}, new[] {-2, -1}).Returns(-1d);
        yield return new TestCaseData(new[] {1}, new[] {2, 3}).Returns(2d);
        yield return new TestCaseData(Array.Empty<int>(), new[] {1, 2, 3, 4, 5}).Returns(3d);
        yield return new TestCaseData(new[] {1, 2, 3, 4, 5}, Array.Empty<int>()).Returns(3d);
    }

    private static IEnumerable<TestCaseData> OddCases() {
        yield return new TestCaseData(new[] {1, 2}, new[] {3, 4}).Returns(2.5d);
        yield return new TestCaseData(new[] {1, 1}, new[] {1, 2}).Returns(1d);
        yield return new TestCaseData(new[] {1, 2, 3, 5, 6, 7}, Array.Empty<int>()).Returns(4d);
        yield return new TestCaseData(new[] {-6, 2}, new[] {-5, 8}).Returns(-1.5d);
        yield return new TestCaseData(new[] {1, 2}, new[] {3, 4, 5, 6, 8, 10}).Returns(4.5d);
    }

    [TestCaseSource(nameof(EvenCases))]
    [TestCaseSource(nameof(OddCases))]
    public static double FindsMedianInSortedArray(int[] nums1, int[] nums2) {
        return new Solution().FindMedianSortedArrays(nums1, nums2);
    }
}