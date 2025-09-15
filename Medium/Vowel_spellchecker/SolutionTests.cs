using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static readonly Solution Solution = new();

	private static IEnumerable<TestCaseData> Cases() {
		string[] words = ["KiTe", "kite", "hare", "Hare"];
		string[] queries = ["kite", "Kite", "KiTe", "Hare", "HARE", "Hear", "hear", "keti", "keet", "keto"];

		yield return new TestCaseData([words, queries])
			.Returns(new string[] { "kite", "KiTe", "KiTe", "Hare", "hare", "", "", "KiTe", "", "KiTe" });

		words = ["YellOw"];
		queries = ["yollow"];

		yield return new TestCaseData([words, queries])
			.Returns(new string[] { "YellOw" });
	}

	[TestCaseSource(nameof(Cases))]
	public static string[] ReturnsSpellCheckedWords(string[] wordlist, string[] queries) {
		return Solution.Spellchecker(wordlist, queries);
	}
}
