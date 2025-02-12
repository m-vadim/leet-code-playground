using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(new[] { 18, 43, 36, 13, 7 }).Returns(54);
	}

	[TestCaseSource(nameof(Cases))]
	public static int ReturnsSum(int[] nums) {
		return new Solution().MaximumSum(nums);
	}
}
