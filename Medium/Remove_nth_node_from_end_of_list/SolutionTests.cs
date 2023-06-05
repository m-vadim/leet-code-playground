using NUnit.Framework;

namespace LeetCode;

[TestFixture, Parallelizable]
internal class SolutionTests {
    private static IEnumerable<TestCaseData> Cases() {
        yield return new TestCaseData(new[] {1, 2, 3, 4, 5}, 2).Returns(new[] {1, 2, 3, 5});
        yield return new TestCaseData(new[] {1}, 2).Returns(Array.Empty<int>());
        yield return new TestCaseData(new[] {1, 2}, 1).Returns(new[] {1});
        yield return new TestCaseData(new[] {1, 2}, 2).Returns(new[] {2});
    }

    [TestCaseSource(nameof(Cases))]
    public static int[] AssertTrueIfNodeRemoved(int[] head, int n) {
        ListNode actual = new Solution().RemoveNthFromEnd(head.ToListNode(), n);
        return actual.ToArray();
    }
    
    [TestCaseSource(nameof(Cases))]
    public static int[] AssertTrueIfNodeRemoved2Pass(int[] head, int n) {
        ListNode actual = new Solution().RemoveNthFromEndTwoPass(head.ToListNode(), n);
        return actual.ToArray();
    }
}