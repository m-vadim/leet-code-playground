using NUnit.Framework;

namespace LeetCode;

[TestFixture, Parallelizable]
internal class SolutionTests {
    private static IEnumerable<TestCaseData> Cases() {
        yield return new TestCaseData("abc", "bca").Returns(true);
        yield return new TestCaseData("a", "aa").Returns(false);
        yield return new TestCaseData("cabbba", "abbccc").Returns(true);
        yield return new TestCaseData("uau", "ssx").Returns(false);
    }

    [TestCaseSource(nameof(Cases))]
    public static bool ReturnsTrueWhenWordsAreClose(string word1, string word2) {
        return new Solution().CloseStrings(word1, word2);
    }
}