using NUnit.Framework;

namespace LeetCode;

[TestFixture, Parallelizable]
internal class SolutionTests {
    private static IEnumerable<TestCaseData> PalindromeCases() {
        yield return new TestCaseData(121);
        yield return new TestCaseData(5005);
        yield return new TestCaseData(7);
        yield return new TestCaseData(0);
        yield return new TestCaseData(99033099);
        yield return new TestCaseData(22322);
    }
    
    private static IEnumerable<TestCaseData> NotPalindromeCases() {
        yield return new TestCaseData(-121);
        yield return new TestCaseData(503105);
        yield return new TestCaseData(1000);
        yield return new TestCaseData(19);
    }

    [TestCaseSource(nameof(PalindromeCases))]
    public static void ReturnsTrueIfNumberIsPalindrome(int number) {
        Assert.IsTrue(new Solution().IsPalindrome(number));
    }
    
    [TestCaseSource(nameof(NotPalindromeCases))]
    public static void ReturnsFalseIfNumberIsNotPalindrome(int number) {
        Assert.IsFalse(new Solution().IsPalindrome(number));
    }
}