using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(new object[] { new[] { "eat", "tea", "tan", "ate", "nat", "bat" } }).Returns(
			new List<IList<string>> {
				new[] {  "eat", "tea", "ate" }, new[] { "tan", "nat" }, new[] { "bat" }
			});
		yield return new TestCaseData(new object[] { new[] { "" } }).Returns(
			new List<IList<string>> {
				new[] { "" }
			});
		yield return new TestCaseData(new object[] { new[] { "eat" } }).Returns(
			new List<IList<string>> {
				new[] { "eat" }
			});
		yield return new TestCaseData(new object[] { new[] { "bdddddddddd","bbbbbbbbbbc" } }).Returns(
			new List<IList<string>> {
				new[] { "bdddddddddd" }, new[] { "bbbbbbbbbbc" }
			});
	}


	[TestCaseSource(nameof(Cases))]
	public static IList<IList<string>> ReturnAnagramsGrouped(string[] words) {
		return new Solution().GroupAnagrams(words);
	}
}