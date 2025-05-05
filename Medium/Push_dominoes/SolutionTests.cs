using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static readonly Solution Solution = new();

	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData("RR.L").Returns("RR.L");
		yield return new TestCaseData(".L.R...LR..L..").Returns("LL.RR.LLRRLL..");
	}

	[TestCaseSource(nameof(Cases))]
	public static string ReturnsFinalState(string dominoes) {
		return Solution.PushDominoes(dominoes);
	}
}
