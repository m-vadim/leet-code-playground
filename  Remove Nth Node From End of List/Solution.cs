namespace LeetCode;

// https://leetcode.com/problems/remove-nth-node-from-end-of-list/
public class Solution {
    public ListNode RemoveNthFromEnd(ListNode head, int n) {
        if (head.next == null) {
            return null;
        }
        
        ListNode current = head;
        ListNode nth = head;
        
        while (current != null) {
            current = current.next;
            if (n-- <= 0 && current != null) {
                nth = nth.next;
            }
        }

        if (n == 0) {
            return nth.next;
        }

        nth.next = nth.next.next;
        return head;
    }
    
    public ListNode RemoveNthFromEndTwoPass(ListNode head, int n) {
        ListNode current = head;
        int listLength = 1;
        
        while (current.next != null) {
            listLength += 1;
            current = current.next;
        }

        if (listLength < 2) {
            return null;
        }

        if (listLength == n) {
            return head.next;
        }
        
        current = head;
        listLength -= n;
        while (current != null) {
            if (--listLength == 0) {
                current.next = current.next.next;
                break;
            }

            current = current.next;
        }

        return head;
    }
}