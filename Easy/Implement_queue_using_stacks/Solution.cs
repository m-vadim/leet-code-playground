/// <summary>
/// https://leetcode.com/problems/implement-queue-using-stacks
/// </summary>
public sealed class MyQueue {
	private readonly Stack<int> _read = new();
	private readonly Stack<int> _write = new();

	private void Move() {
		while (_write.Count > 0) {
			_read.Push(_write.Pop());
		}
	}

	public void Push(int x) {
		_write.Push(x);
	}

	public int Pop() {
		if (_read.Count > 0) {
			return _read.Pop();
		}

		Move();
		return _read.Pop();
	}

	public int Peek() {
		if (_read.Count > 0) {
			return _read.Peek();
		}

		Move();
		return _read.Peek();
	}

	public bool Empty() {
		return _read.Count == 0 && _write.Count == 0;
	}
}