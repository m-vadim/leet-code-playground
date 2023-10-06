using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(new[] { 1, 12, -5, -6, 50, 3 }, 4).Returns(12.75d);
		yield return new TestCaseData(new[] { 5 }, 1).Returns(5d);
		yield return new TestCaseData(new[] { 0, 4, 0, 3, 2 }, 1).Returns(4d);
	}

	[TestCaseSource(nameof(Cases))]
	public static double ReturnsMaxAverageOfKElements(int[] nums, int k) {
		return new Solution().FindMaxAverage(nums, k);
	}
}