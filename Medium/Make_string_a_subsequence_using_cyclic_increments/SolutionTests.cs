using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData("abc", "ad").Returns(true);
		yield return new TestCaseData("ab", "d").Returns(false);
	}

	[TestCaseSource(nameof(Cases))]
	public static bool ReturnsTrueWhenCanBeMadeToSubsequence(string str1, string str2) {
		return new Solution().CanMakeSubsequence(str1, str2);
	}
}
