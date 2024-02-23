using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(new[] { 3, 2, 1, 5, 6, 4 }, 2).Returns(5);
		yield return new TestCaseData(new[] { 3, 2, 3, 1, 2, 4, 5, 5, 6 }, 4).Returns(4);
	}

	[TestCaseSource(nameof(Cases))]
	public static int ReturnsKthLargestElement(int[] nums, int k) {
		return new Solution().FindKthLargest(nums, k);
	}
}