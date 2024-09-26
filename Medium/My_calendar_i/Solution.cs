/// <summary>
/// https://leetcode.com/problems/my-calendar-i
/// </summary>
public sealed class MyCalendar {
	private readonly IList<Slot> _slots;

	public MyCalendar() {
		_slots = new List<Slot>();
	}

	public bool Book(int start, int end) {
		var newSlot = new Slot(start, end);
		if (_slots.Count == 0) {
			return AddLast(newSlot);
		}

		var index = 0;
		Position slotPosition = default;
		while (index < _slots.Count) {
			slotPosition = GetPosition(_slots[index], newSlot);
			if (slotPosition == Position.After) {
				index++;
				continue;
			}

			return slotPosition != Position.DoubleBooking && Insert(newSlot, index);
		}

		if (slotPosition == Position.After) {
			return AddLast(newSlot);
		}

		return false;
	}

	private bool Insert(Slot slot, int index) {
		_slots.Insert(index, slot);
		return true;
	}

	private bool AddLast(Slot slot) {
		_slots.Add(slot);
		return true;
	}

	private static Position GetPosition(Slot existing, Slot newSlot) {
		if (existing.Start >= newSlot.End) {
			return Position.Before;
		}

		if (existing.End <= newSlot.Start) {
			return Position.After;
		}

		return Position.DoubleBooking;
	}

	private enum Position {
		Before = 0,
		After = 1,
		DoubleBooking = -1
	}

	private record Slot(int Start, int End);
}
