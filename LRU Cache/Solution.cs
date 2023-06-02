namespace LeetCode;

// https://leetcode.com/problems/lru-cache/
public sealed class LRUCache : ILRUCache {
	private readonly int _capacity;
	private int _count = 0;
	private readonly Dictionary<int, Slot> _cache;
	private readonly LinkedList<int> _list;

	public LRUCache(int capacity) {
		_capacity = capacity;
		_cache = new Dictionary<int, Slot>(_capacity);
		_list = new LinkedList<int>();
	}

	public int Get(int key) {
#pragma warning disable CS8600
		if (!_cache.TryGetValue(key, out Slot slot)) {
#pragma warning restore CS8600
			return -1;
		}

		_list.Remove(slot.Node);
		_list.AddFirst(slot.Node);

		return slot.Value;
	}

	public void Put(int key, int value) {
#pragma warning disable CS8600
		if (!_cache.TryGetValue(key, out Slot slot)) {
#pragma warning restore CS8600
			if (_count >= _capacity) {
				LinkedListNode<int> lessUsedItem = _list.Last!;
				_cache.Remove(lessUsedItem.Value);
				_list.RemoveLast();
			}
			else {
				_count++;
			}

			var node = new LinkedListNode<int>(key);
			_list.AddFirst(node);
			_cache.Add(key, new Slot(node, value));
			return;
		}

		_list.Remove(slot.Node);
		_list.AddFirst(slot.Node);
		slot.Value = value;
	}
}

internal sealed class Slot {
	public Slot(LinkedListNode<int> node, int value) {
		Node = node;
		Value = value;
	}

	public LinkedListNode<int> Node { get; }
	public int Value { get; set; }
}