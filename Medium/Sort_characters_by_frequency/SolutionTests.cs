using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData("tree").Returns("eert");
		yield return new TestCaseData("cccaaa").Returns("aaaccc");
		yield return new TestCaseData("Aabb").Returns("bbaA");
	}

	[TestCaseSource(nameof(Cases))]
	public static string ReturnsSortedString(string str) {
		return new Solution().FrequencySort(str);
	}
}