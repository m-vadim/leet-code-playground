namespace LeetCode;

public sealed class ListNode {
    // ReSharper disable once InconsistentNaming
    public int val;
    // ReSharper disable once InconsistentNaming
    public ListNode next;

    public ListNode(int val = default, ListNode next = null) {
        this.val = val;
        this.next = next;
    }
}