using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(new[] { 5, 2, 3, 1 }).Returns(
			new[] { 1, 2, 3, 5 });
		yield return new TestCaseData(new[] { 5, 1, 1, 2, 0, 0 }).Returns(
			new[] { 0, 0, 1, 1, 2, 5 });
		yield return new TestCaseData(Enumerable.Range(1, 1000).OrderDescending().ToArray()).Returns(
			Enumerable.Range(1, 1000).ToArray());
	}
	
	[TestCaseSource(nameof(Cases))]
	public static int[] ReturnsSortedArray(int[] nums) {
		return new Solution().SortArray(nums);
	}
	
	[TestCaseSource(nameof(Cases))]
	public static int[] ReturnsSortedArrayWithMergeSort(int[] nums) {
		return Solution.MergeSort(nums).ToArray();
	}
	
	[TestCaseSource(nameof(Cases))]
	public static List<int> ReturnsSortedArrayWithQuickSort(int[] nums) {
		return Solution.QuickSort(nums.ToList());
	}
	
	[TestCaseSource(nameof(Cases))]
	public static int[] ReturnsSortedArrayWithInsertionSort(int[] nums) {
		Solution.InsertionSort(nums);
		return nums;
	}

	[TestCaseSource(nameof(Cases))]
	public static int[] ReturnsSortedArrayWithSelectionSort(int[] nums) {
		Solution.SelectionSort(nums);
		return nums;
	}
	
	[TestCaseSource(nameof(Cases))]
	public static int[] ReturnsSortedArrayWithBubbleSort(int[] nums) {
		Solution.BubbleSort(nums);
		return nums;
	}
}