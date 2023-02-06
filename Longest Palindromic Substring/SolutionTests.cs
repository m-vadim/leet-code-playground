using NUnit.Framework;

namespace LeetCode;

[TestFixture, Parallelizable]
internal class SolutionTests {
    private static IEnumerable<TestCaseData> Cases() {
        yield return new TestCaseData("babad").Returns("bab");
        yield return new TestCaseData("cbbd").Returns("bb");
        yield return new TestCaseData("gogog").Returns("gogog");
        yield return new TestCaseData("gogogoogog").Returns("gogoogog");
        yield return new TestCaseData("g").Returns("g");
        yield return new TestCaseData("gg").Returns("gg");
        yield return new TestCaseData("ac").Returns("a");
        yield return new TestCaseData("tttttttaaaat").Returns("ttttttt");
        yield return new TestCaseData("abcdef").Returns("a");
    }

    [TestCaseSource(nameof(Cases))]
    public static string ReturnsLongestPalindromeSubstring(string s) {
        return new Solution().LongestPalindrome(s);
    }

    private static IEnumerable<TestCaseData> PalindromeCases() {
        yield return new TestCaseData("ababa").Returns(true);
        yield return new TestCaseData("bbb").Returns(true);
        yield return new TestCaseData("aa").Returns(true);
        yield return new TestCaseData("c").Returns(true);
        yield return new TestCaseData("dood").Returns(true);
        yield return new TestCaseData("dodddddddod").Returns(true);
    }
    
    [TestCaseSource(nameof(PalindromeCases))]
    public static bool ReturnsTrueIfStringIsPalindrome(string s) {
        return Solution.IsPalindrome(s);
    }
    
    private static IEnumerable<TestCaseData> NotPalindromeCases() {
        yield return new TestCaseData("ac").Returns(false);
        yield return new TestCaseData("acasad").Returns(false);
        yield return new TestCaseData("aaaddsdaaa").Returns(false);
        yield return new TestCaseData("aAddaa").Returns(false);
    }
    
    [TestCaseSource(nameof(NotPalindromeCases))]
    public static bool ReturnsFalseIfStringIsNotPalindrome(string s) {
        return Solution.IsPalindrome(s);
    }
}