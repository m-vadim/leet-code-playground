using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
    private static IEnumerable<TestCaseData> Cases() {
        yield return new TestCaseData("sadbutsad", "sad").Returns(0);
        yield return new TestCaseData("leetcode", "leeto").Returns(-1);
    }

    [TestCaseSource(nameof(Cases))]
    public static int ReturnsFirstOccurrenceIndexOnNeedleInHaystack(string haystack, string needle) {
        return new Solution().StrStr(haystack, needle);
    }
    
    [TestCaseSource(nameof(Cases))]
    public static int ReturnsFirstOccurrenceIndexOnNeedleInHaystackNaive(string haystack, string needle) {
        return new Solution().StrStrNaive(haystack, needle);
    }
}