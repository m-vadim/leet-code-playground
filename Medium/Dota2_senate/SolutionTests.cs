using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData("RD").Returns("Radiant");
		yield return new TestCaseData("RDD").Returns("Dire");
		yield return new TestCaseData("DDRRRR").Returns("Radiant");
		yield return new TestCaseData("DDRRR").Returns("Dire");
		yield return new TestCaseData("D").Returns("Dire");
	}

	[TestCaseSource(nameof(Cases))]
	public static string ReturnsNameOfParty(string s) {
		return new Solution().PredictPartyVictory(s);
	}
}