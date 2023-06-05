using NUnit.Framework;

namespace LeetCode;

[TestFixture, Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> RotateRightCases() {
		yield return new TestCaseData(new[] { 1, 2, 3, 4, 5, 6 }, 3).Returns(new[] { 4, 5, 6, 1, 2, 3 });
		yield return new TestCaseData(new[] { -1, -100, 3, 99 }, 2).Returns(new[] { 3, 99, -1, -100 });
		yield return new TestCaseData(new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 }, 4).Returns(new[] { 5, 6, 7, 8, 0, 1, 2, 3, 4 });
		yield return new TestCaseData(new[] { 1, 2, 3 }, 1).Returns(new[] { 3, 1, 2 });
	}

	[TestCaseSource(nameof(RotateRightCases))]
	public static int[] RotatesArrayToRight(int[] nums, int k) {
		new Solution().Rotate(nums, k, rotateLeft: false);
		return nums;
	}
	
	private static IEnumerable<TestCaseData> RotateLeftCases() {
		yield return new TestCaseData(new[] { 1, 2, 3, 4, 5 }, 4).Returns(new[] { 5, 1, 2, 3, 4 });
	}

	[TestCaseSource(nameof(RotateLeftCases))]
	public static int[] RotatesArrayToLeft(int[] nums, int k) {
		new Solution().Rotate(nums, k, rotateLeft: true);
		return nums;
	}
}