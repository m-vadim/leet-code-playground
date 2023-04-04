using NUnit.Framework;

namespace LeetCode;

[TestFixture, Parallelizable]
internal class SolutionTests {
    private static IEnumerable<TestCaseData> Cases() {
        yield return new TestCaseData("abacaba").Returns(4);
        yield return new TestCaseData("ssssss").Returns(6);
    }

    [TestCaseSource(nameof(Cases))]
    public static int ReturnsPartitionsCountHashSet(string str) {
        return new Solution().PartitionStringHashSet(str);
    }
    
    [TestCaseSource(nameof(Cases))]
    public static int ReturnsPartitionsCountArrayMap(string str) {
        return new Solution().PartitionStringArrayMap(str);
    }
}