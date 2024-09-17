using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(2, new int[][] { [1, 0] }).Returns(new int[] { 0, 1 });
		yield return new TestCaseData(2, new int[][] { [1, 0], [0, 1] }).Returns(Array.Empty<int>());
		yield return new TestCaseData(4, new int[][] { [1, 0], [2, 0], [3, 1], [3, 2] }).Returns(new int[] { 0, 1, 2, 3 });
	}

	[TestCaseSource(nameof(Cases))]
	public static int[] ReturnsCourseScheduleOrder(int courseCount, int[][] prerequisites) {
		return new Solution().FindOrder(courseCount, prerequisites);
	}
}
