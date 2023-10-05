using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(new[] { 1, 2, 3, 4, 5 }.ToListNode(), 2, 4).Returns(new[] { 1, 4, 3, 2, 5 });
		yield return new TestCaseData(new[] { 5 }.ToListNode(), 1, 1).Returns(new[] { 5 });
		yield return new TestCaseData(new[] { 1, 2, 3, 4, 5 }.ToListNode(), 3, 4).Returns(new[] { 1, 2, 4, 3, 5 });
	}

	[TestCaseSource(nameof(Cases))]
	public static int[] ReturnsReversedLinkedList(ListNode list, int left, int right) {
		return new Solution().ReverseBetween(list, left, right).ToArray();
	}
}