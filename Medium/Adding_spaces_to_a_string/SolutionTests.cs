using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData("LeetcodeHelpsMeLearn", new int[] { 8, 13, 15 }).Returns("Leetcode Helps Me Learn");
	}

	[TestCaseSource(nameof(Cases))]
	public static string ReturnsStringWithSpaces(string s, int[] spaces) {
		return new Solution().AddSpaces(s, spaces);
	}
}
