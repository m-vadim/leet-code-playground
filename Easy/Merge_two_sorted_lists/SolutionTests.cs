using NUnit.Framework;

namespace LeetCode;

[TestFixture, Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(ToListNode(1, 2, 4), ToListNode(1, 3, 4), ToListNode(1, 1, 2, 3, 4, 4));
		yield return new TestCaseData(ToListNode(2), ToListNode(1), ToListNode(1, 2));
		yield return new TestCaseData(ToListNode(Array.Empty<int>()), ToListNode(1, 3, 4), ToListNode(1, 3, 4));
		yield return new TestCaseData(ToListNode(1, 3, 4), ToListNode(Array.Empty<int>()), ToListNode(1, 3, 4));
		yield return new TestCaseData(ToListNode(Array.Empty<int>()), ToListNode(Array.Empty<int>()), ToListNode(Array.Empty<int>()));
	}

	[TestCaseSource(nameof(Cases))]
	public static void AssertTrueIfMergeMatchExpected(ListNode list1, ListNode list2, ListNode expected) {
		Assert.IsTrue(Compare(new Solution().MergeTwoLists(list1, list2), expected));
	}

	private static ListNode ToListNode(params int[] array) {
		if (array.Length == 0) {
			return null;
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