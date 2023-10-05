namespace LeetCode;

/// <summary>
/// https://leetcode.com/problems/reverse-linked-list-ii/
/// </summary>
public class Solution {
	public ListNode ReverseBetween(ListNode head, int left, int right) {
		if (head.next == null || left == right) {
			return head;
		}

		ListNode? detachedHead = null;
		if (left > 1) {
			detachedHead = head;
			while (--left > 1) {
				detachedHead = detachedHead.next;
			}
		}

		ListNode from = head;
		if (detachedHead != null) {
			from = detachedHead.next;
		}

		ListNode? detachedTail = head, to = head;
		while (right-- >= 1) {
			to = detachedTail;
			detachedTail = detachedTail.next;
		}

		to.next = null;
		if (detachedHead != null) {
			detachedHead.next = ReverseLinkedList(from);
		}
		else {
			head = ReverseLinkedList(from);
		}
		
		from.next = detachedTail;
		return head;
	}

	private ListNode ReverseLinkedList(ListNode head) {
		ListNode newTail = null;
		while (head.next != null) {
			ListNode oldTail = head.next;

			if (newTail != null) {
				head.next = newTail;
				newTail = head;
			}
			else {
				head.next = null;
				newTail = head;
			}

			head = oldTail;
		}

		head.next = newTail;

		return head;
	}
}