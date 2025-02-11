using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData("daabcbaabcbc", "abc").Returns("dab");
		yield return new TestCaseData("axxxxyyyyb", "xy").Returns("ab");
	}

	[TestCaseSource(nameof(Cases))]
	public static string ReturnsString(string s, string part) {
		return new Solution().RemoveOccurrences(s, part);
	}
}
