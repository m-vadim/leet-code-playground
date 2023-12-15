using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(new List<IList<string>>
			{ new[] { "B", "C" }, new[] { "D", "B" }, new[] { "C", "A" } }).Returns("A");
		yield return new TestCaseData(new List<IList<string>>
			{ new[] { "London","New York" }, new[] { "New York","Lima" }, new[] { "Lima","Sao Paulo" } }).Returns("Sao Paulo");
	}

	[TestCaseSource(nameof(Cases))]
	public static string ReturnsDestinationCity(IList<IList<string>> paths) {
		return new Solution().DestCity(paths);
	}
}