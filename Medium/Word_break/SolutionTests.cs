using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static readonly Solution Solution = new();

	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData("leetcode", new string[] { "leet", "code" }).Returns(true);
		yield return new TestCaseData("catsandog", new string[] { "cats", "dog", "sand", "and", "cat" }).Returns(false);
	}

	[TestCaseSource(nameof(Cases))]
	public static bool ReturnsTrueWhenWordBreakPossbile(string s, IList<string> words) {
		return Solution.WordBreak(s, words);
	}
}
