using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(new[] { 1, 5, 4, 2, 9, 9, 9 }, 3).Returns(15);
		yield return new TestCaseData(new[] { 9, 9, 9 }, 3).Returns(0);
	}

	[TestCaseSource(nameof(Cases))]
	public static long ReturnsMinMaxProducts(int[] nums, int k) {
		return new Solution().MaximumSubarraySum(nums, k);
	}
}
