using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(new int[] { 4, 3, 2, 1, 0 })
			.SetName("[4, 3, 2, 1, 0]")
			.Returns(1);
		yield return new TestCaseData(new int[] { 0, 1, 2, 3, 4 })
			.SetName("[0, 1, 2, 3, 4]")
			.Returns(5);
		yield return new TestCaseData(new int[] { 1, 0, 2, 3, 4 })
			.SetName("[1, 0, 2, 3, 4]")
			.Returns(4);
		yield return new TestCaseData(new int[] { 0, 1, 3, 2 })
			.SetName("[0, 1, 3, 2]")
			.Returns(3);
	}

	[TestCaseSource(nameof(Cases))]
	public static int ReturnsMaxChunksToSort(int[] nums) {
		return new Solution().MaxChunksToSorted(nums);
	}
}
