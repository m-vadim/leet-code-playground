using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(new object[] {
			new int[][] {
				new[] { 0, 0, 0 },
				new[] { 0, 1, 0 },
				new[] { 0, 0, 0 }
			}
		}).Returns(2);
		yield return new TestCaseData(new object[] {
			new int[][] {
				new[] { 0, 1 },
				new[] { 0, 0 },
			}
		}).Returns(1);
	}

	[TestCaseSource(nameof(Cases))]
	public static int ReturnsUniquePathsCount(int[][] obstacleGrid) {
		return new Solution().UniquePathsWithObstacles(obstacleGrid);
	}
}