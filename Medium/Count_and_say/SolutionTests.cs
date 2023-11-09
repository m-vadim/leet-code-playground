using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(1).Returns("1");
		yield return new TestCaseData(2).Returns("11");
		yield return new TestCaseData(3).Returns("21");
		yield return new TestCaseData(4).Returns("1211");
	}

	[TestCaseSource(nameof(Cases))]
	public static string ReturnsCountAndSay(int n) {
		return new Solution().CountAndSay(n);
	}
}