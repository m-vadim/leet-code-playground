using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(new[] { 3, 2, 1, 2, 1, 7 }).Returns(6);
		yield return new TestCaseData(new[] { 1, 2, 2 }).Returns(1);
		yield return new TestCaseData(new[] { 1, 2 }).Returns(0);
		yield return new TestCaseData(new[] { 1, 2, 3, 100, 100 }).Returns(1);
	}

	[TestCaseSource(nameof(Cases))]
	public static int ReturnsMinimumMovesToMakeArrayUnique(int[] arr) {
		return new Solution().MinIncrementForUnique(arr);
	}
}
