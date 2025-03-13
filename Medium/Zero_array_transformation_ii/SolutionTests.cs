using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static readonly Solution Solution = new();

	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(new object[] { new[] { 2, 0, 2 }, new int[][] { [0, 2, 1], [0, 2, 1], [1, 1, 3] } }).Returns(2);
		yield return new TestCaseData(new object[] { new[] { 4, 3, 2, 1 }, new int[][] { [1, 3, 2], [0, 2, 1] } }).Returns(-1);
		yield return new TestCaseData(new object[] { new[] { 0 }, new int[][] { [0, 0, 2], [0, 0, 4], [0, 0, 4], [0, 0, 3], [0, 0, 5] } }).Returns(0);
	}

	[TestCaseSource(nameof(Cases))]
	public static int ReturnsMinimumToMakeZeroArray(int[] nums, int[][] queries) {
		return Solution.MinZeroArray(nums, queries);
	}
}
