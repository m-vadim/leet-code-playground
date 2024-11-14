using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(1, new[] { 100 }).Returns(100);
		yield return new TestCaseData(2, new[] { 5, 7 }).Returns(7);
		yield return new TestCaseData(6, new[] { 11, 6 }).Returns(3);
		yield return new TestCaseData(22, new[] { 25, 11, 29, 6, 24, 4, 29, 18, 6, 13, 25, 30 }).Returns(13);
	}

	[TestCaseSource(nameof(Cases))]
	public static int ReturnsMinMaxProducts(int n, int[] quantities) {
		return new Solution().MinimizedMaximum(n, quantities);
	}
}
