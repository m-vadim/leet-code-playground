namespace AddTwoNumbers;

// https://leetcode.com/problems/add-two-numbers/
public class Solution {
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        var head = new ListNode();
        ListNode current = head;
        int surplus = 0;

        while (l1 != null || l2 != null || surplus != 0) {
            int l1Digit = l1?.val ?? default;
            int l2Digit = l2?.val ?? default;
            int sum = l1Digit + l2Digit + surplus;
            if (sum >= 10) {
                sum -= 10;
                surplus = 1;
            }
            else {
                surplus = 0;
            }

            current.next = new ListNode(sum);
            current = current.next;
            l1 = l1?.next;
            l2 = l2?.next;
        }

        return head.next;
    }
    
    public ListNode AddTwoNumbersRecursion(ListNode l1, ListNode l2) {
        return SumNodes(l1, l2, 0);
    }

    private ListNode SumNodes(ListNode l1, ListNode l2, int surplus) {
        if (l1 == null && l2 == null) {
            if (surplus == 0) {
                return null;
            }
            
            return new ListNode(1);
        }

        int l1Digit = l1?.val ?? default;
        int l2Digit = l2?.val ?? default;

        int sum = l1Digit + l2Digit + surplus;
        if (sum >= 10) {
            sum = sum - 10;
            surplus = 1;
        }
        else {
            surplus = 0;
        }

        return new ListNode(sum, SumNodes(l1?.next, l2?.next, surplus));
    }
}