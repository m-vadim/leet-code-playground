using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(new[] { "abc", "d", "defg" }, new[] { "abcddefg" }).Returns(true);
		yield return new TestCaseData(new[] { "ab", "c" }, new[] { "a", "bc" }).Returns(true);
		yield return new TestCaseData(new[] { "a", "cb" }, new[] { "ab", "c" }).Returns(false);
	}

	[TestCaseSource(nameof(Cases))]
	public static bool ReturnsTrueWhenStringArraysAreEquals(string[] words1, string[] words2) {
		return new Solution().ArrayStringsAreEqual(words1, words2);
	}
}