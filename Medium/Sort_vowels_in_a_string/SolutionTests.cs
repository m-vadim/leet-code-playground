using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData("lEetcOde").Returns("lEOtcede");
		yield return new TestCaseData("lYmpH").Returns("lYmpH");
	}

	[TestCaseSource(nameof(Cases))]
	public static string ReturnsStringWithSortedVowels(string s) {
		return new Solution().SortVowels(s);
	}
}