using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(new[] { 10, 9, 2, 5, 3, 7, 101, 18 }).Returns(4);
		yield return new TestCaseData(new[] { 7, 7, 7, 7 }).Returns(1);
		yield return new TestCaseData(new[] { 0, 1, 0, 3, 2, 3 }).Returns(4);
		yield return new TestCaseData(new[] { 3, 2, 1 }).Returns(1);
		yield return new TestCaseData(new[] { 1, 3, 6, 7, 9, 4, 10, 5, 6 }).Returns(6);
	}

	[TestCaseSource(nameof(Cases))]
	public static int ReturnsLongestIncreasingSubsequence(int[] nums) {
		return new Solution().LengthOfLIS(nums);
	}
}