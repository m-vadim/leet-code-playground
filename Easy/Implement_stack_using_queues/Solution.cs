// https://leetcode.com/problems/implement-stack-using-queues/

public class MyStack {
	private Queue<int> _queue = new();

	public void Push(int x) {
		if (_queue.Count == 0) {
			_queue.Enqueue(x);
			return;
		}

		var tmp = new Queue<int>(_queue.Count + 1);
		tmp.Enqueue(x);
		
		while (_queue.Count > 0) {
			tmp.Enqueue(_queue.Dequeue());
		}

		_queue = tmp;
	}

	public int Pop() {
		return _queue.Dequeue();
	}

	public int Top() {
		return _queue.Peek();
	}

	public bool Empty() {
		return _queue.Count == 0;
	}
}