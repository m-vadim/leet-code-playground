namespace LeetCode;

/// <summary>
/// https://leetcode.com/problems/delete-the-middle-node-of-a-linked-list
/// </summary>
public class Solution {
	public ListNode DeleteMiddle(ListNode head) {
		ListNode slow = head, fast = head;
		ListNode? middleHead = null;
		
		while (fast is { next: not null }) {
			middleHead = slow;
			slow = slow.next;
			fast = fast.next.next;
		}

		if (middleHead == null) {
			return null!;
			
		}
		
		middleHead.next = slow.next;
		return head;
	}
}