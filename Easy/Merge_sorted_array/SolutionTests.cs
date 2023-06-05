using NUnit.Framework;

namespace LeetCode;

[TestFixture, Parallelizable]
internal class SolutionTests {
    private static IEnumerable<TestCaseData> Cases() {
        yield return
            new TestCaseData(new[] {1, 2, 3, 0, 0, 0}, new[] {2, 5, 6}, 3, 3).Returns(new[] {1, 2, 2, 3, 5, 6});
        yield return
            new TestCaseData(new[] {1}, Array.Empty<int>(), 1, 0).Returns(new[] {1});
    }

    [TestCaseSource(nameof(Cases))]
    public static int[] MergesArray(int[] nums1, int[] nums2, int nums1Len, int nums2Len) {
        new Solution().Merge(nums1, nums1Len, nums2, nums2Len);

        return nums1;
    }

    [TestCaseSource(nameof(Cases))]
    public static int[] MergesArrayNaiveWay(int[] nums1, int[] nums2, int nums1Len, int nums2Len) {
        new Solution().MergeNaive(nums1, nums1Len, nums2, nums2Len);

        return nums1;
    }
}