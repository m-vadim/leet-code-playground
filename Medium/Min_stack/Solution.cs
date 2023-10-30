namespace LeetCode;

/// <summary>
/// https://leetcode.com/problems/min-stack/
/// </summary>
public sealed class MinStack {
	private readonly LinkedList<StackItem> _linkedList = new();

	public void Push(int val) {
		_linkedList.AddLast(_linkedList.Last == null
			? new StackItem(val, val)
			: new StackItem(val, Math.Min(val, _linkedList.Last.Value.Min)));
	}

	public void Pop() {
		_linkedList.RemoveLast();
	}

	public int Top() {
		return _linkedList.Last.Value.Value;
	}

	public int GetMin() {
		return _linkedList.Last.Value.Min;
	}
}

internal record struct StackItem(int Value, int Min);