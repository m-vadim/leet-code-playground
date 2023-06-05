using NUnit.Framework;

namespace LeetCode;

[TestFixture, Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(new[] { 2, 3, 5, 1, 3 }, 3).Returns(new[] { true, true, true, false, true });
	}

	[TestCaseSource(nameof(Cases))]
	public static IList<bool> ReturnsKidsWithCandies(int[] candies, int extraCandies) {
		return new Solution().KidsWithCandies(candies, extraCandies);
	}
}