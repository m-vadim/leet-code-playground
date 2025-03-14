using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static readonly Solution Solution = new();

	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(new object[] { new[] { 5, 8, 6 }, 3 }).Returns(5).SetName("[5, 8, 6] to 3");
		yield return new TestCaseData(new object[] { new[] { 1, 6 }, 13 }).Returns(0).SetName("[1, 6] to 13");
		yield return new TestCaseData(new object[] { new[] { 4, 7, 5 }, 16 }).Returns(1).SetName("[4, 7, 5] to 16");
	}

	[TestCaseSource(nameof(Cases))]
	public static int ReturnsMaxCandyPerChild(int[] piles, int k) {
		return Solution.MaximumCandies(piles, k);
	}
}

