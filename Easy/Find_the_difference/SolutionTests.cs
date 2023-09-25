using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData("abcd", "abcde").Returns('e');
		yield return new TestCaseData("", "a").Returns('a');
	}

	[TestCaseSource(nameof(Cases))]
	public static char ReturnsTrueWhenStringIsSubsequence(string s, string t) {
		return new Solution().FindTheDifference(s, t);
	}
}