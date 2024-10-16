using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(1, 1, 7).Returns("ccaccbcc");
		yield return new TestCaseData(7, 1, 0).Returns("aabaa");
		yield return new TestCaseData(0, 8, 11).Returns("ccbccbbccbbccbbccbc");
	}

	[TestCaseSource(nameof(Cases))]
	public static string ReturnsLongestHappyString(int a, int b, int c) {
		return new Solution().LongestDiverseString(a, b, c);
	}
}
