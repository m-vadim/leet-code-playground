using NUnit.Framework;

namespace LeetCode;

[TestFixture, Parallelizable]
internal class SolutionTests {
    private static IEnumerable<TestCaseData> Cases() {
        yield return new TestCaseData("A man, a plan, a canal: Panama").Returns(true);
        yield return new TestCaseData("race a car").Returns(false);
        yield return new TestCaseData("0P").Returns(false);
        yield return new TestCaseData(" ").Returns(true);
    }

    [TestCaseSource(nameof(Cases))]
    public static bool ReturnsTrueWhenStringIsPalindrome(string s) {
        return new Solution().IsPalindrome(s);
    }
}