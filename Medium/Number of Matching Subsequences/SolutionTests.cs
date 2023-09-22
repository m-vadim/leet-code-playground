using NUnit.Framework;

namespace LeetCode;

[TestFixture, Parallelizable]
internal class SolutionTests {
    

    [TestCaseSource(nameof(Cases))]
    public static int ReturnsNumberMatchingSubsequences(string text, string[] words) {
        return new Solution().NumMatchingSubseq(text, words);
    }
    
    private static IEnumerable<TestCaseData> Cases() {
        yield return new TestCaseData("abcde", new[] {"a","bb","acd","ace"}).Returns(3);
        yield return new TestCaseData("dsahjpjauf", new[] {"ahjpjau","ja","ahbwzgqnuk","tnmlanowax"}).Returns(2);
    }
}