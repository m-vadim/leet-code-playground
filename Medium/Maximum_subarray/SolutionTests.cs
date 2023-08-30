using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(new[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 }).Returns(6);
		yield return new TestCaseData(new[] { 1 }).Returns(1);
		yield return new TestCaseData(new[] { 5, 4, -1, 7, 8 }).Returns(23);
		yield return new TestCaseData(new[] { 1, 2, -1, -2, 2, 1, -2, 1, 4, -5, 4 }).Returns(6);
		yield return new TestCaseData(new[] { -2, 1 }).Returns(1);
	}

	[TestCaseSource(nameof(Cases))]
	public static int ReturnsMaxSumSubarray(int[] nums) {
		return new Solution().MaxSubArray(nums);
	}

	[TestCaseSource(nameof(Cases))]
	public static int ReturnsMaxSumSubarrayBrute(int[] nums) {
		return new Solution().MaxSubArrayBrute(nums);
	}
}