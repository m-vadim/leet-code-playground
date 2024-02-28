namespace LeetCode;

/// <summary>
/// https://leetcode.com/problems/rotate-list/
/// </summary>
public class Solution {
	public ListNode RotateRight(ListNode head, int k) {
		if (k == 0 || head == null) {
			return head;
		}
		
		int count = 1;
		ListNode lastNode = head;
		while (lastNode.next != null) {
			count += 1;
			lastNode = lastNode.next;
		}

		if (k >= count) {
			k %= count;
		}

		if (k == 0) {
			return head;
		}

		k = count - k;

		ListNode newHead = head;
		while (true) {
			k--;
			if (k > 0) {
				newHead = newHead.next;
				continue;
			}

			ListNode child = newHead.next;
			newHead.next = null;
			newHead = child;
			break;
		}

		lastNode.next = head;
		
		return newHead;
	}
}