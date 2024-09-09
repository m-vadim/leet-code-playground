using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		int[][] first = [[0, 2], [5, 10], [13, 23], [24, 25]];
		int[][] second = [[1, 5], [8, 12], [15, 24], [25, 26]];
		int[][] expected = [[1, 2], [5, 5], [8, 10], [15, 23], [24, 24], [25, 25]];

		yield return new TestCaseData(first, second).Returns(expected);
	}

	[TestCaseSource(nameof(Cases))]
	public static int[][] ReturnsIn(int[][] firstList, int[][] secondList) {
		return new Solution().IntervalIntersection(firstList, secondList);
	}
}
