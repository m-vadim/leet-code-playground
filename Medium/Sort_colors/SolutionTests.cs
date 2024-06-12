using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(new[] { 2, 0, 2, 1, 1, 0 }).Returns(new[] { 0, 0, 1, 1, 2, 2 });
		yield return new TestCaseData(new[] { 2, 0, 1 }).Returns(new[] { 0, 1, 2 });
	}

	[TestCaseSource(nameof(Cases))]
	public static int[] SortsColors(int[] colors) {
		new Solution().SortColors(colors);
		return colors;
	}
}
