namespace LeetCode;

// https://leetcode.com/problems/rotate-array/
public class Solution {
	public void Rotate(int[] nums, int k) => Rotate(nums, k, rotateLeft: false);

	public void Rotate(int[] arr, int countOfRotation, bool rotateLeft) {
		int arrayLength = arr.Length;
		if (countOfRotation > arrayLength) {
			countOfRotation %= arrayLength;
		}

		if (countOfRotation == 0) {
			return;
		}

		var source = new int[arrayLength];
		arr.CopyTo(source, 0);
		
		int shiftModifier = arrayLength - countOfRotation;
		for (int i = 0; i < arrayLength; i++) {
			int index;
			if (rotateLeft) {
				index = i + shiftModifier;
				if (index >= arrayLength) {
					index -= arrayLength;
				}
			}
			else {
				index = i - shiftModifier;
				if (index < 0) {
					index += arrayLength;
				}
			}

			arr[index] = source[i];
		}
	}
}