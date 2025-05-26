using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static readonly Solution Solution = new();

	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData([new[] { "ab", "ty", "yt", "lc", "cl", "ab" }]).Returns(8);
		yield return new TestCaseData([new[] { "cc", "ll", "xx" }]).Returns(2);
		yield return new TestCaseData([new[] { "lc", "cl", "gg" }]).Returns(6);
	}

	[TestCaseSource(nameof(Cases))]
	public static int ReturnsLongestPalindrome(string[] words) {
		return Solution.LongestPalindrome(words);
	}
}
