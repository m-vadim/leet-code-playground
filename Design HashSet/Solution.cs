namespace LeetCode;

// https://leetcode.com/problems/design-hashset/
public class MyHashSet {
	private LinkedList<int>[] _buckets;
	private int _bucketsSize = 10;
	private int _size;
	private const double CollisionChance = 0.3;

	public MyHashSet() {
		_buckets = new LinkedList<int>[_bucketsSize];
		for (int i = 0; i < _bucketsSize; i++) {
			_buckets[i] = new LinkedList<int>();
		}
	}

	public void Add(int key) {
		int hash = GetHashCode(key, _bucketsSize);
		LinkedList<int> bucket = _buckets[hash];

		if (bucket.Contains(key)) {
			return;
		}

		bucket.AddLast(key);

		if ((float) _size / _bucketsSize > CollisionChance) {
			Resize();
		}

		_size++;
	}

	public void Remove(int key) {
		int hash = GetHashCode(key, _bucketsSize);
		if (_buckets[hash].Contains(key)) {
			_buckets[hash].Remove(key);
		}
	}

	public bool Contains(int key) {
		int hash = GetHashCode(key, _bucketsSize);

		return _buckets[hash].Contains(key);
	}

	public int[] ToArray() {
		var list = new List<int>();
		foreach (LinkedList<int> bucket in _buckets) {
			foreach (int item in bucket) {
				list.Add(item);
			}
		}

		return list.ToArray();
	}

	private void Resize() {
		int newBucketsSize = _bucketsSize * 2;

		var newBuckets = new LinkedList<int>[newBucketsSize];

		for (int i = 0; i < newBucketsSize; i++) {
			newBuckets[i] = new LinkedList<int>();
		}

		for (int i = 0; i < _bucketsSize; i++) {
			foreach (int item in _buckets[i]) {
				newBuckets[GetHashCode(item, newBucketsSize)].AddLast(item);
			}
		}

		_buckets = newBuckets;
		_bucketsSize = newBucketsSize;
	}

	private int GetHashCode(int item, int hashSize) {
		return item % hashSize;
	}
}