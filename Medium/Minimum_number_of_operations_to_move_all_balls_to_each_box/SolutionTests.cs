using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData("110").Returns(new int[] { 1, 1, 3 });
		yield return new TestCaseData("001011").Returns(new int[] { 11, 8, 5, 4, 3, 4 });
	}

	[TestCaseSource(nameof(Cases))]
	public static int[] ReturnsMinOperations(string boxes) {
		return new Solution().MinOperations(boxes);
	}
}
