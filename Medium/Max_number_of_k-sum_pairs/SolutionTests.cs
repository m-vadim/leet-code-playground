using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(new[] { 1, 2, 3, 4 }, 5).Returns(2);
		yield return new TestCaseData(new[] { 3, 1, 3, 4, 3 }, 6).Returns(1);
		yield return new TestCaseData(new[] { 4, 4, 1, 3, 1, 3, 2, 2, 5, 5, 1, 5, 2, 1, 2, 3, 5, 4 }, 2).Returns(2);
		yield return new TestCaseData(new[] { 2, 2, 2, 3, 1, 1, 4, 1 }, 4).Returns(2);
	}

	[TestCaseSource(nameof(Cases))]
	public static int ReturnsMaxNumberOfKSumPairs(int[] nums, int k) {
		return new Solution().MaxOperations(nums, k);
	}
	
	[TestCaseSource(nameof(Cases))]
	public static int ReturnsMaxNumberOfKSumPairsUsingMap(int[] nums, int k) {
		return new Solution().MaxOperationsMap(nums, k);
	}
}