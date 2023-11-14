using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData("aabca").Returns(3);
		yield return new TestCaseData("adc").Returns(0);
		yield return new TestCaseData("bbcbaba").Returns(4);
	}

	[TestCaseSource(nameof(Cases))]
	public static int ReturnsCountOfUnique3LengthPalindromeSubsequences(string s) {
		return new Solution().CountPalindromicSubsequence(s);
	}
}