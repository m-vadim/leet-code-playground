using NUnit.Framework;

namespace LeetCode;

[TestFixture, Parallelizable]
internal class SolutionTests {
    private static IEnumerable<TestCaseData> Cases() {
        yield return new TestCaseData("42").Returns(42);
        yield return new TestCaseData("   -42").Returns(-42);
        yield return new TestCaseData("4193 with words").Returns(4193);
        yield return new TestCaseData("-91283472332").Returns(int.MinValue);
        yield return new TestCaseData("+91283472332").Returns(int.MaxValue);
        yield return new TestCaseData("+-12").Returns(0);
        yield return new TestCaseData("+10+1").Returns(10);
        yield return new TestCaseData("+10-1").Returns(10);
        yield return new TestCaseData("--10").Returns(0);
        yield return new TestCaseData("00000-42a1234").Returns(0);
        yield return new TestCaseData("-10test12").Returns(-10);
        yield return new TestCaseData("   +0 123").Returns(0);
        yield return new TestCaseData("2147483648").Returns(int.MaxValue);
        yield return new TestCaseData("2147483646").Returns(2147483646);
        
    }
    
    [TestCaseSource(nameof(Cases))]
    public static int ReturnsIntFromStringUsingAtoi(string input) {
        return new Solution().MyAtoi(input);
    }
}