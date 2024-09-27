/// <summary>
/// https://leetcode.com/problems/my-calendar-ii
/// </summary>
public sealed class MyCalendarTwo {
	private readonly IList<Slot> _slots;

	public MyCalendarTwo() {
		_slots = new List<Slot>();
	}

	public bool Book(int start, int end) {
		var newSlot = new Slot(start, end);
		if (_slots.Count == 0) {
			_slots.Add(newSlot);
			return true;
		}

		if (!newSlot.HasIntersectionWith(_slots[0]) && newSlot.IsStartEarlierThan(_slots[0])) {
			_slots.Insert(0, newSlot);
			return true;
		}

		if (HasTripleBooking(newSlot)) {
			return false;
		}

		AddNewSlot(newSlot);
		return true;
	}

	private void AddNewSlot(Slot newSlot) {
		var index = 0;
		while (index < _slots.Count - 1) {
			Slot leftSlot = _slots[index], rightSlot = _slots[index + 1];
			if (rightSlot.End <= newSlot.Start || rightSlot.Start <= newSlot.Start && !leftSlot.HasIntersectionWith(rightSlot)) {
				index++;
				continue;
			}

			_slots.Insert(index + 1, newSlot);
			return;
		}

		_slots.Add(newSlot);
	}

	private bool HasTripleBooking(Slot newSlot) {
		Slot[] intersections = _slots.Where(sl => sl.HasIntersectionWith(newSlot)).ToArray();

		if (intersections.Length > 1) {
			for (int i = 1; i < intersections.Length; i++) {
				if (intersections[i - 1].HasIntersectionWith(intersections[i])) {
					return true;
				}
			}
		}

		return false;
	}
}

internal readonly record struct Slot(int Start, int End) {
	public bool HasIntersectionWith(Slot other) {
		return other.Start < End && other.End > Start;
	}

	public bool IsStartEarlierThan(Slot other) {
		return Start <= other.Start;
	}
}
