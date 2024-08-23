using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData("-1/2+1/2").Returns("0/1");
		yield return new TestCaseData("-1/2+1/2+1/3").Returns("1/3");
		yield return new TestCaseData("1/3-1/2").Returns("-1/6");
		yield return new TestCaseData("4/2+2/2").Returns("3/1");
	}

	[TestCaseSource(nameof(Cases))]
	public static string ReturnsFractionAdditionResult(string expression) {
		return new Solution().FractionAddition(expression);
	}
}
