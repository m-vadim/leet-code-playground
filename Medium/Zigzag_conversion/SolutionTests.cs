using NUnit.Framework;

namespace LeetCode;

[TestFixture, Parallelizable]
internal class SolutionTests {
    private static IEnumerable<TestCaseData> Cases() {
        yield return new TestCaseData("PAYPALISHIRING", 3).Returns("PAHNAPLSIIGYIR");
        yield return new TestCaseData("PAYPALISHIRING", 4).Returns("PINALSIGYAHRPI");
        yield return new TestCaseData("1234567890", 4).Returns("1726835940");
        yield return new TestCaseData("A", 1).Returns("A");
        yield return new TestCaseData("AB", 1).Returns("AB");
        yield return new TestCaseData("ABC", 2).Returns("ACB");
        yield return new TestCaseData("ABCDE", 4).Returns("ABCED");
    }

    [TestCaseSource(nameof(Cases))]
    public static string ReturnZigZagLineByLine(string zigzag, int numRows) {
        return new Solution().Convert(zigzag, numRows);
    }
}