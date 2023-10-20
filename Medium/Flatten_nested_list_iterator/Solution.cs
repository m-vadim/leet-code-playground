namespace LeetCode;

/// <summary>
/// https://leetcode.com/problems/flatten-nested-list-iterator
/// </summary>
public class NestedIterator {
	private readonly IList<NestedInteger> _list;
	private ushort _index = 0;
	private NestedIterator? _iterator = null;
	private int? _next;

	public NestedIterator(IList<NestedInteger> nestedList) {
		_list = nestedList;
		_next = FindNext();
	}

	public bool HasNext() {
		return _next.HasValue;
	}

	public int Next() {
		int result = _next.Value;
		_next = FindNext();
		
		return result;
	}

	private int? FindNext() {
		while (true) {
			if (_index >= _list.Count) {
				return null;
			}

			NestedInteger next = _list[_index];
			if (next.IsInteger()) {
				_index++;
				return next.GetInteger();
			}

			if (_iterator != null && _iterator.HasNext()) {
				return _iterator.Next();
			}

			if (_iterator == null) {
				_iterator = new NestedIterator(next.GetList());
				if (_iterator.HasNext()) {
					return _iterator.Next();
				}
			}

			_iterator = null;
			_index++;
		}
	}
}