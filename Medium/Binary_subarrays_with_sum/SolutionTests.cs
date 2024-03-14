using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(2, new[] { 1, 0, 1, 0, 1 }).Returns(4);
		yield return new TestCaseData(0, new[] { 0, 0, 0, 0, 0 }).Returns(15);
		yield return new TestCaseData(2, new[] { 0, 0, 0, 0, 1 }).Returns(0);
		yield return new TestCaseData(0, new[] { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 }).Returns(27);
	}

	[TestCaseSource(nameof(Cases))]
	public static int ReturnsNumSubarraysWithSum(int goal, int[] nums) {
		return new Solution().NumSubarraysWithSum(nums, goal);
	}
}