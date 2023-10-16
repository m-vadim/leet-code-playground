using NUnit.Framework;

namespace LeetCode;

[TestFixture, Parallelizable]
internal class SolutionTests {
    private static IEnumerable<TestCaseData> Cases() {
        yield return new TestCaseData("3[a]2[bc]").Returns("aaabcbc");
        yield return new TestCaseData("3[a2[c]]").Returns("accaccacc");
        yield return new TestCaseData("2[abc]3[cd]ef").Returns("abcabccdcdcdef");
    }

    [TestCaseSource(nameof(Cases))]
    public static string ReturnsDecodedString(string s) {
        return new Solution().DecodeString(s);
    }
}