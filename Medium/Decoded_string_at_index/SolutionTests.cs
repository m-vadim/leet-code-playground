using NUnit.Framework;

namespace LeetCode;

[TestFixture, Parallelizable]
internal class SolutionTests {
    private static IEnumerable<TestCaseData> Cases() {
        yield return new TestCaseData("leet2code3", 10).Returns("o");
        yield return new TestCaseData("ha22", 5).Returns("h");
        yield return new TestCaseData("a2345678999999999999999", 1).Returns("a");
        yield return new TestCaseData("yyuele72uthzyoeut7oyku2yqmghy5luy9qguc28ukav7an6a2bvizhph35t86qicv4gyeo6av7gerovv5lnw47954bsv2xruaej", 123365626).Returns("l");
    }

    [TestCaseSource(nameof(Cases))]
    public static string ReturnsDecodedCharAtIndex(string s, int k) {
        return new Solution().DecodeAtIndex(s, k);
    }
}