// https://leetcode.com/problems/linked-list-cycle

namespace  LeetCode;
public class Solution {
	public bool HasCycle(ListNode head) {
		if (head == null) {
			return false;
		}
        
		const int mark = -100_001;
		while(head.next != null) {
			if (head.val == mark) {
				return true;
			}

			head.val = mark;
			head = head.next;
		}

		return false;
	}
}