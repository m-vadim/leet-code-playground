using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(new[] { new[] { "bella", "label", "roller" } }).Returns(new[] { "e", "l", "l" });
		yield return new TestCaseData(new[] { new[] { "cool", "lock", "cook" } }).Returns(new[] { "c", "o" });
	}

	[TestCaseSource(nameof(Cases))]
	public static IList<string> ReturnsCommonCharacters(string[] words) {
		return new Solution().CommonChars(words);
	}
}
