using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(new[] { 5, 4, 2, 1 }.ToListNode()).Returns(6);
		yield return new TestCaseData(new[] { 4, 2, 2, 3 }.ToListNode()).Returns(7);
		yield return new TestCaseData(new[] { 1, 100000 }.ToListNode()).Returns(100001);
	}

	[TestCaseSource(nameof(Cases))]
	public static int ReturnsMaxTwinSum(ListNode head) {
		return new Solution().PairSum(head);
	}
}