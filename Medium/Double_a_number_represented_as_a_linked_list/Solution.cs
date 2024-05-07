namespace LeetCode;

/// <summary>
/// https://leetcode.com/problems/double-a-number-represented-as-a-linked-list
/// </summary>
public class Solution {
	public ListNode DoubleIt(ListNode head) {
		ListNode node = head;
		Stack<ListNode> ex = new();
		while (node != null) {
			ex.Push(node);
			node = node.next;
		}

		int exc = 0;
		while (ex.Count > 0) {
			node = ex.Pop();
			node.val *= 2;
			if (exc > 0) {
				node.val += 1;
				exc--;
			}
			if (node.val > 9) {
				exc++;
				node.val %= 10;
			}
		}

		if (exc > 0) {
			return new ListNode(1, head);
		}

		return head;
	}
}
