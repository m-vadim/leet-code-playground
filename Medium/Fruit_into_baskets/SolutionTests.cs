using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static readonly Solution Solution = new();

	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData([new[] { 1, 2, 1 }]).Returns(3);
		yield return new TestCaseData([new[] { 0, 1, 2, 2 }]).Returns(3);
		yield return new TestCaseData([new[] { 1, 2, 3, 2, 2 }]).Returns(4);
	}

	[TestCaseSource(nameof(Cases))]
	public static int ReturnsTotalFruits(int[] fruits) {
		return Solution.TotalFruit(fruits);
	}
}
