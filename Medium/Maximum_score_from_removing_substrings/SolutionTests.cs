using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData("cdbcbbaaabab", 4, 5).Returns(19);
		yield return new TestCaseData("aabbaaxybbaabb", 5, 4).Returns(20);
	}

	[TestCaseSource(nameof(Cases))]
	public static int ReturnsMaxGains(string s, int x, int y) {
		return new Solution().MaximumGain(s, x, y);
	}
}
