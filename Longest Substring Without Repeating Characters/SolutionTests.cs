using NUnit.Framework;

namespace LeetCode;

[TestFixture, Parallelizable]
internal class SolutionTests {
    private static IEnumerable<TestCaseData> Cases() {
        yield return new TestCaseData("abcabcbb").Returns(3);
        yield return new TestCaseData("bbbbb").Returns(1);
        yield return new TestCaseData("x").Returns(1);
        yield return new TestCaseData("eu").Returns(2);
        yield return new TestCaseData("asic").Returns(4);
    }

    [TestCaseSource(nameof(Cases))]
    public static int ReturnsLongestPalindromeSubstring(string s) {
        return new Solution().LengthOfLongestSubstring(s);
    }
}