namespace LeetCode;

internal static class ListNodeExtensions {
    internal static ListNode ToListNode(this int[] array) {
        if (array.Length == 0) {
            return null!;
        }

        var head = new ListNode(array[0]);
        ListNode next = head;

        foreach (int val in array[1..]) {
            next.next = new ListNode(val);
            next = next.next;
        }

        return head;
    }

    internal static int[] ToArray(this ListNode node) {
        if (node == null) {
            return Array.Empty<int>();
        }

        var list = new List<int>();
        while (node != null) {
            list.Add(node.val);
            node = node.next;
        }

        return list.ToArray();
    }
}