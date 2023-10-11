using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(new[] { 5, 10, -5 }).Returns(new[] { 5, 10 });
		yield return new TestCaseData(new[] { 8, -8 }).Returns(Array.Empty<int>());
		yield return new TestCaseData(new[] { 10, 2, -5 }).Returns(new[] { 10 });
		yield return new TestCaseData(new[] { -2, -1, 1, 2 }).Returns(new[] { -2, -1, 1, 2 });
		yield return new TestCaseData(new[] { -2, -2, 1, -2 }).Returns(new[] { -2, -2, -2 });
		yield return new TestCaseData(new[] { 1, -2, -2, -2 }).Returns(new[] { -2, -2, -2 });
	}

	[TestCaseSource(nameof(Cases))]
	public static int[] ReturnsAsteroidsAfterCollision(int[] nums) {
		return new Solution().AsteroidCollision(nums);
	}
}