/// <summary>
/// https://leetcode.com/problems/sort-an-array/
/// </summary>
public class Solution {
	public int[] SortArray(int[] nums) {
		return MergeSort(nums.AsSpan()).ToArray();
	}
	
	public static Span<int> MergeSort(Span<int> arr) {
		if (arr.Length == 1) {
			return arr;
		}

		int pivot = arr.Length / 2;

		Span<int> one = MergeSort(arr[..pivot]);
		Span<int> two = MergeSort(arr[pivot..]);

		return Merge(one, two);
	}
	
	private static int[] Merge(Span<int> one, Span<int> two) {
		int[] result = new int[one.Length + two.Length];
		int oneIndex = 0, twoIndex = 0, resultIndex = 0;
		while (oneIndex < one.Length && twoIndex < two.Length) {
			if (one[oneIndex] <= two[twoIndex]) {
				result[resultIndex++] = one[oneIndex++];
			}
			else {
				result[resultIndex++] = two[twoIndex++];
			}
		}

		while (oneIndex < one.Length) {
			result[resultIndex++] = one[oneIndex++];
		}
		
		while (twoIndex < two.Length) {
			result[resultIndex++] = two[twoIndex++];
		}

		return result;
	}
	
	private static readonly Random Random = new();
	
	public static List<int> QuickSort(List<int> nums) {
		if (nums.Count < 2) {
			return nums;
		}

		int pivotIndex = Random.Next(0, nums.Count - 1);
		int pivot = nums[pivotIndex];
		var less = new List<int>(nums.Count);
		var greater = new List<int>(nums.Count);

		for (var index = 0; index < nums.Count; index++) {
			if (index == pivotIndex) {
				continue;
			}
			
			if (nums[index] > pivot) {
				greater.Add(nums[index]);
			}
			else {
				less.Add(nums[index]);
			}
		}

		List<int> result = QuickSort(less);
		result.Add(pivot);
		result.AddRange(QuickSort(greater));

		return result;
	}  
	
	public static void InsertionSort(int[] nums) {
		for (int i = 1; i < nums.Length; i++) {
			int sorted = i - 1;

			while (sorted > -1 && nums[sorted] > nums[sorted + 1]) {
				(nums[sorted], nums[sorted + 1]) = (nums[sorted + 1], nums[sorted]);
				sorted--;
			}
		}
	}

	public static void SelectionSort(int[] nums) {
		for (int i = 0; i < nums.Length - 1; i++) {
			int minIndex = i;
			for (int j = i + 1; j < nums.Length; j++) {
				if (nums[minIndex] > nums[j]) {
					minIndex = j;
				}
			}

			if (minIndex != i) {
				(nums[i], nums[minIndex]) = (nums[minIndex], nums[i]);
			}
		}
	}
	
	public static void BubbleSort(int[] nums) {
		int len = nums.Length;
		bool sortCompleted = false;
		
		while (!sortCompleted) {
			sortCompleted = true;
			
			for (var i = 1; i < len; i++) {
				if (nums[i] < nums[i - 1]) {
					(nums[i], nums[i - 1]) = (nums[i - 1], nums[i]);
					sortCompleted = false;
				}
			}
		}
	}
}