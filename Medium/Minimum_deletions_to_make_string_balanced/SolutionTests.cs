using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> MinimumDeletionCases() {
		yield return new TestCaseData("aababbab").Returns(2);
		yield return new TestCaseData("bbbba").Returns(1);
		yield return new TestCaseData("bbaaaaabb").Returns(2);
	}

	[TestCaseSource(nameof(MinimumDeletionCases))]
	public static int ReturnsMinimumDeletionCount(string s) {
		return new Solution().MinimumDeletions(s);
	}
}
