using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(new object[] { new int[][] { [1, 1, 0, 0], [0, 0, 1, 0], [0, 0, 1, 0], [0, 0, 0, 1] } }).Returns(4);
		yield return new TestCaseData(new object[] { new int[][] { [1,0], [1,1] } }).Returns(3);
		yield return new TestCaseData(new object[] { new int[][] { [1,0], [0,1] } }).Returns(0);
	}

	[TestCaseSource(nameof(Cases))]
	public static int ReturnsMinLength(int[][] servers) {
		return new Solution().CountServers(servers);
	}
}
