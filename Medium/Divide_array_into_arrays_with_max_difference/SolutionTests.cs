using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(new[] { 1, 3, 4, 8, 7, 9, 3, 5, 1 }, 2).Returns(
			new int[][] { [1, 1, 3], [3, 4, 5], [7, 8, 9] });
		yield return new TestCaseData(new[] { 1, 3, 3, 2, 7, 3 }, 3).Returns(Array.Empty<int[]>());
		yield return new TestCaseData(new[] { 6, 10, 5, 12, 7, 11, 6, 6, 12, 12, 11, 7 }, 2).Returns(
			new int[][] { [5, 6, 6], [6, 7, 7], [10, 11, 11], [12, 12, 12] });
		yield return new TestCaseData(
			new[] { 15, 13, 12, 13, 12, 14, 12, 2, 3, 13, 12, 14, 14, 13, 5, 12, 12, 2, 13, 2, 2 }, 2).Returns(Array.Empty<int[]>());
	}

	[TestCaseSource(nameof(Cases))]
	public static int[][] ReturnsDividedArray(int[] nums, int k) {
		return new Solution().DivideArray(nums, k);
	}
}