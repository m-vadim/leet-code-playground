using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(new[] { 0, 3, 1, 0, 4, 5, 2, 0 }.ToListNode()).Returns(new[] { 4, 11 });
		yield return new TestCaseData(new[] { 0, 1, 0, 3, 0, 2, 2, 0 }.ToListNode()).Returns(new[] { 1, 3, 4 });
	}

	[TestCaseSource(nameof(Cases))]
	public static int[] ReturnsMergedList(ListNode head) {
		return new Solution().MergeNodes(head).ToArray();
	}
}
