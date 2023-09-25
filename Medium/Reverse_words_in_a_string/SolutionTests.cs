using NUnit.Framework;

namespace LeetCode;

[TestFixture, Parallelizable]
internal class SolutionTests {
    private static IEnumerable<TestCaseData> Cases() {
        yield return new TestCaseData("the sky is blue").Returns("blue is sky the");
        yield return new TestCaseData("  hello world  ").Returns("world hello");
        yield return new TestCaseData("a good   example").Returns("example good a");
    }

    [TestCaseSource(nameof(Cases))]
    public static string ReturnsReversedString(string s) {
        return new Solution().ReverseWords(s);
    }
}