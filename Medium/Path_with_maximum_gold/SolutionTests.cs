using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData([new int[][] { [0, 6, 0], [5, 8, 7], [0, 9, 0] }]).Returns(24);
		yield return new TestCaseData([new int[][] { [1, 0, 7], [2, 0, 6], [3, 4, 5], [0, 3, 0], [9, 0, 20] }]).Returns(28);
	}

	[TestCaseSource(nameof(Cases))]
	public static int GetsMaxGoldPossible(int[][] grid) {
		return new Solution().GetMaximumGold(grid);
	}
}
