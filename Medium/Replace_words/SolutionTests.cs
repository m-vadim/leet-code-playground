using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(new[] { "cat", "bat", "rat" }, "the cattle was rattled by the battery")
			.Returns("the cat was rat by the bat");
		yield return new TestCaseData(new[] { "a", "b", "c" }, "aadsfasf absbs bbab cadsfafs")
			.Returns("a a b c");
		yield return new TestCaseData(new[] { "a", "aa", "aaa", "aaaa" }, "a aa a aaaa aaa aaa aaa aaaaaa bbb baba ababa")
			.Returns("a a a a a a a a bbb baba a");
	}

	[TestCaseSource(nameof(Cases))]
	public static string ReturnsAllSubsets(IList<string> dictionary, string sentence) {
		return new Solution().ReplaceWords(dictionary, sentence);
	}
}
