using NUnit.Framework;

namespace LeetCode;

[TestFixture, Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(new[] { -1, -2, -3, -4, 3, 2, 1 }).Returns(1);
		yield return new TestCaseData(new[] { 1, 5, 0, 2, -3 }).Returns(0);
		yield return new TestCaseData(new[] { -1, 1, -1, 1, -1 }).Returns(-1);
	}

	[TestCaseSource(nameof(Cases))]
	public static int ReturnsSignOfArrayProduct(int[] arr) {
		return new Solution().ArraySign(arr);
	}
}