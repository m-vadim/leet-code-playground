namespace LeetCode;

// https://leetcode.com/problems/merge-two-sorted-lists/description/
public class Solution {
    public ListNode MergeTwoLists(ListNode list1, ListNode list2) {
        if (list1 == null || list2 == null) {
            if (list1 != null) {
                return list1;
            }

            return list2!;
        }

        ListNode head;
        if (list1.val <= list2.val) {
            head = list1;
            list1 = list1.next;
        }
        else {
            head = list2;
            list2 = list2.next;
        }
        
        ListNode current = head;

        while (list1 != null || list2 != null) {
            ListNode next;
            if (list1 == null) {
                next = list2;
                list2 = list2.next;
            } else if (list2 == null) {
                next = list1;
                list1 = list1.next;
            } else if (list1.val <= list2.val) {
                next = list1;
                list1 = list1.next;
            }
            else {
                next = list2;
                list2 = list2.next;
            }

            current.next = next;
            current = next;
        }
        
        return head;
    }
}