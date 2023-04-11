using NUnit.Framework;

namespace LeetCode;

[TestFixture, Parallelizable]
internal class SolutionTests {
    private static IEnumerable<TestCaseData> Cases() {
        yield return new TestCaseData("leet**cod*e").Returns("lecoe");
        yield return new TestCaseData("erase*****").Returns(string.Empty);
    }

    [TestCaseSource(nameof(Cases))]
    public static string ReturnsStringWithoutStars(string str) {
        return new Solution().RemoveStars(str);
    }
    
    [TestCaseSource(nameof(Cases))]
    public static string ReturnsStringWithoutStarsNonStack(string str) {
        return new Solution().RemoveStarsNonStack(str);
    }
}