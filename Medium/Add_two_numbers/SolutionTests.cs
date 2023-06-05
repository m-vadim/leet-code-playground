using AddTwoNumbers;
using NUnit.Framework;

namespace LeetCode;

[TestFixture, Parallelizable]
internal class SolutionTests {
    private static IEnumerable<TestCaseData> Cases() {
        yield return new TestCaseData(ToListNode(2, 4, 3), ToListNode(5, 6, 4), ToListNode(7, 0, 8));
        yield return new TestCaseData(ToListNode(0, 0, 0), ToListNode(1, 2, 3), ToListNode(1, 2, 3));
        yield return new TestCaseData(ToListNode(-5, -10, 10), ToListNode(5, 10, -10), ToListNode(0, 0, 0));
    }

    [TestCaseSource(nameof(Cases))]
    public static void SumsTwoListNodes(ListNode l1, ListNode l2, ListNode expected) {
        ListNode sum = new Solution().AddTwoNumbers(l1, l2);

        Assert.IsTrue(Compare(expected, sum));
    }

    private static ListNode ToListNode(params int[] array) {
        if (array.Length == 0) {
            return null!;
        }

        var head = new ListNode(array[0]);
        ListNode next = head;

        foreach (int val in array[1..]) {
            next.next = new ListNode(val);
            next = next.next;
        }

        return head;
    }

    private static bool Compare(ListNode first, ListNode second) {
        while (first != null || second != null) {
            if (first != null && second != null) {
                if (first.val != second.val) {
                    return false;
                }

                first = first.next;
                second = second.next;
            }
            else {
                return false;
            }
        }

        return true;
    }
}