namespace LeetCode;

/// <summary>
/// https://leetcode.com/problems/merge-nodes-in-between-zeros
/// </summary>
public class Solution {
	public ListNode MergeNodes(ListNode head) {
		ListNode node = head.next.next;
		var linkedList = new LinkedList(head.next);
		bool open = true;

		while (node != null) {
			if (node.val == 0) {
				open = !open;
			} else {
				if (open) {
					linkedList.Last.val += node.val;
				} else {
					linkedList.Append(node);
					open = true;
				}
			}
			node = node.next;
		}

		linkedList.Last.next = null;
		return linkedList.Head;
	}

	private sealed class LinkedList {
		public LinkedList(ListNode head) {
			Head = head;
			Last = head;
		}

		public void Append(ListNode node) {
			Last.next = node;
			Last = Last.next;
		}

		public ListNode Head { get; }
		public ListNode Last { get; private set; }
	}
}
