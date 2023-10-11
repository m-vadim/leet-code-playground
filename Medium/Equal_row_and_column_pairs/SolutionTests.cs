using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(new object[] {
			new int[][] {
				new[] { 3, 2, 1 },
				new[] { 1, 7, 6 },
				new[] { 2, 7, 7 }
			}
		}).Returns(1);
		yield return new TestCaseData(new object[] {
			new int[][] {
				new[] { 3, 1, 2, 2 },
				new[] { 1, 4, 4, 5 },
				new[] { 2, 4, 2, 2 },
				new[] { 2, 4, 2, 2 }
			}
		}).Returns(3);
		yield return new TestCaseData(new object[] {
			new int[][] {
				new[] { 8, 8, 8, 8, 8, 8, 10, 8, 8, 8, 8, 8, 8, 8, 8 },
				new[] { 8, 8, 8, 8, 8, 8, 19, 8, 8, 8, 8, 8, 8, 8, 8 },
				new[] { 8, 8, 8, 8, 8, 8, 6, 8, 8, 8, 8, 8, 8, 8, 8 },
				new[] { 8, 8, 8, 8, 8, 8, 6, 8, 8, 8, 8, 8, 8, 8, 8 },
				new[] { 8, 8, 8, 8, 8, 8, 4, 8, 8, 8, 8, 8, 8, 8, 8 },
				new[] { 8, 8, 8, 8, 8, 8, 14, 8, 8, 8, 8, 8, 8, 8, 8 },
				new[] { 6, 6, 6, 6, 6, 6, 7, 6, 6, 6, 6, 6, 6, 6, 6 },
				new[] { 8, 8, 8, 8, 8, 8, 17, 8, 8, 8, 8, 8, 8, 8, 8 },
				new[] { 8, 8, 8, 8, 8, 8, 16, 8, 8, 8, 8, 8, 8, 8, 8 },
				new[] { 8, 8, 8, 8, 8, 8, 19, 8, 8, 8, 8, 8, 8, 8, 8 },
				new[] { 8, 8, 8, 8, 8, 8, 6, 8, 8, 8, 8, 8, 8, 8, 8 },
				new[] { 8, 8, 8, 8, 8, 8, 16, 8, 8, 8, 8, 8, 8, 8, 8 },
				new[] { 8, 8, 8, 8, 8, 8, 10, 8, 8, 8, 8, 8, 8, 8, 8 },
				new[] { 8, 8, 8, 8, 8, 8, 19, 8, 8, 8, 8, 8, 8, 8, 8 },
				new[] { 8, 8, 8, 8, 8, 8, 4, 8, 8, 8, 8, 8, 8, 8, 8 }
			}
		}).Returns(42);
	}

	[TestCaseSource(nameof(Cases))]
	public static int ReturnsCountOfEqualPairs(int[][] grid) {
		return new Solution().EqualPairs(grid);
	}
}