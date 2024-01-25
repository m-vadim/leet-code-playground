using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData("nematode knowledge", "nano").Returns(4);
		yield return new TestCaseData("abc", "def").Returns(0);
		yield return new TestCaseData("subnano", "nematode knowledge").Returns(4);
	}

	[TestCaseSource(nameof(Cases))]
	public static int ReturnsCountOfUnique3LengthPalindromeSubsequences(string s1, string s2) {
		return new Solution().LongestCommonSubsequence(s1, s2);
	}
}