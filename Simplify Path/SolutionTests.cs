using NUnit.Framework;

namespace LeetCode;

[TestFixture, Parallelizable]
internal class SolutionTests {
    private static IEnumerable<TestCaseData> Cases() {
        yield return new TestCaseData("/home/").Returns("/home");
        yield return new TestCaseData("/../").Returns("/");
        yield return new TestCaseData("/...").Returns("/...");
        yield return new TestCaseData("/home//foo/").Returns("/home/foo");
        yield return new TestCaseData("/a/./b/../../c/").Returns("/c");
        yield return new TestCaseData("/a//b////c/d//././/..").Returns("/a/b/c");
    }

    [TestCaseSource(nameof(Cases))]
    public static string ReturnsSimplifiedPath(string str) {
        return new Solution().SimplifyPath(str);
    }
}