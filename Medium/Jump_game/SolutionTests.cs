using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(new int[] { 2, 3, 1, 1, 4 })
			.SetName("[2,3,1,1,4]")
			.Returns(true);
		yield return new TestCaseData(new int[] { 3, 2, 1, 0, 4 })
			.SetName("[3,2,1,0,4]")
			.Returns(false);
		yield return new TestCaseData(new int[] { 2, 0 })
			.SetName("[2,0]")
			.Returns(true);
		yield return new TestCaseData(new int[] { 0, 2, 3 })
			.SetName("[0,2,3]")
			.Returns(false);
	}

	[TestCaseSource(nameof(Cases))]
	public static bool ReturnsWhenJumpCanBeCompleted(int[] nums) {
		return new Solution().CanJump(nums);
	}
}
