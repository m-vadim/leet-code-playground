namespace LeetCode;

public sealed class NestedInteger {
	private readonly bool _isInteger;
	private readonly int _value;
	private readonly List<NestedInteger>? _list;

	public NestedInteger(int val) {
		_isInteger = true;
		_value = val;
	}

	public NestedInteger(params NestedInteger[] arr) {
		_isInteger = false;
		_list = new List<NestedInteger>(arr);
	}

	public bool IsInteger() {
		return _isInteger;
	}

	public int GetInteger() {
		return _value;
	}

	public IList<NestedInteger> GetList() {
		return _list ?? throw new InvalidOperationException();
	}
}