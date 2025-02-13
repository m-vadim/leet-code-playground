using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(10, new[] { 2, 11, 10, 1, 3 }).Returns(2);
		yield return new TestCaseData(1000000000, new[] { 999999999, 999999999, 999999999 }).Returns(2);
	}

	[TestCaseSource(nameof(Cases))]
	public static int ReturnsMIn(int k, int[] nums) {
		return new Solution().MinOperations(nums, k);
	}
}
