using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(new[] { 1, 2, 3, 4, 5 }.ToListNode()).Returns(new[] { 1, 3, 5, 2, 4 });
		yield return
			new TestCaseData(new[] { 2, 1, 3, 5, 6, 4, 7 }.ToListNode()).Returns(new[] { 2, 3, 6, 7, 1, 5, 4 });
	}

	[TestCaseSource(nameof(Cases))]
	public static int[] ReturnsOddEvenList(ListNode head) {
		return new Solution().OddEvenList(head).ToArray();
	}
}