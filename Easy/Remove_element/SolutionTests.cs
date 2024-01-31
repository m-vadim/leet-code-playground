using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(new object?[] {
			new[] { 3, 2, 2, 3 }, 3, new[] { 2, 2 }
		}).Returns(2);
		yield return new TestCaseData(new object?[] {
			new[] { 0, 1, 2, 2, 3, 0, 4, 2 }, 2, new[] { 0, 1, 4, 0, 3 }
		}).Returns(5);
		yield return new TestCaseData(new object?[] {
			new[] { 2, 2, 3 }, 2, new[] { 3 }
		}).Returns(1);
	}

	[TestCaseSource(nameof(Cases))]
	public static int ReturnsArrayWithoutElement(int[] nums, int val, int[] expectedNums) {
		int result = new Solution().RemoveElement(nums, val);
		Assert.That(nums.Take(expectedNums.Length), Is.EquivalentTo(expectedNums));
		return result;
	}
}