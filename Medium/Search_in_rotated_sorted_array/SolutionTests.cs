using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 0).Returns(4);
		yield return new TestCaseData(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 5).Returns(1);
		yield return new TestCaseData(new int[] { 4, 6, 7, 0, 1, 2 }, 5).Returns(-1);
		yield return new TestCaseData(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 3).Returns(-1);
		yield return new TestCaseData(new int[] { 0, 1, 2, 3, 4, 5, 6, 7 }, 3).Returns(3);
		yield return new TestCaseData(new int[] { 1, 2, 3, 4, 5, 6, 7, 0 }, 3).Returns(2);
		yield return new TestCaseData(new int[] { 2, 3, 4, 5, 6, 7, 0, 1 }, 3).Returns(1);
		yield return new TestCaseData(new int[] { 1 }, 3).Returns(-1);
		yield return new TestCaseData(new int[] { 1, 2 }, 1).Returns(0);
		yield return new TestCaseData(new int[] { 2, 1 }, 1).Returns(1);
		yield return new TestCaseData(new int[] { 1 }, 1).Returns(0);
	}

	[TestCaseSource(nameof(Cases))]
	public static int ReturnsFoundIndex(int[] nums, int target) {
		return new Solution().Search(nums, target);
	}
}
