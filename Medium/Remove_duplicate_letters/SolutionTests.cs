using NUnit.Framework;

namespace LeetCode;

[TestFixture, Parallelizable]
internal class SolutionTests {
    private static IEnumerable<TestCaseData> Cases() {
        yield return new TestCaseData("bcabc").Returns("abc");
        yield return new TestCaseData("cbacdcbc").Returns("acdb");
        yield return new TestCaseData("ecbacba").Returns("eacb");
        yield return new TestCaseData("leetcode").Returns("letcod");
        yield return new TestCaseData("abacb").Returns("abc");
    }

    [TestCaseSource(nameof(Cases))]
    public static string ReturnsStringWithoutDuplicateLetters(string s) {
        return new Solution().RemoveDuplicateLetters(s);
    }
}