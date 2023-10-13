using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(new[] { 10, 15, 20 }).Returns(15);
		yield return new TestCaseData(new[] { 1, 100, 1, 1, 1, 100, 1, 1, 100, 1 }).Returns(6);
	}

	[TestCaseSource(nameof(Cases))]
	public static int ReturnsClimbStairsCached(int[] cost) {
		return new Solution().MinCostClimbingStairs(cost);
	}
}