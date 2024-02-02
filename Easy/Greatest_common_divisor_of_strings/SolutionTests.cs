using NUnit.Framework;

namespace LeetCode;

[TestFixture, Parallelizable]
internal class SolutionTests {
    private static IEnumerable<TestCaseData> Cases() {
        yield return new TestCaseData("ABCABC", "ABC").Returns("ABC");
        yield return new TestCaseData("LEET", "CODE").Returns("");
    }

    [TestCaseSource(nameof(Cases))]
    public static string ReturnsGDCOfTwoStrings(string s, string t) {
        return new Solution().GcdOfStrings(s, t);
    }
}