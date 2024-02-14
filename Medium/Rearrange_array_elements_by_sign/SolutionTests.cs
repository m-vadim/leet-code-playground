using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(new[] { 3, 1, -2, -5, 2, -4 }).Returns(
			new[] { 3, -2, 1, -5, 2, -4 });
		yield return new TestCaseData(new[] { -1, 1 }).Returns(
			new[] { 1, -1 });
		yield return new TestCaseData(new[] { -1, -2, -3, 1, 2, 3 }).Returns(
			new[] { 1, -1, 2, -2, 3, -3 });
		yield return new TestCaseData(new[] { 1, 2, 3, -1, -2, -3,  }).Returns(
			new[] { 1, -1, 2, -2, 3, -3 });
	}

	[TestCaseSource(nameof(Cases))]
	public static int[] ReturnsRearrangedArray(int[] nums) {
		return new Solution().RearrangeArray(nums);
	}
}