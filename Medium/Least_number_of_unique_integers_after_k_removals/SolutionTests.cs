using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(new[] { 2, 4, 1, 8, 3, 5, 1, 3 }, 3).Returns(3);
		yield return new TestCaseData(new[] { 5, 5, 4 }, 1).Returns(1);
		yield return new TestCaseData(new[] { 4, 3, 1, 1, 3, 3, 2 }, 3).Returns(2);
		yield return new TestCaseData(new[] { 2,1,1,3,3,3 }, 3).Returns(1);
	}

	[TestCaseSource(nameof(Cases))]
	public static int FindsLeastNumOfUniqueInts(int[] nums, int k) {
		return new Solution().FindLeastNumOfUniqueInts(nums, k);
	}
}