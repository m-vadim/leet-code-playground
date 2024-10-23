using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(new int[] { 1, 3, -1, -3, 5, 3, 6, 7 }, 3).Returns(new double[] { 1.00000, -1.00000, -1.00000, 3.00000, 5.00000, 6.00000 });
		yield return new TestCaseData(new int[] { 2147483647, 2147483647 }, 2).Returns(new double[] { 2147483647 });
		yield return new TestCaseData(new int[] { 1, 2, 3, 4, 2, 3, 1, 4, 2 }, 3).Returns(new double[] { 2.00000, 3.00000, 3.00000, 3.00000, 2.00000, 3.00000, 2.00000 });
		yield return new TestCaseData(new int[] { 7, 0, 3, 9, 9, 9, 1, 7, 2, 3 }, 6).Returns(new double[] { 8.00000, 6.00000, 8.00000, 8.00000, 5.00000 });
	}

	[TestCaseSource(nameof(Cases))]
	public static double[] ReturnsMedianArray(int[] nums, int k) {
		return new Solution().MedianSlidingWindow(nums, k);
	}
}
