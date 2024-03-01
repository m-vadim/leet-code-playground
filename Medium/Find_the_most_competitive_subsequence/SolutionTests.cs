using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(new[] { 3, 5, 2, 6 }, 2)
			.Returns(new[] { 2, 6 });
		yield return new TestCaseData(new[] { 2, 4, 3, 3, 5, 4, 9, 6 }, 4)
			.Returns(new[] { 2, 3, 3, 4 });
		yield return new TestCaseData(new[] { 71, 18, 52, 29, 55, 73, 24, 42, 66, 8, 80, 2 }, 3)
			.Returns(new[] { 8, 80, 2 });
		yield return new TestCaseData(new int[50000], 5000)
			.Returns(new int[5000]);
		yield return new TestCaseData(new[] { 1, 1, 1, 1, 1, 1, 1, 1, 0, 0 }, 5)
			.Returns(new[] { 1, 1, 1, 0, 0 });
	}

	[TestCaseSource(nameof(Cases))]
	public static int[] ReturnsMostCompetitive(int[] nums, int k) {
		return new Solution().MostCompetitive(nums, k);
	}
}