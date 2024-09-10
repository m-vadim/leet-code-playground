namespace LeetCode;

/// <summary>
/// https://leetcode.com/problems/insert-greatest-common-divisors-in-linked-list
/// </summary>
public sealed class Solution {
	public ListNode InsertGreatestCommonDivisors(ListNode head) {
		ListNode current = head, next = head.next;
		while (next != null) {
			var newNode = new ListNode(GetGreatestCommonDivisor(current.val, next.val)) {
				next = next
			};
			current.next = newNode;
			current = next;
			next = next.next;
		}

		return head;
	}

	private static int GetGreatestCommonDivisor(int num1, int num2) {
		if (num1 == num2) {
			return num1;
		}

		while (num1 % num2 > 0)  {
			int r = num1 % num2;
			num1 = num2;
			num2 = r;
		}
		return num2;
	}
}
