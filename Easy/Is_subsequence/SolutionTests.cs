using NUnit.Framework;

namespace LeetCode;

[TestFixture, Parallelizable]
internal class SolutionTests {
    private static IEnumerable<TestCaseData> Cases() {
        yield return new TestCaseData("abc", "ahbgdc").Returns(true);
        yield return new TestCaseData("axc", "ahbgdc").Returns(false);
        yield return new TestCaseData("", "ahbgdc").Returns(true);
        yield return new TestCaseData("asdas", "").Returns(false);
    }

    [TestCaseSource(nameof(Cases))]
    public static bool ReturnsTrueWhenStringIsSubsequence(string part, string text) {
        return new Solution().IsSubsequence(part, text);
    }
}