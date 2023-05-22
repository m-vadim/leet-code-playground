using NUnit.Framework;

namespace LeetCode;

[TestFixture, Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(new object[] { new[] { 1, 1, 1, 2, 2, 3 }, 2, new[] { 1, 2 } });
	}

	[TestCaseSource(nameof(Cases))]
	public static void ReturnsTopKFrequentElements(int[] nums, int k, int[] expectedResult) {
		CollectionAssert.AreEquivalent(new Solution().TopKFrequent(nums, k), expectedResult);
	}
}