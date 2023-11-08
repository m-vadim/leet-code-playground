using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(2, 4, 7, 7, 6).Returns(true);
		yield return new TestCaseData(3, 1, 7, 3, 3).Returns(false);
		yield return new TestCaseData(1, 2, 1, 1, 2).Returns(true);
		yield return new TestCaseData(1, 2, 1, 2, 1).Returns(false);
		yield return new TestCaseData(1, 1, 1, 1, 3).Returns(true);
	}

	[TestCaseSource(nameof(Cases))]
	public static bool ReturnTrueWhenFinishCanBeReachedAtTTime(int sx, int sy, int fx, int fy, int t) {
		return new Solution().IsReachableAtTime(sx, sy, fx, fy, t);
	}
}