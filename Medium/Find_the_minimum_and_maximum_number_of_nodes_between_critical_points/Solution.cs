namespace LeetCode;

/// <summary>
/// https://leetcode.com/problems/find-the-minimum-and-maximum-number-of-nodes-between-critical-points
/// </summary>
public class Solution {
	public int[] NodesBetweenCriticalPoints(ListNode head) {
		ListNode left = head, middle = head.next, right = head.next.next;
		int index = 1;
		var tracker = new Tracker();

		while (right != null) {
			if (IsCriticalPoint(left, middle, right)) {
				tracker.Set(index);
			}

			left = middle;
			middle = right;
			right = right.next;
			index++;
		}

		return [tracker.MinDistance, tracker.MaxDistance];
	}

	private static bool IsCriticalPoint(ListNode left, ListNode middle, ListNode right) {
		return (middle.val < left.val && middle.val < right.val) || (middle.val > left.val && middle.val > right.val);
	}
}

internal sealed class Tracker {
	private int? _first;
	private int _previous;
	private int _last;

	public void Set(int index) {
		if (_first == null) {
			_first = index;
			_previous = index;
			_last = index;
			return;
		}

		_previous = _last;
		_last = index;
		MinDistance = MinDistance == -1 ? (_last - _previous) : Math.Min(MinDistance, _last - _previous);
	}

	private int GetMax() {
		if (_first == null || _first.Value == _last) {
			return -1;
		}

		return _last - _first.Value;
	}

	public int MinDistance { get; private set; } = -1;
	public int MaxDistance => GetMax();
}
