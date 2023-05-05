using NUnit.Framework;

namespace LeetCode;

[TestFixture, Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData("abciiidef", 3).Returns(3);
		yield return new TestCaseData("leetcode", 3).Returns(2);
		yield return new TestCaseData("cbqwqqwr", 3).Returns(0);
		yield return new TestCaseData("asdasdasdasd", 3).Returns(1);
	}

	[TestCaseSource(nameof(Cases))]
	public static int ReturnsMaxVowelCount(string s, int k) {
		return new Solution().MaxVowels(s, k);
	}
}