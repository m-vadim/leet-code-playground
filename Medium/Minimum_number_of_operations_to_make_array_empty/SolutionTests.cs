using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(new object?[] {
			new[] { 2, 3, 3, 2, 2, 4, 2, 3, 4 }
		}).Returns(4);
		yield return new TestCaseData(new object?[] {
			new[] { 2, 1, 2, 2, 3, 3 }
		}).Returns(-1);
		yield return new TestCaseData(new object?[] {
			new[] { 14, 12, 14, 14, 12, 14, 14, 12, 12, 12, 12, 14, 14, 12, 14, 14, 14, 12, 12 }
		}).Returns(7);
	}

	[TestCaseSource(nameof(Cases))]
	public static int ReturnsMinOperations(int[] nums) {
		return new Solution().MinOperations(nums);
	}
	
	[TestCaseSource(nameof(Cases))]
	public static int ReturnsMinOperationsSort(int[] nums) {
		return new Solution().MinOperationsSort(nums);
	}
}