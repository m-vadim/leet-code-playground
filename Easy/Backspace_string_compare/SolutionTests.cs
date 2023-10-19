using NUnit.Framework;

namespace LeetCode;

[TestFixture, Parallelizable]
internal class SolutionTests {
    private static IEnumerable<TestCaseData> Cases() {
        yield return new TestCaseData("ab#c", "ad#c").Returns(true);
        yield return new TestCaseData("ab##", "c#d#").Returns(true);
        yield return new TestCaseData("bxj##tw", "bxo#j##tw").Returns(true);
        yield return new TestCaseData("bxj##tw", "bxj###tw").Returns(false);
    }

    [TestCaseSource(nameof(Cases))]
    public static bool ReturnsTrueWhenStringsAreBackspaceEquals(string s, string t) {
        return new Solution().BackspaceCompare(s, t);
    }
}