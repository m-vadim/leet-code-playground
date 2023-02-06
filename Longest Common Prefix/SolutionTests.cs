using NUnit.Framework;

namespace LeetCode;

[TestFixture, Parallelizable]
internal class SolutionTests {
    private static IEnumerable<TestCaseData> Cases() {
        yield return new TestCaseData(new[] {new[] {"flower","flow","flight"}}).Returns("fl");
        yield return new TestCaseData(new[] {new[] {"dog","racecar","car"}}).Returns(string.Empty);
        yield return new TestCaseData(new[] {new[] {"flower","fkow"}}).Returns("f");
    }

    [TestCaseSource(nameof(Cases))]
    public static string ReturnsLongestCommonPrefix(string[] args) {
        return new Solution().LongestCommonPrefix(args);
    }
}