using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(new[] { 3, 1, 2, 4 }).Returns(new[] { 4, 2, 1, 3 });
		yield return new TestCaseData(new[] { 2, 4, 2, 4 }).Returns(new[] { 2, 4, 2, 4 });
		yield return new TestCaseData(new[] { 1 }).Returns(new[] { 1 });
		yield return new TestCaseData(new[] { 5, 3, 7, 1 }).Returns(new[] { 5, 3, 7, 1 });
	}

	[TestCaseSource(nameof(Cases))]
	public static int[] ReturnsArraySortedByParity(int[] nums) {
		return new Solution().SortArrayByParity(nums);
	}
}