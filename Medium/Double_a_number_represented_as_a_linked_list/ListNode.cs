namespace LeetCode;

public class ListNode {
	public int val;
	public ListNode next;

	public ListNode(int val = 0, ListNode next = null) {
		this.val = val;
		this.next = next;
	}
}

public static class Helpers {
	public static ListNode ToListNode(this int[] array) {
		if (array.Length == 0) {
			return null;
		}

		var head = new ListNode(array[0]);
		var next = head;

		foreach (var val in array[1..]) {
			next.next = new ListNode(val);
			next = next.next;
		}

		return head;
	}

	public static int[] ToArray(this ListNode listNode) {
		if (listNode == null) {
			return Array.Empty<int>();
		}

		var list = new List<int>();
		while (listNode.next != null) {
			list.Add(listNode.val);
			listNode = listNode.next;
		}

		list.Add(listNode.val);
		return list.ToArray();
	}
}
