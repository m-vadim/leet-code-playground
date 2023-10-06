namespace LeetCode;

/// <summary>
/// https://leetcode.com/problems/reorder-list/
/// </summary>
public class Solution {
	public void ReorderList(ListNode head) {
		ListNode slow = head, fast = head;
		while (fast != null && fast.next != null) {
			slow = slow.next;
			fast = fast.next.next;
		}

		ListNode tail = slow.next;
		slow.next = null;

		if (tail == null) {
			return;
		}
		
		tail = ReverseList(tail);

		ListNode node = head;
		while (tail != null) {
			var leftHalf = node.next;
			var nodeToMove = tail;
			tail = tail.next;

			node.next = nodeToMove;
			node.next.next = leftHalf;
			node = leftHalf;
		}
	}

	private ListNode ReverseList(ListNode head) {
		if (head.next == null) {
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