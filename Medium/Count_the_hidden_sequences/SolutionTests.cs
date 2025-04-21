using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static readonly Solution Solution = new();

	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData([new int[] { 1, -3, 4 }, 1, 6]).Returns(2);
		yield return new TestCaseData([new int[] { 3, -4, 5, 1, -2 }, -4, 5]).Returns(4);
		yield return new TestCaseData([new int[] { 4, -7, 2 }, 3, 6]).Returns(0);
		yield return new TestCaseData([new int[] { 1,1,1,1,1 }, -1, 1]).Returns(0);
	}

	[TestCaseSource(nameof(Cases))]
	public static int ReturnsNumberOfArrays(int[] differences, int lower, int upper) {
		return Solution.NumberOfArrays(differences, lower, upper);
	}
}
