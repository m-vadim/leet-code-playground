using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(new object[] { new int[] { 2, 3, 4, 6 } }).Returns(8)
			.SetName("[2, 3, 4, 6]");
		yield return new TestCaseData(new object[] { new int[] { 1, 2, 4, 5, 10 } }).Returns(16)
			.SetName("[1, 2, 4, 5, 10]");
	}

	[TestCaseSource(nameof(Cases))]
	public static int ReturnsTuplesCount(int[] nums) {
		return new Solution().TupleSameProduct(nums);
	}
}
