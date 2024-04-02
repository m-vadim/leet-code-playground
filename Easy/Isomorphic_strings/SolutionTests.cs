using NUnit.Framework;

namespace LeetCode;

[TestFixture, Parallelizable]
internal class SolutionTests {
    private static IEnumerable<TestCaseData> Cases() {
        yield return new TestCaseData("egg", "add").Returns(true);
        yield return new TestCaseData("paper", "title").Returns(true);
        yield return new TestCaseData("foo", "bar").Returns(false);
        yield return new TestCaseData("badc", "baba").Returns(false);
    }

    [TestCaseSource(nameof(Cases))]
    public static bool ReturnsTrueWhenStringsAreIsomorphic(string s, string t) {
        return new Solution().IsIsomorphic(s, t);
    }
}