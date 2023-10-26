namespace LeetCode;

/// <summary>
/// https://leetcode.com/problems/maximum-twin-sum-of-a-linked-list
/// </summary>
public class Solution {
	public int PairSum(ListNode head) {
		ListNode slow = head, fast = head;
		var stack = new Stack<int>();

		while (fast?.next != null) {
			stack.Push(slow.val);
			slow = slow.next;
			fast = fast.next.next;
		}

		int max = int.MinValue;
		while (slow != null) {
			max = Math.Max(max, (stack.Pop() + slow.val));
			slow = slow.next;
		}

		return max;
	}
}