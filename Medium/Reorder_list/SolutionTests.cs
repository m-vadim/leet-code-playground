using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(new[] { 1, 2, 3, 4 }.ToListNode()).Returns(new[] { 1, 4, 2, 3 }).SetName("1, 2, 3, 4");
		yield return new TestCaseData(new[] { 5 }.ToListNode()).Returns(new[] { 5 }).SetName("5");
		yield return new TestCaseData(new[] { 1, 2 }.ToListNode()).Returns(new[] { 1, 2 }).SetName("1, 2");
		yield return new TestCaseData(new[] { 1, 2, 3, 4, 5 }.ToListNode()).Returns(new[] { 1, 5, 2, 4, 3 }).SetName("1, 2, 3, 4, 5");
	}

	[TestCaseSource(nameof(Cases))]
	public static int[] ReturnsReorderedLinkedList(ListNode head) {
		new Solution().ReorderList(head);
		return head.ToArray();
	}
}