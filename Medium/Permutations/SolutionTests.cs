using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(new[] { 1, 2, 3 }).Returns(new[] {
			new[] { 1, 2, 3 },
			new[] { 1, 3, 2 },
			new[] { 2, 1, 3 },
			new[] { 2, 3, 1 },
			new[] { 3, 1, 2 },
			new[] { 3, 2, 1 }
		});
		yield return new TestCaseData(new[] { 1 }).Returns(new[] {
			new[] { 1 }
		});
	}

	[TestCaseSource(nameof(Cases))]
	public static IList<IList<int>> ReturnPermutations(int[] arr) {
		IList<IList<int>> s = new Solution().Permute(arr);
		return s;
	}
}