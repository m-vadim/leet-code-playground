using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(new[] { 1, 2, 3 }, new int[][] { [], [1], [2], [1, 2], [3], [1, 3], [2, 3], [1, 2, 3] });
		yield return new TestCaseData(new[] { 0 }, new int[][] { [], [0] });
	}

	[TestCaseSource(nameof(Cases))]
	public static void ReturnsAllSubsets(int[] nums, IList<IList<int>> expected) {
		CollectionAssert.AreEquivalent(expected, new Solution().Subsets(nums));
	}
}
