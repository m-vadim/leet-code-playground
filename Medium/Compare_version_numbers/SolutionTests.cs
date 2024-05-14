using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData("1.01", "1.001").Returns(0);
		yield return new TestCaseData("1.0", "1.00").Returns(0);
		yield return new TestCaseData("1.0", "1.0.0.0").Returns(0);
		yield return new TestCaseData("0.1", "1.1").Returns(-1);
		yield return new TestCaseData("1.9", "1.9.2").Returns(-1);
	}

	[TestCaseSource(nameof(Cases))]
	public static int ReturnsMostCompetitive(string ver1, string ver2) {
		return new Solution().CompareVersion(ver1, ver2);
	}
}
