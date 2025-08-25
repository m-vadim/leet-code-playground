using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static readonly Solution Solution = new();

	private static IEnumerable<TestCaseData> Cases() {
		int[][] input = [[1, 2, 3], [4, 5, 6], [7, 8, 9]];
		yield return new TestCaseData([input])
			.SetName(MatrixToTestName(input))
			.Returns(new int[] { 1, 2, 4, 7, 5, 3, 6, 8, 9 });

		input = [[1, 2], [3, 4]];
		yield return new TestCaseData([input])
			.SetName(MatrixToTestName(input))
			.Returns(new int[] { 1, 2, 3, 4 });
	}

	[TestCaseSource(nameof(Cases))]
	public static int[] ReturnsDiagonalTraverse(int[][] mat) {
		return Solution.FindDiagonalOrder(mat);
	}

	private static string MatrixToTestName(int[][] mat) => $"[{string.Join(",  ", mat.Select(rows => string.Join(", ", rows).Trim()).Select(s => $"[{s}]"))}]";
}
