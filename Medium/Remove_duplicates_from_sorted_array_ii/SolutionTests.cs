using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(new object[] { new[] { 1, 1, 1, 2, 2, 3 } }).Returns(new[] { 1, 1, 2, 2, 3 });
		yield return new TestCaseData(new object[] { new[] { 0, 0, 1, 1, 1, 1, 2, 3, 3 } }).Returns(new[]
			{ 0, 0, 1, 1, 2, 3, 3 });
		yield return new TestCaseData(new object[] { new[] { 1, 2, 3, 4, 5, 5, 5, 5 } }).Returns(new[]
			{ 1, 2, 3, 4, 5, 5 });
	}

	[TestCaseSource(nameof(Cases))]
	public static int[] RemovesDuplicates(int[] nums) {
		int k = new Solution().RemoveDuplicates(nums);

		return nums.Take(k).ToArray();
	}
}