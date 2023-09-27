using NUnit.Framework;

namespace LeetCode;

[TestFixture, Parallelizable]
internal class SolutionTests {
    private static IEnumerable<TestCaseData> Cases() {
        yield return new TestCaseData(new[] {'a','a','b','b','c','c','c'}, new[] { 'a','2','b','2','c','3', 'c'}).Returns(6);
        yield return new TestCaseData(new[] {'a'}, new[] { 'a' }).Returns(1);
        yield return new TestCaseData(new[] {'a','b','b','b','b','b','b','b','b','b','b','b','b'}
            , new[] { 'a','b','1','2','b','b','b','b','b','b','b','b','b' }).Returns(4);
    }

    [TestCaseSource(nameof(Cases))]
    public static int ReturnsDecodedCharAtIndex(char[] s, char[] expected) {
        int result = new Solution().Compress(s);
    
        CollectionAssert.AreEqual(expected, s);
        
        return result;
    }
}