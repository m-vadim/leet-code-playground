using NUnit.Framework;

namespace LeetCode;

[TestFixture, Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(new object[] {
			new[] { 1, 0, 2 }
		}).Returns(5);

		yield return new TestCaseData(new object[] {
			new[] { 1, 2, 2 }
		}).Returns(4);

		yield return new TestCaseData(new object[] {
			new[] { 1, 3, 4, 5, 2 }
		}).Returns(11);

		yield return new TestCaseData(new object[] {
			new[] { 1, 2, 10, 9, 8, 7, 6 }
		}).Returns(18);

		yield return new TestCaseData(new object[] {
			new[] { 1, 2, 10, 9, 8, 7, 6, 10 }
		}).Returns(20);

		yield return new TestCaseData(new object[] {
			Enumerable.Range(1, 10000).ToArray()
		}).Returns(50005000).SetName("1 to 10000 ascending");

		yield return new TestCaseData(new object[] {
			Enumerable.Range(1, 10000).OrderByDescending(a => a).ToArray()
		}).Returns(50005000).SetName("10000 to 1 descending");

		yield return new TestCaseData(new object[] {
			new[] { 29, 51, 87, 87, 72, 12 }
		}).Returns(12);

		yield return new TestCaseData(new object[] {
			new[] { 0, 1, 2, 3, 2, 1 }
		}).Returns(13);

		yield return new TestCaseData(new object[] {
			new[] { 5, 3, 7, 3 }
		}).Returns(6);

		yield return new TestCaseData(new object[] {
			new[] { 3, 5, 3, 7 }
		}).Returns(6);

		yield return new TestCaseData(new object[] {
			new[] { 1, 2, 3, 5, 4, 3, 2, 1, 4, 3, 2, 1 }
		}).Returns(31);

		yield return new TestCaseData(new object[] {
			new[] { 1, 2, 3, 5, 4, 3, 2, 1, 4, 3, 2, 1, 3, 2, 1, 1, 2, 3, 4 }
		}).Returns(47);
	}

	[TestCaseSource(nameof(Cases))]
	public static int ReturnsMinimumRequiredCandies(int[] children) {
		return new Solution().Candy(children);
	}

	[TestCaseSource(nameof(Cases))]
	public static int ReturnsMinimumRequiredCandiesUsingSequences(int[] children) {
		return new SequencesSolution().Candy(children);
	}

	[TestCaseSource(nameof(Cases))]
	public static int ReturnsMinimumRequiredCandiesRecursiveSolution(int[] children) {
		return new SolutionRecursive().Candy(children);
	}
}