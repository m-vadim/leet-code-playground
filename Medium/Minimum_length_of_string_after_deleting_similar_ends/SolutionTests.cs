using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData("ca").Returns(2);
		yield return new TestCaseData("cabaabac").Returns(0);
		yield return new TestCaseData("aabccabba").Returns(3);
		yield return new TestCaseData("a").Returns(1);
		yield return new TestCaseData("aa").Returns(0);
		yield return new TestCaseData("bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbacccabbabccaccbacaaccacacccaccbbbacaabbccbbcbcbcacacccccccbcbbabccaacaabacbbaccccbabbcbccccaccacaccbcbbcbcccabaaaabbbbbbbbbbbbbbb").Returns(109);
		yield return new TestCaseData("bbbbbbbbbbbbbbbbbbbbbbbbbbbabbbbbbbbbbbbbbbccbcbcbccbbabbb").Returns(1);
	}

	[TestCaseSource(nameof(Cases))]
	public static int ReturnsMinLength(string word) {
		return new Solution().MinimumLength(word);
	}
}