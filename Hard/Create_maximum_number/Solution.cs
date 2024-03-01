public class Solution {
	public int[] MaxNumber(int[] nums1, int[] nums2, int k) {
		if (nums1.Length == 0) {
			return nums2;
		}

		if (nums2.Length == 0) {
			return nums1;
		}

		if (nums1.Length + nums2.Length <= k) {
			return MergeSubsequence(nums1, nums2);
		}

		int[] result = [-1];

		for (var i = 0; i <= k; i++) {
			int firstTake = i;
			int secondTake = k - i;
			if (nums1.Length < firstTake || nums2.Length < secondTake) {
				continue;
			}

			int[] n1 = GetBiggestSubsequence(nums1, firstTake);
			int[] n2 = GetBiggestSubsequence(nums2, secondTake);

			result = Max(result, MergeSubsequence(n1, n2));
		}

		return result;
	}

	private static int[] Max(int[] first, int[] second) {
		for (var i = 0; i < first.Length; i++) {
			if (first[i] == second[i]) {
				continue;
			}

			if (first[i] > second[i]) {
				return first;
			}

			return second;
		}

		return first;
	}

	private static int[] MergeSubsequence(int[] n1, int[] n2) {
		var result = new int[n1.Length + n2.Length];

		int n1Index = 0, n2Index = 0, resultIndex = 0;
		int n1Len = n1.Length, n2Len = n2.Length;

		while (n1Index < n1Len && n2Index < n2Len) {
			int n1Value = n1[n1Index];
			int n2Value = n2[n2Index];
			
			if (n1Value != n2Value) {
				if (n1Value > n2Value) {
					result[resultIndex++] = n1Value;
					n1Index++;
				}
				else {
					result[resultIndex++] = n2Value;
					n2Index++;
				}

				continue;
			}

			int tempLeft = n1Index + 1;
			int tempRight = n2Index + 1;
			while (tempLeft < n1Len && tempRight < n2Len && n1[tempLeft] == n2[tempRight]) {
				tempLeft++;
				tempRight++;
			}

			if (tempLeft == n1Len) {
				result[resultIndex++] = n2Value;
				n2Index++;
			}
			else if (tempRight == n2Len) {
				result[resultIndex++] = n1Value;
				n1Index++;
			}
			else {
				if (n1[tempLeft] > n2[tempRight]) {
					result[resultIndex++] = n1Value;
					n1Index++;
				}
				else {
					result[resultIndex++] = n2Value;
					n2Index++;
				}
			}
		}

		if (resultIndex < result.Length) {
			if (n1Index == n1Len) {
				Array.Copy(n2, n2Index, result, resultIndex, n2Len - n2Index);
			}
			else {
				Array.Copy(n1, n1Index, result, resultIndex, n1Len - n1Index);
			}
		}

		return result;
	}

	private int[] GetBiggestSubsequence(int[] nums, int limit) {
		var stack = new Stack<int>();
		int len = nums.Length;

		for (var index = 0; index < len; index++) {
			int currentNum = nums[index];
			int numbersLeft = len - index;

			while (stack.Count > 0 && nums[stack.Peek()] < currentNum && numbersLeft > limit - stack.Count) {
				stack.Pop();
			}

			if (stack.Count < limit) {
				stack.Push(index);
			}
		}

		var result = new int[stack.Count];
		while (stack.Count > 0) {
			result[stack.Count - 1] = nums[stack.Pop()];
		}

		return result;
	}
}