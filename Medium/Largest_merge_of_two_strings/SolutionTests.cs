using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData("cabaa", "bcaaa").Returns("cbcabaaaaa");
		yield return new TestCaseData("abcabc", "abdcaba").Returns("abdcabcabcaba");
	}

	[TestCaseSource(nameof(Cases))]
	public static string ReturnsMostCompetitive(string word1, string word2) {
		return new Solution().LargestMerge(word1, word2);
	}
}