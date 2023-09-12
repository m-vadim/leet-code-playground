using NUnit.Framework;

namespace LeetCode;

[TestFixture, Parallelizable]
internal class SolutionTests {
    private static IEnumerable<TestCaseData> Cases() {
        yield return new TestCaseData("aab").Returns(0);
        yield return new TestCaseData("aaabbbcc").Returns(2);
        yield return new TestCaseData("ceabaacb").Returns(2);
        yield return new TestCaseData("abcabc").Returns(3);
        yield return new TestCaseData("abcdefghijklmnopqrstuvwxyz").Returns(25);
    }

    [TestCaseSource(nameof(Cases))]
    public static int ReturnMinDeletions(string s) {
        return new Solution().MinDeletions(s);
    }
}