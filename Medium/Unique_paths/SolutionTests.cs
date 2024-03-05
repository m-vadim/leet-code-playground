using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(3, 7).Returns(28);
		yield return new TestCaseData(3, 2).Returns(3);
	}

	[TestCaseSource(nameof(Cases))]
	public static int ReturnsMinLength(int rows, int columns) {
		return new Solution().UniquePaths(rows, columns);
	}
}