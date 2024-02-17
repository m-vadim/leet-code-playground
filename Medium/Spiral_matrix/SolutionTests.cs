using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData([new int[][] { [1, 2, 3], [8, 9, 4], [7, 6, 5] }]).Returns(new[]
			{ 1, 2, 3, 4, 5, 6, 7, 8, 9 }).SetName("3*3 => from 1 to 9");
		yield return new TestCaseData([new int[][] { [1, 2, 3, 4], [10, 11, 12, 5], [9, 8, 7, 6] }]).Returns(new[]
			{ 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }).SetName("4*2 => from 1 to 12");
		yield return new TestCaseData([new int[][] { [1, 2], [4, 3] }]).Returns(new[]
			{ 1, 2, 3, 4 }).SetName("2*2 => from 1 to 4");
		yield return new TestCaseData([new int[][] { [1, 2, 3, 4, 5] }]).Returns(new[]
			{ 1, 2, 3, 4, 5 }).SetName("5*1 => from 1 to 5");
		yield return new TestCaseData([new int[][] { [1] }]).Returns(new[] { 1 }).SetName("1*1 => from 1 to 1");
		yield return new TestCaseData([new int[][] { [1], [2] }]).Returns(new[]
			{ 1, 2 }).SetName("1*2 => from 1 to 2");
		yield return new TestCaseData([new int[][] { [1, 2, 3], [10, 11, 4], [9, 12, 5], [8, 7, 6] }]).Returns(new[]
			{ 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }).SetName("3*4 => from 1 to 12");
	}

	[TestCaseSource(nameof(Cases))]
	public static IList<int> ReturnListOfElementsInMatrixInSpiralOrder(int[][] matrix) {
		return new Solution().SpiralOrder(matrix);
	}
}