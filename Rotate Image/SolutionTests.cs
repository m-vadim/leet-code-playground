using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(new[] {
			new[] {
				new[] { 1, 2, 3 },
				new[] { 4, 5, 6 },
				new[] { 7, 8, 9 }
			}
		}).Returns(new[] {
			new[] { 7, 4, 1 },
			new[] { 8, 5, 2 },
			new[] { 9, 6, 3 }
		}).SetName("3x3 matrix");

		yield return new TestCaseData(new[] {
			new[] {
				new[] { 5, 1, 9, 11 },
				new[] { 2, 4, 8, 10 },
				new[] { 13, 3, 6, 7 },
				new[] { 15, 14, 12, 16 }
			}
		}).Returns(new[] {
			new[] { 15, 13, 2, 5 },
			new[] { 14, 3, 4, 1 },
			new[] { 12, 6, 8, 9 },
			new[] { 16, 7, 10, 11 }
		}).SetName("4x4 matrix");
	}

	[TestCaseSource(nameof(Cases))]
	public static int[][] RotatesMatrix(int[][] matrix) {
		new Solution().Rotate(matrix);
		return matrix;
	}
}