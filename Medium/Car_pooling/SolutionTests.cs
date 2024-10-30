using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(3, new int[][] { [2, 1, 5], [3, 5, 7] })
			.Returns(true);
		yield return new TestCaseData(4, new int[][] { [9, 0, 1], [3, 3, 7] })
			.Returns(false);
	}

	[TestCaseSource(nameof(Cases))]
	public static bool ReturnsTrueWhenCapacityIsMet(int capacity, int[][] trips) {
		return new Solution().CarPooling(trips, capacity);
	}
}
