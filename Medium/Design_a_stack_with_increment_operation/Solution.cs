/// <summary>
/// https://leetcode.com/problems/design-a-stack-with-increment-operation
/// </summary>
public sealed class CustomStack {
	private readonly int[] _storage;
	private int _index = -1;

    public CustomStack(int maxSize) {
		_storage = new int[maxSize];
		Array.Fill(_storage, -1);
	}

    public void Push(int x) {
		if (_index < _storage.Length - 1) {
			_storage[_index + 1] = x;
			_index += 1;
		}
	}

    public int Pop() {
		if (_index < 0) {
			return -1;
		}

		int val = _storage[_index];
		_storage[_index] = -1;
		if (_index >= 0) {
			_index--;
		}

		return val;
	}

    public void Increment(int k, int val) {
		if (_index < 0) {
			return;
		}

		int m = Math.Min(k, _index + 1);
		for (int i = 0; i < m; i++) {
			_storage[i] += val;
		}
	}
}
