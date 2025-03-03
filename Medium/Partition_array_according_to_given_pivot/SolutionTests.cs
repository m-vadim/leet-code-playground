using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData((object)new int[] { 9, 12, 5, 10, 14, 3, 10 }, 10).Returns(new int[] { 9, 5, 3, 10, 10, 12, 14 });
		yield return new TestCaseData((object)new int[] { -3, 4, 3, 2 }, 2).Returns(new int[] { -3, 2, 4, 3 });
	}

	[TestCaseSource(nameof(Cases))]
	public static int[] ReturnsArrayRearrangedByPivot(int[] nums, int pivot) {
		return new Solution().PivotArray(nums, pivot);
	}
}
