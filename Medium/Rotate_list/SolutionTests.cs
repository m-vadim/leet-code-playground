using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(new[] { 1, 2, 3, 4, 5 }.ToListNode(), 2).Returns(new[] { 4, 5, 1, 2, 3 });
		yield return new TestCaseData(new[] { 1, 2, 3, 4, 5 }.ToListNode(), 0).Returns(new[] { 1, 2, 3, 4, 5 });
		yield return new TestCaseData(new[] { 1, 2, 3, 4, 5 }.ToListNode(), 5).Returns(new[] { 1, 2, 3, 4, 5 });
		yield return new TestCaseData(Array.Empty<int>().ToListNode(), 5).Returns(Array.Empty<int>());
	}

	[TestCaseSource(nameof(Cases))]
	public static int[] ReturnsRotatedList(ListNode head, int k) {
		return new Solution().RotateRight(head, k).ToArray();
	}
}