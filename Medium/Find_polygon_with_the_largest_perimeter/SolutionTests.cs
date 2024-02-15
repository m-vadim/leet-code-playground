using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(new[] { 5, 5, 5 }).Returns(15);
		yield return new TestCaseData(new[] { 1, 12, 1, 2, 5, 50, 3 }).Returns(12);
		yield return new TestCaseData(new[] { 5, 5, 50 }).Returns(-1);
	}

	[TestCaseSource(nameof(Cases))]
	public static long ReturnsLargestPerimeter(int[] nums) {
		return new Solution().LargestPerimeter(nums);
	}
}