using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(new[] { 5, 2, 13, 3, 8 }.ToListNode()).Returns(new[] { 13, 8 });
		yield return new TestCaseData(new[] { 1, 1, 1, 1 }.ToListNode()).Returns(new[] { 1, 1, 1, 1 });
		yield return new TestCaseData(new[] { 10, 11, 12, 13, 14 }.ToListNode()).Returns(new[] { 14 });
	}

	[TestCaseSource(nameof(Cases))]
	public static int[] ReturnsListWithRemovedNodes(ListNode head) {
		return new Solution().RemoveNodes(head).ToArray();
	}
}
