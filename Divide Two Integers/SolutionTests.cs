using NUnit.Framework;

[TestFixture, Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(10, 3).Returns(3);
		yield return new TestCaseData(7, -3).Returns(-2);
		yield return new TestCaseData(1, 1).Returns(1);
		yield return new TestCaseData(0, 1).Returns(0);
		yield return new TestCaseData(-1, 1).Returns(-1);
		yield return new TestCaseData(1, -1).Returns(-1);
		yield return new TestCaseData(-1, -1).Returns(1);
		yield return new TestCaseData(int.MaxValue, -1).Returns(-2147483647);
		yield return new TestCaseData(int.MinValue, -1).Returns(int.MaxValue);
		yield return new TestCaseData(int.MinValue, 2).Returns(-1073741824);
		yield return new TestCaseData(int.MinValue, -3).Returns(715827882);
		yield return new TestCaseData(-10, 2).Returns(-5);
		yield return new TestCaseData(10, -10).Returns(-1);
		yield return new TestCaseData(-1010369383, int.MinValue).Returns(0);
	}

	[TestCaseSource(nameof(Cases))]
	public static int ReturnsQuotient(int dividend, int divisor) {
		return new Solution().Divide(dividend, divisor);
	}
}