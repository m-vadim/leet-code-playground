using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(new[] { 17, 13, 11, 2, 3, 5, 7 }).Returns(new[] { 2, 13, 3, 11, 5, 17, 7 });
		yield return new TestCaseData(new[] { 1, 1000 }).Returns(new[] { 1, 1000 });
	}

	[TestCaseSource(nameof(Cases))]
	public static int[] ReturnsRevealDeck(int[] deck) {
		return new Solution().DeckRevealedIncreasing(deck);
	}
}
