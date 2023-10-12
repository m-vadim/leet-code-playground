using LeetCode;

/// <summary>
/// https://leetcode.com/problems/find-in-mountain-array
/// </summary>
internal class Solution {
	public int FindInMountainArray(int target, MountainArray mountainArr) {
		int len = mountainArr.Length();

		int midIndex = len / 2,
			rMidIndex = midIndex + 1,
			minIndex = 0,
			maxIndex = len - 1;

		var resultTracker = new ResultTracker();

		while (!resultTracker.IsSearchCompleted() && minIndex < maxIndex) {
			int mid = mountainArr.Get(midIndex), rMid = mountainArr.Get(rMidIndex);

			if (mid < rMid) {
				if (target <= rMid && !resultTracker.AscCompleted) {
					int result = BinarySearchAsc(target, mountainArr, minIndex, rMidIndex);
					resultTracker.CompleteDirection(Direction.Asc, result);
				}

				minIndex = rMidIndex;
			}
			else {
				if (target <= mid && !resultTracker.DescCompleted) {
					int result = BinarySearchDesc(target, mountainArr, midIndex, maxIndex);
					resultTracker.CompleteDirection(Direction.Desc, result);
				}

				maxIndex = midIndex;
			}

			midIndex = (minIndex + maxIndex) / 2;
			rMidIndex = midIndex + 1;
		}

		return resultTracker.GetResult();
	}

	private static int BinarySearchAsc(int target, MountainArray mountainArr, int min, int max) {
		while (min <= max) {
			int mid = (min + max) / 2;
			int midValue = mountainArr.Get(mid);

			if (midValue == target) {
				return mid;
			}

			if (target < midValue) {
				max = mid - 1;
			}
			else {
				min = mid + 1;
			}
		}

		return -1;
	}

	private static int BinarySearchDesc(int target, MountainArray mountainArr, int min, int max) {
		while (min <= max) {
			int mid = (min + max) / 2;
			int midValue = mountainArr.Get(mid);

			if (midValue == target) {
				return mid;
			}

			if (target < midValue) {
				min = mid + 1;
			}
			else {
				max = mid - 1;
			}
		}

		return -1;
	}
}

internal enum Direction {
	Asc,
	Desc
}

internal struct ResultTracker {
	private int _ascResult = -1;
	private int _descResult = -1;

	public ResultTracker() {
		AscCompleted = false;
		DescCompleted = false;
	}

	public bool AscCompleted { get; private set; }
	public bool DescCompleted { get; private set; }

	public void CompleteDirection(Direction dir, int result) {
		if (dir == Direction.Asc) {
			AscCompleted = true;
			_ascResult = result;
		}
		else {
			DescCompleted = true;
			_descResult = result;
		}
	}

	public bool IsSearchCompleted() {
		if (_ascResult >= 0) {
			return true;
		}

		if (AscCompleted && _descResult >= 0) {
			return true;
		}

		return AscCompleted && DescCompleted;
	}

	public int GetResult() {
		if (_ascResult >= 0) {
			return _ascResult;
		}

		return _descResult;
	}
}