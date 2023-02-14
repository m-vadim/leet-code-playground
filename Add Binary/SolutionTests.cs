using NUnit.Framework;

namespace LeetCode;

[TestFixture, Parallelizable]
internal class SolutionTests {
    private static IEnumerable<TestCaseData> Cases() {
        yield return new TestCaseData("11", "1").Returns("100");
        yield return new TestCaseData("1010", "1011").Returns("10101");
        yield return new TestCaseData("1111", "1111").Returns("11110");
        yield return new TestCaseData(
                "10100000100100110110010000010101111011011001101110111111111101000000101111001110001111100001101",
                "110101001011101110001111100110001010100001101011101010000011011011001011101111001100000011011110011")
            .Returns("110111101100010011000101110110100000011101000101011001000011011000001100011110011010010011000000000");
    }

    [TestCaseSource(nameof(Cases))]
    public static string ReturnsBinarySum(string a, string b) {
        return new Solution().AddBinary(a, b);
    }
}