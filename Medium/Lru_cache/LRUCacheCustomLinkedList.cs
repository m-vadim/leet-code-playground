namespace LeetCode;

// https://leetcode.com/problems/lru-cache/
public sealed class LRUCacheCustomLinkedList : ILRUCache {
	private readonly int _capacity;
	private int _count;
	private readonly Dictionary<int, Node> _cache;
	private readonly Node _head;
	private readonly Node _tail;

	public LRUCacheCustomLinkedList(int capacity) {
		_cache = new Dictionary<int, Node>(_capacity);
		_capacity = capacity;

		_head = new Node(0, 0);
		_tail = new Node(0, 0);
		_head.Tail = _tail;
		_tail.Head = _head;
		_count = 0;
	}


	public int Get(int key) {
		if (!_cache.TryGetValue(key, out Node? item)) {
			return -1;
		}

		DeleteNode(item);
		AddToHead(item);

		return item.Value;
	}

	public void Put(int key, int value) {
		if (_cache.TryGetValue(key, out Node? item)) {
			item.Value = value;
			DeleteNode(item);
			AddToHead(item);

			return;
		}

		item = new Node(key, value);
		_cache.Add(key, item);
		if (_count < _capacity) {
			_count++;
		}
		else {
			Node lowestRatingNode = _tail.Head;
			_cache.Remove(lowestRatingNode.Key);
			DeleteNode(lowestRatingNode);
		}

		AddToHead(item);
	}

	private static void DeleteNode(Node node) {
		node.Head.Tail = node.Tail;
		node.Tail.Head = node.Head;
	}

	private void AddToHead(Node node) {
		node.Tail = _head.Tail;
		node.Tail.Head = node;
		node.Head = _head;
		_head.Tail = node;
	}
}

public sealed class Node {
	public Node(int key, int value) {
		Key = key;
		Value = value;
	}

	public int Key { get; }
	public int Value { get; set; }

	public Node Tail { get; set; }
	public Node Head { get; set; }
}