namespace LeetCode;

internal class MountainArray {
	private readonly int[] _internalArray;
	private int _getCount = 0;
	private const int GetLimit = 100;

	internal MountainArray(int[] internalArray) {
		_internalArray = internalArray;
	}

	public int Get(int index) {
		_getCount++;
		if (_getCount > GetLimit) {
			throw new InvalidOperationException("Get limit exceeded");
		}

		return _internalArray[index];
	}

	public int Length() {
		return _internalArray.Length;
	}
}