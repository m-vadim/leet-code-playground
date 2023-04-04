using NUnit.Framework;

namespace LeetCode;

[TestFixture, Parallelizable]
internal class SolutionTests {
    private static IEnumerable<TestCaseData> Cases() {
        yield return new TestCaseData("abacaba").Returns(4);
        yield return new TestCaseData("ssssss").Returns(6);
    }

    [TestCaseSource(nameof(Cases))]
    public static int ReturnsPartitionsCount(string str) {
        return new Solution().PartitionString(str);
    }
}