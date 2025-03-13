using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static readonly Solution Solution = new();

	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(new object[] { new[] { 1, 0, 1 }, new int[][] { [0, 2] } }).Returns(true);
		yield return new TestCaseData(new object[] { new[] { 4, 3, 2, 1 }, new int[][] { [1, 3], [0, 2] } }).Returns(false);
		yield return new TestCaseData(new object[] { new[] { 1, 1, 0, 0 }, new int[][] { [0, 1] } }).Returns(true);
		yield return new TestCaseData(new object[] { new[] { 3 }, new int[][] { [0, 0], [0, 0] } }).Returns(false);
		yield return new TestCaseData(new object[] { new[] { 0, 3, 9 }, new int[][] { [1, 1], [1, 2], [1, 2], [2, 2], [0, 2], [0, 2] } }).Returns(false);
	}

	[TestCaseSource(nameof(Cases))]
	public static bool ReturnsWhenArrayIsZeroArrayAfterQueries(int[] nums, int[][] queries) {
		return Solution.IsZeroArray(nums, queries);
	}
}
