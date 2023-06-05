using NUnit.Framework;

namespace LeetCode;

[TestFixture, Parallelizable]
internal class SolutionTests {
    private static IEnumerable<TestCaseData> Cases() {
        yield return new TestCaseData("III").Returns(3);
        yield return new TestCaseData("LVIII").Returns(58);
        yield return new TestCaseData("MCMXCIV").Returns(1994);
        yield return new TestCaseData("M").Returns(1000);
        yield return new TestCaseData("IV").Returns(4);
    }

    [TestCaseSource(nameof(Cases))]
    public static int ReturnsIntFromRoman(string romanNumber) {
        return new Solution().RomanToInt(romanNumber);
    }
}