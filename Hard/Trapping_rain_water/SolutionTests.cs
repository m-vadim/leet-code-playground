using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 }).Returns(6);
		yield return new TestCaseData(new int[] { 4, 2, 0, 3, 2, 5 }).Returns(9);
	}

	[TestCaseSource(nameof(Cases))]
	public static int ReturnsTrappedWaterCount(int[] heights) {
		return new Solution().Trap(heights);
	}
}
