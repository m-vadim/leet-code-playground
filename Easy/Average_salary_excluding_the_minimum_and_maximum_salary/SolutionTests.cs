using NUnit.Framework;

namespace LeetCode;

[TestFixture, Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(new[] { 4000, 3000, 1000, 2000 }).Returns(2500);
	}

	[TestCaseSource(nameof(Cases))]
	public static double ReturnsAverageSalary(int[] salary) {
		return new Solution().Average(salary);
	}
}