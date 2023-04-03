using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class KnuthMorrisPrattTests {
    private static IEnumerable<TestCaseData> PrefixCases() {
        yield return new TestCaseData("abcabd").Returns(new[] {0, 0, 0, 1, 2, 0});
        yield return new TestCaseData("a").Returns(new[] {0});
    }

    [TestCaseSource(nameof(PrefixCases))]
    public static int[] ReturnsPrefixFunction(string s) {
        return KnuthMorrisPratt.BuildPrefix(s);
    }

    private static IEnumerable<TestCaseData> PatternCases() {
        yield return new TestCaseData("this is a test text", "test").Returns(new[] {10});
        yield return new TestCaseData("aabaacaadaabaaba","aaba").Returns(new[] {0, 9, 12});
    }

    [TestCaseSource(nameof(PatternCases))]
    public static int[] ReturnsOccurrences(string text, string pattern) {
        return KnuthMorrisPratt.Search(text, pattern).ToArray();
    }
    
    private static IEnumerable<TestCaseData> PatternFirstCases() {
        yield return new TestCaseData("this is a test text", "test").Returns(10);
        yield return new TestCaseData("aabaacaadaabaaba","aaba").Returns(0);
    }

    
    [TestCaseSource(nameof(PatternFirstCases))]
    public static int ReturnsFirstOccurrence(string text, string pattern) {
        return KnuthMorrisPratt.SearchFirst(text, pattern);
    }
}