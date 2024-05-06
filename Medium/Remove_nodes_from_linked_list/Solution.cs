namespace LeetCode;

/// <summary>
/// https://leetcode.com/problems/remove-nodes-from-linked-list
/// </summary>
public class Solution {
	public ListNode RemoveNodes(ListNode head) {
		var stack = new Stack<ListNode>();
		stack.Push(head);

		ListNode? currentNode = head.next;
		while (currentNode != null) {
			while (stack.Count > 0 && stack.Peek().val < currentNode.val) {
				stack.Pop();
			}
			stack.Push(currentNode);
			currentNode = currentNode.next;
		}


		head = stack.Pop();
		head.next = null;

		while (stack.Count > 0) {
			var tmp = stack.Pop();
			tmp.next = head;
			head = tmp;
		}

		return head;
	}
}
