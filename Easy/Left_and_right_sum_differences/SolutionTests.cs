using System.Collections;
using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable Cases() {
		yield return new TestCaseData(new[] { 10, 4, 8, 3 })
			.Returns(new[] { 15, 1, 11, 22 });
		yield return new TestCaseData(new[] { 1 })
			.Returns(new[] { 0 });
	}

	[TestCaseSource(nameof(Cases))]
	public static int[] RunsCases(int[] nums) {
		return new Solution().LeftRightDifference(nums);
	}
}
