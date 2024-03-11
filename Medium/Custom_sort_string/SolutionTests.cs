using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData("cba", "abcd").Returns("dcba");
		yield return new TestCaseData("bcafg", "abcd").Returns("dbca");
	}
	
	[TestCaseSource(nameof(Cases))]
	public static string ReturnsSortedArray(string order, string s) {
		return new Solution().CustomSortString(order, s);
	}
}