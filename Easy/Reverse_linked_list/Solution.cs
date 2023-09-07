// https://leetcode.com/problems/reverse-linked-list/

namespace LeetCode;

public class Solution {
	public ListNode ReverseList(ListNode head) {
		if (head?.next == null) {
			return head;
		}

		ListNode newTail = null;
		while (head.next != null) {
			var oldTail = head.next;

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