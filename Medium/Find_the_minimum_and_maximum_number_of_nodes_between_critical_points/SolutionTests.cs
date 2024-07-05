using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(new[] { 3, 1 }.ToListNode()).Returns(new[] { -1, -1 }).SetName("[3,1] => [-1, -1]");
		yield return new TestCaseData(new[] { 5, 3, 1, 2, 5, 1, 2 }.ToListNode()).Returns(new[] { 1, 3 }).SetName("[5, 3, 1, 2, 5, 1, 2] => [1, 3]");
		yield return new TestCaseData(new[] { 1, 3, 2, 2, 3, 2, 2, 2, 7 }.ToListNode()).Returns(new[] { 3, 3 }).SetName("[1, 3, 2, 2, 3, 2, 2, 2, 7] => [3, 3]");
		yield return new TestCaseData(new[] { 2, 2, 1, 3 }.ToListNode()).Returns(new[] { -1, -1 }).SetName("[2, 2, 1, 3] => [-1, -1]");
	}

	[TestCaseSource(nameof(Cases))]
	public static int[] ReturnsDistance(ListNode head) {
		return new Solution().NodesBetweenCriticalPoints(head).ToArray();
	}
}
