using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(new[] { 1, 2, 0 }).Returns(3);
		yield return new TestCaseData(new[] { 3, 4, -1, 1 }).Returns(2);
		yield return new TestCaseData(new[] { 7, 8, 9, 11, 12 }).Returns(1);
		yield return new TestCaseData(new[] { 2, 1 }).Returns(3);
		yield return new TestCaseData(new[] { 1, 2, 6, 3, 5, 4 }).Returns(7);
		yield return new TestCaseData(new[] { 1, 4, 5, 6, 7 }).Returns(2);
		yield return new TestCaseData(new[] { 1, 1 }).Returns(2);
	}

	[TestCaseSource(nameof(Cases))]
	public static int ReturnsFirstMissingPositive(int[] nums) {
		return new Solution().FirstMissingPositive(nums);
	}
}