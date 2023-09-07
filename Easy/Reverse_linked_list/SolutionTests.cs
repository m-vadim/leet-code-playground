using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(new[] { 1, 2, 3, 4, 5 }.ToListNode()).Returns(new[] { 5, 4, 3, 2, 1 });
		yield return new TestCaseData(new[] { 2 }.ToListNode()).Returns(new[] { 2 });
		yield return new TestCaseData(Array.Empty<int>().ToListNode()).Returns(Array.Empty<int>());
	}

	[TestCaseSource(nameof(Cases))]
	public static int[] ReturnsReversedLinkedList(ListNode list) {
		return new Solution().ReverseList(list).ToArray();
	}
}