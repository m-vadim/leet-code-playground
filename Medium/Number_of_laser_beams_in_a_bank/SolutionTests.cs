using NUnit.Framework;

namespace LeetCode;

[TestFixture]
[Parallelizable]
internal class SolutionTests {
	private static IEnumerable<TestCaseData> Cases() {
		yield return new TestCaseData(new object?[] {
			new[] { "011001", "000000", "010100", "001000" }}).Returns(8);
		yield return new TestCaseData(new object?[] {
			new[] { "000","111","000" }}).Returns(0);
	}

	[TestCaseSource(nameof(Cases))]
	public static int ReturnsLaserBeamsCount(string[] lasers) {
		return new Solution().NumberOfBeams(lasers);
	}
}