using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(new[] { 3,2,3 }).Returns(new[] { 3 });
		yield return new TestCaseData(new[] { 1 }).Returns(new[] { 1 });
		yield return new TestCaseData(new[] { 1, 2 }).Returns(new[] { 1, 2 });
		yield return new TestCaseData(new[] { 1, 2, 3 }).Returns(Array.Empty<int>());
	}
	
	[TestCaseSource(nameof(Cases))]
	public static int[] ReturnsElementsOccursMoreThanThirdUsingVoting(int[] nums) {
		return new Solution().MajorityElement(nums).ToArray();
	}

	[TestCaseSource(nameof(Cases))]
	public static int[] ReturnsElementsOccursMoreThanThirdUsingSort(int[] nums) {
		return new Solution().MajorityElementBySort(nums).ToArray();
	}
}