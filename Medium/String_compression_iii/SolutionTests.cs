using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData("abcde").Returns("1a1b1c1d1e");
		yield return new TestCaseData("aaaaaaaaaaaaaabb").Returns("9a5a2b");
		yield return new TestCaseData("a").Returns("1a");
	}

	[TestCaseSource(nameof(Cases))]
	public static string ReturnsComplressedString(string word) {
		return new Solution().CompressedString(word);
	}
}
