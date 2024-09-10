using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(new[] { 18, 6, 10, 3 }).Returns(new[] { 18, 6, 6, 2, 10, 1, 3 });
	}

	[TestCaseSource(nameof(Cases))]
	public static int[] ReturnsUpdatedList(int[] values) {
		return new Solution().InsertGreatestCommonDivisors(values.ToListNode()).ToArray();
	}
}
