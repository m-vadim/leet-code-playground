using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(new[] { 1, 3, 4, 7, 1, 2, 6 }.ToListNode()).Returns(new[] { 1, 3, 4, 1, 2, 6 });
		yield return new TestCaseData(new[] { 1, 2, 3, 4 }.ToListNode()).Returns(new[] { 1, 2, 4 });
		yield return new TestCaseData(new[] { 2, 1 }.ToListNode()).Returns(new[] { 2 });
		yield return new TestCaseData(new[] { 2 }.ToListNode()).Returns(Array.Empty<int>());
	}

	[TestCaseSource(nameof(Cases))]
	public static int[] RemovesMiddleNode(ListNode head) {
		return new Solution().DeleteMiddle(head).ToArray();
	}
}