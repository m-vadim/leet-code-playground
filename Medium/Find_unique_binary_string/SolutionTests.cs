using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(new[] { new[] { "11", "10" } }).Returns("01");
		yield return new TestCaseData(new[] { new[] { "111", "011", "001" } }).Returns("110");
	}

	[TestCaseSource(nameof(Cases))]
	public static string ReturnsUniqueBinaryString(string[] nums) {
		return new Solution().FindDifferentBinaryString(nums);
	}
}