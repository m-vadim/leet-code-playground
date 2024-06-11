using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(
			new object?[] {
				new[] { 2, 3, 1, 3, 2, 4, 6, 7, 9, 2, 19 },
				new[] { 2, 1, 4, 3, 9, 6 }
			}).Returns(new[] { 2, 2, 2, 1, 4, 3, 3, 9, 6, 7, 19 });
		yield return new TestCaseData(
			new object?[] {
				new[] { 28, 6, 22, 8, 44, 17 },
				new[] { 22, 28, 8, 6 }
			}).Returns(new[] { 22, 28, 8, 6, 17, 44 });
	}

	[TestCaseSource(nameof(Cases))]
	public static int[] ReturnsRelativelySortedArray(int[] arr1, int[] arr2) {
		return new Solution().RelativeSortArray(arr1, arr2);
	}
}
