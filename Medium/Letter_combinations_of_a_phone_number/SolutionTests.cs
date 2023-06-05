using NUnit.Framework;

namespace LeetCode;

[TestFixture, Parallelizable]
internal class SolutionTests {
    private static IEnumerable<TestCaseData> Cases() {
        yield return new TestCaseData("23").Returns(new[] {"ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf"});
        yield return new TestCaseData("2").Returns(new[] {"a", "b", "c"});
        yield return new TestCaseData(string.Empty).Returns(Array.Empty<string>());
    }

    [TestCaseSource(nameof(Cases))]
    public static IList<string> ReturnLetterCombinations(string digits) {
        return new Solution().LetterCombinations(digits);
    }
}