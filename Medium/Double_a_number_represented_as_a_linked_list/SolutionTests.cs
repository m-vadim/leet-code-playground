using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(new[] { 9, 9, 9 }.ToListNode()).Returns(new[] { 1, 9, 9, 8 });
		yield return new TestCaseData(new[] { 1, 8, 9 }.ToListNode()).Returns(new[] { 3, 7, 8 });
		yield return new TestCaseData(new[] { 4 }.ToListNode()).Returns(new[] { 8 });
	}

	[TestCaseSource(nameof(Cases))]
	public static int[] ReturnsDoubledNodes(ListNode head) {
		return new Solution().DoubleIt(head).ToArray();
	}
}
