using NUnit.Framework;

namespace LeetCode;

[TestFixture, Parallelizable]
internal class SolutionTests {
    private static IEnumerable<TestCaseData> Cases() {
        yield return new TestCaseData("hello").Returns("holle");
        yield return new TestCaseData("leetcode").Returns("leotcede");
    }

    [TestCaseSource(nameof(Cases))]
    public static string ReturnsStringWithReversedVowels(string s) {
        return new Solution().ReverseVowels(s);
    }
}