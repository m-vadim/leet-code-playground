using NUnit.Framework;

namespace LeetCode;

[TestFixture, Parallelizable]
internal class SolutionTests {
    private static IEnumerable<TestCaseData> Cases() {
        yield return new TestCaseData("AAB").Returns(8);
        yield return new TestCaseData("V").Returns(1);
        yield return new TestCaseData("AAABBC").Returns(188);
    }

    [TestCaseSource(nameof(Cases))]
    public static int Test(string tiles) {
        return new Solution().NumTilePossibilities(tiles);
    }
}