using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(new int[] { 10, 2 }).Returns("210");
		yield return new TestCaseData(new int[] { 3, 30, 34, 5, 9 }).Returns("9534330");
		yield return new TestCaseData(new int[] { 34323, 3432 }).Returns("343234323");
		yield return new TestCaseData(new int[] { 0, 0 }).Returns("0");
		yield return new TestCaseData(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 }).Returns("9876543210");
	}

	[TestCaseSource(nameof(Cases))]
	public static string ReturnsLargestNumber(int[] nums) {
		return new Solution().LargestNumber(nums);
	}
}
