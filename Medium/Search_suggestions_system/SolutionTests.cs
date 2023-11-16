using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(new[] { "mobile", "mouse", "moneypot", "monitor", "mousepad" }, "mouse").Returns(
			new List<IList<string>> {
				new List<string> { "mobile", "moneypot", "monitor" },
				new List<string> { "mobile", "moneypot", "monitor" },
				new List<string> { "mouse", "mousepad" },
				new List<string> { "mouse", "mousepad" },
				new List<string> { "mouse", "mousepad" }
			});
		yield return new TestCaseData(new[] { "havana" }, "havana").Returns(new List<IList<string>> {
			new List<string> { "havana" },
			new List<string> { "havana" },
			new List<string> { "havana" },
			new List<string> { "havana" },
			new List<string> { "havana" },
			new List<string> { "havana" }
		});
		yield return new TestCaseData(new[] { "havana" }, "tatiana").Returns(new List<IList<string>> {
			new List<string>(),
			new List<string>(),
			new List<string>(),
			new List<string>(),
			new List<string>(),
			new List<string>(),
			new List<string>()
		});
	}

	[TestCaseSource(nameof(Cases))]
	public static IList<IList<string>> ReturnsSuggestions(string[] products, string searchWord) {
		return new Solution().SuggestedProducts(products, searchWord);
	}
}