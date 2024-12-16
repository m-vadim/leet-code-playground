using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(new object[] { new int[] { 2, 1, 3, 5, 6 }, 5, 2 }).Returns(new int[] { 8, 4, 6, 5, 6 });
	}

	[TestCaseSource(nameof(Cases))]
	public static int[] ReturnsArrayAfterOperations(int[] nums, int k, int multiplier) {
		return new Solution().GetFinalState(nums, k, multiplier);
	}
}
