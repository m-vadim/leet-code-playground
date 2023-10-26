namespace LeetCode;

/// <summary>
/// https://leetcode.com/problems/odd-even-linked-list/
/// </summary>
public class Solution {
	public ListNode OddEvenList(ListNode head) {
		if (head?.next == null) {
			return head!;
		}
		
		var oddList = new LinkedList(DetachHead(head, out ListNode? node));
		var evenTail = new LinkedList(DetachHead(node!, out node));
		
		bool even = false;
		while (node != null) {
			ListNode detachedHead = DetachHead(node, out ListNode? nextNode);
			if (even) {
				evenTail.AppendToEnd(detachedHead);
			}
			else {
				oddList.AppendToEnd(detachedHead);
			}
			
			even = !even;
			node = nextNode;
		}

		oddList.AppendToEnd(evenTail.Head);
		
		return oddList.Head;
	}

	private static ListNode DetachHead(ListNode node, out ListNode? tail) {
		tail = node.next;
		node.next = null;
		return node;
	}
}

internal sealed class LinkedList {
	private ListNode _last;

	public LinkedList(ListNode head) {
		Head = head;
		_last = head;
	}

	public void AppendToEnd(ListNode node) {
		_last.next = node;
		_last = _last.next;
	}

	public ListNode Head { get; }
}