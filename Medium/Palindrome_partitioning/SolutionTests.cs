using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData("aab", new string[][] { ["a", "a", "b"], ["aa", "b"] });
		yield return new TestCaseData("a", new string[][] { ["a"] });
		yield return new TestCaseData("cdd", new string[][] { ["c", "d", "d"], ["c", "dd"] });
	}

	[TestCaseSource(nameof(Cases))]
	public static void ReturnsAllSubsets(string str, IList<IList<string>> expected) {
		CollectionAssert.AreEquivalent(expected, new Solution().Partition(str));
	}
}
